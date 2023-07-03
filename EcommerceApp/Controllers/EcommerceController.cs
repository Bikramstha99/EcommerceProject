﻿using EcommerceApp.Data;
using EcommerceApp.Models.Domain;
using EcommerceApp.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class EcommerceController : Controller
    {
        private readonly EcommerceDbContext ecommerce;

        public EcommerceController(EcommerceDbContext ecommerece)
        {
            this.ecommerce = ecommerece;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var item= ecommerce.Ecommerces.ToList();
            return View(item);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddEcommerce addecommerce)
        {
            var item = new Ecommerce()
            {
                Name = addecommerce.Name,
                Category = addecommerce.Category,
                Price = addecommerce.Price,
               
             };
            ecommerce.Ecommerces.Add(item);
            ecommerce.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult View(int id)
        {
            var obj= ecommerce.Ecommerces.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                var item = new UpdateEcommerce()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Category = obj.Category,
                    Price = obj.Price,
                };
                return View(item);

             }
            return RedirectToAction("Index");


        }
        }
}
