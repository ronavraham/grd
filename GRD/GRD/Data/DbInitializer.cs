using GRD.Models;
using System;
using System.Linq;

namespace GRD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjectContext context)
        {

            var users = new User[]
                {
                    new User{Username="admin",Password="admin",Address="some admin adsress",IsAdmin=true,Gender=false},
                    new User{Username="userMaleSmall1",Password="userMaleSmall1",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userMaleSmall2",Password="userMaleSmall2",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userMaleSmall3",Password="userMaleSmall3",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userMaleBig1",Password="userMaleBig1",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userMaleBig2",Password="userMaleBig2",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userMaleBig3",Password="userMaleBig3",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userMaleBig4",Password="userMaleBig4",Address="some user adsress",IsAdmin=false,Gender=false},
                    new User{Username="userFemaleSmall1",Password="userFemaleSmall1",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleSmall2",Password="userFemaleSmall2",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleSmall3",Password="userFemaleSmall3",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleSmall4",Password="userFemaleSmall4",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleBig1",Password="userFemaleBig1",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleBig2",Password="userFemaleBig2",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleBig3",Password="userFemaleBig3",Address="some user adsress",IsAdmin=false,Gender=true},
                    new User{Username="userFemaleBig4",Password="userFemaleBig4",Address="some user adsress",IsAdmin=false,Gender=true}
                };
            var branches = new Branch[]
                {
                    new Branch{Name="סניף כפר סבא",Lat=32.176,Long=34.894,City="כפר סבא",Address="כתובת בכפר סבא",Telephone="0586417813",IsSaturday=true},
                    new Branch{Name="סניף תל אביב",Lat=32.08,Long=34.77,City="תל אביב",Address="כתובת בתל אביב",Telephone="0586417813",IsSaturday=false},
                    new Branch{Name="2 סניף תל אביב",Lat=32.078,Long=34.77,City="תל אביב",Address="2 כתובת בתל אביב",Telephone="0586417813",IsSaturday=true},
                    new Branch{Name="סניף חולון",Lat=32.017,Long=34.78,City="חולון",Address="כתובת בחולון",Telephone="0586417813",IsSaturday=false},
                    new Branch{Name="סניף בת ים",Lat=32.015,Long=34.753,City="בת ים",Address="כתובת בבת ים",Telephone="0586417813",IsSaturday=true},
                };
            var suppliers = new Supplier[]
                {
                    new Supplier{Name="ZARA"},
                    new Supplier{Name="H&M"},
                    new Supplier{Name="ADIDAS"},
                };
            var productTypes = new ProductType[]
            {
                new ProductType{Gender=false,Name="מכנס גבר"},
                new ProductType{Gender=true,Name="מכנס אישה"},
                new ProductType{Gender=false,Name="חולצה גבר"},
                new ProductType{Gender=true,Name="חולצה אישה"},
                new ProductType{Gender=false,Name="נעליים גבר"},
                new ProductType{Gender=true,Name="נעליים אישה"}
            };
            var products = new Product[]
                {
                    new Product{Name="מכנס גבר קטן 1",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר קטן 2",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר קטן 3",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר קטן 4",Size=37,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר קטן 5",Size=38,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[0] },

                    new Product{Name="מכנס גבר גדול 2",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר גדול 3",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר גדול 4",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר גדול 5",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס גבר גדול 1",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[0] },

                    new Product{Name="מכנס אישה קטן 1",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה קטן 2",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה קטן 3",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה קטן 4",Size=37,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה קטן 5",Size=38,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[1] },

                    new Product{Name="מכנס אישה גדול 1",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה גדול 2",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה גדול 3",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה גדול 4",Size=48,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[1] },
                    new Product{Name="מכנס אישה גדול 5",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[1] },


                    new Product{Name="חולצה גבר קטנה 1",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר קטנה 2",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר קטנה 3",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר קטנה 4",Size=37,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר קטנה 5",Size=38,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[2] },

                    new Product{Name="חולצה גבר גדולה 1",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר גדולה 2",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר גדולה 3",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר גדולה 4",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[2] },
                    new Product{Name="חולצה גבר גדולה 5",Size=48,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[2] },

                    new Product{Name="חולצה אישה קטנה 1",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה קטנה 2",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה קטנה 3",Size=37,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה קטנה 4",Size=38,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה קטנה 5",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[3] },

                    new Product{Name="חולצה אישה גדולה 1",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה גדולה 2",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה גדולה 3",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה גדולה 4",Size=48,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[3] },
                    new Product{Name="חולצה אישה גדולה 5",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[3] },

                    new Product{Name="נעליים גבר קטנות 1",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר קטנות 2",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר קטנות 3",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר קטנות 4",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר קטנות 5",Size=37,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[4] },

                    new Product{Name="נעליים גבר גדולות 1",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר גדולות 2",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר גדולות 3",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר גדולות 4",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[4] },
                    new Product{Name="נעליים גבר גדולות 5",Size=48,Price=51,PictureName="1.jpg", Supplier = suppliers[2] ,ProductType = productTypes[4] },

                    new Product{Name="נעליים אישה קטנות 1",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה קטנות 2",Size=35,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה קטנות 3",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה קטנות 4",Size=37,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה קטנות 5",Size=36,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[5] },

                    new Product{Name="נעליים אישה גדולות 1",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה גדולות 2",Size=45,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה גדולות 3",Size=46,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה גדולות 4",Size=48,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[5] },
                    new Product{Name="נעליים אישה גדולות 5",Size=47,Price=51,PictureName="1.jpg", Supplier = suppliers[1] ,ProductType = productTypes[5] },
                };
            var Purchases = new Purchase[]
                {
					// admin
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[0],Branch=branches[0],User=users[0]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[1],Branch=branches[1],User=users[0]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[20],Branch=branches[2],User=users[0]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[21],Branch=branches[3],User=users[0]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[40],Branch=branches[4],User=users[0]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[41],Branch=branches[0],User=users[0]},
					
					// userMaleSmall1
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[2],Branch=branches[1],User=users[1]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[3],Branch=branches[2],User=users[1]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[22],Branch=branches[3],User=users[1]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[23],Branch=branches[4],User=users[1]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[42],Branch=branches[0],User=users[1]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[43],Branch=branches[1],User=users[1]},
					
					// userMaleSmall2
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[3],Branch=branches[2],User=users[2]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[4],Branch=branches[3],User=users[2]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[23],Branch=branches[4],User=users[2]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[24],Branch=branches[0],User=users[2]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[43],Branch=branches[1],User=users[2]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[44],Branch=branches[2],User=users[2]},
					
					// userMaleSmall3
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[0],Branch=branches[3],User=users[3]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[4],Branch=branches[4],User=users[3]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[20],Branch=branches[0],User=users[3]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[24],Branch=branches[1],User=users[3]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[40],Branch=branches[2],User=users[3]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[44],Branch=branches[3],User=users[3]},
					
					// userMaleBig1
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[5],Branch=branches[0],User=users[4]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[6],Branch=branches[0],User=users[4]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[25],Branch=branches[0],User=users[4]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[26],Branch=branches[0],User=users[4]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[45],Branch=branches[0],User=users[4]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[46],Branch=branches[0],User=users[4]},
					
					// userMaleBig2
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[7],Branch=branches[0],User=users[5]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[8],Branch=branches[0],User=users[5]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[27],Branch=branches[0],User=users[5]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[28],Branch=branches[0],User=users[5]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[47],Branch=branches[0],User=users[5]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[48],Branch=branches[0],User=users[5]},
					
					// userMaleBig3
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[8],Branch=branches[0],User=users[6]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[9],Branch=branches[0],User=users[6]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[28],Branch=branches[0],User=users[6]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[29],Branch=branches[0],User=users[6]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[48],Branch=branches[0],User=users[6]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[49],Branch=branches[0],User=users[6]},
					
					// userMaleBig4
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[5],Branch=branches[0],User=users[7]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[9],Branch=branches[0],User=users[7]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[25],Branch=branches[0],User=users[7]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[29],Branch=branches[0],User=users[7]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[45],Branch=branches[0],User=users[7]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[49],Branch=branches[0],User=users[7]},
					
					// userFemaleSmall1
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[10],Branch=branches[0],User=users[8]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[11],Branch=branches[0],User=users[8]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[30],Branch=branches[0],User=users[8]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[31],Branch=branches[0],User=users[8]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[50],Branch=branches[0],User=users[8]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[51],Branch=branches[0],User=users[8]},
					
					// userFemaleSmall2
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[12],Branch=branches[1],User=users[9]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[13],Branch=branches[1],User=users[9]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[32],Branch=branches[1],User=users[9]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[33],Branch=branches[1],User=users[9]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[52],Branch=branches[1],User=users[9]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[53],Branch=branches[1],User=users[9]},
					
					// userFemaleSmall3
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[13],Branch=branches[2],User=users[10]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[14],Branch=branches[2],User=users[10]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[33],Branch=branches[2],User=users[10]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[34],Branch=branches[2],User=users[10]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[53],Branch=branches[2],User=users[10]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[54],Branch=branches[2],User=users[10]},
					
					// userFemaleSmall4
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[10],Branch=branches[3],User=users[11]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[14],Branch=branches[3],User=users[11]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[30],Branch=branches[3],User=users[11]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[34],Branch=branches[3],User=users[11]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[50],Branch=branches[3],User=users[11]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[54],Branch=branches[3],User=users[11]},
					
					// userFemaleBig1
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[15],Branch=branches[4],User=users[12]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[16],Branch=branches[4],User=users[12]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[35],Branch=branches[4],User=users[12]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[36],Branch=branches[4],User=users[12]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[55],Branch=branches[4],User=users[12]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[56],Branch=branches[4],User=users[12]},
					
					// userFemaleBig2
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[17],Branch=branches[1],User=users[13]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[18],Branch=branches[1],User=users[13]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[37],Branch=branches[1],User=users[13]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[38],Branch=branches[1],User=users[13]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[57],Branch=branches[1],User=users[13]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[58],Branch=branches[1],User=users[13]},
					
					// userFemaleBig3
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[18],Branch=branches[0],User=users[14]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[19],Branch=branches[0],User=users[14]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[38],Branch=branches[0],User=users[14]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[39],Branch=branches[0],User=users[14]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[58],Branch=branches[0],User=users[14]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[59],Branch=branches[0],User=users[14]},
					
					// userFemaleBig4
					new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[15],Branch=branches[2],User=users[15]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[19],Branch=branches[2],User=users[15]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[35],Branch=branches[2],User=users[15]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[39],Branch=branches[2],User=users[15]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[55],Branch=branches[2],User=users[15]},
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[59],Branch=branches[2],User=users[15]},
                };

            // Look for any Users.
            if (!context.Users.Any())
            {
                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }

            // Look for any Branches.
            if (!context.Branches.Any())
            {
                foreach (Branch c in branches)
                {
                    context.Branches.Add(c);
                }
                context.SaveChanges();
            }

            // Look for any Suppliers.
            if (!context.Suppliers.Any())
            {
                foreach (Supplier s in suppliers)
                {
                    context.Suppliers.Add(s);
                }
                context.SaveChanges();
            }

            // Look for any ProductTypes.
            if (!context.ProductTypes.Any())
            {
                foreach (ProductType u in productTypes)
                {
                    context.ProductTypes.Add(u);
                }
                context.SaveChanges();
            }

            // Look for any Products.
            if (!context.Products.Any())
            {
                foreach (Product e in products)
                {
                    context.Products.Add(e);
                }

                context.SaveChanges();
            }

            // Look for any Products.
            if (!context.Purchases.Any())
            {
                foreach (Purchase p in Purchases)
                {
                    context.Purchases.Add(p);
                }
                context.SaveChanges();
            }

            return;
        }
    }
}