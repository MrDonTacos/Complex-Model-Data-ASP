using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Categoria
    {
        [Key]
        public string id_categoria { get; set; }
        public string nom_categoria { get; set; }
    }
}
