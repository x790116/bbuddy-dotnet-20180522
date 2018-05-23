using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.Repositories;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository _repository;

        public BudgetController(IBudgetRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBudget(BudgetViewModel model)
        {
            this._repository.Add(model);

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