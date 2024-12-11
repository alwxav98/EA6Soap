using EA6Soap.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EA6Soap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Método para consumir el servicio SOAP
        public async Task<IActionResult> CallSoapService()
        {
            string soapUrl = "http://localhost:80/StudentService.asmx";
            string soapRequestBody = @"<?xml version=""1.0"" encoding=""utf-8""?> 
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://tempuri.org/"">
                <soap:Body>
                    <web:GetStudentInfo>
                        <web:name>Tanya Alexandra Vaca Mena</web:name>
                    </web:GetStudentInfo>
                </soap:Body>
            </soap:Envelope>";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/IStudentService/GetStudentInfo");

                StringContent content = new StringContent(soapRequestBody, Encoding.UTF8, "text/xml");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(soapUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ViewBag.Response = responseBody;
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Response = $"Error: {ex.Message}";
                }
            }

            return View();
        }
    }
}