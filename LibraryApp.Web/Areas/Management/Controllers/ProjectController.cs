using Microsoft.AspNetCore.Mvc;
using LibraryApp.Web.Models;
using LibraryApp.Web.Utils;

namespace LibraryApp.Web.Areas.Management.Controllers {
    [Area("Management")]
    public class ProjectController : Controller {
        LibraryContext db = new LibraryContext();
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProjectController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index() {
            var model = db.Projects.ToList();
            return View(model);
        }

        public IActionResult Details(int id) {
            var model = db.Projects.Find(id);
            if (model == null) {
				return Redirect("/Management/Project/Index");
			}
            return View(model);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project model, IFormFile img) {
            if (ModelState.IsValid) {
                if (img != null) {
                    model.ImageUrl = 
                        await ImageUploader.UploadImageAsync(_hostEnvironment, img);
                }
                model.Status = true;
                model.CreatedDate = DateTime.Now;
                db.Projects.Add(model);
                db.SaveChanges();
                return Redirect("/Management/Project/Index");
            }
            return View(model);
        }
    }
}
