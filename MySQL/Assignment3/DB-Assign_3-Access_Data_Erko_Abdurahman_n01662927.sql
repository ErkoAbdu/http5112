--YOUR NAME HERE	ASSIGNMENT 3 REFINING DATA
--Put your answers on the lines after each letter. E.g. your query for question 1A should go on line 5; your query for question 1B should go on line 7...
-- 1 
--A
SELECT * FROM `employees` WHERE role = "manager" OR "assistant";
--Selects all from employees where the role is manager or assistant
--B
SELECT * FROM `stock_items` WHERE category = "Piscine" AND inventory <=24
--selects all from stock items where the category is Piscine and the inventory is less than or equal to 24

-- 2
--A
SELECT * FROM `stock_items` WHERE item LIKE "%cage"
--selects all from stock items where the item has the word cage in it
--B
SELECT * FROM `employees` WHERE first_name LIKE "f%";
--selects all from employees where the first name starts with an f

-- 3
--A
SELECT * FROM `stock_items` WHERE id BETWEEN 1010 and 1015;
--selects all from stock items where the id is between 1010 and 1015
--B
SELECT * FROM `stock_items` WHERE price BETWEEN 10 and 20;
--selects all from stock items where the price is between 10 and 20

-- 4
--A
SELECT first_name, last_name, role AS "Job Title", phone FROM `employees` ORDER BY last_name; 
-- selects first name, last name, role titled as Job Title, and phone from employees ordered by last name
--B
SELECT id, item, price, inventory FROM `stock_items` WHERE category = "Murine" AND inventory >=20 ORDER BY price DESC; 
-- selects id, item, price, inventory from stock items where the category is "Murine" and the inventory is greater than or equal to 20 ordered by price descending