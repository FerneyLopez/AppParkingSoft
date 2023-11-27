using API_AppParkingSoft.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            await PopulateReservesAsync();
            await PopulateRatesAsync();

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
                    //Id = new Guid("2d5317b9-8750-45f3-0b42-08dbee8f948e"),
                    CategoryName = "Motocicleta"

                });

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    //Id = new Guid("cdb5731f-7255-42ed-99fc-08dbee9d7cd2"),
                    CategoryName = "Carro"
                });

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    //Id = new Guid("0b316524-2595-40b8-99fd-08dbee9d7cd2"),
                    CategoryName = "Ciclomotor",
                });

                _context.CategoryVehicles.Add(new CategoryVehicle
                {
                    //Id = new Guid("bf47106b-0962-4d33-99fe-08dbee9d7cd2"),
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
                    CategoryName = "Motocicleta"

                });

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "ILB-58D",
                    Brand = "Renault",
                    Model = "2023",
                    CategoryName = "Carro"

                });

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "UFI-16F",
                    Brand = "YAMAHA",
                    Model = "2022",
                    CategoryName = "Motocicleta"
                });

                _context.Vehicles.Add(new Vehicle
                {
                    LicensePlate = "WKGSN001428",
                    Brand = "RUNNER",
                    Model = "2015",
                    CategoryName = "Bicicleta"
                });
            }
        }


        private async Task PopulateReservesAsync()
        {
            if (!_context.Reserves.Any())
            {

                _context.Reserves.Add(new Reserve
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    //TotalCost = 4000,
                    activeVehicle = true,
                    LicensePlate = "STD-05D",
                    NameUser = "Ferney Orlando"

                });


                _context.Reserves.Add(new Reserve
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    //TotalCost = 20000,
                    activeVehicle = true,
                    LicensePlate = "ILB-58D",
                    NameUser = "Ferney Orlando"

                });


                _context.Reserves.Add(new Reserve
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    //TotalCost = 9000,
                    activeVehicle = true,
                    LicensePlate = "UFI-16F",
                    NameUser = "Leidy Melissa"

                });


                _context.Reserves.Add(new Reserve
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    //TotalCost = 2000,
                    activeVehicle = false,
                    LicensePlate = "WKGSN001428",
                    NameUser = "Leidy Melissa"

                });

            }
        }


        private async Task PopulateRatesAsync()
        {
            if (!_context.Rates.Any())
            {
                var motocicletaCategory = await _context.CategoryVehicles
                    .FirstOrDefaultAsync(c => c.CategoryName == "Motocicleta");

                var carroCategory = await _context.CategoryVehicles
                    .FirstOrDefaultAsync(c => c.CategoryName == "Carro");

                var ciclomotorCategory = await _context.CategoryVehicles
                    .FirstOrDefaultAsync(c => c.CategoryName == "Ciclomotor");

                var bicicletaCategory = await _context.CategoryVehicles
                    .FirstOrDefaultAsync(c => c.CategoryName == "Bicicleta");

                _context.Rates.Add(new Rate
                {
                    RateName = "Parqueo Motocicleta",
                    hourlyRate = 1000,
                    dailyRate = 3000,
                    weeklyRate = 15000,
                    monthlyRate = 50000,
                    CategoryName = "Motocicleta",
                    idCategoryVehicle = motocicletaCategory.Id
                });

                _context.Rates.Add(new Rate
                {
                    RateName = "Parqueo Carro",
                    hourlyRate = 5000,
                    dailyRate = 10000,
                    weeklyRate = 45000,
                    monthlyRate = 150000,
                    CategoryName = "Carro",
                    idCategoryVehicle = carroCategory.Id

                });

                _context.Rates.Add(new Rate
                {
                    RateName = "Parqueo Ciclo Motor",
                    hourlyRate = 1000,
                    dailyRate = 2000,
                    weeklyRate = 15000,
                    monthlyRate = 45000,
                    CategoryName = "Ciclomotor",
                    idCategoryVehicle = ciclomotorCategory.Id
                });

                _context.Rates.Add(new Rate
                {
                    RateName = "Parqueo Bicicleta",
                    hourlyRate = 500,
                    dailyRate = 1000,
                    weeklyRate = 10000,
                    monthlyRate = 30000,
                    CategoryName = "Bicicleta",
                    idCategoryVehicle = bicicletaCategory.Id
                }); 
            }
        }
        #endregion

    }
}
