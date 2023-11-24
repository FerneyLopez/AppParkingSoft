using API_AppParkingSoft.DAL.Entities;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace API_AppParkingSoft.DAL
{
    public class SeederDB
    {
        
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {

            await _context.Database.EnsureCreatedAsync();


            await PopulateUsersAsync(); 
            await PopulateCategoryVehiclesAsync();
            await PopulateVehiclesAsync();

            await _context.SaveChangesAsync(); 
        }

        #region Private Methos
        private async Task PopulateUsersAsync()
        {
            if (!_context.Users.Any())
            {

                _context.Users.Add(new User
                {
                    idUser = "1152700974",
                    Name = "Ferney Orlando",
                    LastName = "López Copete",
                    Email = "ferneylopez111213@gmail.com",
                    Password = "123456789*"

                });

                _context.Users.Add(new User
                {
                    idUser = "1152666999",
                    Name = "Leidy Melissa",
                    LastName = "Trejos Pamplona",
                    Email = "leidytrejos11@gmail.com",
                    Password = "Polola14$"

                });

                _context.Users.Add(new User
                {
                    idUser = "123",
                    Name = "Admin",
                    LastName = " ",
                    Email = "admin@gmail.com",
                    Password = "Admin2023*&"

                });

                _context.Users.Add(new User
                {
                    idUser = "1111111",
                    Name = "Pepe",
                    LastName = "Godinez",
                    Email = "ppegodinez@gmail.com",
                    Password = "147258963"

                });
            }
        }


        private async Task PopulateCategoryVehiclesAsync()
        {
            if (!_context.CategoryVehicles.Any())
            {

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    CategoryName = "Motocicleta",
                    


                });

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    CategoryName = "Carro",


                });

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    CategoryName = "Ciclomotor",


                });

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    CategoryName = "Bicicleta",

                });
            }
        }


        private async Task PopulateVehiclesAsync()
        {
            if (!_context.Vehicles.Any())
            {

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "STD-05D",
                    Brand = "AKT",
                    Model = "2015",
                    
                });

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "ILB-58D",
                    Brand = "Renault",
                    Model = "2023",
                });

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "UFI-16F",
                    Brand = "YAMAHA",
                    Model = "2022",
                });

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "WKGSN001428",
                    Brand = "RUNNER",
                    Model = "2015",
                });
            }
        }
        #endregion
    }
}
