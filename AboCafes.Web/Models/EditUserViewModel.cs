using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Número de teléfono")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un departamento.")]
        public int DepartamentoId { get; set; }

        public IEnumerable<SelectListItem> Departamentos { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una ciudad.")]
        public int CiudadId { get; set; }

        public IEnumerable<SelectListItem> Ciudades { get; set; }


    }





}



