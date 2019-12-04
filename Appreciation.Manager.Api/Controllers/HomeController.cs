using Appreciation.Manager.Services.Contracts;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Appreciation.Manager.Api.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IStudentService service)
        {
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
