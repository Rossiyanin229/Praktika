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

## Task 07 — GROUP BY + HAVING: фильтрация групп
### SQL

```sql
USE PracticeDB;
GO

SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2;
GO

SELECT DepartmentId, ROUND(AVG(Salary), 2) AS AvgSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000;
GO

SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000;
GO
```

### Результат
* Отделы с >2 сотрудниками: DepartmentId = 1 (4 сотрудника), DepartmentId = 2 (3 сотрудника).

* Отделы со средней зарплатой > 55000: DepartmentId = 1 (60000.00), DepartmentId = 4 (90000.00).

* Отделы с суммарной зарплатой > 150000: DepartmentId = 1 (240000.00), DepartmentId = 2 (171000.00).

### Вывод
Понял ключевое отличие WHERE от HAVING: WHERE фильтрует строки до группировки, а HAVING — после (применяется к результатам агрегатных функций). Научился использовать HAVING с COUNT, AVG и SUM.

## Task 08 — INNER JOIN: сотрудники и отделы
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName,
    d.DepartmentName,
    e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;
GO
```

### Результат
EmployeeName|DepartmentName|Salary
---|---|---|
Ольга Смирнова|Аналитика|61000.00
Дмитрий Орлов|Аналитика|58000.00
Елена Волкова|Аналитика|52000.00
Алексей Лебедев|Менеджмент|90000.00
Пётр Сидоров|Разработка|72000.00
Анна Иванова|Разработка|65000.00
Мария Кузнецова|Разработка|55000.00
Иван Петров|Разработка|48000.00
Сергей Морозов|Тестирование|45000.00
Наталья Соколова|Тестирование|43000.00

### Вывод
Научился использовать INNER JOIN для соединения двух таблиц по общему ключу (DepartmentId). Понял, что INNER JOIN возвращает только те строки, где есть совпадение в обеих таблицах.

## Task 09 — LEFT JOIN: сотрудники без проектов
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeId,
    e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL;
GO
```

### Результат
EmployeeId|EmployeeName
---|---
9|Наталья Соколова

### Вывод
Разобрался, как работает LEFT JOIN: он возвращает все строки из левой таблицы (Employees), даже если в правой (EmployeeProjects) нет совпадений. В таких случаях правая часть заполняется NULL. Фильтр WHERE ep.EmployeeId IS NULL позволяет найти «сирот» — сотрудников без проектов.

## Task 10 — Множественный JOIN: сотрудники, отделы, проекты
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName,
    d.DepartmentName,
    p.ProjectName,
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName ASC, e.EmployeeName ASC, p.ProjectName ASC;
GO
```

### Результат

EmployeeName	|DepartmentName|	ProjectName	|Hours
---|---|---|---
Дмитрий Орлов	|Аналитика	|AI Assistant	|50
Дмитрий Орлов	|Аналитика	|Data Warehouse|	70
Елена Волкова	|Аналитика	|Mobile App	|95
Ольга Смирнова	|Аналитика	|Data Warehouse	|110
Алексей Лебедев	|Менеджмент	|AI Assistant	|200
Алексей Лебедев|	Менеджмент	|CRM System	|30
Анна Иванова	|Разработка	|CRM System	|120
Анна Иванова	|Разработка	|Data Warehouse	|80
Иван Петров|	Разработка	|Legacy Refactor	|40
Иван Петров	|Разработка	|Mobile App	|90
Мария Кузнецова	|Разработка|	Mobile App	|100
Пётр Сидоров	|Разработка	|AI Assistant	|60
Пётр Сидоров	|Разработка	|CRM System	|150
Сергей Морозов	|Тестирование	|Legacy Refactor	|130

### Вывод
Научился соединять более двух таблиц с помощью последовательных INNER JOIN. Понял, как важно правильно указывать связи через ON (по общим ключам). Также убедился, что сортировка по нескольким столбцам (ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName) позволяет получить аккуратный и читаемый результат.

## Task 11 — Self-join: иерархия руководителей
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName,
    m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId
ORDER BY e.EmployeeName;
GO
```

### Результат

EmployeeName	|ManagerName
---|---
Алексей Лебедев|	NULL
Анна Иванова	|NULL
Дмитрий Орлов	|Ольга Смирнова
Елена Волкова	|NULL
Иван Петров	|Анна Иванова
Мария Кузнецова|	Пётр Сидоров
Наталья Соколова	|Алексей Лебедев
Ольга Смирнова	|NULL
Пётр Сидоров	|NULL
Сергей Морозов	|NULL

### Вывод
Научился использовать self-join — соединение таблицы с самой собой. Для этого мы используем два алиаса (e для сотрудника, m для руководителя) и связываем ManagerId с EmployeeId. LEFT JOIN нужен, чтобы сотрудники без руководителя тоже попали в результат (с NULL в поле ManagerName).

## Task 12 — Подзапросы в WHERE
### SQL

```sql
USE PracticeDB;
GO

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);
GO

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
GO
```

### Результат
* Выше средней (средняя = 58900.00):

EmployeeId	|EmployeeName	|Salary
---|---|---
1	|Анна Иванова	|65000.00
2|	Пётр Сидоров	|72000.00
5	|Ольга Смирнова|	61000.00
10	|Алексей Лебедев	|90000.00

* С максимальной зарплатой:

EmployeeId	|EmployeeName	|Salary
---|---|---
10|	Алексей Лебедев	|90000.00

### Вывод
Понял, как работают подзапросы в WHERE: сначала выполняется внутренний запрос (например, находит среднюю или максимальную зарплату), а затем внешний запрос использует это значение для фильтрации. Это позволяет делать динамические сравнения без жестко заданных чисел.

## Task 13 — Скалярные подзапросы в SELECT
### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName,
    e.Salary,
    e.DepartmentId,
    (SELECT ROUND(AVG(Salary), 2) FROM Employees e2 WHERE e2.DepartmentId = e.DepartmentId) AS DeptAvgSalary,
    ROUND(e.Salary - (SELECT AVG(Salary) FROM Employees e3 WHERE e3.DepartmentId = e.DepartmentId), 2) AS Difference
FROM Employees e
ORDER BY e.DepartmentId, e.EmployeeName;
GO
```

### Результат

EmployeeName	|Salary|	DepartmentId|	DeptAvgSalary|	Difference
---|---|---|---|---
Анна Иванова|65000.00	|1	|60000.000000	|5000.000000
Иван Петров	|48000.00	|1|	60000.000000	|-12000.000000
Мария Кузнецова|	55000.00	|1	|60000.000000	|-5000.000000
Пётр Сидоров	|72000.00	|1	|60000.000000	|12000.000000
Дмитрий Орлов	|58000.00	|2	|57000.000000	|1000.000000
Елена Волкова	|52000.00	|2|	57000.000000|	-5000.000000
Ольга Смирнова	|61000.00	|2|	57000.000000	|4000.000000
Наталья Соколова	|43000.00|	3	|44000.000000|	-1000.000000
Сергей Морозов	|45000.00	|3|	44000.000000|	1000.000000
Алексей Лебедев	|90000.00|	4|	90000.000000|	0.000000

### Вывод
Научился использовать скалярный подзапрос в SELECT. Он выполняется для каждой строки внешнего запроса и возвращает одно значение (в нашем случае — среднюю зарплату по отделу сотрудника). Это позволяет сравнивать значения «на лету» без дополнительных JOIN.