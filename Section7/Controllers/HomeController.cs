using Microsoft.AspNetCore.Mvc;
using Section7.Models;

namespace Section7.Controllers;
public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return Content("<h1>Welcome to the Section 7 - Person Area.</h1>", "text/html");
    }

    [Route("register")]
    public IActionResult Index(Person person)
    {
        if (!ModelState.IsValid)
        {
            string errors = string.Join("\n",
            ModelState.Values.SelectMany(value => value.Errors).Select(err =>
            err.ErrorMessage));

            return BadRequest(errors);
        }

        return Content($"{person}");
    }
}
