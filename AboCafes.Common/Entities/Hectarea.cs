using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AboCafes.Common.Entities
{
    public class Hectarea
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Required]
        public int Palos { get; set; }

        public DateTime Siembra { get; set; }

        public int Altitud { get; set; }

        public int Distancia { get; set; }

        public float Sombrio { get; set; }

        public int Arrobas { get; set; }

        [DisplayName("Nitrógeno (kg)")]
        public int CantidadKN { get; set; }

        [DisplayName("Potasio (kg)")]
        public int CantidadKP { get; set; }

        [DisplayName("Fósforo (kg)")]
        public int CantidadKF { get; set; }

        public int Menores { get; set; }

        public decimal Ph { get; set; }


        public Cafe Cafe { get; set; }

        [DisplayName("Variedad")]
        public int CafeId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdLote { get; set; }


        [JsonIgnore]
        public Lote Lote { get; set; }



    }

}

