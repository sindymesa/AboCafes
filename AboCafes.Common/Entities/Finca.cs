using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Finca
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        [Required]
        [StringLength(40)]
        public string TerceroId { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        public Tercero Terceros { get; set; }


        public ICollection<Lote> Lotes { get; set; }

        [DisplayName("Lotes Number")]
        public int LotesNumber => Lotes == null ? 0 : Lotes.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdVereda { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdTercero { get; set; }
    }

}
