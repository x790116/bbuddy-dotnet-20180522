using System;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests
{
    [Binding]
    public class BudgetSteps:FluentTest
    {
        [BeforeFeature()]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [When(@"add a Budget With month ""(.*)"" and amount (.*)")]
        public void WhenAddABudgetWithMonthAndAmount(string month, int amount)
        {
            I.Open("http://localhost:58527/budget/add")
                .Enter(month).In("#month")
                .Enter(amount).In("#amount")
                .Click("#save");
        }
        
        [Then(@"the following Budget will be added")]
        public void ThenTheFollowingBudgetWillBeAdded(Table table)
        {
        }
    }
}
