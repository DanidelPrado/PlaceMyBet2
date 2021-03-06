-- MySQL Script generated by MySQL Workbench
-- Mon Oct  5 17:35:19 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PlaceMyBet` DEFAULT CHARACTER SET utf8 ;
USE `PlaceMyBet` ;

-- -----------------------------------------------------
-- Table `mydb`.`Evento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Evento` (
  `id_Evento` INT NOT NULL AUTO_INCREMENT,
  `local` VARCHAR(45) NOT NULL,
  `visitante` VARCHAR(45) NOT NULL,
  `fecha` DATE NOT NULL,
  PRIMARY KEY (`id_Evento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Mercado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Mercado` (
   `id_Mercado` INT NOT NULL AUTO_INCREMENT,
  `cuota_Over` DOUBLE NOT NULL,
  `cuota_Under` DOUBLE NOT NULL,
  `dinero_Over` DOUBLE NOT NULL,
  `dinero_Under` DOUBLE NOT NULL,
  `tipo_Mercado` DOUBLE NOT NULL,
  `id_Evento` INT NOT NULL,
  PRIMARY KEY (`id_Mercado`),
  CONSTRAINT `relEvento` FOREIGN KEY (`id_Evento`) REFERENCES `PlaceMyBet`.`Evento` (`id_Evento`) ON DELETE NO ACTION ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table `mydb`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Usuario` (
  `email` VARCHAR(50) NOT NULL,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(45) NOT NULL,
  `edad` INT NOT NULL,
  PRIMARY KEY (`email`));


-- -----------------------------------------------------
-- Table `mydb`.`Banco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Banco` (
  `email` VARCHAR(50) NOT NULL,
  `saldo` DECIMAL(10) NOT NULL,
  `nombre_Banco` VARCHAR(45) NOT NULL,
  `num_Tarjeta` INT NOT NULL,
  PRIMARY KEY (`email`),
  CONSTRAINT `relUsuario2` FOREIGN KEY (`email`) REFERENCES `PlaceMyBet`.`Usuario` (`email`) ON DELETE NO ACTION ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `mydb`.`Apuesta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Apuesta` (
  `id_Apuesta` INT NOT NULL AUTO_INCREMENT,
  `tipo_Mercado` DOUBLE NOT NULL,
  `cuota` DOUBLE NOT NULL,
  `dinero` DOUBLE NOT NULL,
  `fecha` DATE NOT NULL,
  `id_Mercado` INT NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `tipo_Cuota` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id_Apuesta`),
  CONSTRAINT `relUsuario` FOREIGN KEY (`email`) REFERENCES `PlaceMyBet`.`Usuario` (`email`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `relMercado` FOREIGN KEY (`id_Mercado`) REFERENCES `PlaceMyBet`.`Mercado` (`id_Mercado`) ON DELETE NO ACTION ON UPDATE NO ACTION);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


INSERT INTO `PlaceMyBet`.`Evento` (`id_Evento`, `local`, `visitante`, `fecha`) VALUES (1, 'Valencia', 'Espanyol', '2020-10-17');
INSERT INTO `PlaceMyBet`.`Evento` (`id_Evento`, `local`, `visitante`, `fecha`) VALUES (2, 'Barcelona', 'Valladolid', '2020-10-30');
INSERT INTO `PlaceMyBet`.`Evento` (`id_Evento`, `local`, `visitante`, `fecha`) VALUES (3, 'Madrid', 'Villareal', '2020-10-23');
INSERT INTO `PlaceMyBet`.`Mercado` (`id_Mercado`, `cuota_Over`, `cuota_Under`, `dinero_Over`, `dinero_Under`, `tipo_Mercado`, `id_Evento`) VALUES (1, 1.43, 2.85, 100, 50, 1.5, 1);
INSERT INTO `PlaceMyBet`.`Mercado` (`id_Mercado`, `cuota_Over`, `cuota_Under`, `dinero_Over`, `dinero_Under`, `tipo_Mercado`, `id_Evento`) VALUES (2, 1.9, 1.9, 100, 100, 2.5, 2);
INSERT INTO `PlaceMyBet`.`Mercado` (`id_Mercado`, `cuota_Over`, `cuota_Under`, `dinero_Over`, `dinero_Under`, `tipo_Mercado`, `id_Evento`) VALUES (3, 2.85, 1.43, 50, 100, 3.5, 3);
INSERT INTO `PlaceMyBet`.`Usuario` (`email`, `nombre`, `apellido`, `edad`) VALUES ('AnaRS@gmail.com', 'Ana', 'Rodríguez Sánchez', 25);
INSERT INTO `PlaceMyBet`.`Usuario` (`email`, `nombre`, `apellido`, `edad`) VALUES ('JuanPL@gmail.com', 'Juan', 'Pérez López', 27);
INSERT INTO `PlaceMyBet`.`Usuario` (`email`, `nombre`, `apellido`, `edad`) VALUES ('PepeGB@gmail.com', 'Pepe', 'Gómez Botella', 23);
INSERT INTO `PlaceMyBet`.`Apuesta` (`id_Apuesta`, `tipo_Mercado`, `cuota`, `dinero`, `fecha`, `id_Mercado`, `email`, `tipo_Cuota`) VALUES (1, 1.5, 1.87, 200, '2020-10-14', 1, 'AnaRS@gmail.com', 'over');
INSERT INTO `PlaceMyBet`.`Apuesta` (`id_Apuesta`, `tipo_Mercado`, `cuota`, `dinero`, `fecha`, `id_Mercado`, `email`, `tipo_Cuota`) VALUES (2, 2.5, 2.39, 150, '2020-09-15', 2, 'JuanPL@gmail.com', 'under');
INSERT INTO `PlaceMyBet`.`Apuesta` (`id_Apuesta`, `tipo_Mercado`, `cuota`, `dinero`, `fecha`, `id_Mercado`, `email`, `tipo_Cuota`) VALUES (3, 3.5, 1.92, 175, '2020-09-16', 3, 'PepeGB@gmail.com', 'over');
INSERT INTO `PlaceMyBet`.`Banco` (`email`, `saldo`, `nombre_Banco`, `num_Tarjeta`) VALUES ('AnaRS@gmail.com', 2000, 'Santander', 227814591);
INSERT INTO `PlaceMyBet`.`Banco` (`email`, `saldo`, `nombre_Banco`, `num_Tarjeta`) VALUES ('JuanPL@gmail.com', 1900, 'Sabadell', 835917893);
INSERT INTO `PlaceMyBet`.`Banco` (`email`, `saldo`, `nombre_Banco`, `num_Tarjeta`) VALUES ('PepeGB@gmail.com', 1800, 'Bankia', 446512586);