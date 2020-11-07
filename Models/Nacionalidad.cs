using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Nacionalidad
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string id_nacionalidad{ get; set; }
        public string nacionalidad { get; set; }
    }
}
