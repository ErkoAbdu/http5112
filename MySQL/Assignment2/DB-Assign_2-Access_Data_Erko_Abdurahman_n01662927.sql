--YOUR NAME HERE	ASSIGNMENT 2 ACCESSING DATA PART 1
--Put your answers on the lines after each letter. E.g. your query for question 1A should go on line 5; your query for question 1B should go on line 7...
-- 1 
--A
SELECT * FROM 'employees';
--gets all data from 'employees'
--B
SELECT * FROM 'stock_items';\
--gets all data from 'stock_items'

-- 2
--A
SELECT item, price FROM 'stock_items';
--gets item and price data from 'stock_items'
--B
SELECT first_name, last_name, role, phone FROM 'employees';
--gets first name, last name, role and phone number from 'employees'
-- 3
--A
SELECT item AS "Product", category AS "Animal" FROM 'stock_items';
--gets item (Product) and category (Animal) from 'stock_items'
--B
SELECT last_name AS "Pet Store Staff", id AS "Emp. ID", sin AS "SIN" FROM `employees`;
-- gets last name (Pet Store Staff) id (Emp. ID) and the sin (SIN) from 'employees'

-- 4
--A
SELECT first_name AS "Employee", phone AS "Contact", role AS "Position" FROM `employees` WHERE role = "Sales";
-- gets first name, phone and role from 'employees' if the role is "Sales"
--B
SELECT item AS "Product", id AS "ID", inventory AS "Stock" FROM `stock_items` WHERE inventory <= 12;
-- gets item, id, inventory from 'stock_items' where the inventory is less than or equal to 12

-- 5
--A
SELECT item AS "Product", category AS "Animal Type", price AS "Price" FROM `stock_items` WHERE category = "Feline";
-- gets item, category, and price from 'stock_items' where the category is "Feline" 
--B
SELECT CONCAT(first_name, " ", last_name) AS "Staff Name", id AS "Emp. ID", phone AS "Contact", role AS "Position" FROM `employees` WHERE id = "115"
-- gets employees first and last name, id, phone, and role, from employees where the id = 115