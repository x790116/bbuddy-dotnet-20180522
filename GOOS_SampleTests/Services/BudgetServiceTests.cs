using System;
using System.Collections.Generic;
using GOOS_Sample.Repositories;
using GOOS_Sample.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GOOS_SampleTests.Services
{
    [TestClass()]
    public class BudgetServiceTests
    {
        private readonly BudgetService _service;

        public BudgetServiceTests()
        {
            this._service = this.GetService();
        }

        [TestMethod()]
        public void FindBudget_20180415_20180515_Returns_620()
        {
            var target = this._service.FindBudget(new DateTime(2018, 04, 15), new DateTime(2018, 05, 15));

            Assert.AreEqual(620, target);
        }

        [TestMethod()]
        public void FindBudget_20180415_20180630_Returns_940()
        {
            var target = this._service.FindBudget(new DateTime(2018, 04, 15), new DateTime(2018, 06, 30));

            Assert.AreEqual(940, target);
        }

        [TestMethod()]
        public void FindBudget_20180520_20180716_Returns_560()
        {
            var target = this._service.FindBudget(new DateTime(2018, 05, 20), new DateTime(2018, 07, 16));

            Assert.AreEqual(560, target);
        }

        [TestMethod()]
        public void FindBudget_20160115_20160213_Returns_260()
        {
            var target = this._service.FindBudget(new DateTime(2016, 01, 15), new DateTime(2016, 02, 13));

            Assert.AreEqual(260, target);
        }

        [TestMethod()]
        public void FindBudget_20160222_20180530_Returns_1360()
        {
            var target = this._service.FindBudget(new DateTime(2016, 02, 22), new DateTime(2018, 05, 30));

            Assert.AreEqual(1360, target);
        }

        [TestMethod()]
        public void FindBudget_20180415_20180415_Returns_20()
        {
            var target = this._service.FindBudget(new DateTime(2018, 04, 15), new DateTime(2018, 04, 15));

            Assert.AreEqual(20, target);
        }

        [TestMethod()]
        public void FindBudget_20180402_20180429_Returns_560()
        {
            var target = this._service.FindBudget(new DateTime(2018, 04, 02), new DateTime(2018, 04, 29));

            Assert.AreEqual(560, target);
        }

        [TestMethod()]
        public void FindBudget_20180101_20180222_Returns_0()
        {
            var target = this._service.FindBudget(new DateTime(2018, 01, 01), new DateTime(2018, 02, 22));

            Assert.AreEqual(0, target);
        }

        private BudgetService GetService()
        {
            var budgetList = new List<Budgets>()
            {
                new Budgets() { YearMonth = "2016-02", Amount = 580 },
                new Budgets() { YearMonth = "2018-04", Amount = 600 },
                new Budgets() { YearMonth = "2018-05", Amount = 620 },
                new Budgets() { YearMonth = "2018-07", Amount = 620 }
            };

            return new BudgetService(budgetList);
        }
    }
}