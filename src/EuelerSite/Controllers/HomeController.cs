using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Contract;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace EuelerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<IProblemTest> _problems;
        private string _gitUrl;

        public HomeController(
            IEnumerable<IProblemTest> problems, IOptions<AppSettings> appSettings)
        {
            _problems = problems;
            _gitUrl = appSettings.Value.GitApiUrl;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ExecuteProblem(string problemId)
        {
            var problem = _problems.First(p => p.FileName == problemId);
            return new JsonResult(problem.Execute());
        }

        public JsonResult ViewCode(string fileName)
        {
            //HttpWebRequest test = new HttpWebRequest();
            using (var client = new HttpClient())
            {
                var url = _gitUrl + fileName;
                //client.BaseAddress = new Uri(url);
                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent",
                                 "EulerTestSite");
                var response = client.GetAsync(url);
                if (response.Result.IsSuccessStatusCode)
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    var test = JObject.Parse(result.Result);
                    var base64Content = test["content"].ToString();
                    byte[] data = Convert.FromBase64String(base64Content);
                    string decodedString = Encoding.UTF8.GetString(data);
                    return new JsonResult("<PRE>" + decodedString.Replace("\t", "  ") + "</PRE>");
                    
                    //do something with the response here. Typically use JSON.net to deserialise it and work with it
                }
                throw new InvalidOperationException("Failed to retrieve git data");
            }
        }

        public IActionResult Problems()
        {
            return View(_problems);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
