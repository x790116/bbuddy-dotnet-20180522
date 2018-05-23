using System;
using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests.Controllers
{
    [TestClass]
    public class BudgetControllerTests
    {
        [TestMethod]
        public void Add_Budget_should_Call_Service_Add()
        {
            //// Arrange
            var stubBudgetService = Substitute.For<IBudgetService>();
            BudgetViewModel model = new BudgetViewModel();
            BudgetController ctrl = new BudgetController(stubBudgetService);

            //// Act
            ctrl.AddBudget(model);

            //// Assert
            stubBudgetService.Received().Add(model);
        }
    }
}
