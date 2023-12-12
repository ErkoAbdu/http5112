--Erko Abdurahman HTTP5112 Final Project: Animal Sanctuary

-- CREATING TABLES
CREATE TABLE animals_table (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    animal_name VARCHAR(30) NOT NULL,
    animal VARCHAR(30) NOT NULL,
    species VARCHAR(30) NOT NULL,
    gender VARCHAR(30) NOT NULL,
    status VARCHAR(30) NOT NULL)
    ENGINE=INNODB 
    DEFAULT CHARSET=utf8 
    COMMENT='animals table';

CREATE TABLE animals_status_table (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    animal_name VARCHAR(30),
    animal_id INT(3), 
    CONSTRAINT animal_id_FK FOREIGN KEY (animal_id) REFERENCES animals_table(id),
    enter_date DATE NOT NULL,
    exit_date DATE)
    ENGINE=INNODB 
    DEFAULT CHARSET=utf8 
    COMMENT='animal status table';

CREATE TABLE donors_table (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    f_name VARCHAR(30) NOT NULL,
    l_name VARCHAR(30) NOT NULL,
    email VARCHAR(30) NOT NULL,
    phone VARCHAR(30) NOT NULL)
    ENGINE=INNODB 
    DEFAULT CHARSET=utf8 
    COMMENT='donors table';

CREATE TABLE donations_table (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    donor_id INT(3), 
    CONSTRAINT donor_id_FK FOREIGN KEY (donor_id) REFERENCES donors_table(id),
    donations_animal_id INT(3) NOT NULL,
    CONSTRAINT animal_id_FK2 FOREIGN KEY (donations_animal_id) REFERENCES animals_table(id),
    donation_date DATE NOT NULL,
    amount INT(100) NOT NULL)
    ENGINE=INNODB 
    DEFAULT CHARSET=utf8 
    COMMENT='donations table';

-- INSERTING DATA INTO TABLES
INSERT INTO animals_table (animal_name, animal, species, gender, status)
VALUES 
	("Tony The Tiger", "TIGER", "Panthera tigris", "Male","At Sanctuary"),
    ("Toucan Sam", "TOUCAN", "Ramphastidae", "Male", "At Sanctuary"),
    ("Timon", "MEERKAT", "Suricata suricatta", "Male", "At Sanctuary"),
    ("Pumba", "WARTHOG", "Phacochoerus africanus", "Male", "Left Sanctuary"),
    ("Dumbo", "ELEPHANT", "Loxodonta africana", "Male", "Left Sanctuary");

INSERT INTO animals_status_table (animal_id, animal_name, enter_date, exit_date)
VALUES 
	(1, "Tony The Tiger", CURRENT_DATE, NULL),
    (2, "Toucan Sam", CURRENT_DATE, NULL),
    (3, "Timon", CURRENT_DATE, NULL),
    (4, "Pumba", "2020-11-24", CURRENT_DATE),
    (5, "Dumbo", "2008-8-25", CURRENT_DATE);

INSERT INTO donors_table (f_name, l_name, email, phone)
VALUES 
	("Erko", "Abdurahman", "erkosemail@gmail.com", "(123)-456-7890"),
    ("John", "Doe", "johndoe@gmail.com", "(098)-765-4321"),
    ("Jane", "Dooeeee", "janedooeeee@gmail.com", "(123)-654-8790"),
    ("Shrek", "Ogre", "shrektheman@gmail.com", "(657)-432-9612"),
    ("Judy", "Alvarez", "notarealemail@gmail.com", "(999)-888-7766");
    
INSERT INTO donations_table (donor_id, donations_animal_id, donation_date, amount)
VALUES 
	(1, 1, "2018-9-10", 150),
    (2, 1, "2015-2-17", 1),
    (3, 3, "2019-6-1", 4500),
    (4, 5, CURRENT_DATE, 150000),
    (5, 5, CURRENT_DATE, 10);

--CREATING TRIGGERS for Animal tables
DELIMITER $$
CREATE TRIGGER animal_status_insert
AFTER INSERT ON animals_table
FOR EACH ROW
BEGIN
  INSERT INTO animals_status_table(animal_id, animal_name, enter_date, exit_date)
  VALUES (NEW.id, NEW.animal_name, CURRENT_DATE, NULL);
END $$
DELIMITER ;

--TEST: to see if ENTER TRIGGER works, it does
INSERT INTO animals_table (animal_name, animal, species, gender, status)
VALUES 
	("Curious George", "MONKEY", "Monkey Thing", "Female", "At Sanctuary");
-------------------------------------------------------------------------------------------
DELIMITER $$
CREATE TRIGGER animal_status_update
AFTER UPDATE ON animals_table
FOR EACH ROW
BEGIN
  IF NEW.status = 'Left Sanctuary' THEN
    UPDATE animals_status_table
    SET exit_date = CURRENT_DATE
    WHERE animal_id = NEW.id;
  END IF;
END $$
DELIMITER ;

--TEST: to see if EXIT TRIGGER works, it does
UPDATE animals_table SET status = "Left Sanctuary" WHERE id = 7;
-------------------------------------------------------------------------------------------

--CREATING VIEW, FUNCTION and TRIGGER for Donations Tables

--Need to create a function that will display the total donations each naimal recieves
DELIMITER $$
CREATE FUNCTION donations_by_species(species_name VARCHAR(30))
RETURNS DECIMAL(10, 2)
BEGIN
    DECLARE total_donations DECIMAL(10, 2);
    SELECT SUM(donations_table.amount)
    INTO total_donations
    FROM donations_table 
    JOIN animals_table ON donations_table.donations_animal_id = animals_table.id
    WHERE animals_table.species = species_name;
    IF total_donations IS NULL THEN
        SET total_donations = 0.00;
    END IF;
    RETURN total_donations;
END $$
DELIMITER ;

--Test to see if Function works, it does
SELECT donations_by_species('Panthera tigris') AS total_donations;

SELECT
    species, donations_by_species(species) AS total_donations
    FROM
        animals_table;
-------------------------------------------------------------------------------------------
--Need to create a VIEW to see who donated where but only the most necessary data will show
CREATE VIEW protected_donor_list
AS 
SELECT id, f_name, l_name
FROM donors_table;  

--Test to show the protected_donor_list VIEW is working
INSERT INTO donors_table (f_name, l_name, email, phone)
VALUES 
	("Jeferson", "TheCat", "Meow@gmail.com", "(123)-456-7890");