﻿using Microsoft.AspNetCore.Mvc;
using MVCFlowerShopWeek3.Models;
using MVCFlowerShopWeek3.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCFlowerShopWeek3.Controllers
{
    public class FlowerListController : Controller
    {
        private readonly MVCFlowerShopWeek3Context _context;

        public FlowerListController(MVCFlowerShopWeek3Context context)
        {
            _context = context;
        }

        //Function 1: Learn hot to crete the add flower form

        public IActionResult AddNewFlower()
        {
            return View();
        }

        //Funciton 2: Learn how to insert ot the flower table
        [HttpPost]
        [ValidateAntiForgeryToken] // avoid cross-site attack

        public async Task<IActionResult> AddFlower(Flower flower)
        {
            if (ModelState.IsValid)
            {
                _context.FlowerTable.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "FlowerList");
            }
            return View("AddNewFlower", flower);
        }

        //Function 3: Learn how to retreive data back from Flower Table

        public async Task<IActionResult> Index()
        {
            List<Flower> flowerList = await _context.FlowerTable.ToListAsync();
            return View(flowerList);
        }

    }
}
