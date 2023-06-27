using Microsoft.AspNetCore.Mvc;

namespace ArtsofteAPI.Controllers;

public class EmployerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}