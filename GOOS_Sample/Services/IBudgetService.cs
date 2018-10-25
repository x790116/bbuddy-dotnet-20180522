using GOOS_Sample.Models;

namespace GOOS_Sample.Services
{
    public interface IBudgetService
    {
        void Add(BudgetViewModel model);

        BudgetViewModel Get();
    }
}
