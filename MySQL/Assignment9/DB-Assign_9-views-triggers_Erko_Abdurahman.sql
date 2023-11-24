--Erko Abdurahman	ASSIGNMENT 7 GROUPING RESULTS
--Put your answers on the lines after each letter. E.g. your query for question 1A should go on line 5; your query for question 1B should go on line 7...
-- 1 
--A
CREATE VIEW low_stock
AS SELECT stock_items.item, stock_items.category, stock_items.inventory
FROM stock_items
WHERE stock_items.inventory <= 20
--B
CREATE VIEW employee_sales
AS SELECT CONCAT(employees.first_name," ", employees.last_name) AS "Employee_Name", COUNT(sales.employee) AS "Total_Sales"
FROM employees
JOIN sales ON employees.id 
WHERE sales.employee = employees.id
GROUP BY employees.id, employees.first_name, employees.last_name
ORDER BY COUNT("Total_Sales") DESC;    

-- 2
--Wasnt sure if you wanted the code for creating the table but here it is either way
CREATE TABLE data_log (
    logid INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    time_stamp TIMESTAMP,
    action VARCHAR(30),
    first_name VARCHAR(30),
    last_name VARCHAR(30),
    pay_per_hour DECIMAL(10,2))
    ENGINE=INNODB 
    DEFAULT CHARSET=utf8 
    COMMENT='data log table';
--A
DELIMITER $$
CREATE TRIGGER employee_pay_per_hour_updates
AFTER UPDATE ON employees
FOR EACH ROW
BEGIN
  INSERT INTO data_log(time_stamp, actions, first_name, last_name, pay_per_hour)
  VALUES (CURRENT_TIMESTAMP(), 'Update', OLD.first_name, OLD.last_name, NEW.pay_per_hour);
END $$
DELIMITER ;
--B
DELIMITER $$
CREATE TRIGGER deleted_employees
BEFORE DELETE ON employees
FOR EACH ROW
BEGIN
  INSERT INTO data_log(time_stamp, actions, first_name, last_name, pay_per_hour)
  VALUES (CURRENT_TIMESTAMP(), 'Delete', OLD.first_name, OLD.last_name, OLD.pay_per_hour);
END $$
DELIMITER ;


