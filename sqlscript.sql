-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: mysqlsunucum.mysql.database.azure.com    Database: denemedb
-- ------------------------------------------------------
-- Server version	5.6.39.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20190822142704_x','2.1.8-servicing-32085');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `birimkoordinatorleri`
--

DROP TABLE IF EXISTS `birimkoordinatorleri`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `birimkoordinatorleri` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProfilID` int(11) NOT NULL,
  `Unvan` text,
  PRIMARY KEY (`ID`),
  KEY `IX_BirimKoordinatorleri_ProfilID` (`ProfilID`),
  CONSTRAINT `FK_BirimKoordinatorleri_Hesaplar_ProfilID` FOREIGN KEY (`ProfilID`) REFERENCES `hesaplar` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `birimkoordinatorleri`
--

LOCK TABLES `birimkoordinatorleri` WRITE;
/*!40000 ALTER TABLE `birimkoordinatorleri` DISABLE KEYS */;
/*!40000 ALTER TABLE `birimkoordinatorleri` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `birimler`
--

DROP TABLE IF EXISTS `birimler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `birimler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Ad` text,
  `Aciklama` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `birimler`
--

LOCK TABLES `birimler` WRITE;
/*!40000 ALTER TABLE `birimler` DISABLE KEYS */;
INSERT INTO `birimler` VALUES (5,'Yazilim','safasf'),(6,'Donanim','Donanim');
/*!40000 ALTER TABLE `birimler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `birimvekoordinator`
--

DROP TABLE IF EXISTS `birimvekoordinator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `birimvekoordinator` (
  `BirimID` int(11) NOT NULL,
  `BirimKoordinatoruID` int(11) NOT NULL,
  PRIMARY KEY (`BirimID`,`BirimKoordinatoruID`),
  KEY `IX_BirimveKoordinator_BirimKoordinatoruID` (`BirimKoordinatoruID`),
  CONSTRAINT `FK_BirimveKoordinator_BirimKoordinatorleri_BirimKoordinatoruID` FOREIGN KEY (`BirimKoordinatoruID`) REFERENCES `birimkoordinatorleri` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BirimveKoordinator_Birimler_BirimID` FOREIGN KEY (`BirimID`) REFERENCES `birimler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `birimvekoordinator`
--

LOCK TABLES `birimvekoordinator` WRITE;
/*!40000 ALTER TABLE `birimvekoordinator` DISABLE KEYS */;
/*!40000 ALTER TABLE `birimvekoordinator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `birimvestajyer`
--

DROP TABLE IF EXISTS `birimvestajyer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `birimvestajyer` (
  `BirimID` int(11) NOT NULL,
  `StajyerID` int(11) NOT NULL,
  PRIMARY KEY (`BirimID`,`StajyerID`),
  KEY `IX_BirimveStajyer_StajyerID` (`StajyerID`),
  CONSTRAINT `FK_BirimveStajyer_Birimler_BirimID` FOREIGN KEY (`BirimID`) REFERENCES `birimler` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BirimveStajyer_Stajyerler_StajyerID` FOREIGN KEY (`StajyerID`) REFERENCES `stajyerler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `birimvestajyer`
--

LOCK TABLES `birimvestajyer` WRITE;
/*!40000 ALTER TABLE `birimvestajyer` DISABLE KEYS */;
INSERT INTO `birimvestajyer` VALUES (5,1);
/*!40000 ALTER TABLE `birimvestajyer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devamsizlik`
--

DROP TABLE IF EXISTS `devamsizlik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devamsizlik` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `StajyerID` int(11) NOT NULL,
  `Tarih` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Devamsizlik_StajyerID` (`StajyerID`),
  CONSTRAINT `FK_Devamsizlik_Stajyerler_StajyerID` FOREIGN KEY (`StajyerID`) REFERENCES `stajyerler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devamsizlik`
--

LOCK TABLES `devamsizlik` WRITE;
/*!40000 ALTER TABLE `devamsizlik` DISABLE KEYS */;
INSERT INTO `devamsizlik` VALUES (3,1,'2019-08-02 00:00:00'),(4,1,'2019-08-08 00:00:00');
/*!40000 ALTER TABLE `devamsizlik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `duyurular`
--

DROP TABLE IF EXISTS `duyurular`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `duyurular` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Baslik` text,
  `Icerik` text,
  `EklenmeTarihi` datetime NOT NULL,
  `GuncellenmeTarihi` datetime NOT NULL,
  `EkleyenID` int(11) NOT NULL,
  `EkleyenYetki` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `duyurular`
--

LOCK TABLES `duyurular` WRITE;
/*!40000 ALTER TABLE `duyurular` DISABLE KEYS */;
INSERT INTO `duyurular` VALUES (1,'fdg','dsg','2019-08-26 10:48:02','2019-08-26 10:48:02',1,1),(2,'fdgffff','dsgfff','2019-08-26 10:48:11','2019-08-26 10:48:11',1,1);
/*!40000 ALTER TABLE `duyurular` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ekdosya`
--

DROP TABLE IF EXISTS `ekdosya`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ekdosya` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `GunlukID` int(11) NOT NULL,
  `Path` text,
  PRIMARY KEY (`ID`),
  KEY `IX_EkDosya_GunlukID` (`GunlukID`),
  CONSTRAINT `FK_EkDosya_Gunlukler_GunlukID` FOREIGN KEY (`GunlukID`) REFERENCES `gunlukler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ekdosya`
--

LOCK TABLES `ekdosya` WRITE;
/*!40000 ALTER TABLE `ekdosya` DISABLE KEYS */;
/*!40000 ALTER TABLE `ekdosya` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gunlukler`
--

DROP TABLE IF EXISTS `gunlukler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gunlukler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `OgrenciID` int(11) NOT NULL,
  `Baslik` text,
  `Bilgiler` text,
  `OnayDurumu` int(11) NOT NULL,
  `Tarih` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Gunlukler_OgrenciID` (`OgrenciID`),
  CONSTRAINT `FK_Gunlukler_Stajyerler_OgrenciID` FOREIGN KEY (`OgrenciID`) REFERENCES `stajyerler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gunlukler`
--

LOCK TABLES `gunlukler` WRITE;
/*!40000 ALTER TABLE `gunlukler` DISABLE KEYS */;
INSERT INTO `gunlukler` VALUES (1,1,'Son Gunluk','Bu gun stajda son gunum.. hersey cok iyi.. son kontrolelri yaptik ve ardindan sunum yapacagiz.',0,'2019-08-26 12:40:06'),(2,1,'#SonGunluk','son gunluk...',1,'2019-08-28 11:23:25'),(3,1,'asfasf','asfasf',-1,'2019-08-28 11:59:37');
/*!40000 ALTER TABLE `gunlukler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hesaplar`
--

DROP TABLE IF EXISTS `hesaplar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hesaplar` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Ad` text,
  `Soyad` text,
  `Email` varchar(767) DEFAULT NULL,
  `Sifre` text,
  `KullaniciAdi` varchar(767) DEFAULT NULL,
  `Fotograf` text,
  `Telefon` text,
  `Adres` text,
  `Il` text,
  `Ilce` text,
  `Sokak` text,
  `Rol` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Hesaplar_Email` (`Email`),
  UNIQUE KEY `IX_Hesaplar_KullaniciAdi` (`KullaniciAdi`)
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hesaplar`
--

LOCK TABLES `hesaplar` WRITE;
/*!40000 ALTER TABLE `hesaplar` DISABLE KEYS */;
INSERT INTO `hesaplar` VALUES (1,'Niyazi','EKinci','a@a.com','cRDtpNCeBiql5KOQsKVyrA0sAiA=','yonetici','/profile_images\\IMG_1_20190828_11101910.png',NULL,NULL,NULL,NULL,NULL,1),(2,'Ismail','Sava','ismailsava@gmail.com','cRDtpNCeBiql5KOQsKVyrA0sAiA=','ismailsava','/profile_images\\IMG_1_20190828_11182620.png','0(532) 543-2704',NULL,NULL,NULL,NULL,4),(3,'Moderator','Moderator','niyaziekinci5050@gmail.com','cRDtpNCeBiql5KOQsKVyrA0sAiA=','moderator','/profile_images\\IMG_1_20190828_11460243.png','0(555) 555-5555',NULL,NULL,NULL,NULL,2);
/*!40000 ALTER TABLE `hesaplar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mesajlar`
--

DROP TABLE IF EXISTS `mesajlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mesajlar` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProjeID` int(11) NOT NULL,
  `YazanProfilID` int(11) NOT NULL,
  `Mesaj` text,
  `Tarih` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Mesajlar_ProjeID` (`ProjeID`),
  KEY `IX_Mesajlar_YazanProfilID` (`YazanProfilID`),
  CONSTRAINT `FK_Mesajlar_Hesaplar_YazanProfilID` FOREIGN KEY (`YazanProfilID`) REFERENCES `hesaplar` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Mesajlar_Projeler_ProjeID` FOREIGN KEY (`ProjeID`) REFERENCES `projeler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mesajlar`
--

LOCK TABLES `mesajlar` WRITE;
/*!40000 ALTER TABLE `mesajlar` DISABLE KEYS */;
INSERT INTO `mesajlar` VALUES (1,1,1,'Selam\n','2019-08-26 15:31:35'),(2,1,2,'Selam','2019-08-26 15:32:10'),(3,1,2,'naber','2019-08-26 15:32:17'),(4,1,1,'ss','2019-08-26 13:54:52'),(5,1,1,'aaa','2019-08-26 16:55:01'),(6,1,1,'Deneme','2019-08-27 10:33:48'),(7,1,1,'rt','2019-08-28 11:21:50'),(8,1,1,'wqrqwqwt','2019-08-28 14:05:22'),(9,1,1,'asfsaf','2019-08-28 14:06:33'),(10,1,2,'fff','2019-08-28 14:06:49'),(11,1,1,'asdasf','2019-08-28 14:19:10'),(12,1,2,'merhaba\n','2019-08-28 14:20:38'),(13,2,1,'ffff','2019-08-28 14:56:38'),(14,2,2,'fffasf','2019-08-28 15:00:06');
/*!40000 ALTER TABLE `mesajlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moderatorler`
--

DROP TABLE IF EXISTS `moderatorler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `moderatorler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProfilID` int(11) NOT NULL,
  `Unvan` text,
  PRIMARY KEY (`ID`),
  KEY `IX_Moderatorler_ProfilID` (`ProfilID`),
  CONSTRAINT `FK_Moderatorler_Hesaplar_ProfilID` FOREIGN KEY (`ProfilID`) REFERENCES `hesaplar` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moderatorler`
--

LOCK TABLES `moderatorler` WRITE;
/*!40000 ALTER TABLE `moderatorler` DISABLE KEYS */;
INSERT INTO `moderatorler` VALUES (1,3,'Ordinaryüs Profesör');
/*!40000 ALTER TABLE `moderatorler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projebirim`
--

DROP TABLE IF EXISTS `projebirim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projebirim` (
  `ProjeID` int(11) NOT NULL,
  `BirimKoordinatoruID` int(11) NOT NULL,
  PRIMARY KEY (`ProjeID`,`BirimKoordinatoruID`),
  KEY `IX_ProjeBirim_BirimKoordinatoruID` (`BirimKoordinatoruID`),
  CONSTRAINT `FK_ProjeBirim_BirimKoordinatorleri_BirimKoordinatoruID` FOREIGN KEY (`BirimKoordinatoruID`) REFERENCES `birimkoordinatorleri` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProjeBirim_Projeler_ProjeID` FOREIGN KEY (`ProjeID`) REFERENCES `projeler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projebirim`
--

LOCK TABLES `projebirim` WRITE;
/*!40000 ALTER TABLE `projebirim` DISABLE KEYS */;
/*!40000 ALTER TABLE `projebirim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projeler`
--

DROP TABLE IF EXISTS `projeler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projeler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Ad` text,
  `Icerik` text,
  `Baslangic` datetime NOT NULL,
  `Bitis` datetime NOT NULL,
  `Link` text,
  `KullanilanTeknolojiler` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projeler`
--

LOCK TABLES `projeler` WRITE;
/*!40000 ALTER TABLE `projeler` DISABLE KEYS */;
INSERT INTO `projeler` VALUES (1,'Stajyer Takip','Stajyer Takip programinin yapilmasi','2019-08-01 00:00:00','2019-08-01 00:00:00','https://gitlab.com/staj-takip.git',NULL),(2,'fdhdfg','saf','2019-08-01 00:00:00','2019-08-16 00:00:00','dhfdhdfh',NULL);
/*!40000 ALTER TABLE `projeler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistemyoneticisi`
--

DROP TABLE IF EXISTS `sistemyoneticisi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sistemyoneticisi` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProfilID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_SistemYoneticisi_ProfilID` (`ProfilID`),
  CONSTRAINT `FK_SistemYoneticisi_Hesaplar_ProfilID` FOREIGN KEY (`ProfilID`) REFERENCES `hesaplar` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sistemyoneticisi`
--

LOCK TABLES `sistemyoneticisi` WRITE;
/*!40000 ALTER TABLE `sistemyoneticisi` DISABLE KEYS */;
INSERT INTO `sistemyoneticisi` VALUES (1,1);
/*!40000 ALTER TABLE `sistemyoneticisi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stajyerler`
--

DROP TABLE IF EXISTS `stajyerler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stajyerler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProfilID` int(11) NOT NULL,
  `Okul` text,
  `Bolum` text,
  `GunSayisi` int(11) NOT NULL,
  `EklenmeTarihi` datetime NOT NULL,
  `BaslangicTarihi` datetime NOT NULL,
  `BitisTarihi` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Stajyerler_ProfilID` (`ProfilID`),
  CONSTRAINT `FK_Stajyerler_Hesaplar_ProfilID` FOREIGN KEY (`ProfilID`) REFERENCES `hesaplar` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stajyerler`
--

LOCK TABLES `stajyerler` WRITE;
/*!40000 ALTER TABLE `stajyerler` DISABLE KEYS */;
INSERT INTO `stajyerler` VALUES (1,2,'Akdeniz U.','Bilgisayar M.',20,'0001-01-01 00:00:00','2019-07-01 00:00:00','2019-08-01 00:00:00');
/*!40000 ALTER TABLE `stajyerler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stajyerprojeler`
--

DROP TABLE IF EXISTS `stajyerprojeler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stajyerprojeler` (
  `StajyerID` int(11) NOT NULL,
  `ProjeID` int(11) NOT NULL,
  PRIMARY KEY (`StajyerID`,`ProjeID`),
  KEY `IX_StajyerProjeler_ProjeID` (`ProjeID`),
  CONSTRAINT `FK_StajyerProjeler_Projeler_ProjeID` FOREIGN KEY (`ProjeID`) REFERENCES `projeler` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_StajyerProjeler_Stajyerler_StajyerID` FOREIGN KEY (`StajyerID`) REFERENCES `stajyerler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stajyerprojeler`
--

LOCK TABLES `stajyerprojeler` WRITE;
/*!40000 ALTER TABLE `stajyerprojeler` DISABLE KEYS */;
INSERT INTO `stajyerprojeler` VALUES (1,1),(1,2);
/*!40000 ALTER TABLE `stajyerprojeler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yorumlar`
--

DROP TABLE IF EXISTS `yorumlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yorumlar` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Baslik` text,
  `Icerik` text,
  `Puan` int(11) NOT NULL,
  `YorumlayanAdi` text,
  `YorumlayanID` int(11) NOT NULL,
  `EklenmeTarihi` datetime NOT NULL,
  `StajyerID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Yorumlar_StajyerID` (`StajyerID`),
  KEY `IX_Yorumlar_YorumlayanID` (`YorumlayanID`),
  CONSTRAINT `FK_Yorumlar_Hesaplar_YorumlayanID` FOREIGN KEY (`YorumlayanID`) REFERENCES `hesaplar` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Yorumlar_Stajyerler_StajyerID` FOREIGN KEY (`StajyerID`) REFERENCES `stajyerler` (`ID`) ON DELETE CASCADE
) /*!50100 TABLESPACE `innodb_system` */ ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yorumlar`
--

LOCK TABLES `yorumlar` WRITE;
/*!40000 ALTER TABLE `yorumlar` DISABLE KEYS */;
INSERT INTO `yorumlar` VALUES (1,'Basarili','Basarili bir staj oldu tebrik ederim',10,'Niyazi EKinci',1,'2019-08-26 12:34:24',1),(2,'fdg','dgs',7,'Niyazi EKinci',1,'2019-08-28 08:16:00',1),(3,'safasf','safasf',10,'Niyazi EKinci',1,'2019-08-28 11:17:57',1),(4,'asf','asf',3,'Niyazi EKinci',1,'2019-08-28 12:18:57',1);
/*!40000 ALTER TABLE `yorumlar` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-28 15:29:07
