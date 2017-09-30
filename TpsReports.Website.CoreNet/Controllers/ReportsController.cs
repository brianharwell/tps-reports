using System;
using Microsoft.AspNetCore.Mvc;
using TpsReports.Website.CoreNet.ViewModels;

namespace TpsReports.Website.CoreNet.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Create()
        {
            var createReportViewModel = new CreateReportViewModel();

            createReportViewModel.Name = Guid.NewGuid().ToString();

            return View(createReportViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateReportViewModel createReportViewModel)
        {
            createReportViewModel.Host = Environment.MachineName;
            createReportViewModel.Version = 1;

            TempData["ReportName"] = createReportViewModel.Name;

            GenerateString();

            return RedirectToAction("Created");
        }

        public IActionResult Created()
        {
            @ViewBag.ReportName = TempData["ReportName"];

            return View();
        }

        private void GenerateString()
        {
            string foo = string.Empty;

            for (int iter = 0; iter < 10000; iter++)
            {
                var random = new Random(iter);

                foo = foo + char.ConvertFromUtf32(random.Next(0, 10_175));
            }
        }
    }
}