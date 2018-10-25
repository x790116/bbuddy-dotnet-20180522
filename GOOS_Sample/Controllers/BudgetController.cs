using System;
using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.Services;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetService _service;

        public BudgetController(IBudgetService service)
        {
            this._service = service;
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBudget(BudgetViewModel model)
        {
            this._service.Add(model);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var model = this._service.Get();

            return View(model);
        }
    }
}