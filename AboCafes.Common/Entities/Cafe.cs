using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
