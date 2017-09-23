using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TpsReports.Website.Core.Pages.Reports
{
    public class CreatedModel : PageModel
    {
        [BindProperty]
        public string ReportName { get; set; }

        public void OnGet()
        {
            ReportName = TempData["ReportName"].ToString();
        }
    }
}