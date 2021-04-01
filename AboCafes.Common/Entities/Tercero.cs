using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AboCafes.Common.Entities
{


    public class Tercero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "El campo debe contener menos de 15 caracteres")]
        public string Documento { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "El campo debe contener menos de 40 caracteres")]
        public string Nombre { get; set; }


        [MaxLength(50, ErrorMessage = "El campo debe contener menos de 50 caracteres")]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [MaxLength(20, ErrorMessage = "El campo debe contener menos de 20 caracteres")]
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [MaxLength(50, ErrorMessage = "El campo debe contener menos de 50 caracteres")]
        public string Email { get; set; }

        public int CiudadId { get; set; }

        public Ciudad Ciudad { get; set; }




    }
}
