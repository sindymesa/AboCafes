using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AboCafes.Common.Entities
{
    public class Finca
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        public int TerceroId { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        public Tercero Tercero { get; set; }

        public ICollection<Lote> Lotes { get; set; }

        [DisplayName("Lotes Number")]
        public int LotesNumber => Lotes == null ? 0 : Lotes.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdVereda { get; set; }


        [JsonIgnore]
        public Vereda Vereda { get; set; }



    }

}
