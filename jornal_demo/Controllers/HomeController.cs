using jornal_demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jornal_demo.Controllers
{
    public class HomeController : Controller
    {
        private CarContext db =  new CarContext();
        public ActionResult Index()
        {
            return View(db.Cars.ToList());

        }



        // Просмотр записи
        public ActionResult Details(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);          
        }


        // Удаление записи
        [HttpGet]
         public ActionResult Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Car c = new Car { Id = id };
            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();

            //Car car = db.Cars.Find(id);
            //if (car != null)
            //{
            //    db.Cars.Remove(car);
            //    db.SaveChanges();
            //}
            return RedirectToAction("Index");
        }

      
        // Редактирование записи
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.Options = db.Options.ToList();
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car, int[] selectedOptions)
        {
            Car newCar = db.Cars.Find(car.Id);
            newCar.Name = car.Name;
            newCar.Description = car.Description;
            newCar.Weburl = car.Weburl;

            newCar.Options.Clear();
            if (selectedOptions != null)
            {
                foreach (var opt in db.Options.Where(option => selectedOptions.Contains(option.Id)))
                {
                    newCar.Options.Add(opt);
                }
            }

            db.Entry(newCar).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
         
        }



        //Создание новой записи

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Options = db.Options.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Car car, int[] selectedOptions)
        {
            // Получить список опций
            if (selectedOptions != null)
            {
                foreach (var opt in db.Options.Where(option => selectedOptions.Contains(option.Id)))
                {
                    car.Options.Add(opt);
                }
            }

            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}