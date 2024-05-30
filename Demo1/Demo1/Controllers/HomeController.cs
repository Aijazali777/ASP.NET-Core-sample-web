using Demo1.Models;
using Demo1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository empRepo;

        public HomeController(IEmployeeRepository employeeRepo)
        {
            empRepo = employeeRepo;
        }

        [Route("")]
        [Route("~/")]
        public ViewResult Index()
        {
            var model = empRepo.GetAllEmployees();
            return View(model);
        }

        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            // Employee model = empRepo.GetEmployee(2);
            HomeDetailsViewModel detailsViewModel = new HomeDetailsViewModel()
            {
                Employee = empRepo.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };

            #region ViewData
            // ViewData["Employee"] = model;
            // ViewData["PageTitle"] = "Employee Details";
            #endregion

            #region ViewBag
            //ViewBag.Employee = model;
            //ViewBag.PageTitle = "Page Title";
            #endregion
            return View(detailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee newEmployee = empRepo.Add(employee);
                //return RedirectToAction("Details", new { id = newEmployee.Id });
            }

           return View();
        }
    }
}
