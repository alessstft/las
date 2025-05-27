# LEGO Car Store (EF + PostgreSQL)

Консольное приложение для управления онлайн-магазином LEGO-машинок с использованием базы данных PostgreSQL через Entity Framework Core.

## 📦 Команды

1. **Просмотр всех LEGO-машинок**
2. **Добавление новой машинки**
3. **Удаление машинки**
4. **Выход**

## ⚙️ Настройка подключения к PostgreSQL

Файл `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=legocarstore;Username=postgres;Password=yourpassword"
  }
}
```

## 🛠 Миграции и запуск

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```