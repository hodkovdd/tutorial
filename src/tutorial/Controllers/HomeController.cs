using System.Linq;
using Microsoft.AspNet.Mvc;
using tutorial.Models; // пространство имен моделей
using System;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        //[ActionName("Welcome")]
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
        //--------------//


        //[HttpPost]
        public string lesson5()
        {
            string AltitudeStr = Request.Query.FirstOrDefault(p => p.Key == "altitude").Value;
            int Altitude = Int32.Parse(AltitudeStr);

            string HeightStr = Request.Query.FirstOrDefault(p => p.Key == "height").Value;
            int Height = Int32.Parse(HeightStr);

            int Square = Altitude * Height / 2;
            Geometry geo = new Geometry(Altitude, Height);

            return $"S triangle with a {geo.Altitude} and h {geo.Height} = {geo.GetSquare()}";
        }

        public string Square()
        {
            string altitudeString = Request.Query.FirstOrDefault(p => p.Key == "altitude").Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Query.FirstOrDefault(p => p.Key == "height").Value;
            int height = Int32.Parse(heightString);

            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }



        public string Sum(Geometry[] geos)
        { 
            return $"S squares = {geos.Sum(g=>g.GetSquare())}";
        }


        public IActionResult ForLessons()
        {
            return View();
        }
    }
    public class Geometry
    {
        public int Altitude { get; set; } // основание
        public int Height { get; set; } // высота
        public Geometry(int a, int b)
        {
            Altitude = a;
            Height = b;
        }
        

        public double GetSquare() // вычисление площади треугольника
        {
            return Altitude * Height / 2;
        }
    }
}