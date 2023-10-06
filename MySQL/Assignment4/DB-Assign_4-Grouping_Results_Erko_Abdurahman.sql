--Erko Abdurahman	ASSIGNMENT 4 GROUPING RESULTS
--Put your answers on the lines after each letter. E.g. your query for question 1A should go on line 5; your query for question 1B should go on line 7...
-- 1 
--A
SELECT MIN(price) FROM stock_items;
--B
SELECT MAX(inventory) FROM stock_items;

-- 2
--A
SELECT role, COUNT(role) FROM employees GROUP BY role;
--B
SELECT role,  COUNT(role), COUNT(phone) FROM employees GROUP BY role;

-- 3
--A
SELECT COUNT(item), category AS "Mammals" FROM stock_items GROUP BY category HAVING category IN("Feline ", "Canine", "Murine");
--B
SELECT SUM(inventory) AS "In-Stock",category AS "Animal" FROM stock_items GROUP BY category ORDER BY SUM(inventory) ASC;
--C
SELECT MAX(price) AS "Highest Price", category FROM stock_items GROUP BY category ORDER BY MAX(price) DESC;
-- SELECT item, price AS "Highest Price", category FROM stock_items WHERE price IN(SELECT MAX(price) FROM stock_items GROUP BY category) ORDER BY price DESC;
--D
SELECT MAX(price) AS "Highest Price", category FROM stock_items WHERE price > 50 GROUP BY category ORDER BY MAX(price) DESC;
-- SELECT item, price AS "Highest Price", category FROM stock_items WHERE price IN(SELECT MAX(price) FROM stock_items GROUP BY category) AND price > 50 ORDER BY price DESC;