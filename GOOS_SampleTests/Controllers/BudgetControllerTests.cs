using System;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests.Controllers
{
    [TestClass]
    public class BudgetControllerTests
    {
        private readonly BudgetController _ctrl;

        public BudgetControllerTests(BudgetController ctrl)
        {
            this._ctrl = ctrl;
        }

        [TestMethod]
        public void Add_Budget_should_Call_Repo_Add()
        {
            BudgetViewModel model = new BudgetViewModel();
            this._ctrl.AddBudget(model);

            var stubBudgetRepo = Substitute.For<IBudgetRepository>();

            stubBudgetRepo.Received().Add();
        }
    }
}
