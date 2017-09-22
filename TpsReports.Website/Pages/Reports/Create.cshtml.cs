using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TpsReports.Website.Pages.Reports
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateReportViewModel CreateReportViewModel { get; set; }

        public string ReportName { get; set; }

        public void OnGet()
        {
            CreateReportViewModel = new CreateReportViewModel();

            CreateReportViewModel.Name = Guid.NewGuid().ToString();
        }

        public IActionResult OnPost(CreateReportViewModel createReportViewModel)
        {
            createReportViewModel.Host = Environment.MachineName;

            TempData["ReportName"] = createReportViewModel.Name;

            GenerateString();

            return RedirectToPage("Created");
        }

        private void GenerateString()
        {
            string foo = string.Empty;

            for (int iter = 0; iter < 1000; iter++)
            {
                var random = new Random(iter);

                foo = foo + char.ConvertFromUtf32(random.Next(0, 10_175));
            }
        }
    }
}