using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Vereda
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        public ICollection<Finca> Fincas { get; set; }

        [DisplayName("Número de Fincas")]
        public int FincasNumber => Fincas == null ? 0 : Fincas.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdCorregimiento { get; set; }

        [JsonIgnore]
        public Corregimiento Corregimiento { get; set; }

    }

}