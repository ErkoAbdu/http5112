-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Oct 10, 2023 at 05:08 PM
-- Server version: 5.7.24
-- PHP Version: 8.1.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `http5112-petstore`
--

-- --------------------------------------------------------

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `id` smallint(4) UNSIGNED NOT NULL COMMENT 'Primary key for this table.',
  `last_name` varchar(30) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `sin` int(9) UNSIGNED NOT NULL COMMENT 'Social Insurance Number',
  `phone` int(10) UNSIGNED NOT NULL,
  `role` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `pay_per_hour` decimal(10,2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Pet store employees table for HTTP5112.';

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `last_name`, `first_name`, `sin`, `phone`, `role`, `email`, `pay_per_hour`) VALUES
(110, 'Maracle', 'James', 123456789, 4165551234, 'Manager', 'jamesm@httppetstore.com', 50.00),
(111, 'Marquis', 'Henry', 987654321, 4165551235, 'Sales', 'marquis@httppetstore.com', 20.50),
(112, 'Kaur', 'Jas', 456123789, 4165551236, 'Sales','jaskaur@httppetstore.com', 20.90),
(113, 'Neema', 'Hank', 654987321, 4165551237, 'Assistant', 'neemahank@thepetstore.com', 20.20),
(114, 'Said', 'Farud', 258741369, 4165551238, 'Sales', 'saidf@httppetstore.com', 20.00),
(115, 'Fitzpatrick', 'Henry', 753951842, 4165551239, 'Stock', 'henryf@httppetstore.com', 27.90 ),
(116, 'Chovey', 'Ann', 453911842, 2895551230, 'Sales', 'annc@httppetstore.com', 27.90 ),
(117, 'Bugg', 'Aida', 953951999, 4169998888, 'Stock', 'aidab@httppetstore.com', 27.90 ),
(118, 'Legge', 'Scout', 75396789, 4168082034, 'Sales', 'scout@httppetstore.com', 27.90 ),
(119, 'Shin', 'Ray', 753922344, 41652324567, 'Stock', 'rayshin@httppetstore.com', 27.90 );


-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `id` int(255) NOT NULL,
  `date` date NOT NULL,
  `item` varchar(255) NOT NULL,
  `employee` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`id`, `date`, `item`, `employee`) VALUES
(21000, '2021-06-09', '1002', 111),
(21001, '2021-06-09', '1003', 111),
(21002, '2021-06-09', '1004', 111),
(21003, '2021-06-10', '1005', 112),
(21004, '2021-06-10', '1011', 114),
(21005, '2021-06-11', '1012', 111),
(21006, '2021-06-11', '1002', 111),
(21007, '2021-06-12', '1010', 114),
(21008, '2021-06-12', '1009', 114),
(21009, '2021-06-12', '1005', 111),
(21010, '2021-06-12', '1017', 114),
(21011, '2021-06-12', '1018', 114),
(21012, '2021-06-12', '1014', 112),
(21013, '2021-06-13', '1003', 112),
(21014, '2021-06-13', '1004', 112),
(21015, '2021-06-13', '1005', 112),
(21016, '2021-06-13', '1002', 116),
(21017, '2021-06-14', '1019', 114),
(21018, '2021-06-14', '1020', 112),
(21019, '2021-06-15', '1014', 111),
(21020, '2021-06-15', '1011', 114),
(21021, '2021-06-15', '1004', 114),
(21022, '2021-06-15', '1009', 118),
(21023, '2021-06-16', '1019', 111),
(21024, '2021-06-16', '1018', 111),
(21025, '2021-06-16', '1014', 114),
(21026, '2021-06-16', '1010', 111),
(21027, '2021-06-17', '1003', 114),
(21028, '2021-06-17', '1005', 114),
(21029, '2021-06-17', '1014', 112),
(21030, '2021-06-17', '1011', 112),
(21031, '2021-06-18', '1020', 114),
(21032, '2021-06-18', '1004', 111),
(21033, '2021-06-18', '1006', 114),
(21034, '2021-06-19', '1014', 112),
(21035, '2021-06-19', '1011', 112),
(21036, '2021-06-19', '1020', 111),
(21037, '2021-06-20', '1007', 114),
(21038, '2021-06-20', '1117', 114),
(21039, '2021-06-20', '1020', 112),
(21040, '2021-06-20', '1008', 111);

-- --------------------------------------------------------


--
-- Table structure for table `stock_items`
--

CREATE TABLE `stock_items` (
  `id` smallint(5) UNSIGNED NOT NULL COMMENT 'Primary key for this table.',
  `item` varchar(30) NOT NULL COMMENT 'Name of stock item.',
  `price` decimal(10,0) NOT NULL COMMENT 'Retail price of item.',
  `inventory` smallint(4) NOT NULL COMMENT 'How many currently in stock.',
  `category` varchar(7) NOT NULL COMMENT 'Animal group this item is for.'
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Pet store demo table for HTTP5112.';

--
-- Dumping data for table `stock_items`
--

INSERT INTO `stock_items` (`id`, `item`, `price`, `inventory`, `category`) VALUES
(1001, 'Luxury dog bed', '95', 2, 'Canine'),
(1002, 'Super size chew toy', '15', 45, 'Canine'),
(1003, 'Water dish', '87', 11, 'Feline '),
(1004, 'Fish bowl starter kit', '46', 22, 'Piscine'),
(1005, 'Luxury cat bed', '89', 0, 'Feline '),
(1006, 'Just as good dog bed', '74', 14, 'Canine'),
(1007, 'Deluxe Aquarium', '12', 10, 'Piscine'),
(1008, 'Terrarium', '231', 24, 'Murine'),
(1009, 'Cat stand', '55', 6, 'Feline '),
(1010, 'Premium Terrarium', '524', 2, 'Murine'),
(1011, 'Water dish', '10', 88, 'Canine'),
(1012, 'Giant clam aerator', '15', 12, 'Piscine'),
(1013, 'Small cage', '20', 26, 'Murine'),
(1014, 'Small chew toy', '6', 123, 'Canine'),
(1015, 'Collar', '12', 65, 'Feline '),
(1016, 'Collar', '15', 87, 'Canine'),
(1017, 'Air pump', '18', 36, 'Piscine'),
(1018, 'Hamster tubes', '65', 12, 'Murine'),
(1019, 'Large cage', '30', 11, 'Murine'),
(1020, 'Leash', '18', 88, 'Canine');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
