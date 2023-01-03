using DadJokes.Clients;
using DadJokes.Data;
using DadJokes.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DadJokes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJokesRepository _jokesRepository;

        public HomeController(IJokesRepository jokesRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _jokesRepository = jokesRepository;
        }

        public async Task<IActionResult> Index()
        {            
                var result = await _jokesRepository.GetJokesAsync();
                return View(result);
         
        }

        public IActionResult Privacy()
        {
            return View();
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var execeptionHandlerPathFeture = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    ErrorMessage = execeptionHandlerPathFeture?.Error.Message,
                    Source = execeptionHandlerPathFeture?.Error.Source,
                    ErrorPath = execeptionHandlerPathFeture?.Path,
                    StackTrace = execeptionHandlerPathFeture?.Error.StackTrace,
                    InnerException = Convert.ToString(execeptionHandlerPathFeture?.Error.InnerException)
                }
                );

        }
    }
}