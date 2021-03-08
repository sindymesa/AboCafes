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
        public string Name { get; set; }

        public ICollection<Finca> Finca { get; set; }

        [DisplayName("FincasNumber")]
        public int FincasNumber => Finca == null ? 0 : Finca.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdCorregimiento { get; set; }
    }

}