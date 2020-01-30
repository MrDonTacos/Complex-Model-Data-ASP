using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda_Musica.Models;

namespace Tienda_Musica.Data.IRepo{

    public interface IAlbum{

       Task Create(Album album);

       Task Delete(int id);

       Task Update(int id, Album artist);

       Task <Album> GetById(int id);

       Task <IList<string>> GetGenre();

       Task <IList<Album>> GetAll(string album, string genre, string artist);
    }

}