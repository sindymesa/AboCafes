using AboCafes.Common.Entities;
using AboCafes.Common.Enums;
using AboCafes.Web.Data.Entities;
using AboCafes.Web.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }




        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckDepartamentosAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1023932253", "Sindy", "Mesa", "sindymesapo@gmail.com", "3015042069", "Calle 20 11b 60", UserType.Admin);


        }

        private async Task<User> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    Ciudad = _context.Ciudades.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

            }



            return user;


        }







        private async Task CheckDepartamentosAsync()
        {
            if (!_context.Departamentos.Any())
            {
                _context.Departamentos.Add(new Departamento
                {
                    Name = "Tolima",
                    Ciudades = new List<Ciudad>
                {
                    new Ciudad
                    {
                        Name = "Ibagué",

                    },
                    new Ciudad
                    {
                        Name = "Rovira",

                    },
                      new Ciudad
                    {
                        Name = "Fresno",

                    },
                        new Ciudad
                    {
                        Name = "Cajamarca",

                    },
                          new Ciudad
                    {
                        Name = "Planadas",

                    },
                            new Ciudad
                    {
                        Name = "Ataco",

                    },
                              new Ciudad
                    {
                        Name = "Líbano",

                    },
                                new Ciudad
                    {
                        Name = "Herveo",

                    },
                                new Ciudad
                    {
                        Name = "Alvarado",

                    }
                }
                });
                _context.Departamentos.Add(new Departamento
                {
                    Name = "Cundinamarca",
                    Ciudades = new List<Ciudad>
                {
                    new Ciudad
                    {
                        Name = "Chía",

                    }

                    }


                });

                await _context.SaveChangesAsync();

            }

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _context.SaveChangesAsync();

        }




    }


}

