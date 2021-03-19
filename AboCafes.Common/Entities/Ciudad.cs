using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Ciudad
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo debe contener menos de 50 caracteres")]
        [DisplayName("Nombre")]
        public String Name { get; set; }

        public ICollection<Corregimiento> Corregimientos { get; set; }

        [DisplayName("Número de corregimientos")]
        public int CorregimientosNumber => Corregimientos == null ? 0 : Corregimientos.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdDepartamento { get; set; }


    }
}
