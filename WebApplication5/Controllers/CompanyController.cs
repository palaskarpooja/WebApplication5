using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
     
    public class CompanyController : Controller
    {
        
        public organisationContext db;
        public CompanyController(organisationContext db1)
        {
            db = db1;
        }
        
        public IActionResult Index()
        {
            var t = db.Companies.Include(x => x.Location);
            return View(t);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "Locationid", "Name");       
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company c)
        {
            db.Companies.Add(c);
            db.SaveChanges();
            return View();
        }
        
        public IActionResult Edit(int id)
        {
            var Company = db.Companies.Find(id);
            ViewBag.Locationid = new SelectList(db.Locations, "Locationid", "Name");
            return View(Company);
        }
        [HttpPost]
        public IActionResult Edit(Company company, int id)
        {
            if (id != null)
            {
                db.Companies.Update(company);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
