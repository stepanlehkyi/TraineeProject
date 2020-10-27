
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trainee_project.Models;
using Trainee_project.Models.Context;

namespace Trainee_project.Controllers
{
    public class FileUploadController : Controller
    {
        private UserContext db;
        public FileUploadController(UserContext db)
        {
           this.db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = db.Users.ToList();
            return View("FileUploadPage",users);
        }
        [HttpPost]
       
        public ActionResult Upload(IFormFile file)
        {
            if (file != null)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader,CultureInfo.GetCultureInfo("en-AU")))
                {
                    csv.Configuration.RegisterClassMap<MapUsers>();
                    var records = csv.GetRecords<User>().ToList();
                    foreach(var record in records)
                    {
                        if (!db.Users.Contains(record))
                        {
                            db.Add(record);
                            db.SaveChanges();
                        }
                    }
                     
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Models.User user = db.Users.Find(id);
            if (user == null)
            {
                return new NotFoundResult();
            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(user);
        }
    }
}
