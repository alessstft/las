using LegoCarStoreEF.Application;

namespace LegoCarStoreEF.Views
{
    public class ConsoleUI
    {
        private readonly CarStoreController _controller;

        public ConsoleUI(CarStoreController controller)
        {
            _controller = controller;
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
                Console.WriteLine("4. Посмотреть машинки");
                Console.WriteLine("5. Посмотреть пользователей");
                Console.WriteLine("6. Посмотреть категории");
                Console.WriteLine("7. Посмотреть теги");
                Console.WriteLine("8. Посмотреть заказы");
                Console.WriteLine("9. Выход");
                Console.Write("Сделайте выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllCars().Wait();
                        break;
                    case "2":
                        AddCar().Wait();
                        break;
                    case "3":
                        DeleteCar().Wait();
                        break;
                    case "4":
                        ShowAllProducts().Wait();
                        break;
                    case "5":
                        ShowAllUsers().Wait();
                        break;
                    case "6":
                        ShowCategories().Wait();
                        break;
                    case "7":
                        ShowTags().Wait();
                        break;
                    case "8":
                        ShowOrders().Wait();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод! Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task ShowAllUsers()
        {
            var users = await _controller.GetAllUsersAsync();
            Console.WriteLine("\n--- Пользователи ---");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Email: {user.Email}");
                if (user.Profile != null)
                    Console.WriteLine($"    Имя: {user.Profile.FullName}, Адрес: {user.Profile.Address}");
            }
            Console.ReadKey();
        }

        private async Task ShowCategories()
        {
            var categories = await _controller.GetAllCategoriesAsync();
            Console.WriteLine("\n--- Категории ---");
            foreach (var cat in categories)
                Console.WriteLine($"{cat.Id}: {cat.Name}");
            Console.ReadKey();
        }

        private async Task ShowTags()
        {
            var tags = await _controller.GetAllTagsAsync();
            Console.WriteLine("\n--- Теги ---");
            foreach (var tag in tags)
                Console.WriteLine($"{tag.Id}: {tag.Name}");
            Console.ReadKey();
        }

        private async Task ShowOrders()
        {
            var users = await _controller.GetAllUsersAsync();
            foreach (var user in users)
            {
                var orders = await _controller.GetOrdersByUserAsync(user.Id);
                Console.WriteLine($"\nЗаказы пользователя {user.Email}:");
                foreach (var order in orders)
                {
                    Console.WriteLine($"  Заказ #{order.Id} от {order.OrderDate}");
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine($"    - {item.Product?.Name} x{item.Quantity} = {item.Price}₽");
                    }
                }
            }
            Console.ReadKey();
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
