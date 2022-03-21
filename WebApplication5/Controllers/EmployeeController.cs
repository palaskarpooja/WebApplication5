using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        public organisationContext db;
        public EmployeeController(organisationContext db1)
        {
            db = db1;
        }
        public IActionResult Index()
        {
            return View(db.Employees);
        }
    }
}
