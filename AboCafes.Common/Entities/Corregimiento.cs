using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Corregimiento
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        public ICollection<Vereda> Veredas { get; set; }

        [DisplayName("Número de Veredas")]
        public int VeredasNumber => Veredas == null ? 0 : Veredas.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdCiudad { get; set; }
    }

}

