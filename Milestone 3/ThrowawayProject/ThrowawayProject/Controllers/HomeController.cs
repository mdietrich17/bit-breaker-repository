using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThrowawayProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(string searchString)
        //{
            //{
            //    IQueryable<StockItem> products = db.StockItems;
            //    ViewBag.Message = "Sorry the athlete that your looking for has not been found";

            //    if (!String.IsNullOrEmpty(searchString))
            //    {
            //        products = products.Where(s => s.StockItemName.Contains(searchString));
            //    }

            //    return View(products.ToList());
            //}
        //}

        // GET: Detail results (uses a ViewModel in Model folder)
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StockItem stockItem = db.StockItems.Find(id);
        //    if (stockItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    StockDetailsViewModel viewModel = new StockDetailsViewModel(stockItem);
        //    return View(viewModel);
        //}

    }
}