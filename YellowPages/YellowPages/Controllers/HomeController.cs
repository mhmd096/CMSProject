using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YellowPagesDB;
namespace YellowPages.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /*public ActionResult SearchbyUnit(string name)
        {
            IEnumerable<Unit> units = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50194/api/");
                var responseTask = client.GetAsync("Units?name=" + name);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Unit>>();
                    readTask.Wait();
                    units = readTask.Result;
                }
                else
                {
                    units = Enumerable.Empty<Unit>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
                return View(units);
            }
        }*/
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}