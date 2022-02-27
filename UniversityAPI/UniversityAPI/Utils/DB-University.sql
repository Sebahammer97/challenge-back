-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.5.5-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para university
CREATE DATABASE IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `university`;

-- Volcando estructura para tabla university.course
CREATE TABLE IF NOT EXISTS `course` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) NOT NULL,
  `Hours` int(11) NOT NULL,
  `Credits` int(11) DEFAULT NULL,
  `InstructorId` int(11) NOT NULL,
  `CreatedOn` datetime DEFAULT NULL,
  `UpdatedOn` datetime DEFAULT NULL,
  `SoftDeleted` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `FK_Course_Instructor` (`InstructorId`) USING BTREE,
  CONSTRAINT `FK_Course_Teacher` FOREIGN KEY (`InstructorId`) REFERENCES `instructor` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla university.enrollment
CREATE TABLE IF NOT EXISTS `enrollment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CourseId` int(11) NOT NULL,
  `StudentId` int(11) NOT NULL,
  `Grade` int(11) DEFAULT NULL,
  `CreatedOn` datetime DEFAULT NULL,
  `UpdatedOn` datetime DEFAULT NULL,
  `SoftDeleted` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `FK_Enrollment_Course` (`CourseId`) USING BTREE,
  KEY `FK_Enrollment_Student` (`StudentId`) USING BTREE,
  CONSTRAINT `FK_Enrollment_Course` FOREIGN KEY (`CourseId`) REFERENCES `course` (`Id`),
  CONSTRAINT `FK_Enrollment_Student` FOREIGN KEY (`StudentId`) REFERENCES `student` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla university.instructor
CREATE TABLE IF NOT EXISTS `instructor` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL DEFAULT '',
  `MidName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) NOT NULL DEFAULT '',
  `Birthday` datetime NOT NULL,
  `EnrollmentDate` datetime NOT NULL,
  `CreatedOn` datetime DEFAULT NULL,
  `UpdatedOn` datetime DEFAULT NULL,
  `SoftDeleted` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla university.student
CREATE TABLE IF NOT EXISTS `student` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL DEFAULT '',
  `MidName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) NOT NULL DEFAULT '',
  `Birthday` datetime NOT NULL,
  `EnrollmentDate` datetime NOT NULL,
  `CreatedOn` datetime DEFAULT NULL,
  `UpdatedOn` datetime DEFAULT NULL,
  `SoftDeleted` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
