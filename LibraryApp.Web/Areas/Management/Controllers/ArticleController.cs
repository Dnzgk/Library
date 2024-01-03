using Microsoft.AspNetCore.Mvc;
using LibraryApp.Web.Models;

namespace LibraryApp.Web.Areas.Management.Controllers
{
	[Area("Management")]
	public class ArticleController : Controller
	{
		LibraryContext db = new LibraryContext();
		public IActionResult Index()
		{
			IEnumerable<Article> model = db.Articles.Where(c => c.Status == true).ToList();
			return View(model);
		}

		public IActionResult Details(int id)
		{
			//Article model = db.Articles.FirstOrDefault(c => c.Id == id);
			Article? model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Article model)
		{
			if (ModelState.IsValid)
			{
				model.Status = true;
				model.CreatedDate = DateTime.Now;
				model.UpdatedDate = null;
				db.Articles.Add(model);
				db.SaveChanges();
				return Redirect("/Management/Article/Index");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Article? model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Article model)
		{
			if (ModelState.IsValid)
			{
				Article? editModel = db.Articles.Find(model.Id);
				if (editModel == null)
				{
					return Redirect("/Management/Article/Index");
				}

				editModel.Title = model.Title;
				editModel.Subject = model.Subject;
				editModel.Author = model.Author;
				editModel.UpdatedDate = DateTime.Now;
				editModel.Description = model.Description;
				db.SaveChanges();
				return Redirect("/Management/Article/Index");

			}
			return View(model);
		}

		public IActionResult Delete(int id)
		{
			Article? model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			Article? model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			//soft delete (yazılımda silindi olarak göstermek) için
			model.Status = false;
			db.SaveChanges();

			//dbden tamamen silmek için
			//db.Articles.Remove(model);
			//db.SaveChanges();

			return Redirect("/Management/Article/Index");
		}
	}
}
