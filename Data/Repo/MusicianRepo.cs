using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tienda_Musica.Data.IRepo;
using Tienda_Musica.Models;
using System.Linq;

namespace Tienda_Musica.Data.Repo
{
    public class MusicianRepo : IMusician
    {
        private readonly TiendaMusicaContext _context;

        public MusicianRepo(TiendaMusicaContext context){
            _context = context;
        }

        
        private async Task <bool> Exist (Musician artist){
            return await _context.Musician.AnyAsync(w => w.Name == artist.Name && w.Id != artist.Id);
        } 
        public async Task Create(Musician artist)
        {
            Musician _artist = new Musician (){
                Id = artist.Id,
                Name = artist.Name,
                Genre = artist.Genre,
                ReleaseDate = artist.ReleaseDate,
                Image = artist.Image,
            };
            try
            {
                if(await Exist(artist))
                throw new Exception ("El artista ya existe en la database");
                await _context.Musician.AddAsync(_artist);
                await _context.SaveChangesAsync();
            }catch(Exception aEx)
            {
             throw new ApplicationException("No se pudo crear el perfil del artista en la DB",aEx);
            }
                
        }

        public async Task Delete(int id)
        {
            var _musician = await _context.Musician.FindAsync(id);
            try
            {
                if(_musician==null)
                throw new Exception("No se encontró el músico en la base de datos");

                _context.Musician.Remove(_musician);
                await _context.SaveChangesAsync();
            }catch(Exception aEx)
            {
             throw new ApplicationException("No se pudo Eliminar el artista en la DB",aEx);
            }
        }

        public async Task<IList<Musician>> GetAll(string artist, string genre)
        {
            IList <Musician> selectAll = new List<Musician>();
            var _Musician = from m in _context.Musician
                         select m;

            try{
            if(!string.IsNullOrEmpty(artist))
            {
             _Musician = _Musician.Where(w=>w.Name ==artist);
            }
            if(!string.IsNullOrEmpty(genre))
            {
             _Musician = _Musician.Where(s=>s.Genre == genre);
            }

            var data = await _Musician.ToListAsync();
               selectAll = data.Select(s => new Musician(){
                    Id = s.Id,
                    Name = s.Name,
                    Image = s.Image,
                    ReleaseDate = s.ReleaseDate,
                    Genre = s.Genre,
                    Album = s.Album

               }).ToList();
                }catch(Exception aEx)
                {
                    throw new ApplicationException("Hubo un error al encontrar a los artistas", aEx);
                }
                return selectAll;
        }

        public async Task<IList<string>> GetArtists()
        {
            IList <string> resultAll = new List<string>();
            IQueryable<string> gQuery = null;
            try
            {
            gQuery = _context.Musician.OrderBy(o=>o.Name).Select(s=>s.Name);
            resultAll = await gQuery.Distinct().ToListAsync();
            }catch(Exception aEx)
            {
                throw new ApplicationException("No se encontró ningún artista en la DB", aEx);
            }finally
            {
                gQuery =null;
            }

            return resultAll;
        }

        public async Task<Musician> GetById(int id)
        {
           Musician musician = new Musician();
           try
           {

           var artist = await _context.Musician.FirstOrDefaultAsync(s=>s.Id==id);

           if(artist!=null)
           musician = new Musician(){
                    Id = artist.Id,
                    Name = artist.Name,
                    Image = artist.Image,
                    ReleaseDate = artist.ReleaseDate,
                    Genre = artist.Genre,
                    Album = artist.Album
           };
           }catch(Exception aEx)
           {
               throw new ApplicationException("No se pudo hacer a la DB", aEx);
           }
           return musician;
        }

        public async Task<IList<string>> GetGenre()
        {
             IList <string> resultAll = new List<string>();
            IQueryable<string> gQuery = null;
            try
            {
            gQuery = _context.Musician.OrderBy(o=>o.Genre).Select(s=>s.Genre);
            resultAll = await gQuery.Distinct().ToListAsync();
            }catch(Exception aEx)
            {
                throw new ApplicationException("No se encontró ningún Genero de artista en la DB", aEx);
            }finally
            {
                gQuery =null;
            }

            return resultAll;
        }

        public async Task Update(int id, Musician artist)
        {
            var _artist = await _context.Musician.FirstOrDefaultAsync(w=>w.Id==id);
            try
            {
               if(_artist==null)
               throw new Exception("No se encontró ningún artista");

                _artist.Id = artist.Id;
                _artist.Id = artist.Id;
                _artist.Name = artist.Name;
                _artist.Genre = artist.Genre;
                _artist.ReleaseDate = artist.ReleaseDate;
                _artist.Image = artist.Image;

                _context.Update(_artist);
                await _context.SaveChangesAsync();
            }catch(Exception aEx)
            {
             throw new ApplicationException("No se pudo resubir el artista en la DB",aEx);
            }
        }
    }
}