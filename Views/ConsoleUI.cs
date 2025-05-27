using LegoCarStoreEF.Services;

namespace LegoCarStoreEF.Views
{
    public class ConsoleUI
    {
        private readonly CarStoreService _service;
        public ConsoleUI(CarStoreService service)
        {
            _service = service;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== LEGO Car Store (EF + PostgreSQL) ===");
                Console.WriteLine("1. View all LEGO cars");
                Console.WriteLine("2. Add a new LEGO car");
                Console.WriteLine("3. Delete a LEGO car");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllCars();
                        break;
                    case "2":
                        AddCar();
                        break;
                    case "3":
                        DeleteCar();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input! Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllCars()
        {
            var cars = _service.GetAllCars();
            Console.WriteLine("\n--- LEGO Cars in Store ---");
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available.");
            }
            else
            {
                foreach (var car in cars)
                    Console.WriteLine($"{car.Id}: {car.Name} - ${car.Price}");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private void AddCar()
        {
            Console.Write("\nEnter car name: ");
            string name = Console.ReadLine();

            Console.Write("Enter car price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price! Press any key...");
                Console.ReadKey();
                return;
            }

            try
            {
                await _service.AddCarAsync(name, price);
                Console.WriteLine("Car added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding car: {ex.Message}");
            }
        }

        private void DeleteCar()
        {
            Console.Write("\nEnter car ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID! Press any key...");
                Console.ReadKey();
                return;
            }

            if (_service.RemoveCar(id))
                Console.WriteLine("Car deleted.");
            else
                Console.WriteLine("Car not found.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}