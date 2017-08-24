using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace jornal_demo.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Option> Options { get; set; }
    }

    //Инициализируем БД
    public class OptionDbInitialize : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            Car car1 = new Car { Id = 1, Name = "Alfa Romeo Gulia", Description = "Alfa Romeo Giulia (Серия 952) - престижный автомобиль среднего класса," +
                "выпускающийся компанией Alfa Romeo с февраля 2016 года.", Weburl = "https://www.alfaromeousa.com/cars/alfa-romeo-giulia-quadrifoglio" };

            Car car2 = new Car
            {
                Id = 2,
                Name = "Jaguar XF",
                Description = "Jaguar XF — люксовый седан бизнес-класса/ спортивный седан, выпускаемый британской автомобилестроительной компанией Jaguar с 2008 года.",
                Weburl = "https://www.jaguar.ru/jaguar-range/xf/index.html"
            };
            Car car3 = new Car
            {
                Id = 3,
                Name = "Mercedes-Benz CLS",
                Description = "Mercedes-Benz CLS-класс — серия люксовых среднеразмерных четырёхдверных купе, выпускающихся немецкой маркой Mercedes-Benz с 2004 года.",
                Weburl = "http://topruscar.ru/komplektacii-ceny/2016/mercedes-gls-2016"
            };
            Car car4 = new Car
            {
                Id = 4,
                Name = "BMW 7",
                Description = "BMW 7, или седьмая серия BMW, — автомобили серии класса люкс. Начиная с 1977 года было выпущено шесть поколений этой серии.",
                Weburl = "https://www.bmw.ru/ru/all-models/7-series/sedan/2015/at-a-glance.html"
            };
            Car car5 = new Car
            {
                Id = 5,
                Name = "Audi A8",
                Description = "Audi A8 — автомобиль представительского класса, преемник модели Audi V8.",
                Weburl = "http://2017.wiki/audi-a8-2017/"
            };


            context.Cars.Add(car1);
            context.Cars.Add(car2);
            context.Cars.Add(car3);
            context.Cars.Add(car4);
            context.Cars.Add(car5);

            Option opt1 = new Option
            {
                Id = 1,
                Name = "Биксеноновые фары",
                Cars = new List<Car>() { car1, car2, car4, car5 }
            };

            Option opt2 = new Option
            {
                Id = 2,
                Name = "Фаркоп",
                Cars = new List<Car>() { car2, car4 }
            };

            Option opt3 = new Option
            {
                Id = 3,
                Name = "Круиз-контроль",
                Cars = new List<Car>() { car1, car2, car4, car5}
            };

            Option opt4 = new Option
            {
                Id = 4,
                Name = "Климат-контроль",
                Cars = new List<Car>() { car1, car3, car2, car4, car5 }
            };


            Option opt5 = new Option
            {
                Id = 5,
                Name = "Камера заднего вида",
                Cars = new List<Car>() { car4, car3 }
            };

            context.Options.Add(opt2);
            context.Options.Add(opt3);
            context.Options.Add(opt4);
            context.Options.Add(opt5);

            context.SaveChanges();
        }
    }
}