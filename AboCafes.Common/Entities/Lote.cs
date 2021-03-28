using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Lote
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        public ICollection<Hectarea> Hectareas { get; set; }

        [DisplayName("Número de Hectáreas")]
        public int HectareasNumber => Hectareas == null ? 0 : Hectareas.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdFinca { get; set; }

        [JsonIgnore]
        public Finca  Finca { get; set; }

    }

}
