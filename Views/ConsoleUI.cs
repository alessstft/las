using System.ComponentModel;
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
                Console.WriteLine("2. Поиск по имени");
                Console.WriteLine("3. Добавить новую машинку LEGO");
                Console.WriteLine("4. Удалить машинку");
                Console.WriteLine("6. Заказы пользователей");
                Console.WriteLine("7. Выход");
                Console.Write("Сделайте выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllCars();
                        break;
                    case "2":
                        Console.Write("Название: ");
                        var name = Console.ReadLine();
                        var products = db.Products.Where(p => p.Name.Contains(name!));
                        foreach (var p in products)
                            Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}₽");
                        break;
                    case "3":
                        AddCar();
                        break;
                    case "4":
                        DeleteCar();
                        break;
                    case "5":
                        Category();
                        break;
                    case "6":
                        Console.Write("User ID: ");
                        int uid = int.Parse(Console.ReadLine()!);
                        var orders = db.Orders.Where(o => o.UserId == uid).ToList();
                        foreach (var o in orders)
                        {
                            Console.WriteLine($"Заказ #{o.Id}");
                            var items = db.OrderItems.Where(i => i.OrderId == o.Id).ToList();
                            foreach (var item in items)
                                Console.WriteLine($" - Товар ID: {item.ProductId}, количество: {item.Quantity}");
                        }
                    case "7":
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
