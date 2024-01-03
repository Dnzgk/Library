using Microsoft.AspNetCore.Mvc;
using LibraryApp.Web.Models;
using LibraryApp.Web.Utils;

namespace LibraryApp.Web.Areas.Management.Controllers;

[Area("Management")]
public class AboutController : Controller {
    LibraryContext db = new LibraryContext();
    private readonly IWebHostEnvironment _hostEnvironment;
    public AboutController(IWebHostEnvironment hostEnvironment) {
        _hostEnvironment = hostEnvironment;
    }
    public IActionResult Index() {
        var model = db.Abouts.FirstOrDefault();
        return View(model);
    }


    public IActionResult Edit(int id) {
        var model = db.Abouts.Find(id);
        if (model == null) {
            return Redirect("/Management/About/Index");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(About model, IFormFile img) {
        if (ModelState.IsValid) {
            var editModel = db.Abouts.Find(model.Id);
            if (editModel == null) {
                return Redirect("/Management/About/Index");
            }

            if (img != null) {
                await ImageUploader.DeleteImageAsync(_hostEnvironment, editModel.ImageUrl);
                editModel.ImageUrl = await ImageUploader.UploadImageAsync(_hostEnvironment, img);
            }

            editModel.Title = model.Title;
            editModel.Description = model.Description;
            db.SaveChanges();
            return Redirect("/Management/About/Index");
        }
        return View(model);
    }

}