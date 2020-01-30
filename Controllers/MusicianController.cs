using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda_Musica.Data.IRepo;
using Tienda_Musica.Models;

namespace Tienda_Musica.Controllers
{   
    [Route("api/Tienda_Musica")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private IMusician _svc;

        public MusicianController(ILogger<HomeController> logger, IMusician svc)
        {
            _logger = logger;
            _svc = svc;
        }
        [HttpPost]
               public async Task<IActionResult> Create(Musician musician)
        {
            try{
                await _svc.Create(musician);
                return Ok();
            }catch(ApplicationException aEx)
            {
                return BadRequest(aEx.Message);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _svc.Delete(id);
                return Ok();
            }catch(ApplicationException aEx)
            {
                return BadRequest(aEx.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Musician musician, int Id)
        {
            try
            {
                await _svc.Update(Id, musician);
                return Ok();
            }catch(ApplicationException aEx)
            {
                return BadRequest(aEx.Message);
            }
        }

        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _svc.GetById(id);
            return Ok(data);
        }
        
         [HttpGet]
         [Route("Genre")]
        public async Task<IActionResult> GetByGenre()
        {
            var data = await _svc.GetGenre();
            return Ok(data);
        }
        
         [HttpGet]
         [Route("Items")]
        public async Task<IActionResult> GetAll(string name, string genre)
        {
            var data = await _svc.GetAll(name, genre);
            return Ok(data);
        }
        
         [HttpGet]
         [Route("Name")]
        public async Task<IActionResult> GetNames(string name)
        {
            var data = await _svc.GetArtists();
            return Ok(data);
        }
        
        

    }
}