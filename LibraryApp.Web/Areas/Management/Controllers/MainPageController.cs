using Microsoft.AspNetCore.Mvc;
using LibraryApp.Web.Models;
using LibraryApp.Web.Utils;

namespace LibraryApp.Web.Areas.Management.Controllers {
    [Area("Management")]
    public class MainPageController : Controller {
        LibraryContext db = new LibraryContext();
        
        private readonly IWebHostEnvironment _hostEnvironment;
        public MainPageController(IWebHostEnvironment hostEnvironment) {
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index() {
            MainPage model = db.MainPages.FirstOrDefault();
            return View(model);
        }

        public IActionResult Edit(int id) {
            MainPage? model = db.MainPages.Find(id);
            if (model == null) {
                return Redirect("/Management/MainPage/Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MainPage model, IFormFile img) {
            if (ModelState.IsValid) {
                MainPage? editModel = db.MainPages.Find(model.Id);
                if (editModel == null) {
                    return Redirect("/Management/MainPage/Index");
                }

                if (img != null) {
                    await ImageUploader.DeleteImageAsync(_hostEnvironment, editModel.ImageUrl);
                    editModel.ImageUrl = await ImageUploader
                        .UploadImageAsync(_hostEnvironment, img);
                }

                editModel.Title = model.Title;
                editModel.Description = model.Description;
                db.SaveChanges();

                return Redirect("/Management/MainPage/Index");
            }
            return View(model);
        }
    }
}
