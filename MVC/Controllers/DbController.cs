using Microsoft.AspNetCore.Mvc;
using MVC.Context;
using MVC.Entities;
using System.Globalization;

namespace MVC.Controllers
{
    public class DbController : Controller
    {
        private readonly Db _db;

        public DbController(Db db)
        {
            _db = db;

        }
        public IActionResult Test()
        {
            return Content("User count:" + _db.Users.Count());
        }

        public IActionResult Seed()
        {
            //içinde foreign key olmayanla seedleme yapılır

            _db.Roles.Add(new Role()
            {
                Name = "admin",
                Users = new List<User>()
                {
                    new User()
                    {
                        BirthDate = new DateTime(1980,5,1),
                        IsActive = true,
                        Password = "Bilge",
                        Status = Enums.Statuses.Junior,
                        UserName = "Bilge"
                    },
                    new User()
                    {
                        BirthDate = DateTime.Parse("20.10.2022" , new CultureInfo("tr-TR")),
                        IsActive = true,
                        Password = "kaan",
                        Status = Enums.Statuses.Junior,
                        UserName = "kaan"
                    }

                }
            });

            _db.Roles.Add(new Role()
            {
                Name = "user",
                Users = new List<User>()
                {
                    new User()
                    {
                        BirthDate = DateTime.Parse("22.10.2023", new CultureInfo("tr-TR")),
                        IsActive = true,
                        Password = "leo",
                        Status = Enums.Statuses.Master,
                        UserName = "leo"
                    }

                }
            });

            _db.SaveChanges();
            return Content("Database seed successful");
        }

    }
}
