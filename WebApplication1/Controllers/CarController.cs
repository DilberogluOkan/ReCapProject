using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarController : Controller
    {
        CarManager carManager = new CarManager(new EfCarDal());
        public IActionResult Index()
        {
            var result = carManager.GetAll();
            if (result.Success==false)
            {
                 return View(); 
            }
            TempData["testmsg"] = result.Message ;
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult CarAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CarAdd(Car car)
        {
            
            if (carManager.Add(car).Success==false)
            {
                TempData["testmsg"] = carManager.Add(car).Message;
                return RedirectToAction("CarAdd");
            }
            carManager.Add(car);
            return RedirectToAction("Index");
        }
    }
}
