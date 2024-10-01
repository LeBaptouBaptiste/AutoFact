-- MariaDB dump 10.19  Distrib 10.11.6-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: Autofact
-- ------------------------------------------------------
-- Server version	10.11.6-MariaDB-0+deb12u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Avoirs`
--

DROP TABLE IF EXISTS `Avoirs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Avoirs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `montant` decimal(9,2) NOT NULL,
  `contrat` varchar(50) DEFAULT NULL,
  `client` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `contrat` (`contrat`),
  KEY `client` (`client`),
  CONSTRAINT `Avoirs_ibfk_1` FOREIGN KEY (`contrat`) REFERENCES `Contrats` (`reference`),
  CONSTRAINT `Avoirs_ibfk_2` FOREIGN KEY (`client`) REFERENCES `Clients` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Avoirs`
--

LOCK TABLES `Avoirs` WRITE;
/*!40000 ALTER TABLE `Avoirs` DISABLE KEYS */;
/*!40000 ALTER TABLE `Avoirs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Clients`
--

DROP TABLE IF EXISTS `Clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Clients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `adresse` varchar(255) NOT NULL,
  `cp` char(5) NOT NULL,
  `tel` char(10) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `nom` varchar(32) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Clients`
--

LOCK TABLES `Clients` WRITE;
/*!40000 ALTER TABLE `Clients` DISABLE KEYS */;
/*!40000 ALTER TABLE `Clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Contrats`
--

DROP TABLE IF EXISTS `Contrats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Contrats` (
  `reference` varchar(50) NOT NULL,
  `id` int(11) NOT NULL,
  `promo` int(11) DEFAULT NULL,
  `client` int(11) NOT NULL,
  PRIMARY KEY (`reference`),
  KEY `id` (`id`),
  KEY `client` (`client`),
  CONSTRAINT `Contrats_ibfk_1` FOREIGN KEY (`id`) REFERENCES `DelaisPaiement` (`id`),
  CONSTRAINT `Contrats_ibfk_2` FOREIGN KEY (`client`) REFERENCES `Clients` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contrats`
--

LOCK TABLES `Contrats` WRITE;
/*!40000 ALTER TABLE `Contrats` DISABLE KEYS */;
/*!40000 ALTER TABLE `Contrats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DelaisPaiement`
--

DROP TABLE IF EXISTS `DelaisPaiement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `DelaisPaiement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(50) NOT NULL,
  `nbjours` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DelaisPaiement`
--

LOCK TABLES `DelaisPaiement` WRITE;
/*!40000 ALTER TABLE `DelaisPaiement` DISABLE KEYS */;
/*!40000 ALTER TABLE `DelaisPaiement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Designation`
--

DROP TABLE IF EXISTS `Designation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Designation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) NOT NULL,
  `prix` decimal(15,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Designation`
--

LOCK TABLES `Designation` WRITE;
/*!40000 ALTER TABLE `Designation` DISABLE KEYS */;
/*!40000 ALTER TABLE `Designation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EtatContrats`
--

DROP TABLE IF EXISTS `EtatContrats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EtatContrats` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EtatContrats`
--

LOCK TABLES `EtatContrats` WRITE;
/*!40000 ALTER TABLE `EtatContrats` DISABLE KEYS */;
/*!40000 ALTER TABLE `EtatContrats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Particulier`
--

DROP TABLE IF EXISTS `Particulier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Particulier` (
  `id` int(11) NOT NULL,
  `civilitée` varchar(10) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `Particulier_ibfk_1` FOREIGN KEY (`id`) REFERENCES `Clients` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Particulier`
--

LOCK TABLES `Particulier` WRITE;
/*!40000 ALTER TABLE `Particulier` DISABLE KEYS */;
/*!40000 ALTER TABLE `Particulier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Produits`
--

DROP TABLE IF EXISTS `Produits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Produits` (
  `id` int(11) NOT NULL,
  `prixAchat` decimal(15,2) NOT NULL,
  `quantite` int(11) DEFAULT NULL,
  `id_fournisseur` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_fournisseur` (`id_fournisseur`),
  CONSTRAINT `Produits_ibfk_1` FOREIGN KEY (`id`) REFERENCES `Designation` (`id`),
  CONSTRAINT `Produits_ibfk_2` FOREIGN KEY (`id_fournisseur`) REFERENCES `Societe` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Produits`
--

LOCK TABLES `Produits` WRITE;
/*!40000 ALTER TABLE `Produits` DISABLE KEYS */;
/*!40000 ALTER TABLE `Produits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ServiceClient`
--

DROP TABLE IF EXISTS `ServiceClient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ServiceClient` (
  `id` int(11) NOT NULL,
  `reference` varchar(50) NOT NULL,
  `quantité` int(11) NOT NULL,
  `prix` decimal(9,2) NOT NULL,
  PRIMARY KEY (`id`,`reference`),
  KEY `reference` (`reference`),
  CONSTRAINT `ServiceClient_ibfk_1` FOREIGN KEY (`id`) REFERENCES `Designation` (`id`),
  CONSTRAINT `ServiceClient_ibfk_2` FOREIGN KEY (`reference`) REFERENCES `Contrats` (`reference`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ServiceClient`
--

LOCK TABLES `ServiceClient` WRITE;
/*!40000 ALTER TABLE `ServiceClient` DISABLE KEYS */;
/*!40000 ALTER TABLE `ServiceClient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Services`
--

DROP TABLE IF EXISTS `Services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Services` (
  `id` int(11) NOT NULL,
  `duree` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `Services_ibfk_1` FOREIGN KEY (`id`) REFERENCES `Designation` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Services`
--

LOCK TABLES `Services` WRITE;
/*!40000 ALTER TABLE `Services` DISABLE KEYS */;
/*!40000 ALTER TABLE `Services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Societe`
--

DROP TABLE IF EXISTS `Societe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Societe` (
  `id` int(11) NOT NULL,
  `siret` varchar(19) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `Societe_ibfk_1` FOREIGN KEY (`id`) REFERENCES `Clients` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Societe`
--

LOCK TABLES `Societe` WRITE;
/*!40000 ALTER TABLE `Societe` DISABLE KEYS */;
/*!40000 ALTER TABLE `Societe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StatutContrat`
--

DROP TABLE IF EXISTS `StatutContrat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `StatutContrat` (
  `reference` varchar(50) NOT NULL,
  `etat` int(11) NOT NULL,
  `dateAction` date DEFAULT NULL,
  PRIMARY KEY (`reference`,`etat`),
  KEY `etat` (`etat`),
  CONSTRAINT `StatutContrat_ibfk_1` FOREIGN KEY (`reference`) REFERENCES `Contrats` (`reference`),
  CONSTRAINT `StatutContrat_ibfk_2` FOREIGN KEY (`etat`) REFERENCES `EtatContrats` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StatutContrat`
--

LOCK TABLES `StatutContrat` WRITE;
/*!40000 ALTER TABLE `StatutContrat` DISABLE KEYS */;
/*!40000 ALTER TABLE `StatutContrat` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-01  6:50:46
