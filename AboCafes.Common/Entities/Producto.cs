using System.ComponentModel.DataAnnotations;

namespace AboCafes.Common.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Detalle { get; set; }


        public int CantidadKN { get; set; }

        public int CantidadKP { get; set; }

        public int CantidadKF { get; set; }

        public int Menores { get; set; }
    }
}