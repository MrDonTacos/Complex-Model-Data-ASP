using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tienda_Musica.Data.IRepo;
using Tienda_Musica.Models;
using System.Diagnostics;

namespace Tienda_Musica.Controllers
{
    public class MusiciansController : Controller
    
    {
        private readonly ILogger <MusiciansController> _logger;
        private IMusician _svc;
        public MusiciansController(ILogger <MusiciansController> logger, IMusician svc){
            _logger = logger;
            _svc = svc;
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create ([Bind("Id", "Name", "Genre", "ReleaseDate", "Image")] Musician musician)
        {
            try
            {
            await _svc.Create(musician);
            return RedirectToAction(nameof(Index));
            }catch(ApplicationException aEx){
               return BadRequest(aEx.Message);
            }
        }


    }
}

