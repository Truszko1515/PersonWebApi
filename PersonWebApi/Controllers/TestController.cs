using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebApi.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("XDdd");
            return View();

        }
    }
}
