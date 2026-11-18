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

## Task 02 — INSERT: заполнение данными
### SQL

```sql
USE PracticeDB;
GO


INSERT INTO Departments (DepartmentName) VALUES
    (N'Разработка'),
    (N'Аналитика'),
    (N'Тестирование'),
    (N'Менеджмент');


INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId, ManagerId) VALUES
    (N'Анна Иванова',    65000, '2020-03-15', 1, NULL),
    (N'Пётр Сидоров',    72000, '2019-07-01', 1, NULL),
    (N'Мария Кузнецова', 55000, '2021-11-20', 1, NULL),
    (N'Иван Петров',     48000, '2023-02-10', 1, NULL),
    (N'Ольга Смирнова',  61000, '2020-09-05', 2, NULL),
    (N'Дмитрий Орлов',   58000, '2022-04-18', 2, NULL),
    (N'Елена Волкова',   52000, '2023-06-01', 2, NULL),
    (N'Сергей Морозов',  45000, '2021-12-12', 3, NULL),
    (N'Наталья Соколова',43000, '2024-01-15', 3, NULL),
    (N'Алексей Лебедев', 90000, '2018-05-25', 4, NULL);


INSERT INTO Projects (ProjectName, StartDate) VALUES
    (N'CRM System',      '2023-01-10'),
    (N'Mobile App',      '2023-05-01'),
    (N'Data Warehouse',  '2022-11-20'),
    (N'AI Assistant',    '2024-02-01'),
    (N'Legacy Refactor', '2021-06-15');


INSERT INTO EmployeeProjects (EmployeeId, ProjectId, Hours) VALUES
    (1, 1, 120), (1, 3, 80),
    (2, 1, 150), (2, 4, 60),
    (3, 2, 100), (4, 2, 90),
    (4, 5, 40),  (5, 3, 110),
    (6, 3, 70),  (6, 4, 50),
    (7, 2, 95),  (8, 5, 130),
    (10, 4, 200),(10, 1, 30);


SELECT 'Departments' AS TableName, COUNT(*) AS [Count] FROM Departments
UNION ALL
SELECT 'Employees', COUNT(*) FROM Employees
UNION ALL
SELECT 'Projects', COUNT(*) FROM Projects
UNION ALL
SELECT 'EmployeeProjects', COUNT(*) FROM EmployeeProjects;
```
### Результат
Departments: 4, Employees: 10, Projects: 5, EmployeeProjects: 14.

### Вывод
Понял, как работает множественный INSERT (один запрос на несколько строк). Убедился, что количество строк совпадает с ожидаемым.
## Task 03 — SELECT + WHERE: базовые выборки
### SQL

```sql
USE PracticeDB;
GO

-- 1. Сотрудники с зарплатой > 50000
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE Salary > 50000;
GO

-- 2. Сотрудники, нанятые в 2023 году
SELECT EmployeeId, EmployeeName, HireDate
FROM Employees
WHERE YEAR(HireDate) = 2023;
GO

-- 3. Сотрудники, чьё имя начинается на «А»
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE EmployeeName LIKE N'А%';
GO

-- 4. Сотрудники из отдела DepartmentId = 2
SELECT EmployeeId, EmployeeName, DepartmentId
FROM Employees
WHERE DepartmentId = 2;
GO

-- 5. Сотрудники с зарплатой в диапазоне 40000–60000
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE Salary BETWEEN 40000 AND 60000;
GO
```
### Результат
* Сотрудники с зарплатой > 50000: Анна Иванова, Пётр Сидоров, Мария Кузнецова, Ольга Смирнова, Дмитрий Орлов, Елена Волкова, Алексей Лебедев
* Нанятые в 2023: Иван Петров, Елена Волкова
* Сотрудники, чьё имя начинается на «А»: Анна Иванова, Алексей Лебедев
* Сотрудники из отдела DepartmentId = 2: Ольга Смирнова, Дмитрий Орлов, Елена Волкова
* Сотрудники с зарплатой в диапазоне 40000–60000: Мария Кузнецова, Иван Петров, Дмитрий Орлов, Елена Волкова, Сергей Морозов, Наталья Соколова

### Вывод
Изучил оператор WHERE и логические условия. Понял, как работает LIKE для поиска по шаблону и BETWEEN для диапазонов.

## Task 04 — ORDER BY + TOP: сортировка и лимит
### SQL

```sql
USE PracticeDB;
GO

SELECT TOP 3 EmployeeId, EmployeeName, Salary
FROM Employees
ORDER BY Salary DESC;
GO

SELECT TOP 5 EmployeeId, EmployeeName, HireDate
FROM Employees
ORDER BY HireDate ASC;
GO

SELECT EmployeeId, EmployeeName, DepartmentId, Salary
FROM Employees
ORDER BY DepartmentId ASC, Salary DESC;
GO
```
### Результат
* Топ-3 по зарплате: Алексей Лебедев, Пётр Сидоров, Анна Иванова.

* Топ-5 самых давних: Алексей Лебедев, Пётр Сидоров, Ольга Смирнова, Анна Иванова, Мария Кузнецова.

* Сотрудники отсортированы по отделам (1, 2, 3, 4), внутри отдела — по убыванию зарплаты.

### Вывод
Научился использовать ORDER BY для сортировки по одному или нескольким столбцам (с указанием ASC/DESC). Понял, как работает TOP N для ограничения количества строк.

## Task 05 — Агрегация: COUNT, SUM, AVG, MIN, MAX
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    COUNT(*) AS TotalEmployees,
    SUM(Salary) AS TotalSalary,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary
FROM Employees;
GO

SELECT COUNT(*) AS EmployeesWithHighSalary
FROM Employees
WHERE Salary > 50000;
GO
```
### Результат
* TotalEmployees: 10

* TotalSalary: 589000.00

* AverageSalary: 58900.00

* MinSalary: 43000.00

* MaxSalary: 90000.00

* EmployeesWithHighSalary: 7

### Вывод
Изучил агрегатные функции. Узнал, что COUNT(*) считает все строки, а COUNT(column) — только строки, где значение не NULL. Понял, как работает ROUND для округления и CASE внутри COUNT для условного подсчета.

## Task 06 — GROUP BY: статистика по отделам
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    ROUND(AVG(Salary), 2) AS AvgSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AvgSalary DESC;
GO
```
### Результат

DepartmentId|EmployeeCount|AvgSalary|TotalSalary
---|---|---|---
4|1|90000.00|90000.00
1|4|60000.00|240000.00
2|3|57000.00|171000.00
3|2|44000.00|88000.00

### Вывод
Научился использовать GROUP BY для группировки строк по значению столбца. Понял, что агрегатные функции (COUNT, AVG, SUM) применяются к каждой группе отдельно. Также освоил сортировку результата группировки через ORDER BY.