using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tienda_Musica.Data.IRepo;
using Tienda_Musica.Models;

namespace Tienda_Musica.Data.Repo{

    public class AlbumRepo : IAlbum
    {
        private readonly TiendaMusicaContext _context;

        public AlbumRepo(TiendaMusicaContext context){
            _context =context;
        }

        public async Task<bool> Exist(Album album){
            return await _context.Album.AnyAsync(e => e.Title == album.Title && e.Id != album.Id);
        }
        public async Task Create(Album album)
        {
            Album alb = new Album(){
                    Id = album.Id,
                    Title = album.Title,
                    Price = album.Price,
                    Image = album.Image,
                    ReleaseDate = album.ReleaseDate,
                    Time = album.Time,
                    Genre = album.Genre,
                    Musician = album.Musician
                };
            try
            {
                if(await Exist(album))
                throw new Exception("Album duplicado");
                await _context.AddAsync(alb);
                await _context.SaveChangesAsync();
                
            }catch(Exception aEx)
            {
                throw new ApplicationException("No se pudo conectar con la base de datos", aEx);
            }
        }

        public async Task Delete(int id)
        {
           var alb = await _context.Album.FindAsync(id);
            try
            {
                if(alb==null)
              throw new Exception("No existe la película en el catalogo");
              
              _context.Remove(alb);
              await _context.SaveChangesAsync();
            }catch(Exception aEx)
            {
                throw new ApplicationException("No se pudo acceder a la DB", aEx);
            }
        }

        public async Task<IList<Album>> GetAll(string album, string genre, string artist)
        {
            IList <Album> resultAll = new List<Album>();
           var _alb = from m in _context.Album
                         select m;
            try
            {
                if(!string.IsNullOrEmpty(album))
               _alb = _alb.Where(w => w.Title == album);
               if(!string.IsNullOrEmpty(genre))
               _alb = _alb.Where(n => n.Genre == genre);
               if(!string.IsNullOrEmpty(artist))
               _alb = _alb.Where(a => a.Musician.Name == artist);
               
               var data = await _alb.ToListAsync();
               resultAll = data.Select(s => new Album(){
                    Id = s.Id,
                    Title = s.Title,
                    Price = s.Price,
                    Image = s.Image,
                    ReleaseDate = s.ReleaseDate,
                    Time = s.Time,
                    Genre = s.Genre,
                    Musician = s.Musician

               }).ToList();

            }catch(Exception aEx)
            {
                throw new ApplicationException("Error al consultar los datos en la DB", aEx);
            }
            return resultAll;
        }

        

        public async Task<Album> GetById(int id)
        {
            var alb = new Album();
            try
            {
                var _alb = await _context.Album.FirstOrDefaultAsync(s => s.Id == id);
                if(_alb!=null)
                alb = new Album(){
                    Id = _alb.Id,
                    Title = _alb.Title,
                    Price = _alb.Price,
                    Image = _alb.Image,
                    ReleaseDate = _alb.ReleaseDate,
                    Time = _alb.Time,
                    Genre = _alb.Genre,
                    Musician = _alb.Musician
                    
                };
            }catch(Exception aEx)
            {
                throw new ApplicationException("Error encontrando ID en la DB", aEx);
            }
            return alb;
        }

        public async Task<IList<string>> GetGenre()
        {

           IList <string> resultGenre = new List<string>(); 
           IQueryable<string>  gQuery = null;
            try{
           gQuery = _context.Album.OrderBy(o => o.Genre).Select(s => s.Genre);
           resultGenre = await gQuery.Distinct().ToListAsync();
            }catch(Exception aEx)
            {
                throw new ApplicationException("Error obteniendo los generos de la DB", aEx);
            }
            finally{
                gQuery = null;
            }
            return resultGenre;
        }

        public async Task Update(int id, Album album)
        {
            var _album = await _context.Album.FirstOrDefaultAsync(w => w.Id ==id);

           try
            {
            if (_album == null)
            throw new Exception("No existe el album");

                _album.Id = album.Id;
                _album.Title = album.Title;
                _album.Price = album.Price;
                _album.Image = album.Image;
                _album.ReleaseDate = album.ReleaseDate;
                _album.Time = album.Time;
                _album.Genre = album.Genre;
                _album.Musician = album.Musician;

                _context.Update(_album);
                await _context.SaveChangesAsync();
            }catch(Exception aEx)
            {
                throw new ApplicationException("No se pudo conectar a la DB", aEx);
            }
        }
    }
}