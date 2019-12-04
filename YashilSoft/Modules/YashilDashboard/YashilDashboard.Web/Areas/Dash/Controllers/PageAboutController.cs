using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
    [Area("Dash")]
    public class PageAboutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            
            return View();
        }
    }
}
