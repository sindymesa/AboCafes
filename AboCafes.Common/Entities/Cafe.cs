using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AboCafes.Common.Entities
{
   
    public class Cafe
    {
        [Key]
        public int Id { get; set; }

 
        [Required]
        [MaxLength(50, ErrorMessage = "El campo debe contener menos de 50 caracteres")]
        public string Variedad { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo debe contener menos de 50 caracteres")]
        public string Detalle { get; set; }


        public ICollection<Hectarea> Hectareas { get; set; }



    }
}
