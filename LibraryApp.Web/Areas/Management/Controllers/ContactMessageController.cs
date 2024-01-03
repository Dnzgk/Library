using Microsoft.AspNetCore.Mvc;
using LibraryApp.Web.Models;

namespace LibraryApp.Web.Areas.Management.Controllers;

[Area("Management")]
public class ContactMessageController : Controller
{
    LibraryContext db = new LibraryContext();
    public IActionResult Index()
    {
        IEnumerable<ContactMessage> model = db.ContactMessages
            .Where(c => c.Status == true)
            .OrderByDescending(o => o.CreatedDate)
            .ToList();

        return View(model);
    }
 

}
