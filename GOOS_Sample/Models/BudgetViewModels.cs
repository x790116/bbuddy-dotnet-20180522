using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace GOOS_Sample.Models
{
    public class BudgetViewModel
    {
        [Required]
        public string Month { get; set; }

        [Required]
        public string Amount { get; set; }
    }    
}