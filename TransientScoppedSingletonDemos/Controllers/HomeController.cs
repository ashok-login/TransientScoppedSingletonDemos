using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransientScoppedSingletonDemos.Models;

namespace TransientScoppedSingletonDemos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transient1;
        private readonly ITransientService _transient2;
        private readonly IScoppedService _scopped1;
        private readonly IScoppedService _scopped2;
        private readonly ISingletonService _singleton1;
        private readonly ISingletonService _singleton2;

        public HomeController(ILogger<HomeController> logger, ITransientService transient1, ITransientService transient2,
                                IScoppedService scopped1, IScoppedService scopped2,
                                ISingletonService singleton1, ISingletonService singleton2)
        {
            _logger = logger;
            _transient1 = transient1;
            _transient2 = transient2;
            _scopped1 = scopped1;
            _scopped2 = scopped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        public IActionResult Index()
        {
            ViewBag.Transient1 = _transient1.GetOperationId();
            ViewBag.Transient2 = _transient2.GetOperationId();

            ViewBag.Scopped1  = _scopped1.GetOperationId();
            ViewBag.Scopped2  = _scopped2.GetOperationId();

            ViewBag.Singleton1 = _singleton1.GetOperationId();
            ViewBag.Singleton2 = _singleton2.GetOperationId();
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
    }
}