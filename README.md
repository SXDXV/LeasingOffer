# LeasingOffer

## Описание

Проект представляет собой Web API и web-интерфейс для управления офферами и поставщиками. Реализованы как backend, так и frontend части.

### Backend

Реализован на ASP.NET Core Web API (.NET 8.0) с использованием Entity Framework Core и MS SQL (DB first).

Реализованные методы:
1. Получение всех офферов (условный поиск по пустым параметрам);
2. Поиск офферов по полям: марка, модель, поставщик (частичное совпадение по строкам);
3. Создание оффера;
4. Получение топ-3 поставщиков с наибольшим количеством офферов.

Реализована сервисная и интерфейсная логика для соблюдения принципов SOLID.

---

### Frontend

Фронтенд написан на Angular с использованием standalone-компонентов. Для хранения состояния и управления загрузкой используются signals.

Реализовано три основных раздела:
1. **Популярные поставщики**
   - Отображение 3 поставщиков с наибольшим количеством офферов;
   - Карточки в едином визуальном стиле.
2. **Поиск**
   - Форма с полями: Марка, Модель, Поставщик;
   - Результаты отображаются в виде карточек;
   - Поддерживается сброс фильтра.
3. **Список всех офферов**
   - Вывод всех доступных офферов;
   - Унифицированное оформление карточек.

Интерфейс выполнен в адаптивной сетке. При наведении на карточку реализован эффект сужения с сохранением фиксированного правого края.

---

### Запуск проекта

Клонируйте репозиторий:

```
git clone https://github.com/SXDXV/LeasingOffer
cd leasing-offer
```

Запустите backend (ASP.NET Core Web API):

```
cd LeasingOfferBack
dotnet run
```

Запустите frontend (Angular):

```
cd ../LeasingOfferFront
npm install
ng serve (или npm run dev)
```

Необходимо убедиться, что локальное приложение (бэк + фронт) запускается на корректных портах для взаимосвязи.

---

### Возможные доработки

- Реализовать выпадающие списки (autocomplete) для поиска по поставщикам, марке и модели;
- Провести реорганизацию фронтенд-структуры и разбить по более узким модулям;
- Добавить поддержку локализации;
- Добавить возможность создания офферов на фронте.

---

### Синхронизация моделей с базой данных (Использовать Package Manager Console)

```
dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=TestOffersDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -c AppDbContext --context-dir Data --use-database-names
```

---

### SQL-скрипт для автоматического создания базы, таблиц, полей, содержимого

```
CREATE DATABASE TestOffersDB;
GO

USE TestOffersDB;
GO

CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Offers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Brand NVARCHAR(100) NOT NULL,
    Model NVARCHAR(100) NOT NULL,
    SupplierId INT NOT NULL,
    RegisteredAt DATETIME NOT NULL,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
);

INSERT INTO Suppliers (Name, CreatedAt)
VALUES 
(N'Поставщик Зеленый', '2025-07-14 09:00:00'),
(N'Поставщик Южный', '2025-07-15 10:30:00'),
(N'Поставщик Надежный', '2025-07-16 11:45:00'),
(N'Поставщик Из Кореи', '2025-07-17 14:20:00'),
(N'Поставщик Приколов', '2025-07-18 16:10:00');

INSERT INTO Offers (Brand, Model, SupplierId, RegisteredAt)
VALUES
('Chery', 'Tiggo 7 Pro', 1, '2025-07-21 09:10:00'),
('Mazda', 'CX-5', 1, '2025-07-21 15:45:00'),
('Geely', 'Coolray', 1, '2025-07-22 10:00:00'),
('Volkswagen', 'Polo', 2, '2025-07-22 17:20:00'),
('BYD', 'Song Plus', 2, '2025-07-23 08:50:00'),
('Ford', 'Kuga', 2, '2025-07-23 14:10:00'),
('Exeed', 'TXL', 3, '2025-07-24 09:30:00'),
('Hyundai', 'Tucson', 3, '2025-07-24 16:00:00'),
('Audi', 'Q3', 3, '2025-07-25 11:15:00'),
('BMW', 'iX1', 3, '2025-07-25 18:40:00'),
('Nissan', 'X-Trail', 4, '2025-07-26 09:25:00'),
('Haval', 'Jolion', 4, '2025-07-26 13:55:00'),
('Kia', 'Sportage', 5, '2025-07-27 08:10:00'),
('Toyota', 'RAV4', 5, '2025-07-27 12:30:00'),
('Lexus', 'UX 250h', 5, '2025-07-27 17:45:00'),

('Chery', 'Arrizo 5 Plus', 2, '2025-07-27 18:30:00'),
('Toyota', 'Camry', 1, '2025-07-27 18:45:00'),
('Mazda', '3', 3, '2025-07-27 19:00:00'),
('BYD', 'Atto 3', 4, '2025-07-27 19:15:00');
```
