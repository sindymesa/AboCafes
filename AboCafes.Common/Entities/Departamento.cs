using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AboCafes.Common.Entities
{
    public class Departamento
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo debe contener menos de 50 caracteres")]
        [DisplayName("Nombre")]
        public String Name { get; set; }

        public ICollection<Ciudad> Ciudades { get; set; }

        [DisplayName("Número de Ciudades")]
        public int CiudadesNumber => Ciudades == null ? 0 : Ciudades.Count;

    }
}
