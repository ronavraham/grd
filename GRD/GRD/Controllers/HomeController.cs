using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using GRD.Data;
using GRD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using Accord.Math.Optimization.Losses;
using Accord.MachineLearning;
using Accord.Statistics.Analysis;
using Accord.Math.Distances;
using GRD.Helpers;
using Accord.Statistics.Filters;

namespace GRD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectContext _context;

        public HomeController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult NearestBranch(float lat, float lng)
        {
            var coord = new GeoCoordinate(lat, lng);
            var branches = _context.Branches.Select(x => new Branch
            {
                Id = x.Id,
                Lat = x.Lat,
                Long = x.Long,
                IsSaturday = x.IsSaturday,
                Address = x.Address,
                City = x.City,
                Name = x.Name,
                Telephone = x.Telephone
            }).ToList();

            var nearestBranch = branches.OrderBy(x => new GeoCoordinate(x.Lat, x.Long).GetDistanceTo(coord))
                                   .First();
            return Json(nearestBranch);
        }

        [HttpGet]
        public JsonResult PredictPossibleProducts()
        {
            var userIdString = HttpContext.Session.GetString("userid");
            var userId = 0;
            var didParsed = Int32.TryParse(userIdString, out userId);

            if (!didParsed || userId == -1)
            {
                return Json(new { });
            }

            var userGender = _context.Users
                .Where(x => x.Id == userId)
                .Select(x => x.Gender)
                .SingleOrDefault();

            var trainData = _context.Purchases
                .OrderBy(x => x.UserId)
                .Select(x => new
                {
                    userId = x.UserId.Value,
                    size = x.Product.Size,
                    type = x.Product.ProductTypeId,
                    gender = x.Product.ProductType.Gender,
                    genderUser = x.User.Gender
                })
                .ToList();

            var inputs = trainData.Select(x =>
            {
                double[] res = new double[]
                {
                    Convert.ToInt32(x.gender),
                    Convert.ToInt32(x.genderUser),
                    x.type.Value,
                    x.size
                };

                return res;
            })
            .ToArray();

            var codification = new Codification<double>()
            {
                CodificationVariable.Categorical,
                CodificationVariable.Categorical,
                CodificationVariable.Categorical,
                CodificationVariable.Discrete
            };

            // Learn the codification from observations
            var model = codification.Learn(inputs);

            // Transform the mixed observations into only continuous:
            double[][] newInputs = model.ToDouble().Transform(inputs);

            KMedoids kmeans = new KMedoids(k: 4)
            {
                Distance = new WeightedSquareEuclidean(new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })
            };
            var clusters = kmeans.Learn(newInputs);
            int[] labels = clusters.Decide(newInputs);

            var knn5 = new KNearestNeighbors(k: 5);

            knn5.Learn(newInputs, labels);

            var purchasesById = _context.Purchases
                .Select(x => new
                {
                    userId = x.UserId.Value,
                    size = x.Product.Size,
                    type = x.Product.ProductTypeId,
                    gender = x.Product.ProductType.Gender,
                    genderUser = x.User.Gender
                })
                .GroupBy(x => x.userId)
                .ToList();

            IList<Tuple<int, int[]>> labelsForUsers = new List<Tuple<int, int[]>>();
            for (int i = 0; i < purchasesById.Count; i++)
            {
                var userInputs = purchasesById[i].
                    Select(x =>
                    {
                        double[] res = new double[]
                        {
                            Convert.ToInt32(x.gender),
                            Convert.ToInt32(x.genderUser),
                            x.type.Value,
                            x.size
                        };

                        return res;
                    })
                    .ToArray();

                //double[][] newUserInputs = model.ToDouble().Transform(userInputs);
                double[][] newUserInputs = model.ToDouble().Transform(userInputs);
                //var label = clusters.Decide(newUserInputs)
                //    .GroupBy(x => x)
                //    .Select(x => new
                //    {
                //        label = x,
                //        count = x.Count()
                //    })
                //    .OrderByDescending(x => x.count)
                //    .First()
                //    .label
                //    .Key;
                labelsForUsers.Add(new Tuple<int, int[]>(purchasesById[i].Key, clusters.Decide(newUserInputs).Distinct().ToArray()));
                //labelsForUsers.Add(new Tuple<int, int>(purchasesById[i].Key, label));
            }

            var productIdsUserBought = _context.Purchases
                .Where(x => x.UserId == userId)
                .Select(x => x.ProductId)
                .Distinct()
                .ToList();

            var productsToPredict = _context.Products
                .Where(x => !productIdsUserBought.Contains(x.Id))
                .Select(x => new
                {
                    id = x.Id,
                    size = x.Size,
                    type = x.ProductTypeId,
                    gender = x.ProductType.Gender,
                    genderUser = userGender
                })
                .ToList();

            var predInputs = productsToPredict.Select(x =>
            {
                double[] res = new double[]
                {
                    Convert.ToInt32(x.gender),
                    Convert.ToInt32(x.genderUser),
                    x.type.Value,
                    x.size
                };

                return res;
            })
            .ToArray();
            double[][] newPredInputs = model.ToDouble().Transform(predInputs);

            int[] lol = knn5.Decide(newPredInputs);

            IList<int> productIdsPrediction = new List<int>();
            var userLabels = labelsForUsers.Where(x => x.Item1 == userId).FirstOrDefault().Item2;
            for (int i = 0; i < lol.Length; i++)
            {
                if (userLabels.Contains(lol[i]))
                {
                    productIdsPrediction.Add(productsToPredict[i].id);
                }
            }

            var predictedProduct = _context.Products
                .Where(x => productIdsPrediction.Contains(x.Id))
                .ToList();

            //5int[] userLabels = clusters.Decide(userPurchaces);
            return Json(1);
        }

        [HttpGet]
        public JsonResult PredictPossibleProducts1()
        {
            var userIdString = HttpContext.Session.GetString("userid");
            var userId = 0;
            var didParsed = Int32.TryParse(userIdString, out userId);

            if (!didParsed || userId == -1)
            {
                return Json(new { });
            }

            var userGender = _context.Users
                .Where(x => x.Id == userId)
                .Select(x => x.Gender)
                .SingleOrDefault();
            /* ###############################
             * Creating the learning data
             * ############################### */
            var trainData = _context.Purchases
                .OrderBy(x => x.UserId)
                .Select(x => new
                {
                    userId = x.UserId.Value,
                    size = x.Product.Size,
                    type = x.Product.ProductTypeId,
                    gender = x.User.Gender,
                    bought = x.UserId.Value == userId ? 1 : 0
                })
                .ToList();

            var inputs = trainData.Select(x =>
            {
                double[] res = new double[]
                {
                    x.size,
                    Convert.ToInt32(x.gender),
                    x.type.Value
                };

                return res;
            })
            .ToArray();
            var outputs = trainData.Select(x => x.bought).ToArray();

            /* ###############################
             * Creating the model
             * ############################### */

            //var smo = new SequentialMinimalOptimization<Gaussian>()
            //{
            //    Complexity = 100
            //};

            //var svm = smo.Learn(inputs, outputs);

            //var knn1 = new KNearestNeighbors(k: 1);
            //var knn2 = new KNearestNeighbors(k: 2);
            //var knn3 = new KNearestNeighbors(k: 3);
            //var knn4 = new KNearestNeighbors(k: 4);
            //var knn5 = new KNearestNeighbors(k: 5);

            //knn1.Learn(inputs, outputs);
            //knn2.Learn(inputs, outputs);
            //knn3.Learn(inputs, outputs);
            //knn4.Learn(inputs, outputs);
            //knn5.Learn(inputs, outputs);


            /* ###############################
             * Manually test data.
             * ############################### */
            //double[][] testInputs =
            //{
            //    // variables:  x1  x2  x3
            //    new double[] {  42,  0,  1 }, // 0
            //    new double[] {  33,  0,  1 }, // 1
            //    new double[] {  36,  0,  1 }, // 1
            //    new double[] {  44,  0,  1 }, // 0
            //    new double[] {  44,  0,  2 }, // 0
            //    new double[] {  34,  0,  2 }, // 0
            //    new double[] {  46,  0,  3 }, // 0
            //    new double[] {  47,  0,  3 }, // 0
            //    new double[] {  33,  0,  3 }, // 1
            //    new double[] {  46,  0,  4 }, // 0
            //    new double[] {  25,  0,  4 }, // 0
            //    new double[] {  35,  0,  5 }, // 1
            //    new double[] {  36,  0,  5 }, // 1
            //    new double[] {  48,  0,  5 }, // 0
            //    new double[] {  28,  0,  6 }, // 0
            //    new double[] {  33,  0,  6 }, // 0
            //    new double[] {  34,  0,  6 }, // 0
            //};

            //int[] testOutpus = new int[] { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0 };
            //int[] res1 = knn1.Decide(testInputs);
            //int[] res2 = knn2.Decide(testInputs);
            //int[] res3 = knn3.Decide(testInputs);
            //int[] res4 = knn4.Decide(testInputs);
            //int[] res5 = knn5.Decide(testInputs);
            //double[] lol1 = new double[] { 0, 0, 0 };
            //var lol = knn1.Scores(new double[] { 35, 0, 1 });
            //// Let's say we would like to compute the error matrix for the classifier:
            //var cm1 = GeneralConfusionMatrix.Estimate(knn1, testInputs, testOutpus);
            //var cm2 = GeneralConfusionMatrix.Estimate(knn2, testInputs, testOutpus);
            //var cm3 = GeneralConfusionMatrix.Estimate(knn3, testInputs, testOutpus);
            //var cm4 = GeneralConfusionMatrix.Estimate(knn4, testInputs, testOutpus);
            //var cm5 = GeneralConfusionMatrix.Estimate(knn5, testInputs, testOutpus);
            //// We can use it to estimate measures such as 
            //double error1 = cm1.Error;  // should be 
            //double acc1 = cm1.Accuracy; // should be 

            //double error2 = cm2.Error;  // should be 
            //double acc2 = cm2.Accuracy; // should be 

            //double error3 = cm3.Error;  // should be 
            //double acc3 = cm3.Accuracy; // should be 

            //double error4 = cm4.Error;  // should be 
            //double acc4 = cm4.Accuracy; // should be 

            //double error5 = cm5.Error;  // should be 
            //double acc5 = cm5.Accuracy; // should be 

            ///* ###############################
            // * Learning on products.
            // * ############################### */

            //var productIdsUserBought = _context.Purchases
            //    .Where(x => x.UserId == userId)
            //    .Select(x => x.ProductId)
            //    .Distinct()
            //    .ToList();

            //var productsToPredict = _context.Products
            //    .Where(x => !productIdsUserBought.Contains(x.Id))
            //    .Select(x => new
            //    {
            //        id = x.Id,
            //        size = x.Size,
            //        type = x.ProductTypeId,
            //        gender = userGender,
            //    })
            //    .ToList();

            //var predInputs = productsToPredict.Select(x =>
            //{
            //    double[] res = new double[]
            //    {
            //        x.size,
            //        Convert.ToInt32(x.gender),
            //        x.type.Value
            //    };

            //    return res;
            //})
            //.ToArray();
            //int[] prediction = knn3.Decide(predInputs);

            //var predictedProductId = new List<int>();
            //for (int i = 0; i < productsToPredict.Count; i++)
            //{
            //    if (prediction[i] == 1)
            //    {
            //        predictedProductId.Add(productsToPredict[i].id);
            //    }
            //}

            //var predictedProduct = _context.Products
            //    .Where(x => predictedProductId.Contains(x.Id))
            //    .ToList();

            var codification = new Codification<double>()
            {
                CodificationVariable.Discrete,
                CodificationVariable.Categorical,
                CodificationVariable.Categorical
            };

            // Learn the codification from observations
            var model = codification.Learn(inputs);

            // Transform the mixed observations into only continuous:
            double[][] newInputs = model.ToDouble().Transform(inputs);

            KMeans kmeans = new KMeans(k: 4)
            {
                // For example, let's say we would like to consider the importance of 
                // the first column as 0.1, the second column as 0.7 and the third 0.9
                Distance = new WeightedSquareEuclidean(new double[] { 1, 8, 8, 4, 4, 4, 4, 4, 4 })
            };
            var clusters = kmeans.Learn(newInputs);
            int[] labels = clusters.Decide(newInputs);

            var purchasesById = _context.Purchases
                .Select(x => new
                {
                    userId = x.UserId.Value,
                    size = x.Product.Size,
                    type = x.Product.ProductTypeId,
                    gender = x.User.Gender
                })
                .GroupBy(x => x.userId)
                .ToList();

            IList<Tuple<int, int[]>> labelsForUsers = new List<Tuple<int, int[]>>();
            for (int i = 0; i < purchasesById.Count; i++)
            {
                var userInputs = purchasesById[i].
                    Select(x =>
                    {
                        double[] res = new double[]
                        {
                            x.size,
                            Convert.ToInt32(x.gender),
                            x.type.Value
                        };

                        return res;
                    })
                    .ToArray();

                double[][] newUserInputs = model.ToDouble().Transform(userInputs);
                //var label = clusters.Decide(newUserInputs)
                //    .GroupBy(x => x)
                //    .Select(x => new
                //    {
                //        label = x,
                //        count = x.Count()
                //    })
                //    .OrderByDescending(x => x.count)
                //    .First()
                //    .label
                //    .Key;
                labelsForUsers.Add(new Tuple<int, int[]>(purchasesById[i].Key, clusters.Decide(newUserInputs).Distinct().ToArray()));
            }

            var productIdsUserBought = _context.Purchases
                .Where(x => x.UserId == userId)
                .Select(x => x.ProductId)
                .Distinct()
                .ToList();

            var productsToPredict = _context.Products
                .Where(x => !productIdsUserBought.Contains(x.Id))
                .Select(x => new
                {
                    id = x.Id,
                    size = x.Size,
                    type = x.ProductTypeId,
                    gender = userGender,
                })
                .ToList();

            var predInputs = productsToPredict.Select(x =>
            {
                double[] res = new double[]
                {
                    x.size,
                    Convert.ToInt32(x.gender),
                    x.type.Value
                };

                return res;
            })
            .ToArray();

            int[] lol = clusters.Decide(predInputs);

            IList<int> productIdsPrediction = new List<int>();
            var userLabels = labelsForUsers.Where(x => x.Item1 == userId).FirstOrDefault().Item2;
            for (int i = 0; i < lol.Length; i++)
            {
                if (userLabels.Contains(lol[i]))
                {
                    productIdsPrediction.Add(productsToPredict[i].id);
                }
            }

            var predictedProduct = _context.Products
                .Where(x => productIdsPrediction.Contains(x.Id))
                .ToList();

            //5int[] userLabels = clusters.Decide(userPurchaces);
            return Json(1);
        }
    }
}