using System.ComponentModel.DataAnnotations;

namespace AboCafes.Common.Entities
{
    public class Parafertil
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Detalle { get; set; }
        [Required]
        public int Meses { get; set; }

        [Required]
        public int PalosDesde { get; set; }

        [Required]
        public int PalosHasta { get; set; }


        public int Phdesde { get; set; }


        public int PhHasta { get; set; }

        public int CantidadKN { get; set; }

        public int CantidadKP { get; set; }

        public int CantidadKF { get; set; }

        public int Menores { get; set; }
    }
}
