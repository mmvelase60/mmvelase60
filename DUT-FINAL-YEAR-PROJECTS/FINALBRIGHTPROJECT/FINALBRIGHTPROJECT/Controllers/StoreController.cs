using FINALBRIGHTPROJECT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class StoreController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            var categories = db.categories.ToList();

            return View(categories);
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.categories.ToList();
            return PartialView(categories);

        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Browse(string category)
        {
            var categoryModel = db.Items.Where(x => x.Categories.CatName == category).ToList();
            return View(categoryModel);
        }
        public ActionResult Details(int id)
        {
            var Item = db.Items.Find(id);
            return View(Item);
        }

    }
}