# Разработка онлайн-магазина для Lego-машинок
## Диаграмма классов
![image](https://github.com/user-attachments/assets/ac8e3be7-3d5b-49fe-a512-4f3cc058c502)

**Основные классы и их атрибуты:**
· User – базовый класс пользователя с данными для авторизации.
· Collector – расширенный профиль коллекционера с вишлистом и коллекцией.
· LegoCar – модель Lego-машинки с характеристиками (год выпуска, редкость, цена и др.).
· Order и Payment – логика оформления и оплаты заказов.
· Review – отзывы пользователей.

**Связи между классами:**
Агрегация (User → Order, Collector → LegoCar) показывает, что пользователь может создавать заказы и владеть коллекцией.
Наследование (User ← Collector) выделяет расширенные возможности для коллекционеров.
Ассоциации (Order → Payment, LegoCar → Review) отражают зависимость оплаты от заказа и связь отзывов с товарами.

Коллекционер наследует свойства пользователя, добавляя функционал для управления коллекцией.
Каждый заказ включает одну или несколько Lego-машинок и привязан к оплате.


## Диаграмма последовательностей
![Sequence Diagram1](https://github.com/user-attachments/assets/f59e8a2b-8ac9-495a-8778-0a65969b3726)

**Участники (Actors и компоненты):**
Пользователь (User) – инициирует процесс заказа.
Веб-интерфейс (UI) – принимает действия пользователя и передает их системе.
OrderController – управляет логикой создания заказа.
InventoryService – проверяет наличие товаров на складе.
PaymentGateway – обрабатывает платежи.
NotificationService – отправляет уведомления.

**Основные шаги процесса:**
Пользователь добавляет товары в корзину → система создает заказ.
OrderController запрашивает InventoryService для проверки наличия.
После подтверждения система перенаправляет на оплату через PaymentGateway.
После успешной оплаты:
Товары резервируются.
Пользователь получает email-подтверждение через NotificationService.


## Диаграмма вариантов использования
![image](https://github.com/user-attachments/assets/bbc50346-230d-4826-84a3-dd0481ce643d)

**Диаграмма решает:**
Определяет границы системы и ее основные функции
Показывает, какие пользователи (акторы) взаимодействуют с системой
Описывает ключевые сценарии использования (варианты использования)
Служит мостом между бизнес-требованиями и технической реализацией

**Акторы системы**
Гость (неавторизованный пользователь):
Просмотр каталога товаров
Поиск по параметрам (тематика, год выпуска, редкость)
Регистрация в системе

Коллекционер (зарегистрированный пользователь):
Управление коллекцией (учет имеющихся наборов)
Работа с вишлистом (отложенные товары)
Оформление заказов
Написание отзывов
Сравнение цен

Администратор:
Управление ассортиментом (добавление/редактирование товаров)
Модерация отзывов
Просмотр аналитики продаж

**Диаграмма включает:**
Основные функции (Оформить заказ, Управлять коллекцией)
Включенные подпроцессы (Оплатить заказ в рамках оформления)
Дополнительные возможности (Сравнить цены)

**Практическая польза**
Для разных участников проекта диаграмма дает:
Разработчикам - понимание необходимых модулей системы
Тестировщикам - основу для создания тест-кейсов
Аналитикам - ясное видение функциональных требований
Заказчикам - наглядное представление о возможностях системы

**Перспективы развития**
Диаграмма может быть дополнена:
Новыми акторами (например, Поставщик)
Интеграциями с внешними системами
Дополнительными сервисами (программа лояльности, мобильное приложение)



# LEGO Cars Online Store — База данных PostgreSQL

## Структура базы данных

### Таблицы:

- **users** — учётные записи пользователей
- **profiles** — личная информация пользователей (1:1 с users)
- **categories** — категории товаров (например, "Спорткары")
- **products** — товары магазина
- **orders** — заказы пользователей
- **order_items** — товары в заказах
- **tags** — теги товаров (например, "новинка")
- **product_tags** — связь многие-ко-многим: товары ↔ теги

## 🔗 Типы связей:

| Связь                      | Тип       |
|---------------------------|-----------|
| users → profiles          | Один к одному |
| categories → products     | Один ко многим |
| products ↔ tags           | Многие ко многим (через `product_tags`) |
| users → orders            | Один ко многим |
| orders → order_items      | Один ко многим |
| order_items → products    | Многие к одному |

##  Примеры SQL-запросов

```sql
-- Все товары с категориями
SELECT p.name AS product, c.name AS category
FROM products p
JOIN categories c ON p.category_id = c.id;

-- Все заказы с товарами и пользователями
SELECT o.id AS order_id, u.email, p.name AS product, oi.quantity
FROM orders o
JOIN users u ON o.user_id = u.id
JOIN order_items oi ON o.id = oi.order_id
JOIN products p ON oi.product_id = p.id;

-- Все теги товаров
SELECT p.name AS product, t.name AS tag
FROM products p
JOIN product_tags pt ON p.id = pt.product_id
JOIN tags t ON pt.tag_id = t.id;

```
***пример запроса***

![image](https://github.com/user-attachments/assets/2e54cf5c-50c3-440d-9729-d1b28189aca1)



**Как это выглядит**
---
*При добавлении*

![image](https://github.com/user-attachments/assets/983c491b-df46-4fbd-8ce1-37419f323792)

---

*При просмотре всего ассортимента*

![image](https://github.com/user-attachments/assets/67a6874e-5e6c-4c8e-957a-1e520141cc4b)

---

*При удалении*

![image](https://github.com/user-attachments/assets/851e28f6-a71e-4bc3-9943-14033beb3c0b)


# Асинхронность и обработка ошибок

Все операции с БД реализованы асинхронно (async/await), обеспечивая отзывчивость и производительность.

Для всех операций можно использовать try/catch в вызывающем коде (ConsoleUI), чтобы отловить ошибки подключения или некорректных запросов.

*** Пример обработки ошибок в UI***
```
try
{
    await _service.AddCarAsync(name, price);
    Console.WriteLine("Car added successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"Error adding car: {ex.Message}");
}
```

# Бизнес-слой

***Бизнес-логика реализована отдельно от слоя представления и работы с БД, соблюдая принципы инкапсуляции и разделения ответственности.***

LegoCarBase.cs — абстрактный базовый класс, описывающий общие свойства для товаров:

 ```
public abstract class LegoCarBase
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public abstract string GetCategory();
}
```

SportLegoCar.cs, TruckLegoCar.cs — конкретные реализации машинок:
```
public class SportLegoCar : LegoCarBase
{
    public override string GetCategory() => "Спорткар";
}

public class TruckLegoCar : LegoCarBase
{
    public override string GetCategory() => "Грузовик";
}
```

CarLogic.cs — класс бизнес-логики, реализующий валидацию и обработку моделей:

```
public class CarLogic
{
    public bool IsValidPrice(decimal price) => price >= 0 && price < 1000;

    public string FormatDisplay(LegoCarBase car)
    {
        return $"[{car.GetCategory()}] {car.Name} - {car.Price:C}";
    }
}
```

 ##Архитектура
***Архитектура проекта соответствует трёхслойной: ConsoleUI → CarController → CarStoreService*** 
ромежуточный слой — Application/Controllers
Этот слой будет:
-Принимать команды от ConsoleUI,
-Делегировать их в CarStoreService,
-Обрабатывать результат (валидация, объединение данных и др).

Пример: CarController.cs в папке Application/

![image](https://github.com/user-attachments/assets/3a4038ac-cefb-417e-8bf0-27a4e775fbde)














