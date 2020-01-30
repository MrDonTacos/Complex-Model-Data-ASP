using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Tienda_Musica.Models
{
    public class Musician
    {
        public int Id { get ; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Name {get ; set;}

        [Display(Name= "Genero")]
        public string Genre {get;set;}

        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name= "Imagen Perfil")]
        public string Image {get;set;}

        public ICollection<Album> Album {get;set;}
    }

        

}