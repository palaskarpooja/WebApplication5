using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    
    public class DepartmentController : Controller
    {
 
        public organisationContext db;
        public DepartmentController(organisationContext db1)
        {
            db = db1;
        }
        public IActionResult Index()
        {
            return View(db.Departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return View();
        }

    }
}
