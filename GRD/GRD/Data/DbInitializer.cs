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
                    new User{Username="user",Password="user",Address="some user adsress",IsAdmin=false,Gender=true}
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
                new ProductType{Name="מכנס גבר"},
                new ProductType{Name="מכנס אישה"},
                new ProductType{Name="חולצה גבר"},
                new ProductType{Name="חולצה אישה"},
                new ProductType{Name="נעליים גבר"},
                new ProductType{Name="נעליים אישה"},
                new ProductType{Name="שמלה"},
            };
            var products = new Product[]
                {
                    new Product{Name="חולצה",Size=48,Price=51,PictureName="1.jpg", Supplier = suppliers[0] ,ProductType = productTypes[0] },
                    new Product{Name="מכנס",Size=44,Price=11,PictureName="Chrysanthemum.jpg", Supplier = suppliers[1], ProductType = productTypes[1] },
                    new Product{Name="ג'ינס",Size=23,Price=88,PictureName="Desert.jpg", Supplier = suppliers[2], ProductType = productTypes[3] },
                    new Product{Name="שמלה",Size=23,Price=88,PictureName="Desert.jpg", Supplier = suppliers[2], ProductType = productTypes[4] },
                    new Product{Name="חולצה מגניבה",Size=23,Price=88,PictureName="Desert.jpg", Supplier = suppliers[2], ProductType = productTypes[2] },
                };
            var Purchases = new Purchase[]
                {
                    new Purchase{Count=3,PurchaseDate=new DateTime(2018,9,22),Product=products[0],Branch=branches[0],User=users[1]},
                    new Purchase{Count=4,PurchaseDate=new DateTime(2018,8,1),Product=products[2],Branch=branches[2],User=users[0]},
                    new Purchase{Count=1,PurchaseDate=new DateTime(2018,7,13),Product=products[1],Branch=branches[3],User=users[1]},
                    new Purchase{Count=7,PurchaseDate=new DateTime(2018,10,16),Product=products[0],Branch=branches[1],User=users[0]},
                    new Purchase{Count=9,PurchaseDate=new DateTime(2018,5,25),Product=products[1],Branch=branches[2],User=users[1]},
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