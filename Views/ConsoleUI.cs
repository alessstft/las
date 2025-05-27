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
                Console.WriteLine("=== Магазин LEGO машинок ===");
                Console.WriteLine("1. Посмотреть все LEGO машинки");
                Console.WriteLine("2. Добавить новую машинку LEGO");
                Console.WriteLine("3. Удалить машинку");
                Console.WriteLine("4. Выход");
                Console.Write("Сделайте выбор: ");

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
                        Console.WriteLine("Неверный ввод! Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllCars()
        {
            var cars = _service.GetAllCars();
            Console.WriteLine("\n--- LEGO машинки в магазине ---");
            if (cars.Count == 0)
            {
                Console.WriteLine("Машин в наличии нет :(");
            }
            else
            {
                foreach (var car in cars)
                    Console.WriteLine($"{car.Id}: {car.Name} - ${car.Price}");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        private void AddCar()
        {
            Console.Write("\nВведите название машинки: ");
            string name = Console.ReadLine();

            Console.Write("Ведите цену машинки: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Неверная цена! Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            try
            {
                await _service.AddCarAsync(name, price);
                Console.WriteLine("Автомобиль успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка добавления автомобиля: {ex.Message}");
            }
        }

        private void DeleteCar()
        {
            Console.Write("\nВведите идентификатор автомобиля для удаления(какой по счету была добавлена машинка): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный идентификатор! Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            if (_service.RemoveCar(id))
                Console.WriteLine("Успешно удалено!");
            else
                Console.WriteLine("Машинка не найдена, попробуйте другую. У вас получится найти нужную!!!");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
