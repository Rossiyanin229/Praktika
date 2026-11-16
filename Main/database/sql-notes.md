# SQL notes
> Учебная БД: PracticeDB. Скрипт создания — `init.sql`.
> Все запросы выполнялись в SSMS.

## Task 01 — Создание базы данных и таблиц
### SQL

```sql
-- Выполнен скрипт init.sql (Приложение А)
-- Создание базы данных
CREATE DATABASE PracticeDB;
GO
USE PracticeDB;
GO

-- Создание таблиц (пример для Departments)
CREATE TABLE Departments (
    DepartmentId   INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL
);
-- ... и остальные таблицы (Employees, Projects, EmployeeProjects)
```
### Результат

База PracticeDB и 4 таблицы успешно созданы.

### Вывод

Изучил синтаксис DDL (CREATE DATABASE, CREATE TABLE). Понял, как работают внешние ключи (FOREIGN KEY) и ограничения (PRIMARY KEY, IDENTITY).
