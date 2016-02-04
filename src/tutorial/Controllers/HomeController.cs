using System.Linq;
using Microsoft.AspNet.Mvc;
using tutorial.Models; // пространство имен моделей

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
    }
}