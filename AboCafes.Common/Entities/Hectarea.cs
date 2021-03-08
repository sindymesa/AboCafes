using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Hectarea
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Descripcion { get; set; }

        [Required]
        public int Palos { get; set; }

        public DateTime Siembra { get; set; }

        public int Arrobas { get; set; }

        public int CantidadKN { get; set; }

        public int CantidadKP { get; set; }

        public int CantidadKF { get; set; }

        public int Menores { get; set; }

        public decimal Ph { get; set; }

        public Lote Lote { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdLote { get; set; }


    }

}

