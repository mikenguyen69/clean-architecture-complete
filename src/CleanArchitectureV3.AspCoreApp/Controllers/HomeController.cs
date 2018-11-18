using CleanArchitectureV3.AspCoreApp.ViewModels.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureV3.AspCoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(TasksIndexViewModelQuery query)
        {
            return RedirectToAction("Index", "Tasks");
        }
    }
}
