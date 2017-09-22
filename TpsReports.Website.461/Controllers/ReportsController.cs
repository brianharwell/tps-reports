using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpsReports.Website._461.ViewModels;

namespace TpsReports.Website._461.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Create()
        {
            var createReportViewModel = new CreateReportViewModel();

            createReportViewModel.Name = Guid.NewGuid().ToString();

            return View(createReportViewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateReportViewModel createReportViewModel)
        {
            createReportViewModel.Host = Environment.MachineName;

            TempData["ReportName"] = createReportViewModel.Name;

            GenerateString();

            return RedirectToAction("Created");
        }

        public ActionResult Created()
        {
            @ViewBag.ReportName = TempData["ReportName"];

            return View();
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