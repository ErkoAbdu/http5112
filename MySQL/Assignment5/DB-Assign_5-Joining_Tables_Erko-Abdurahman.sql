--Erko Abdurahman	ASSIGNMENT 5 JOINING TABLES
--Put your answers on the lines after each letter. E.g. your query for question 1A should go on line 5; your query for question 1B should go on line 7...
--1 
-- A
SELECT sales.date, stock_items.item
FROM  sales 
JOIN stock_items ON sales.item = stock_items.id
WHERE sales.item = 1014;
-- B
SELECT sales.employee, stock_items.id, stock_items.category, stock_items.item
FROM  stock_items 
INNER JOIN sales ON stock_items.id = sales.item
WHERE stock_items.id = 1003;

--2
-- A
SELECT sales.date, employees.first_name, employees.last_name, sales.item
FROM  employees 
INNER JOIN sales ON employees.id = sales.employee
WHERE employees.id = 111;
-- B
SELECT CONCAT(employees.first_name, " ", employees.last_name) AS Employee_Name, employees.sin, employees.role, sales.item  
FROM  employees 
RIGHT JOIN sales ON sales.employee = employees.id
WHERE employees.sin LIKE "258%" 
OR employees.sin LIKE "456%"
OR employees.sin LIKE "753%";

--3
-- A
SELECT sales.date, sales.item, employees.first_name
FROM  sales 
LEFT JOIN employees ON employees.id = sales.employee
WHERE sales.date BETWEEN "2021-06-12" AND "2021-06-18";
-- B
SELECT COUNT(sales.employee), CONCAT(employees.first_name, " ", employees.last_name) AS "sales_person"
FROM employees
LEFT JOIN sales ON employees.id = sales.employee
GROUP BY sales_person 
ORDER BY COUNT(sales.employee) DESC;
--4
-- A
SELECT s.date, i.item, i.price, i.category, e.first_name 
FROM sales s 
LEFT JOIN employees e ON s.employee = e.id  
LEFT JOIN stock_items i ON s.item = i.id 
WHERE e.first_name = "Farud" AND e.last_name = "Said"
ORDER BY s.date;
-- NULL in item, price, and category caused by typo with airpump sold on "2021-06-20" item id"1117"
-- B NOT CORRECT MAYBE
SELECT DISTINCT sales.item, stock_items.id, stock_items.item,  stock_items.price, stock_items.category
FROM stock_items 
LEFT JOIN sales ON stock_items.id = sales.item  
ORDER BY stock_items.id;