using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using TpsReports.Website.Core.ViewModels;

namespace TpsReports.Website.Core.Pages.Reports
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
            createReportViewModel.Version = 1;

            TempData["ReportName"] = createReportViewModel.Name;

            GenerateString();

            Publish(createReportViewModel);

            return RedirectToPage("Created");
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

        public void Publish(CreateReportViewModel createReportViewModel)
        {
            var connectionFactory = new ConnectionFactory() { HostName = "bugs", UserName = "guest", Password = "guest" };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    model.QueueDeclare(queue: "core", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(createReportViewModel);
                    var body = Encoding.UTF8.GetBytes(json);

                    model.BasicPublish(exchange: string.Empty, routingKey: "core", mandatory: false, basicProperties: null, body: body);
                }
            }
        }
    }
}