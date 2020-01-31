using System;
using Tienda_Musica.Data.Repo;
using Tienda_Musica.Data.IRepo;
using Tienda_Musica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Tienda_Musica.Controllers
{
    [Route("api/Albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        
        private readonly ILogger <AlbumController> _logger;
        private IAlbum _svc;
        public AlbumController (ILogger <AlbumController> logger, IAlbum svc)
        {
            _logger = logger;
            _svc = svc;
        }

        [HttpPost]
        public async Task <IActionResult> Create (Album album)
        {
            try
            {
            await _svc.Create(album);
            return Ok();
            }catch(ApplicationException aEx)
            {
                return BadRequest(aEx.Message);
            }
        }
        [HttpGet]
        [Route("Id")]
        public async Task <IActionResult> GetById(int id){
            try
            {
                var data = await _svc.GetById(id);
                return Ok(data);
            }catch(ApplicationException aEx){
            return BadRequest(aEx.Message);
            }
        }
    }
}