using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda_Musica.Models;

namespace Tienda_Musica.Data.IRepo{

    public interface IMusician{

       Task Create(Musician artist);

       Task Delete(int id);

       Task Update(int id, Musician artist);

       Task <Musician> GetById(int id);

       Task <IList<string>> GetArtists();

       Task <IList<string>> GetGenre();

       Task <IList<Musician>> GetAll(string artist, string genre);
    }

}