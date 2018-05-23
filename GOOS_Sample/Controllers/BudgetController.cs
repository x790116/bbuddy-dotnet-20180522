using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBudget(BudgetViewModel model)
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            BudgetViewModel model = new BudgetViewModel() { };
            model.Month = "2018-05";
            model.Amount = "500";

            return View(model);
        }
    }
}