using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tienda_Musica.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required]
        public string Title {get; set;}

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price{get; set;}

        [Display(Name= "Imagen de Album")]
        public string Image {get;set;}

        [Display(Name = "Fecha de lanzamiento")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Duracion del album")]
        public string Time {get; set;}

        [Display(Name = "Genero")]
        public string Genre {get; set;}

        public int MusicianRefId {get;set;}
        
        [ForeignKey("MusicianRefId")]
        public Musician Musician{get;set;}
    }

}