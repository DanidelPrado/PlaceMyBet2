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
  `Id_evento` VARCHAR(45) NOT NULL,
  `Local` VARCHAR(30) NOT NULL,
  `Visitante` VARCHAR(30) NOT NULL,
  `Fecha` DATETIME NOT NULL,
  PRIMARY KEY (`Id_evento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Mercado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Mercado` (
  `over/under` DOUBLE NOT NULL,
  `cuota over` DOUBLE NOT NULL,
  `cuota under` DOUBLE NOT NULL,
  `dinero over` DOUBLE NOT NULL,
  `dinero under` DOUBLE NOT NULL,
  `Id_evento` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`over/under`),
    FOREIGN KEY (`Id_evento`)
    REFERENCES `PlaceMyBet`.`Evento` (`Id_evento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Usuario` (
  `email` VARCHAR(45) NOT NULL,
  `Nombre` VARCHAR(30) NOT NULL,
  `Apellidos` VARCHAR(45) NOT NULL,
  `Edad` INT NOT NULL,
  PRIMARY KEY (`email`),
  KEY idx_email (email))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Banco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Banco` (
  `num_tarjeta` VARCHAR(25) NOT NULL,
  `Saldo` DOUBLE NOT NULL,
  `Nom_banco` VARCHAR(25) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`num_tarjeta`),
  KEY idx_emailBanco (email))
ENGINE = InnoDB;

ALTER TABLE `PlaceMyBet`.`Banco`
ADD FOREIGN KEY (email) REFERENCES `PlaceMyBet`.`Usuario`(email);


-- -----------------------------------------------------
-- Table `mydb`.`Apuesta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Apuesta` (
  `Id_apuesta` INT NOT NULL,
  `tipo` VARCHAR(45) NOT NULL,
  `dinero` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `over/under` DOUBLE NOT NULL,
  PRIMARY KEY (`Id_apuesta`),
  CONSTRAINT `over/under`
    FOREIGN KEY (`over/under`)
    REFERENCES `PlaceMyBet`.`Mercado` (`over/under`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `email`
    FOREIGN KEY (`email`)
    REFERENCES `PlaceMyBet`.`Usuario` (`email`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
