using AboCafes.Common.Entities;
using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboCiudades(int DepartamentoId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            Departamento departamento = _context.Departamentos
                .Include(c => c.Ciudades)
                .FirstOrDefault(c => c.Id == DepartamentoId);
            if (departamento != null)
            {
                list = departamento.Ciudades.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una ciudad...]",
                Value = "0"
            });

            return list;

        }







        public IEnumerable<SelectListItem> GetComboDepartamentos()
        {
            List<SelectListItem> list = _context.Departamentos.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
      .OrderBy(t => t.Text)
      .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un departamento...]",
                Value = "0"
            });

            return list;
        }

        IEnumerable<SelectListItem> ICombosHelper.GetComboCiudades(int DepartamentoId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<SelectListItem> ICombosHelper.GetComboDepartamentos()
        {
            throw new NotImplementedException();
        }
    }


}








