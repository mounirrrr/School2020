CREATE DATABASE  IF NOT EXISTS `school2018` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `school2018`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: school2018
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblcomponent`
--

DROP TABLE IF EXISTS `tblcomponent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblcomponent` (
  `Id` int(11) NOT NULL,
  `Afkorting` varchar(3) DEFAULT NULL,
  `Omschrijving` varchar(45) DEFAULT NULL,
  `Gewicht` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcomponent`
--

LOCK TABLES `tblcomponent` WRITE;
/*!40000 ALTER TABLE `tblcomponent` DISABLE KEYS */;
INSERT INTO `tblcomponent` VALUES (1,'TA','Taak',10),(2,'TO','Toets',10),(3,'GO','Grote Overhoring',30),(4,'EX','Examen',50),(5,'LE','Lezen',15),(6,'SCH','Schrijven',15);
/*!40000 ALTER TABLE `tblcomponent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblevaluatie`
--

DROP TABLE IF EXISTS `tblevaluatie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblevaluatie` (
  `VakId` int(11) NOT NULL,
  `ComponentId` int(11) NOT NULL,
  `Datum` datetime NOT NULL,
  `Titel` varchar(45) DEFAULT NULL,
  `Behaald` double DEFAULT NULL,
  `Max` double DEFAULT NULL,
  PRIMARY KEY (`VakId`,`ComponentId`,`Datum`),
  KEY `fk_tblVak_has_tblComponent_tblComponent1_idx` (`ComponentId`),
  KEY `fk_tblVak_has_tblComponent_tblVak_idx` (`VakId`),
  CONSTRAINT `fk_tblVak_has_tblComponent_tblComponent1` FOREIGN KEY (`ComponentId`) REFERENCES `tblcomponent` (`id`),
  CONSTRAINT `fk_tblVak_has_tblComponent_tblVak` FOREIGN KEY (`VakId`) REFERENCES `tblvak` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblevaluatie`
--

LOCK TABLES `tblevaluatie` WRITE;
/*!40000 ALTER TABLE `tblevaluatie` DISABLE KEYS */;
INSERT INTO `tblevaluatie` VALUES (1,1,'2018-11-01 00:00:00','Priemgetallen',15,20),(1,1,'2019-01-10 00:00:00','Integralen',15,20);
/*!40000 ALTER TABLE `tblevaluatie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblgebruiker`
--

DROP TABLE IF EXISTS `tblgebruiker`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblgebruiker` (
  `id` int(12) NOT NULL,
  `gebruikersnaam` varchar(32) NOT NULL,
  `paswoord` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblgebruiker`
--

LOCK TABLES `tblgebruiker` WRITE;
/*!40000 ALTER TABLE `tblgebruiker` DISABLE KEYS */;
INSERT INTO `tblgebruiker` VALUES (1,'joris','v123'),(2,'marie','m123');
/*!40000 ALTER TABLE `tblgebruiker` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblvak`
--

DROP TABLE IF EXISTS `tblvak`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblvak` (
  `Id` int(11) NOT NULL,
  `Naam` varchar(45) DEFAULT NULL,
  `AUren` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblvak`
--

LOCK TABLES `tblvak` WRITE;
/*!40000 ALTER TABLE `tblvak` DISABLE KEYS */;
INSERT INTO `tblvak` VALUES (1,'Wiskunde',3),(2,'Softwareontwikkeling',6),(3,'Beheer',4),(4,'Nederlands',3),(5,'Engels',3),(6,'Frans',3);
/*!40000 ALTER TABLE `tblvak` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-15 10:10:44
