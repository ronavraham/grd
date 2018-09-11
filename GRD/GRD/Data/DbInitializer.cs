using GRD.Models;
using System;
using System.Linq;

namespace GRD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjectContext context)
        {


            // context.Database.EnsureCreated();

            // Look for any Users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{Username="admin",Password="admin",Address="some admin adsress",IsAdmin=true,Gender=false},
            new User{Username="user",Password="user",Address="some user adsress",IsAdmin=false,Gender=true}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            // Look for any Branches.
            if (context.Branches.Any())
            {
                return;   // DB has been seeded
            }

            var branches = new Branch[]
            {
            new Branch{Name="סניף כפר סבא",Lat=32.176,Long=34.894,City="כפר סבא",Address="כתובת בכפר סבא",Telephone="0586417813",IsSaturday=true},
            new Branch{Name="סניף תל אביב",Lat=32.08,Long=34.77,City="תל אביב",Address="כתובת בתל אביב",Telephone="0586417813",IsSaturday=false},
            new Branch{Name="2 סניף תל אביב",Lat=32.078,Long=34.77,City="תל אביב",Address="2 כתובת בתל אביב",Telephone="0586417813",IsSaturday=true},
            new Branch{Name="סניף חולון",Lat=32.017,Long=34.78,City="חולון",Address="כתובת בחולון",Telephone="0586417813",IsSaturday=false},
            new Branch{Name="סניף בת ים",Lat=32.015,Long=34.753,City="בת ים",Address="כתובת בבת ים",Telephone="0586417813",IsSaturday=true},
            };
            foreach (Branch c in branches)
            {
                context.Branches.Add(c);
            }
            context.SaveChanges();

            // Look for any Products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
            new Product{Name="חולצה",Size=48,Price=51,PictureName="1.jpg"},
            new Product{Name="מכנס",Size=44,Price=11,PictureName="Chrysanthemum.jpg"},
            new Product{Name="קקקק",Size=23,Price=88,PictureName="Desert.jpg"},
            };
            foreach (Product e in products)
            {
                context.Products.Add(e);
            }
            context.SaveChanges();
        }
    }
}