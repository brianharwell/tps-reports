using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TpsReports.Website.Pages.Reports
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