using LibraryApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        LibraryContext db = new LibraryContext();

        [HttpGet]
        public IActionResult Index()
        {
            MainPage model = db.MainPages.FirstOrDefault();
            return View(model);
        }
        public IActionResult Contact()
        {
            Contact model = db.Contacts.FirstOrDefault();
            return View(model);
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                // baþarýlýysa kaydet
                model.Status = true;
                model.CreatedDate = DateTime.Now;
                model.FirstName = model.FirstName.ToUpper();
                model.LastName = model.LastName.ToUpper();

                db.ContactMessages.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult About()
        {
            About model = db.Abouts.FirstOrDefault();
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
