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
        [TestMethod]
        public void Add_Budget_should_Call_Repo_Add()
        {
            //// Arrange
            var stubBudgetRepo = Substitute.For<IBudgetRepository>();
            BudgetViewModel model = new BudgetViewModel();
            BudgetController ctrl = new BudgetController(stubBudgetRepo);

            //// Act
            ctrl.AddBudget(model);

            //// Assert
            stubBudgetRepo.Received().Add(model);
        }
    }
}
