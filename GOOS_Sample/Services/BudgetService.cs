using System;
using System.Collections.Generic;
using System.Linq;
using GOOS_Sample.Models;
using GOOS_Sample.Repositories;

namespace GOOS_Sample.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly List<Budgets> _totalBudgets;

        public BudgetService(List<Budgets> budgetList)
        {
            _totalBudgets = budgetList;
        }

        public int FindBudget(DateTime startDateTime, DateTime endDateTime)
        {
            var budgetResult = 0;

            if (GetYearMonth(startDateTime) == GetYearMonth(endDateTime))
            {
                var amountPerDay = GetAmountPerDay(startDateTime);
                var dayDiff = (decimal)((endDateTime - startDateTime).TotalDays + 1);

                budgetResult = (int)(amountPerDay * dayDiff);
            }
            else
            {
                var startAmountPerDay = GetAmountPerDay(startDateTime);
                var endAmountPerDay = GetAmountPerDay(endDateTime);
                var startResult = startAmountPerDay * (DateTime.DaysInMonth(startDateTime.Year, startDateTime.Month) - startDateTime.Day + 1);
                var endResult = endAmountPerDay * endDateTime.Day;
                var periodResult = GetPeriodResult(startDateTime, endDateTime);

                budgetResult = (int)(startResult + endResult + periodResult);
            }

            return budgetResult;
        }

        private decimal GetPeriodResult(DateTime startDateTime, DateTime endDateTime)
        {
            var startYear = startDateTime.AddMonths(1).Year;
            var startMonth = startDateTime.AddMonths(1).Month;
            var endYear = endDateTime.AddMonths(-1).Year;
            var endMonth = endDateTime.AddMonths(-1).Month;
            decimal result = 0;

            for (int i = startYear; i <= endYear; i++)
            {
                for (int j = startMonth; j <= endMonth; j++)
                {
                    result += _totalBudgets
                        .Where(x => x.YearMonth == i.ToString() + "-" + j.ToString("00")).Sum(y => y.Amount);
                }
            }

            return result;
        }

        private decimal GetAmountPerDay(DateTime dateTime)
        {
            var yearMonthBudget =
                _totalBudgets.Where(i => i.YearMonth == GetYearMonth(dateTime)).Sum(x => x.Amount);
            var amountPerDay = yearMonthBudget / DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return amountPerDay;
        }

        private string GetYearMonth(DateTime dateTime)
        {
            return dateTime.Year.ToString() + "-" + dateTime.Month.ToString("00");
        }

        public void Add(BudgetViewModel model)
        {
        }

        public BudgetViewModel Get()
        {
            return new BudgetViewModel() { };
        }
    }
}
