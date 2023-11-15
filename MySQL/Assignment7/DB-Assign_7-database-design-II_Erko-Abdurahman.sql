--Erko Abdurahman	ASSIGNMENT 7 GROUPING RESULTS
--Put your answers on the lines after each letter. E.g. your query for question 1A should go on line 5; your query for question 1B should go on line 7...
-- 1 
--A
CREATE DATABASE gaming_blog;

CREATE TABLE authors (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    account_creation TIMESTAMP,
    role VARCHAR(30),
    first_name VARCHAR(30),
    last_name VARCHAR(30))
    ENGINE=INNODB 
    DEFAULT CHARSET=utf8 
    COMMENT='authors table';

CREATE TABLE posts (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    post_date_time TIMESTAMP,
    author_id INT(30),
    post_description TEXT(255),
    post_upvotes INT(30))
    ENGINE=INNODB
    DEFAULT CHARSET=utf8
    COMMENT='posts table';
--B
INSERT INTO authors (account_creation, role, first_name, last_name)
VALUES 
	(CURRENT_TIMESTAMP, "user", "Dillion", "Brooks"),
    (CURRENT_TIMESTAMP, "admin", "John", "Doe"),
    (CURRENT_TIMESTAMP, "user", "John", "Deer");

INSERT INTO posts (post_date_time, author_id, post_description, post_ranking)
VALUES
    (CURRENT_TIMESTAMP, 1, "League of legends is a game for people who dont enjoy smiling", 200),
    (CURRENT_TIMESTAMP, 2, "CS2 is a far inferior version of a game compared to CS:GO", 69),
    (CURRENT_TIMESTAMP, 3, "Rainbow Six: Siege has gotten worse and worse with every update", 9);
-- 2
--A
CREATE TABLE comments (
    id INT(3) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    author_id INT(30),
    comment TEXT(255))
    ENGINE=INNODB
    DEFAULT CHARSET=utf8
    COMMENT='comments table';
--B
INSERT INTO comments (author_id, post_id, comment)
VALUES
    (1, 1, "I smile all the time and still play league what you mean hahahaha....help"),
    (2, 2, "CS:GO had MUCH better hit reg than CS2, and dont forget the peakers advantage being crazy bad right now due to server latency!"),
    (3, 3, "Its crazy how much Ubisoft has downgraded the graphics of this game since release because pro players keep crying about to many effects on screen....");

-- 3
--A
ALTER TABLE comments
ADD comment_date DATE; 

UPDATE comments SET comment_date = "2023/11/04" WHERE id = 1 || 2 || 3;  
--B
DELETE authors, posts  
	FROM authors 
	JOIN posts ON authors.id = posts.author_id
	WHERE authors.id IN (1, 2) 
