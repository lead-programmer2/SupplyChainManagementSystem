/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50051
Source Host           : localhost:3306
Source Database       : scmsiv

Target Server Type    : MYSQL
Target Server Version : 50051
File Encoding         : 65001

Date: 2013-03-19 16:53:48
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `accounts`
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `AccountCode` bigint(20) NOT NULL,
  `AccountName` varchar(175) default '',
  `AccountCategory` varchar(150) default '',
  `Active` tinyint(4) default '1',
  `FromAccountCode` bigint(20) default '0',
  `ToAccountCode` bigint(20) default '0',
  `Header` tinyint(4) default '0',
  `Sum` tinyint(4) default '0',
  `HeaderAccountCode` bigint(20) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `Voided` tinyint(4) default '0',
  `DateVoided` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`AccountCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO `accounts` VALUES ('31015', 'Parts consumption', 'Profit and Loss', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('31085', 'Stock adjustments', 'Profit and Loss', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('34615', 'Bank charges', 'Profit and Loss', '1', '0', '0', '0', '0', '0', '2013-02-28 11:33:23', '2013-02-28 11:33:23', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('34625', 'Exchange rate differences', 'Profit and Loss', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('36020', 'Bank interest received', 'Profit and Loss', '1', '0', '0', '0', '0', '0', '2013-02-28 11:33:23', '2013-02-28 11:33:23', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('51005', 'Raw materials & consumables - spare parts', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('52005', 'Trade debtors', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('52010', 'Prepayments from customer', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('52035', 'Cash advances', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('54005', 'Cash at hand', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('54050', 'Unallocated payments / cheques', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('55005', 'Trade creditors', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('55010', 'Prepayments to supplier', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('55040', 'Freight cost suspense', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-28 11:33:23', '2013-02-28 11:33:23', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('55045', 'Customs cost suspense', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-28 11:33:23', '2013-02-28 11:33:23', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('55050', 'Insurance cost suspense', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-28 11:33:23', '2013-02-28 11:33:23', '0', '1900-01-01 00:00:00');
INSERT INTO `accounts` VALUES ('58005', 'Result carried forward previous years', 'Balance Sheet', '1', '0', '0', '0', '0', '0', '2013-02-11 10:57:14', '2013-02-11 10:57:14', '0', '1900-01-01 00:00:00');

-- ----------------------------
-- Table structure for `additionalcharges`
-- ----------------------------
DROP TABLE IF EXISTS `additionalcharges`;
CREATE TABLE `additionalcharges` (
  `AdditionalCharge` varchar(175) NOT NULL,
  `ChargeGroup` int(11) default '0',
  `AccountCode` bigint(20) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`AdditionalCharge`),
  KEY `achrgaccountcode` (`AccountCode`),
  CONSTRAINT `achrgaccountcode` FOREIGN KEY (`AccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of additionalcharges
-- ----------------------------
INSERT INTO `additionalcharges` VALUES ('Admin Cost', '1', '55040', '2013-03-04 11:44:47', '2013-03-04 11:44:47');
INSERT INTO `additionalcharges` VALUES ('Customs Clearance', '3', '55045', '2013-03-04 11:44:06', '2013-03-04 11:44:06');
INSERT INTO `additionalcharges` VALUES ('Customs Duty', '3', '55045', '2013-03-04 11:48:14', '2013-03-04 11:48:14');
INSERT INTO `additionalcharges` VALUES ('Destination Customs Duty', '3', '55045', '2013-03-04 11:46:44', '2013-03-04 11:47:37');
INSERT INTO `additionalcharges` VALUES ('Document & Handling', '1', '55040', '2013-03-04 11:52:39', '2013-03-04 11:52:39');
INSERT INTO `additionalcharges` VALUES ('Freight Cost', '2', '55040', '2013-03-04 11:45:33', '2013-03-04 11:45:33');
INSERT INTO `additionalcharges` VALUES ('Insurance Cost', '4', '55050', '2013-03-04 11:45:53', '2013-03-04 11:45:53');

-- ----------------------------
-- Table structure for `bankmiscellaneous`
-- ----------------------------
DROP TABLE IF EXISTS `bankmiscellaneous`;
CREATE TABLE `bankmiscellaneous` (
  `BankMiscellaneous` varchar(175) NOT NULL,
  `AccountCode` bigint(20) default '0',
  `Type` int(11) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`BankMiscellaneous`),
  KEY `bnkmiscaccountcode` (`AccountCode`),
  CONSTRAINT `bnkmiscaccountcode` FOREIGN KEY (`AccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bankmiscellaneous
-- ----------------------------
INSERT INTO `bankmiscellaneous` VALUES ('Bank Charges', '34615', '1', '2013-03-04 15:51:28', '2013-03-04 15:51:28');
INSERT INTO `bankmiscellaneous` VALUES ('Bank Interest', '36020', '0', '2013-03-04 15:27:09', '2013-03-04 15:33:38');

-- ----------------------------
-- Table structure for `banks`
-- ----------------------------
DROP TABLE IF EXISTS `banks`;
CREATE TABLE `banks` (
  `Bank` varchar(175) NOT NULL,
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Bank`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of banks
-- ----------------------------
INSERT INTO `banks` VALUES ('BDO', '2013-03-03 13:09:32', '2013-03-03 13:09:32');
INSERT INTO `banks` VALUES ('BPI', '2013-03-03 12:51:20', '2013-03-03 13:05:29');
INSERT INTO `banks` VALUES ('East West Bank', '2013-03-03 13:05:44', '2013-03-03 13:05:44');
INSERT INTO `banks` VALUES ('HSBC', '2013-03-03 12:56:09', '2013-03-03 12:56:09');
INSERT INTO `banks` VALUES ('Mashreq', '2013-03-03 12:50:18', '2013-03-03 12:54:01');
INSERT INTO `banks` VALUES ('Nordea', '2013-03-03 13:06:16', '2013-03-03 13:06:16');
INSERT INTO `banks` VALUES ('RAK Bank', '2013-03-03 13:06:05', '2013-03-03 13:06:05');

-- ----------------------------
-- Table structure for `brands`
-- ----------------------------
DROP TABLE IF EXISTS `brands`;
CREATE TABLE `brands` (
  `Brand` varchar(175) NOT NULL,
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Brand`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of brands
-- ----------------------------
INSERT INTO `brands` VALUES ('4RUNNER', '2013-03-04 08:09:29', '2013-03-04 08:09:29');
INSERT INTO `brands` VALUES ('ALL', '2013-03-04 08:16:39', '2013-03-04 08:16:39');
INSERT INTO `brands` VALUES ('CHEVROLET', '2013-03-04 08:13:39', '2013-03-04 08:13:39');
INSERT INTO `brands` VALUES ('DAIHATSU', '2013-03-14 16:30:24', '2013-03-14 16:30:24');
INSERT INTO `brands` VALUES ('DODGE', '2013-03-04 08:13:13', '2013-03-04 08:13:13');
INSERT INTO `brands` VALUES ('FORCE', '2013-03-14 16:27:39', '2013-03-14 16:27:39');
INSERT INTO `brands` VALUES ('FORD', '2013-03-16 10:07:54', '2013-03-16 10:07:54');
INSERT INTO `brands` VALUES ('GMC', '2013-03-07 16:31:33', '2013-03-07 16:31:33');
INSERT INTO `brands` VALUES ('HYUNDAI', '2013-03-07 16:34:12', '2013-03-07 16:34:12');
INSERT INTO `brands` VALUES ('LEXUS', '2013-03-04 08:10:01', '2013-03-04 08:10:01');
INSERT INTO `brands` VALUES ('MITSUBISHI', '2013-03-04 08:10:17', '2013-03-04 08:10:17');
INSERT INTO `brands` VALUES ('NISSAN', '2013-03-04 08:10:50', '2013-03-04 08:10:50');
INSERT INTO `brands` VALUES ('PIRELLI', '2013-03-16 09:17:35', '2013-03-16 09:17:35');
INSERT INTO `brands` VALUES ('SUZUKI', '2013-03-04 08:11:03', '2013-03-04 08:11:03');
INSERT INTO `brands` VALUES ('TOYOTA', '2013-03-04 08:11:19', '2013-03-04 08:11:19');
INSERT INTO `brands` VALUES ('VOLVO', '2013-03-04 08:11:43', '2013-03-04 08:11:54');
INSERT INTO `brands` VALUES ('YAMAHA', '2013-03-04 08:12:48', '2013-03-04 08:12:48');

-- ----------------------------
-- Table structure for `companies`
-- ----------------------------
DROP TABLE IF EXISTS `companies`;
CREATE TABLE `companies` (
  `Company` varchar(10) NOT NULL default '',
  `Name` varchar(255) default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Company`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of companies
-- ----------------------------
INSERT INTO `companies` VALUES ('CSPT-FZE', 'Centralized Spare Parts Trading - FZE', '2013-02-09 13:00:27', '2013-02-09 13:00:27');
INSERT INTO `companies` VALUES ('CSPT-INC', 'Centralized Spare Parts Trading - INC', '2013-02-09 13:00:27', '2013-02-09 13:00:27');

-- ----------------------------
-- Table structure for `currencies`
-- ----------------------------
DROP TABLE IF EXISTS `currencies`;
CREATE TABLE `currencies` (
  `Currency` varchar(10) NOT NULL default '',
  `Description` varchar(255) default '',
  `AccountCode` bigint(20) default '0',
  `ExchangeRateAccountCode` bigint(20) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Currency`),
  KEY `currencyac` (`AccountCode`),
  KEY `currencyexac` (`ExchangeRateAccountCode`),
  CONSTRAINT `currencyac` FOREIGN KEY (`AccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `currencyexac` FOREIGN KEY (`ExchangeRateAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of currencies
-- ----------------------------
INSERT INTO `currencies` VALUES ('AED', 'Arab Emirates Dirhams', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('AFA', 'Afghanistan Afghani', '54005', '34625', '2013-02-11 10:57:22', '2013-03-05 08:52:08');
INSERT INTO `currencies` VALUES ('AUD', 'Australian Dollar', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('DKK', 'Danish Krone', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('EUR', 'Euro', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('GBP', 'British Pound', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('JPY', 'Japanese Yen', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('KWD', 'Kuwaiti Dinar', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('NGN', 'Nigerian Naira', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('OMR', 'Omani Rial', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('PGK', 'Papua New Guinean Kina', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('PHP', 'Philippine Peso', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('PKR', 'Pakistani Rupee', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('SOS', 'Somali Shilling', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('UGX', 'Ugandan Shilling', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('USD', 'United States Dollar', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');
INSERT INTO `currencies` VALUES ('ZAR', 'South African Rand', '54005', '34625', '2013-02-11 10:57:22', '2013-02-11 10:57:22');

-- ----------------------------
-- Table structure for `currencydenominations`
-- ----------------------------
DROP TABLE IF EXISTS `currencydenominations`;
CREATE TABLE `currencydenominations` (
  `DetailId` mediumint(9) NOT NULL auto_increment,
  `Currency` varchar(10) default '',
  `Denomination` decimal(20,2) default '0.00',
  `Active` tinyint(4) default '1',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`),
  KEY `curdenomcurrency` (`Currency`),
  CONSTRAINT `curdenomcurrency` FOREIGN KEY (`Currency`) REFERENCES `currencies` (`Currency`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=175 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of currencydenominations
-- ----------------------------
INSERT INTO `currencydenominations` VALUES ('1', 'AED', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('2', 'AFA', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('3', 'AUD', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('4', 'DKK', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('5', 'EUR', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('6', 'GBP', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('7', 'JPY', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('8', 'KWD', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('9', 'NGN', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('10', 'OMR', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('11', 'PGK', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('12', 'PHP', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('13', 'PKR', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('14', 'SOS', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('15', 'UGX', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('16', 'USD', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('17', 'ZAR', '0.25', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('18', 'AED', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('19', 'AFA', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('20', 'AUD', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('21', 'DKK', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('22', 'EUR', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('23', 'GBP', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('24', 'JPY', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('25', 'KWD', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('26', 'NGN', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('27', 'OMR', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('28', 'PGK', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('29', 'PHP', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('30', 'PKR', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('31', 'SOS', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('32', 'UGX', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('33', 'USD', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('34', 'ZAR', '0.50', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('35', 'AED', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('36', 'AFA', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('37', 'AUD', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('38', 'DKK', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('39', 'EUR', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('40', 'GBP', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('41', 'JPY', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('42', 'KWD', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('43', 'NGN', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('44', 'OMR', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('45', 'PGK', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('46', 'PHP', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('47', 'PKR', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('48', 'SOS', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('49', 'UGX', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('50', 'USD', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('51', 'ZAR', '1.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('52', 'AED', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('53', 'AFA', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('54', 'AUD', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('55', 'DKK', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('56', 'EUR', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('57', 'GBP', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('58', 'JPY', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('59', 'KWD', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('60', 'NGN', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('61', 'OMR', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('62', 'PGK', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('63', 'PHP', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('64', 'PKR', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('65', 'SOS', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('66', 'UGX', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('67', 'USD', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('68', 'ZAR', '5.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('69', 'AED', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('70', 'AFA', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('71', 'AUD', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('72', 'DKK', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('73', 'EUR', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('74', 'GBP', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('75', 'JPY', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('76', 'KWD', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:44');
INSERT INTO `currencydenominations` VALUES ('77', 'NGN', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('78', 'OMR', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('79', 'PGK', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('80', 'PHP', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('81', 'PKR', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('82', 'SOS', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('83', 'UGX', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('84', 'USD', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('85', 'ZAR', '10.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('86', 'AED', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('87', 'AFA', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('88', 'AUD', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('89', 'DKK', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('90', 'EUR', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('91', 'GBP', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('92', 'JPY', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('93', 'KWD', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('94', 'NGN', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('95', 'OMR', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('96', 'PGK', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('97', 'PHP', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('98', 'PKR', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('99', 'SOS', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('100', 'UGX', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('101', 'USD', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('102', 'ZAR', '20.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('103', 'AED', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('104', 'AFA', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('105', 'AUD', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('106', 'DKK', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('107', 'EUR', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('108', 'GBP', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('109', 'JPY', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('110', 'KWD', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('111', 'NGN', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('112', 'OMR', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('113', 'PGK', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('114', 'PHP', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('115', 'PKR', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('116', 'SOS', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('117', 'UGX', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('118', 'USD', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('119', 'ZAR', '50.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('120', 'AED', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('121', 'AFA', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('122', 'AUD', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('123', 'DKK', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('124', 'EUR', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('125', 'GBP', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('126', 'JPY', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('127', 'KWD', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('128', 'NGN', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('129', 'OMR', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('130', 'PGK', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('131', 'PHP', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('132', 'PKR', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('133', 'SOS', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('134', 'UGX', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('135', 'USD', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('136', 'ZAR', '100.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('137', 'AED', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('138', 'AFA', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('139', 'AUD', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('140', 'DKK', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('141', 'EUR', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('142', 'GBP', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('143', 'JPY', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('144', 'KWD', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('145', 'NGN', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('146', 'OMR', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('147', 'PGK', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('148', 'PHP', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('149', 'PKR', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('150', 'SOS', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('151', 'UGX', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('152', 'USD', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('153', 'ZAR', '500.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('154', 'AED', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('155', 'AFA', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('156', 'AUD', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('157', 'DKK', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('158', 'EUR', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('159', 'GBP', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('160', 'JPY', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('161', 'KWD', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('162', 'NGN', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('163', 'OMR', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('164', 'PGK', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('165', 'PHP', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('166', 'PKR', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('167', 'SOS', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:45');
INSERT INTO `currencydenominations` VALUES ('168', 'UGX', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:46');
INSERT INTO `currencydenominations` VALUES ('169', 'USD', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:46');
INSERT INTO `currencydenominations` VALUES ('170', 'ZAR', '1000.00', '1', '2013-02-27 16:05:08', '2013-02-27 16:07:46');
INSERT INTO `currencydenominations` VALUES ('174', 'PHP', '0.10', '0', '2013-03-05 10:43:54', '2013-03-05 10:44:48');

-- ----------------------------
-- Table structure for `currencyrates`
-- ----------------------------
DROP TABLE IF EXISTS `currencyrates`;
CREATE TABLE `currencyrates` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `Currency` varchar(10) default '',
  `DateEffective` date default '1900-01-01',
  `EffectiveUntil` date default '1900-01-01',
  `Rate` double(20,4) default '100.0000',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`),
  KEY `ratecurrency` (`Currency`),
  CONSTRAINT `ratecurrency` FOREIGN KEY (`Currency`) REFERENCES `currencies` (`Currency`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of currencyrates
-- ----------------------------

-- ----------------------------
-- Table structure for `customergroups`
-- ----------------------------
DROP TABLE IF EXISTS `customergroups`;
CREATE TABLE `customergroups` (
  `CustomerGroup` varchar(175) NOT NULL default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`CustomerGroup`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of customergroups
-- ----------------------------
INSERT INTO `customergroups` VALUES ('COM - All Commercial Customers', '2013-03-03 14:07:42', '2013-03-03 14:09:42');
INSERT INTO `customergroups` VALUES ('GO - Government Organizations', '2013-03-03 14:14:29', '2013-03-03 14:14:29');
INSERT INTO `customergroups` VALUES ('GRP1 - Customer ATEMP Only', '2013-03-03 14:08:22', '2013-03-03 14:15:45');
INSERT INTO `customergroups` VALUES ('GRP2 - Customer No lemon', '2013-03-03 14:08:55', '2013-03-03 14:10:28');

-- ----------------------------
-- Table structure for `customers`
-- ----------------------------
DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers` (
  `CustomerCode` varchar(30) NOT NULL default '',
  `CustomerNo` varchar(10) default '',
  `CustomerName` varchar(175) default '',
  `CustomerGroup` varchar(175) default '',
  `Active` tinyint(4) default '1',
  `Address` longtext,
  `Country` varchar(175) default '',
  `Phone` varchar(175) default '',
  `Mobile` varchar(175) default '',
  `Fax` varchar(175) default '',
  `Email` varchar(175) default '',
  `POC` varchar(175) default '',
  `AccountCode` bigint(20) default '0',
  `PrepaymentAccountCode` bigint(20) default '0',
  `CreditLimit` decimal(20,2) default '0.00',
  `MarginPercentage` decimal(20,2) default '0.00',
  `PaymentTerm` varchar(175) default '',
  `LocationCode` varchar(30) default '',
  `UDF1` varchar(175) default '',
  `UDFValue1` varchar(255) default '',
  `UDF2` varchar(175) default '',
  `UDFValue2` varchar(255) default '',
  `UDF3` varchar(175) default '',
  `UDFValue3` varchar(255) default '',
  `UDF4` varchar(175) default '',
  `UDFValue4` varchar(255) default '',
  `UDF5` varchar(175) default '',
  `UDFValue5` varchar(255) default '',
  `UDF6` varchar(175) default '',
  `UDFValue6` varchar(255) default '',
  `Notes` longtext,
  `Company` varchar(10) default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`CustomerCode`),
  KEY `cuscustomergrp` (`CustomerGroup`),
  KEY `cuspaymentterm` (`PaymentTerm`),
  KEY `cuscompany` (`Company`),
  KEY `cuslocationcode` USING BTREE (`LocationCode`),
  KEY `cusaccountcode` (`AccountCode`),
  KEY `cusprepayaccountcode` (`PrepaymentAccountCode`),
  CONSTRAINT `cusaccountcode` FOREIGN KEY (`AccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `cuscompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE,
  CONSTRAINT `cuscustomergrp` FOREIGN KEY (`CustomerGroup`) REFERENCES `customergroups` (`CustomerGroup`) ON UPDATE CASCADE,
  CONSTRAINT `cuspaymentterm` FOREIGN KEY (`PaymentTerm`) REFERENCES `paymentterms` (`PaymentTerm`) ON UPDATE CASCADE,
  CONSTRAINT `cusprepayaccountcode` FOREIGN KEY (`PrepaymentAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of customers
-- ----------------------------

-- ----------------------------
-- Table structure for `deleteditems`
-- ----------------------------
DROP TABLE IF EXISTS `deleteditems`;
CREATE TABLE `deleteditems` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `TableName` varchar(175) default '',
  `Value` varchar(255) default '',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of deleteditems
-- ----------------------------
INSERT INTO `deleteditems` VALUES ('1', 'vehiclemodels', 'MODEL-00001', '2013-03-16 15:48:20');
INSERT INTO `deleteditems` VALUES ('2', 'vehiclemodels', 'MODEL-00003', '2013-03-16 15:48:24');
INSERT INTO `deleteditems` VALUES ('3', 'models', 'MODEL-00001', '2013-03-16 15:48:28');
INSERT INTO `deleteditems` VALUES ('6', 'stockadjustments', 'ADJ-CSPT-FZE-00007', '2013-03-18 17:25:06');
INSERT INTO `deleteditems` VALUES ('7', 'stockadjustments', 'ADJ-CSPT-FZE-00010', '2013-03-19 08:44:46');

-- ----------------------------
-- Table structure for `departments`
-- ----------------------------
DROP TABLE IF EXISTS `departments`;
CREATE TABLE `departments` (
  `Department` varchar(150) NOT NULL default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Department`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of departments
-- ----------------------------
INSERT INTO `departments` VALUES ('Administration', '2013-03-07 14:17:22', '2013-03-07 14:17:22');
INSERT INTO `departments` VALUES ('Executive Management', '2013-03-02 11:08:11', '2013-03-02 11:08:11');
INSERT INTO `departments` VALUES ('Finance', '2013-03-02 09:26:30', '2013-03-02 09:27:49');
INSERT INTO `departments` VALUES ('IT Department', '2013-03-02 12:22:26', '2013-03-02 12:22:26');
INSERT INTO `departments` VALUES ('Product & Procurement', '2013-03-02 09:26:13', '2013-03-02 09:26:13');
INSERT INTO `departments` VALUES ('Sales', '2013-03-02 09:27:11', '2013-03-02 09:27:11');
INSERT INTO `departments` VALUES ('Systems Development', '2013-02-09 12:21:36', '2013-02-09 12:21:36');
INSERT INTO `departments` VALUES ('Systems Support', '2013-03-02 12:20:09', '2013-03-02 12:20:09');

-- ----------------------------
-- Table structure for `keysettings`
-- ----------------------------
DROP TABLE IF EXISTS `keysettings`;
CREATE TABLE `keysettings` (
  `TableName` varchar(175) NOT NULL,
  `Counter` bigint(20) default '0',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`TableName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of keysettings
-- ----------------------------
INSERT INTO `keysettings` VALUES ('locations', '5', '2013-03-03 17:01:39');
INSERT INTO `keysettings` VALUES ('models', '8', '2013-03-16 10:08:07');
INSERT INTO `keysettings` VALUES ('parts', '6', '2013-03-19 16:45:48');
INSERT INTO `keysettings` VALUES ('scripts', '2', '2013-03-11 08:49:26');
INSERT INTO `keysettings` VALUES ('stockadjustments', '12', '2013-03-19 09:09:31');
INSERT INTO `keysettings` VALUES ('vehiclemakes', '6', '2013-03-06 13:14:30');

-- ----------------------------
-- Table structure for `locations`
-- ----------------------------
DROP TABLE IF EXISTS `locations`;
CREATE TABLE `locations` (
  `LocationCode` varchar(30) NOT NULL default '',
  `Location` varchar(175) NOT NULL default '',
  `Company` varchar(10) NOT NULL default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Location`,`Company`),
  UNIQUE KEY `locloccode` USING BTREE (`LocationCode`),
  KEY `loccompany` (`Company`),
  CONSTRAINT `loccompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of locations
-- ----------------------------
INSERT INTO `locations` VALUES ('CSPT-FZE-00005', '1A1', 'CSPT-FZE', '2013-03-03 17:01:40', '2013-03-03 17:01:40');
INSERT INTO `locations` VALUES ('CSPT-FZE-00003', 'LIT', 'CSPT-FZE', '2013-03-03 16:58:53', '2013-03-03 16:58:53');
INSERT INTO `locations` VALUES ('CSPT-FZE-00002', 'SIT', 'CSPT-FZE', '2013-03-03 16:58:25', '2013-03-03 16:58:25');
INSERT INTO `locations` VALUES ('CSPT-FZE-00001', 'WIP', 'CSPT-FZE', '2013-03-03 16:52:52', '2013-03-03 16:52:52');

-- ----------------------------
-- Table structure for `locks`
-- ----------------------------
DROP TABLE IF EXISTS `locks`;
CREATE TABLE `locks` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `Username` varchar(30) default '',
  `Reference` varchar(175) default '',
  `ReferenceNo` varchar(30) default '',
  PRIMARY KEY  (`DetailId`),
  KEY `locksusername` (`Username`),
  CONSTRAINT `locksusername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of locks
-- ----------------------------

-- ----------------------------
-- Table structure for `measurements`
-- ----------------------------
DROP TABLE IF EXISTS `measurements`;
CREATE TABLE `measurements` (
  `Unit` varchar(10) NOT NULL default '',
  `Description` varchar(150) default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Unit`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of measurements
-- ----------------------------
INSERT INTO `measurements` VALUES ('Bag', '', '2013-03-06 10:04:07', '2013-03-06 10:04:07');
INSERT INTO `measurements` VALUES ('Bottle', '', '2013-03-06 10:04:12', '2013-03-06 10:05:01');
INSERT INTO `measurements` VALUES ('Box', '', '2013-03-06 10:04:31', '2013-03-06 10:04:31');
INSERT INTO `measurements` VALUES ('Bucket', '', '2013-03-06 10:04:37', '2013-03-06 10:04:37');
INSERT INTO `measurements` VALUES ('Kg', 'Kilogram', '2013-03-14 16:46:10', '2013-03-14 16:46:10');
INSERT INTO `measurements` VALUES ('Pc(s)', 'Pieces', '2013-03-06 10:05:57', '2013-03-06 10:05:57');

-- ----------------------------
-- Table structure for `models`
-- ----------------------------
DROP TABLE IF EXISTS `models`;
CREATE TABLE `models` (
  `ModelCode` varchar(30) NOT NULL,
  `Model` varchar(175) NOT NULL default '',
  `Brand` varchar(175) NOT NULL default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Model`,`Brand`),
  UNIQUE KEY `mdlcode` USING BTREE (`ModelCode`),
  KEY `modelbrand` (`Brand`),
  CONSTRAINT `modelbrand` FOREIGN KEY (`Brand`) REFERENCES `brands` (`Brand`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of models
-- ----------------------------
INSERT INTO `models` VALUES ('MODEL-00002', 'COROLLA', 'TOYOTA', '2013-03-06 11:44:08', '2013-03-06 11:44:08');
INSERT INTO `models` VALUES ('MODEL-00008', 'EXPEDITION', 'FORD', '2013-03-16 10:08:07', '2013-03-16 10:08:07');
INSERT INTO `models` VALUES ('MODEL-00007', 'FT', 'FORCE', '2013-03-14 16:43:35', '2013-03-14 16:43:35');
INSERT INTO `models` VALUES ('MODEL-00004', 'HIACE', 'TOYOTA', '2013-03-06 11:51:52', '2013-03-06 11:54:19');
INSERT INTO `models` VALUES ('MODEL-00005', 'HILUX', 'TOYOTA', '2013-03-06 13:06:48', '2013-03-06 13:07:27');
INSERT INTO `models` VALUES ('MODEL-00006', 'LAND CRUISER', 'TOYOTA', '2013-03-06 13:14:30', '2013-03-06 13:14:47');

-- ----------------------------
-- Table structure for `partcategories`
-- ----------------------------
DROP TABLE IF EXISTS `partcategories`;
CREATE TABLE `partcategories` (
  `PartCategory` varchar(150) NOT NULL default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`PartCategory`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of partcategories
-- ----------------------------
INSERT INTO `partcategories` VALUES ('AGP Glass', '2013-03-04 10:25:10', '2013-03-04 10:25:10');
INSERT INTO `partcategories` VALUES ('ARB', '2013-03-04 10:25:29', '2013-03-04 10:25:29');
INSERT INTO `partcategories` VALUES ('Batteries', '2013-03-04 10:27:05', '2013-03-04 10:27:47');
INSERT INTO `partcategories` VALUES ('Consumables', '2013-03-04 10:28:19', '2013-03-04 10:28:19');
INSERT INTO `partcategories` VALUES ('Genuine Spare Parts', '2013-03-04 10:28:33', '2013-03-04 10:28:33');
INSERT INTO `partcategories` VALUES ('Oils and Lubricants', '2013-03-07 16:21:48', '2013-03-07 16:21:48');
INSERT INTO `partcategories` VALUES ('Others', '2013-03-04 10:28:53', '2013-03-04 10:28:53');
INSERT INTO `partcategories` VALUES ('Tires', '2013-03-04 10:29:22', '2013-03-04 10:29:22');
INSERT INTO `partcategories` VALUES ('Tools and Equipments', '2013-03-04 10:29:06', '2013-03-04 10:29:06');

-- ----------------------------
-- Table structure for `partnames`
-- ----------------------------
DROP TABLE IF EXISTS `partnames`;
CREATE TABLE `partnames` (
  `PartName` varchar(255) NOT NULL default '',
  `PartCategory` varchar(150) default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`PartName`),
  KEY `partcateg` (`PartCategory`),
  CONSTRAINT `partcateg` FOREIGN KEY (`PartCategory`) REFERENCES `partcategories` (`PartCategory`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of partnames
-- ----------------------------
INSERT INTO `partnames` VALUES ('Bearing Clutch', 'Genuine Spare Parts', '2013-03-16 09:10:53', '2013-03-16 09:10:53');
INSERT INTO `partnames` VALUES ('Combination Wrench', 'Tools and Equipments', '2013-03-06 13:47:19', '2013-03-16 15:58:08');
INSERT INTO `partnames` VALUES ('Oil Seal', 'Genuine Spare Parts', '2013-03-14 16:24:58', '2013-03-14 16:24:58');
INSERT INTO `partnames` VALUES ('Pinion', 'Genuine Spare Parts', '2013-03-06 13:48:32', '2013-03-06 13:48:32');
INSERT INTO `partnames` VALUES ('Seal', 'Genuine Spare Parts', '2013-03-16 10:07:41', '2013-03-16 10:07:41');
INSERT INTO `partnames` VALUES ('Tires', 'Tires', '2013-03-06 13:48:55', '2013-03-06 13:49:06');

-- ----------------------------
-- Table structure for `parts`
-- ----------------------------
DROP TABLE IF EXISTS `parts`;
CREATE TABLE `parts` (
  `PartCode` varchar(30) NOT NULL default '',
  `PartNo` varchar(50) default '',
  `PartName` varchar(255) default '',
  `Description` varchar(255) default '',
  `SuperPartCode` varchar(30) default '',
  `Brand` varchar(150) default '',
  `ModelCode` varchar(160) default '',
  `Unit` varchar(10) default '',
  `ReorderPoint` int(11) default '0',
  `ReorderQty` int(11) default '0',
  `StockType` int(11) default '0',
  `OriginatingCountry` varchar(150) default '',
  `Active` tinyint(4) default '1',
  `UDF1` varchar(150) default '',
  `UDFValue1` varchar(255) default '',
  `UDF2` varchar(150) default '',
  `UDFValue2` varchar(255) default '',
  `UDF3` varchar(150) default '',
  `UDFValue3` varchar(255) default '',
  `UDF4` varchar(150) default '',
  `UDFValue4` varchar(255) default '',
  `UDF5` varchar(150) default '',
  `UDFValue5` varchar(255) default '',
  `UDF6` varchar(150) default '',
  `UDFValue6` varchar(255) default '',
  `Notes` longtext,
  `Company` varchar(10) default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`PartCode`),
  KEY `prtunit` (`Unit`),
  KEY `prtpartname` (`PartName`),
  KEY `prtpartcode` USING BTREE (`SuperPartCode`),
  KEY `prtcompany` (`Company`),
  KEY `prtmodelcode` USING BTREE (`ModelCode`),
  KEY `prtbrand` (`Brand`),
  CONSTRAINT `prtbrand` FOREIGN KEY (`Brand`) REFERENCES `brands` (`Brand`) ON UPDATE CASCADE,
  CONSTRAINT `prtcompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE,
  CONSTRAINT `prtpartname` FOREIGN KEY (`PartName`) REFERENCES `partnames` (`PartName`) ON UPDATE CASCADE,
  CONSTRAINT `prtunit` FOREIGN KEY (`Unit`) REFERENCES `measurements` (`Unit`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of parts
-- ----------------------------
INSERT INTO `parts` VALUES ('PART-CSPT-FZE-00001', '75513', 'Combination Wrench', 'Combination Wrench 10mm', '', 'ALL', '', 'Pc(s)', '0', '0', '2', 'Taiwan', '1', 'User-defined Field 1', '', 'User-defined Field 2', '', 'User-defined Field 3', '', 'User-defined Field 4', '', 'User-defined Field 5', '', 'User-defined Field 6', '', '', 'CSPT-FZE', '1900-01-01 00:00:00', '2013-03-16 15:58:08');
INSERT INTO `parts` VALUES ('PART-CSPT-FZE-00002', '235-85-R16', 'Tires', 'Pirelli Scorpion Mud Tires', '', 'PIRELLI', '', 'Pc(s)', '0', '0', '2', 'Brazil', '1', 'User-defined Field 1', '', 'User-defined Field 2', '', 'User-defined Field 3', '', 'User-defined Field 4', '', 'User-defined Field 5', '', 'User-defined Field 6', '', '', 'CSPT-FZE', '2013-03-16 09:29:27', '2013-03-16 09:30:46');
INSERT INTO `parts` VALUES ('PART-CSPT-FZE-00003', '7W7Z7052A', 'Seal', 'Seal', '', 'FORD', 'MODEL-00008', 'Pc(s)', '0', '0', '2', 'United States', '1', 'User-defined Field 1', '', 'User-defined Field 2', '', 'User-defined Field 3', '', 'User-defined Field 4', '', 'User-defined Field 5', '', 'User-defined Field 6', '', '', 'CSPT-FZE', '2013-03-16 10:08:23', '2013-03-16 10:08:23');
INSERT INTO `parts` VALUES ('PART-CSPT-FZE-00004', '7W7Z7052B', 'Seal', 'Seal', 'PART-CSPT-FZE-00003', 'ALL', '', 'Pc(s)', '0', '0', '2', 'Brazil', '1', 'User-defined Field 1', '', 'User-defined Field 2', '', 'User-defined Field 3', '', 'User-defined Field 4', '', 'User-defined Field 5', '', 'User-defined Field 6', '', '', 'CSPT-FZE', '2013-03-19 11:57:27', '2013-03-19 16:27:08');
INSERT INTO `parts` VALUES ('PART-CSPT-FZE-00005', '7W7Z7052C', 'Seal', 'Seal', 'PART-CSPT-FZE-00003', 'FORD', 'MODEL-00008', 'Pc(s)', '0', '0', '2', 'Japan', '1', 'User-defined Field 1', '', 'User-defined Field 2', '', 'User-defined Field 3', '', 'User-defined Field 4', '', 'User-defined Field 5', '', 'User-defined Field 6', '', '', 'CSPT-FZE', '2013-03-19 12:34:05', '2013-03-19 15:54:35');
INSERT INTO `parts` VALUES ('PART-CSPT-FZE-00006', '7W7Z7052D', 'Seal', 'Seal', 'PART-CSPT-FZE-00003', 'FORD', 'MODEL-00008', 'Pc(s)', '0', '0', '2', 'Brazil', '1', 'User-defined Field 1', '', 'User-defined Field 2', '', 'User-defined Field 3', '', 'User-defined Field 4', '', 'User-defined Field 5', '', 'User-defined Field 6', '', '', 'CSPT-FZE', '2013-03-19 16:45:48', '2013-03-19 16:45:48');

-- ----------------------------
-- Table structure for `paymentterms`
-- ----------------------------
DROP TABLE IF EXISTS `paymentterms`;
CREATE TABLE `paymentterms` (
  `PaymentTerm` varchar(175) NOT NULL default '',
  `Description` varchar(255) default '',
  `Term` varchar(175) default '',
  `Days` int(11) default '0',
  `Months` int(11) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`PaymentTerm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of paymentterms
-- ----------------------------
INSERT INTO `paymentterms` VALUES ('15 Days PDC', 'PDC 15 Days', 'Net', '15', '0', '2013-03-05 13:08:03', '2013-03-05 13:08:03');
INSERT INTO `paymentterms` VALUES ('30 Days PDC', 'PDC 30 Days', 'Net', '30', '0', '2013-03-05 13:05:59', '2013-03-05 13:07:04');
INSERT INTO `paymentterms` VALUES ('CAD', 'Cash Against Document', 'Net', '0', '0', '2013-03-05 13:19:52', '2013-03-05 13:20:06');
INSERT INTO `paymentterms` VALUES ('Net Cash', 'Net Cash', 'Net', '0', '0', '2013-03-05 13:04:16', '2013-03-05 13:04:16');

-- ----------------------------
-- Table structure for `positions`
-- ----------------------------
DROP TABLE IF EXISTS `positions`;
CREATE TABLE `positions` (
  `Position` varchar(150) NOT NULL default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`Position`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of positions
-- ----------------------------
INSERT INTO `positions` VALUES ('Accounting Manager', '2013-03-03 11:38:21', '2013-03-03 11:38:21');
INSERT INTO `positions` VALUES ('Area Sales Manager', '2013-03-07 14:24:51', '2013-03-07 14:24:51');
INSERT INTO `positions` VALUES ('Chief Executive Officer', '2013-03-03 11:39:27', '2013-03-03 11:43:22');
INSERT INTO `positions` VALUES ('IT Manager', '2013-03-03 11:37:51', '2013-03-03 11:37:51');
INSERT INTO `positions` VALUES ('Project Team Leader', '2013-02-09 12:21:36', '2013-02-09 12:21:36');
INSERT INTO `positions` VALUES ('Systems Administrator', '2013-03-03 11:31:09', '2013-03-03 11:31:09');
INSERT INTO `positions` VALUES ('Vice President', '2013-03-03 11:45:42', '2013-03-03 11:45:42');

-- ----------------------------
-- Table structure for `scripts`
-- ----------------------------
DROP TABLE IF EXISTS `scripts`;
CREATE TABLE `scripts` (
  `ReferenceNo` varchar(30) NOT NULL,
  `Title` varchar(175) default '',
  `Author` varchar(255) default '',
  `Script` longtext,
  `SystemVersion` varchar(30) default '',
  `RequireBackup` tinyint(4) default '0',
  `RequireAppRestart` tinyint(4) default '0',
  `RequirePcRestart` tinyint(4) default '0',
  `Description` varchar(255) default '',
  `Executed` tinyint(4) default '0',
  `AutoScript` tinyint(4) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `DateExecuted` datetime default NULL,
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`ReferenceNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of scripts
-- ----------------------------
INSERT INTO `scripts` VALUES ('SQL-CSPT-FZE-00001', '1st sample script', 'Joseph Lambert Reyes', 'SELECT CURDATE() AS `Date`\nUNION ALL\nSELECT DATE(NOW()) AS `Date`\nUNION ALL\nSELECT CAST(\'1900-01-01\' AS date) AS `Date`;', '1.0.0.0', '1', '1', '0', 'sample only.', '1', '0', '2013-03-09 11:23:11', '2013-03-11 08:43:36', '2013-03-10 14:54:02');
INSERT INTO `scripts` VALUES ('SQL-CSPT-FZE-00002', '2nd sample script', 'Joseph Lambert Reyes', 'SELECT CURDATE() AS `Date`\nUNION ALL\nSELECT DATE(NOW()) AS `Date`\nUNION ALL\nSELECT CAST(\'1900-01-01\' AS date) AS `Date`;', '1.0.0.0', '1', '1', '0', '2nd sample script', '1', '0', '2013-03-11 08:49:26', '2013-03-11 17:27:48', '2013-03-11 08:49:26');

-- ----------------------------
-- Table structure for `settings`
-- ----------------------------
DROP TABLE IF EXISTS `settings`;
CREATE TABLE `settings` (
  `Company` varchar(10) NOT NULL,
  `Address` longtext,
  `Country` varchar(175) default '',
  `Phone` varchar(175) default '',
  `Mobile` varchar(175) default '',
  `Fax` varchar(175) default '',
  `Email` varchar(175) default '',
  `CompanyLogo` longblob,
  `ReportLogo` longblob,
  `CashAdvanceAccountCode` bigint(20) default '0',
  `RawMaterialAccountCode` bigint(20) default '0',
  `StockConsumptionAccountCode` bigint(20) default '0',
  `StockAdjustmentAccountCode` bigint(20) default NULL,
  `UnallocatedPaymentAccountCode` bigint(20) default '0',
  `RollForwardAccountCode` bigint(20) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `LastRestored` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`Company`),
  KEY `gscaaccount` (`CashAdvanceAccountCode`),
  KEY `gsupaccount` (`UnallocatedPaymentAccountCode`),
  KEY `gsrfaccount` (`RollForwardAccountCode`),
  KEY `gsstconsaccountcode` (`RawMaterialAccountCode`),
  KEY `gsstadjaccountcode` (`StockAdjustmentAccountCode`),
  CONSTRAINT `gscaaccount` FOREIGN KEY (`CashAdvanceAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `gscompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE,
  CONSTRAINT `gsrawmataccount` FOREIGN KEY (`RawMaterialAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `gsrfaccount` FOREIGN KEY (`RollForwardAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `gsstadjaccountcode` FOREIGN KEY (`StockAdjustmentAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `gsstconsaccountcode` FOREIGN KEY (`RawMaterialAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `gsupaccount` FOREIGN KEY (`UnallocatedPaymentAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of settings
-- ----------------------------
INSERT INTO `settings` VALUES ('CSPT-FZE', 'RAKFTZ Technology Park Shed 10, Warehouse 1, P.O. Box: 54569 Ras Al Khaimah', 'U.A.E.', '+971(0)7 244 5800', '', '+971(0)7 244 5825', 'info@c-s-p-t.com', 0x89504E470D0A1A0A0000000D494844520000021C000000C30806000000C909C8AF0000000467414D410000B18E7CFB5193000000206348524D0000870F00008C0F0000FD520000814000007D790000E98B00003CE5000019CC733C857700000A396943435050686F746F73686F70204943432070726F66696C65000048C79D96775454D71687CFBD777AA1CD30025286DEBBC000D27B935E456198196028030E3334B121A2021145449A224850C480D150245644B1101454B007240828311845542C6F46D68BAEACBCF7F2F2FBE3AC6FEDB3F7B9FBECBDCF5A170092A72F9797064B0190CA13F0833C9CE911915174EC0080011E608029004C5646BA5FB07B0810C9CBCD859E2172025F0401F07A58BC0270D3D033804E07FF9FA459E97C81E89800119BB339192C11178838254B902EB6CF8A981A972C66182566BE284111CB893961910D3EFB2CB2A398D9A93CB688C539A7B353D962EE15F1B64C2147C488AF880B33B99C2C11DF12B1468A30952BE237E2D8540E33030014496C1770588922361131891F12E422E2E500E048095F71DC572CE0640BC49772494BCFE173131205741D962EDDD4DA9A41F7E464A5700402C300262B99C967D35DD252D399BC1C0016EFFC5932E2DAD24545B634B5B6B434343332FDAA50FF75F36F4ADCDB457A19F8B96710ADFF8BEDAFFCD21A0060CC896AB3F38B2DAE0A80CE2D00C8DDFB62D3380080A4A86F1DD7BFBA0F4D3C2F890241BA8DB1715656961197C3321217F40FFD4F87BFA1AFBE67243EEE8FF2D05D39F14C618A802EAE1B2B2D254DC8A767A433591CBAE19F87F81F07FE751E06419C780E9FC313458489A68CCB4B10B59BC7E60AB8693C3A97F79F9AF80FC3FEA4C5B91689D2F81150638C80D4752A407EED07280A1120D1FBC55DFFA36FBEF830207E79E12A938B73FFEF37FD67C1A5E225839BF039CE252884CE12F23317F7C4CF12A0010148022A9007CA401DE800436006AC802D70046EC01BF8831010095603164804A9800FB2401ED8040A4131D809F6806A50071A41336805C741273805CE834BE01AB8016E83FB60144C80676016BC060B10046121324481E421154813D287CC2006640FB941BE50101409C54209100F124279D066A8182A83AAA17AA819FA1E3A099D87AE4083D05D680C9A867E87DEC1084C82A9B012AC051BC30CD809F68143E0557002BC06CE850BE01D7025DC001F853BE0F3F035F8363C0A3F83E7108010111AA28A18220CC405F147A29078848FAC478A900AA4016945BA913EE426328ACC206F51181405454719A26C519EA850140BB506B51E5582AA461D4675A07A51375163A859D4473419AD88D647DBA0BDD011E8047416BA105D816E42B7A32FA26FA327D0AF31180C0DA38DB1C2786222314998B59812CC3E4C1BE61C6610338E99C362B1F2587DAC1DD61FCBC40AB085D82AEC51EC59EC107602FB0647C4A9E0CC70EEB8281C0F978FABC01DC19DC10DE126710B7829BC26DE06EF8F67E373F0A5F8467C37FE3A7E02BF4090266813EC08218424C2264225A1957091F080F0924824AA11AD8981442E7123B192788C789938467C4B9221E9915C48D124216907E910E91CE92EE925994CD6223B92A3C802F20E7233F902F911F98D0445C248C24B822DB141A246A2436248E2B9245E5253D24972B564AE6485E409C9EB92335278292D291729A6D47AA91AA99352235273D2146953697FE954E912E923D257A4A764B0325A326E326C99029983321764C62908459DE242615136531A29172913540C559BEA454DA21653BFA30E506765656497C986C966CBD6C89E961DA521342D9A172D85564A3B4E1BA6BD5BA2B4C4690967C9F625AD4B8696CCCB2D957394E3C815C9B5C9DD967B274F9777934F96DF25DF29FF5001A5A0A710A890A5B05FE1A2C2CC52EA52DBA5ACA5454B8F2FBDA7082BEA290629AE553CA8D8AF38A7A4ACE4A194AE54A57441694699A6ECA89CA45CAE7C46795A85A262AFC255295739ABF2942E4B77A2A7D02BE9BDF4595545554F55A16ABDEA80EA829AB65AA85ABE5A9BDA4375823A433D5EBD5CBD477D564345C34F234FA345E39E265E93A199A8B957B34F735E4B5B2B5C6BAB56A7D694B69CB69776AE768BF6031DB28E83CE1A9D069D5BBA185D866EB2EE3EDD1B7AB09E855EA25E8DDE757D58DF529FABBF4F7FD0006D606DC0336830183124193A19661AB6188E19D18C7C8DF28D3A8D9E1B6B184719EF32EE33FE6862619262D26872DF54C6D4DB34DFB4DBF477333D3396598DD92D73B2B9BBF906F32EF317CBF4977196ED5F76C78262E167B1D5A2C7E283A59525DFB2D572DA4AC32AD6AAD66A84416504304A1897ADD1D6CED61BAC4F59BFB5B1B411D81CB7F9CDD6D036D9F688EDD472EDE59CE58DCBC7EDD4EC9876F576A3F674FB58FB03F6A30EAA0E4C870687C78EEA8E6CC726C749275DA724A7A34ECF9D4D9CF9CEEDCEF32E362EEB5CCEB922AE1EAE45AE036E326EA16ED56E8FDCD5DC13DC5BDC673D2C3CD67A9CF3447BFA78EEF21CF152F26279357BCD7A5B79AFF3EEF521F904FB54FB3CF6D5F3E5FB76FBC17EDE7EBBFD1EACD05CC15BD1E90FFCBDFC77FB3F0CD00E5813F06320263020B026F0499069505E505F30253826F848F0EB10E790D290FBA13AA1C2D09E30C9B0E8B0E6B0F970D7F0B2F0D108E3887511D7221522B9915D51D8A8B0A8A6A8B9956E2BF7AC9C88B6882E8C1E5EA5BD2A7BD595D50AAB53569F8E918C61C69C8845C786C71E897DCFF4673630E7E2BCE26AE366592EACBDAC676C4776397B9A63C729E34CC6DBC597C54F25D825EC4E984E7448AC489CE1BA70ABB92F923C93EA92E693FD930F257F4A094F694BC5A5C6A69EE4C9F09279BD69CA69D96983E9FAE985E9A36B6CD6EC5933CBF7E137654019AB32BA0454D1CF54BF5047B8453896699F5993F9262B2CEB44B674362FBB3F472F677BCE64AE7BEEB76B516B596B7BF254F336E58DAD735A57BF1E5A1FB7BE6783FA86820D131B3D361EDE44D894BCE9A77C93FCB2FC579BC337771728156C2C18DFE2B1A5A550A2905F38B2D5766BDD36D436EEB681EDE6DBABB67F2C62175D2D3629AE287E5FC22AB9FA8DE93795DF7CDA11BF63A0D4B274FF4ECC4EDECEE15D0EBB0E974997E5968DEFF6DBDD514E2F2F2A7FB52766CF958A6515757B097B857B472B7D2BBBAA34AA7656BDAF4EACBE5DE35CD356AB58BBBD767E1F7BDFD07EC7FDAD754A75C575EF0E700FDCA9F7A8EF68D06AA83888399879F049635863DFB78C6F9B9B149A8A9B3E1CE21D1A3D1C74B8B7D9AAB9F988E291D216B845D8327D34FAE88DEF5CBFEB6A356CAD6FA3B5151F03C784C79E7E1FFBFDF0719FE33D2718275A7FD0FCA1B69DD25ED40175E474CC7626768E7645760D9EF43ED9D36DDBDDFEA3D18F874EA99EAA392D7BBAF40CE14CC1994F6773CFCE9D4B3F37733EE1FC784F4CCFFD0B11176EF506F60E5CF4B978F992FBA50B7D4E7D672FDB5D3E75C5E6CAC9AB8CAB9DD72CAF75F45BF4B7FF64F153FB80E540C775ABEB5D37AC6F740F2E1F3C33E43074FEA6EBCD4BB7BC6E5DBBBDE2F6E070E8F09D91E891D13BEC3B537753EEBEB897796FE1FEC607E807450FA51E563C527CD4F0B3EECF6DA396A3A7C75CC7FA1F073FBE3FCE1A7FF64BC62FEF270A9E909F544CAA4C364F994D9D9A769FBEF174E5D38967E9CF16660A7F95FEB5F6B9CEF31F7E73FCAD7F366276E205FFC5A7DF4B5ECABF3CF46AD9AB9EB980B947AF535F2FCC17BD917F73F82DE36DDFBBF077930B59EFB1EF2B3FE87EE8FEE8F3F1C1A7D44F9FFE050398F3FCBAC4E8D3000000097048597300000B1100000B11017F645F9100007B9749444154785EED9D07981445DAC77B5936127602BB0495A020028264246F00CC11F5F40C60CEE90C48900C9273CE4190A018503262D633E7702AA6BBF3BE3B03775EC03BA5BEFFBFA76BA96D7A667AE2CEEE14CFF33E3BCC74575757BD55F5ABF77DABCAA8BFF05523DED260E12B46C3F9AF180DE6BD6C3498FB92517FEE8B46FDD9CF1B4590C259CF1985339F350A673C63144EDF67F8A73F6DF8A6EE317C53F618FE29BB0DDFE45D867FF24EC33F6987E11BFB84E1BBFF11C337724B1879C4F0E23AEFF0CD8667F826C3338CB2D1F00CDD60140CD9607886AC370AEE85DCF3A0299EBBD69AE2BD73356495E1BD6395E1BB7DA5E1BF6D85E183F86F5966F84288F79AB986F7AAD9C1A410BFBDEB1D3CEBA06FF0CC83BE41330FFA07CD38E8BF62FA41FFE5D34CF15E36F5A0F7D229073DBF9D6C4AC125930ED685D4F9CD44536A5D34E1606D48FE85E30FE60F1C77306FE0D883B994F3C71CCC396F34E5F5EC7347D58318D542068E37B24FB9C3C81E707BE472E67D4656B38E46568D0C232B27478B2E03AD035A07B40EA4800E08210CBBC41D36082FD51D3808232180A308BF7D02E010000E01E010000E01E010800D53001C02C021001BA6003804804300364C017008008700700800870070080087007008C006E53D804661D5878D9146F685938CECBE571B5959994656CD1A510840233B4B773029D0C168E0D3C0AB7540EB80D4010D1C915938BA012CEA05B37478AF9C150C3A081C1F271838DEADF2C0710E60E337538DEC3E570680214B4383EEAC7567AD7540EB4075D1010D1CEE80E322B854560134FEE8BB79E948EFCD4B0D47B97E81068E685D3A166C6499B0810E86960D3D43D765A07540EB80D6816AA3031A38820347116238EE85EC431CC74F000E01E010008EBF01366A05850EE7380E6DE108072217D18D72156023CFC8CAD4B0A1614BCF6AB50E681DA86E3AA081A32270642268B41D8246E72368F44BC0C62F1001E0100A7008C0C6F58EC071D3126DE10807164EBF5F303110B3919D0BCB06E236F48C469781D601AD035A07AA9D0E68E0080087172B544E83EC0070FC0CE010000E41D808021C2F796F5A52036254901B176BE08814384CD8B82610B3A1033DAB5D07A3E151CFD2B50E681DD041A38165B12702366E81BC04D810140007242C70FC04D018E0081CCECB63B54BE50810B156A31413366AEA8156CFE6B40E681DD03A50CD75201D2D1C59D887E34CECC33105C0F1B7BAF73C28001C266C44001C02B0B1DE73D362E308B971A1E1B05A4503870A1C72358AE946D1AB51F40C50CF00B50E681D48071D4827E0688A8DBF6EC6C65F8F7A866CF85FC190F502C02162008E3F7A6E5CDC1A625490EB357084DC0BA47C350A034419B3A10344D3A1A3D1EFA80754AD035A07D201383A61A7D199D869F403008700700800878803700880C6040D1C11EE6CCAD528C5B46CC8D528808E6A6E46D4EFA73B5AAD035A07B40EE41CB1CB2801A43AEC349AE31BF9C8E9D8DAFC71DFF0CD7F057008000724EEC0F11C80A3505B385C42070344CD980DBD1A45773E7A00D23AA07520DD74A0EA5938C66D0D77964A06CE599900E0F82F8043003844E28063D121EF8D8B2EF5DCB8086E154B18D771DD7C7B1C878EE13061E35AC046B6DE41545B74B4554BEB80D68134D4812A061CDB0DDF0338C06D0C0E700B7D78DB19000E9104E010008EB5808DACC3D02181A3C2416E690C1C5C8DF20060E33ABDEC350D3B98749BC1E9F7D5560BAD03C175A0EA01C7C4ED867F22A0233470140038DE4E0670786E58F457EF0D8B3A430C531034EAB916168E6BE6A97B72A427709801A2532C378AB66CE88E480F465A07B40EA4B30E5451E0D86678714CBD77C4C38123E89DE56A1C639F68978A00700880C638484D15383CD70238AE9E23A123FD8043AE4629DF4154AF4649E78E46BFBB1E68B50E681DA89AC03101C031711B5C2B8F87028EE3011CFB131CC32181E3AF9EEB1716420CEF750B4C0B8787160E6E026642C71C3F4E8BFD28AD4E8B3557A3304034DF3A1B45AF46D11DAEEE70B50E681D48671DA8BAC031E129C32F034861E1005CD8A506BE9B9C24E010808DEB1C802303C05103C0710A80E3ABB4010E068896206623074B5FF53E1B3A384EC7AE681DD03AA075003A50B58163FC93861F560E1F5C2B0EC0C1EFFA7B876FFE670257A9480B0781E325CFF50B7CB07034878563302C1C8B60E1780BC07100C0F11F00C7A1B4008E72D860CC86DEB23C9D6733FADDF56C5EEB80D6015507AA0A7064FB27EF6CE19F84552A0C1AA54B85160E0207C40BE8F08CD8EC24B5001C4F260938001D0BFE00E010000E81A051C85C01E010000EC86C51BD81C35A8D52727D60E96B0E4537365D065A07B40E681DD03A10D081AA001C19BEC9BB660038BE0170F43E0238E056A16BC58B552B008B23A003C0710DBEFF4F6236FE5AA45A38081C222D81A37C350ADD2850AC2C9C8FA261439781D601AD035A07B40E283A50158063B27FF22E01E010008EAF011C3D2B583818C741E818FD9881780D038061171F8003DB9A2762A7D1F4038E9CF3461B46BF7B0DA3F8AEC372D6B8C0A65E3A6643772E7A80D13AA07540EB40101D4869E0F04FD933D53F653760A31C380480E31B0047CF72978A040E2C93F58D7A34B054D6061D008E69008E5FE3BFB5797A00474D58308C014302D2E37663F4FAA78DC75FF9A85C6E99B8D0C8C8A985D5281968687A358AB6EE6813BAD601AD035A078ED48154068EC9FEA97B0E39008700707C0BE0E861C67048E060F028AC1C662C075D2B15A50580E36F1A38C29F799205B8A871D6FDA6649D33CAC8C0DF66574F37DEFBF2FF4C79F7F33F1FE1875BBB7299C17FBA81E94E56EB80D601AD035A0782E9402A0247A67FFAD313FDD3001B53F78820C021001CDF0238BAABC0E1A55B05560E07E030001C4F68E0080D1CC6A9430D5A338E193CD56830708CB1E38D3F183FFEF33FC64FFFFED931D8472ACF92A54B35706833B2064EAD035A07B40E84D48154038ECCC2E9FB260038847FFA5E110A387C139E12008E3F02387A98311CDC04CC020EEF48EC3E4AB7CAB04DAAF4D3C0E1001C8CC938E53EC3E83FC4E87CCB3CE38E25DB42C28593C268E0D0331A3DABD53AA07540EB40381D4825E0C8289CF1CC44000760C3357008C0C6D7901E158063D416735F0EEFB08D9604C003C0F1B667E806E119B241140C592F0AEE5D2FEADEF3A0288078EE5A6B8AF7CED59055C27BC72AE1BB7DA529FEDB5608FF2DCB848F72F352E1A5DCB444E0C0B62ABB4AC50CFE3C6D986174BFCD281EBADCB866CEA3118386B670E80E265C07A37FD73AA27540EB80D48154028E89000E51382362E010808DAFFC639F3899311C66E0288183CB64653CC7D08D862720976BE0186598B05176AFD1EE96B9C6B8D5BB8DBFFFEB60D4B04105D2160EDDA1E84145EB80D601AD03E1742055806352E1CC67011BD102C713808EC7BE864BA5BB0A1CE6A16E70AD207E232043371E05E0F85BBA5B388C3EBF339A5F39CDF8E48F7F8B0934B485437730E13A18FDBBD611AD035A0752C9C2F140E1ACE70EC501380480E34F008E93A585A31C38B86265D8A6EE70A9EC05701C4C47E0603068E6D9238D7C0483FEFEE36F8CAFFF76202EB0A12D1CBA33D1038AD601AD035A07DCE840655A386AD49FFDFCB8A2D9CF1F027088380187F08DDAF227004737BA542CE0A88D552BE3011C3FA563D02821C33865A89187788DA75EFBC4F8E1A77FC70D34B4854377326E3A197D8DD613AD035A072A736BF3CCFA735F1C5B7FCEF3A2081267E010808D6F20270338DAC2A5F26212CF5249A9ADCD6B9C39C2C8397794D1E9DA99C696973E8C3B6868E0D09D881E48B40E681DD03AE056072ACBC231AEC1DC174DD8481070003A1EF901C0F175128FA74FA9B35432CFBEDFDC827CEA23CF270C343470E88EC66D47A3AFD3BAA27540EB40D281A3E1BC97C73798F7B24802700800874837E0902B5078D6C9DCADAF241C36740C87EE44F440A27540EB80D601373A906CE098D8703E60430387F00F9A21FC574C17FECBA799E2B974AAF0FC768A28B864B229752F9E24EA406A5F34D194FC0B27885A174DC0DFF1227FE038913770ACC8A59C3F46003228EF669F37BA902B508661A9EB232F7D9014D8D0C0A13B1A371D8DBE46EB89D601AD0349038E860B5F99D070FE2B87D219383C836709EFE099C23B68A6F001387C000EDF65D344D1A0E9E2A8AB67894657CE140D07CF30A501BEAB0F29BA62AA2985974F11FE4B278BBC0B081BE34CD8C8A10038001A94778D92BB0B872CDF6E1CC2DE184E159BA8EFF43E1CBA23D18389D601AD035A07C2E940328023ABFEC257C703387E05708874008E826BE68B82ABE70A0FC47BF51CE1C7DF7AD7CC118DAE9B2B8EBF75916873E752D1E99E15A2C77DAB449F61AB45DFE1960CC3FF8706A4F77D2B452F48CF21CB4DE971EF3253BADDBD5474B973B16877EB02D1F286D9A2E9D5D345E1A50F88ACD387BF77E3BCC71BFC72E85046A2C02258BA1A38744713AEA3D1BF6B1DD13AA0752019C0D102C0F1318003B0517D81A3E0BA85A2EE75008D6BE70BFFF50B44FD1B178826B72E11ADEF5A21BA0E5B23FA8C5A2F4AC6AC17A5A3D7899251EB441965E483A2ECFEB5A694DCBF46948C582D8A011F94BE840F48EFA12B4CE975DF7240C872D10BF0D1EB9E65A2E73D4B450F48F77B960040168AD261CB3FDDF3CEE77D50A1C740EA43F22159C9800F0D1CBA23D18389D601AD035A07C2E98033702CF8BD513F5259F8AA01B008265D001CFBAB2370D40568D4B96E81F0DDB048340260B40060741CFEA0E83B7683E8376193281BB75194E273C998872A00472980A314C0510AD8A0B8050ED3E201E008C0C661E0281BBEE2D3BDEF7CDE1F157A12A40BA433A435E4688817929B28F8D0C0A13B9A701D8DFE5DEB88D601AD038EC051B8F44D2312295AF22640039012023A001C9D011C808EEA11345A078051979071FB32D172C81AD171C43AD11B70D17FD223A274C266518ACF2514133692061CFD50A1ED209D2C2178748374859C08696CC147663CE1430387EE48F460A27540EB80D681703AE0081CFE55EF1B11C9CAF70C133A681509021D0D16BE6200383A6059ECE75579958A07A7C47A6F5E229ADCBD4AB4BFFF21D173FC26D16FD21651F6C023A264E2C3A204B0518CEF4CD8A87CE090E0C1BF848F93211D202D218D2039F1000F0D1CBAA309D7D1E8DFB58E681DD03AE00C1C00087F84526FC5BB46BDA56F19458B5F77840E0B380CC0468706735FDA5FD5F6E1E0D1F43CA2FED87BD788AE6337893E008CB2C95B44E9035B001A8F88E2090F4336A7327048F8A0AB85160FFE6D0B6912ABBB450387EE48F460A27540EB80D681703A1057E0F02F7FC7A8B7FC6DA368D16B474087021C0680A32380637F82771A8D79E32FEFED2B85F7B695A2DE6D2B44338046B771800A58334AA73C264A011BC5808E62C04615030EBBD583E041AB4753485441A61A38744713AEA3D1BF6B1DD13AA0752001C0F19619FF51B4E48D0AD061030E0367A974C6592A267424E02C156E6D1E13701400367C90C6F7AC15DDC63F0CC8781C90F1982899FC6840001ED5003854AB073F9F046918297868E0D01D891E4CB40E681DD03A104E07120B1C74AF58D60E07E030705A6C579C16FB652A0187E78ED582B0D1E89E0745DBD188C598F684289B2661A3DA02876AF5A0BB85AB5B7C10577B7A68E0D01D4DB88E46FFAE7544EB80D681C40307A0A3C1A2578D060BCCA051C670D0A5420B0781C300707405707C11C7E3E9795A6C54168E3A77AE11BEDFAD112D466C10BD61D1E83763AB091CA553D30A386480295D2DCD20B5C205966AE0D01D891E4CB40E681DD03A104E0792061C0D83038701E0E804E0F8A270C633A270C63EE19FFE3464AFF04FDD23FC53760BFFE45D909DC23F69BBF04DDC2EFC13B609DF84A7847FFC93C2376EABF08F7902F298F08E7E4CF846113622070EC246FD7BD7894E131E15A5D39F1465339E3461234D81435A3CB8A496CB6CEB85820E0D1CBAA309D7D1E8DFB58E681DD03A9074E0C03E1C760B0781C300707402707C5929C071F783A2D9FD1B45CF695B45D9CC6D2670944C0F5837D21C38A4B5A3A315545AD349613470E88E440F265A07B40E681D08A703F1008E0C2CA1CDE2B2D8C02A15256894311C964B455A384CE0805B4571A948E030001C9D0BA7EFFB2259168EBAF7AE1705B06AB49EB045F49DF994289DB50DA0F15400363470A8711D74AF701F8F3690DA76A5D1C0A13B9A701D8DFE5DEB88D601AD03F1008E8B011CEB001C6701381ABA050E2C8B65FC8629968583C0610038BA0038BE4BB44B85B0516FE806D161F213A278F636510CE0A068E028DFA554050E75354B7B2BA0B4FC445A0D1CBA23D18389D601AD035A07C2E980237078577D60B8145A375E81080087A8B7FC9D8F001CB763596C0773596C080B0781A3FE9C17001BCF064043CAF47D1D011C5F260A380A001975001B0D476C165DA60132E66C137D357038C145A8EF68F1E0F25973158B060EDDD184EB68F4EF5A47B40E681D881538FA600BF49F2470142E7F07D0F1960070FC1F80631180E302480157A9D85D2A4180230F168EE712E5522918BA51D41DF290386AE4C3A23B6335E6EC147D001B1A38425A358281075D2C3C9936530387EE48F460A27540EB80D681703AE0081CBED51F186E04569095000EA15838442180A368E99B02C0211A2C7EFD1700C73E00C77800C7715C162B63384C97CA1CBA54CC80D180CC786654228346EBC2BAD174CC16D17BF60E513A7727406347728163EC43383D760304E7AF8CDF2CFAF1EFD88DA694E190B7329C285B3A3A202538CEBE18D21727CA52FA8C582BFAE254D9DEC32143D7885E43578B9EA6AC12DDEE592E068C5EF787DFEFFF6B6F54E8F156AC05E32D12293C0C8E2B581A3CB86E9DC17FE1944DFFAE3B24AD035A07B40EA4AF0EC4021CC7034A3E0B031C02C021001C02C0F12980631580E3F4C05E1C1670003AAC188E2E008E7F250A380A866D124DC73D2AFACC256CEC127DE7EC482C70E000B7525370722C762AED37718BE8337C85E876D314D1E18A61A2CDC09B0372FE4D96DC28DA9C1790D694736F30A5D539D743AE1327405A9D7D9D6869C9F1675D2B02728D687EE635A2F59957FDE5DC4BAE987CF555570DBFEAAAAB462641EEE733AEB9F6DAD17D8B8B6FCDCCCABA1C1DC9157194CB9056518A744E47231F6743AE85CC81CCD2125319CC43F9758CB16E7370FF5990ABE2A873F1D4DFEA9216CBB73B846D2055271547216F9742066B5D886B1F1C4F1D66FD381E166A78D67C1856BCAB3F1806E038140170080007E4E59F001C6F01386E8285C30BC90070D48485634FA2F6E1206C34216CCCDB294AE6EF44DC06AC1B09008E121CE4563AE951F3B4D862582BBADF315BB43AEF067154A712E139A6B9C8F7D51379053E915BA740E4D4AA1D5FC9AF7528B366CD9F8D1A350E26597EAE81E74299FE1367F909E9F5ACA44E2E0BCF6D01190A7901F257C83F210721424B5CCAE09218EBB61EEE7FCDAA9378EB9E4EEF707BA6CEFF68B5812FF1770BE40EC8B190EC18EB305E00738A95475D6FF1EF87E355A60750477E470B870BE0A8ED5DF3E11E008788023884723CFDB7008E51008E89008E7F2702383CC3368B4674A3C0AA51327F97280674C41B38CAA660FBF3A95B459FD10F8A6E77CC12CD4FB954789AB41039F9F9222B3B5BD4A464D5B4240BFFA758DF47F997E9AA126B7AB1DE9F8041F857A4D927C91D5A2D3CAF37E471C8BF12F04E1A560E03DBC531D66D21EE7F5FD7515CE02F1ABDFC2FCAFE19C84590FA31D665ACE0713A9ECF494F34EFA1EF494EB9515F1C3790343C6B3F0A2703001C07E2001C229187B7150C0FC0468FD9B06C2CD82D8AE30C1C3CD0ADDF8CEDA2E7B015A2EDE5F789FA6DBB8BACBC3C51A3866142856E00317500FFB306FF583B23B7F717E3791B749DC5546791E87C3C80E35D5D5F49ABAF5075CB7AA0BBB1712581C769782E67E291E89FBE36B9E5454B5954C091032099EF5BF3914865E0F08C785814629BF3EE808D7E0BF60036E2091C8F89FEB31107326193687DE1ADC2D7FC449161182233C308581D925B91D5F579C9020ECECEC64148E061CBB226AED1125D19D8CA5703870B7D73A3932974CDABC8CB95908C248387068ED4D7A5E0C051B0F6632384B404707C9FCAC0E1BDFF11E11FF588E8386387E8B770AF051BF1018ED2A9709F6049ED49570E17456DBA8ACCCC1A266CD81BBD1E94621E9492011CDD506FCF3A75D8BAFEA2ABBF50E59668E0D07516FF3A8BA03ED53EF011D43563A0DC5A1763BDAE0270683D48AE1EB8D491A880230320723B8043A42A707861D5F08E7C44B49AF294285BF4B4289D1F3FE028659CC6D8F5A2719FB3CDC04F8246CDAC235D275AE1A3577865504A34700CC0B3BED1B0117D5D45AAE71A389257D691D64D2CD707B1B0FC01DF9F9B24E8D0C091A29657453742B854D67D62789CC5E359FBF12BA90E1C4D26E24879C206AC1B2571008E329CAB5236639BE874E303C2DBAC5520F8B366A6B66A2440C993041CD7E339DF6BAB547207400D1CC92DEF5820229A7B1DC083AB5B6E49828B45034702FAE26874C07E4FACC051E679F063E161FC460AC67078703C7DFDB18F899EF3F7889245808D38004729DC27848D13B06706AD1A74A1D8E334E251313A8D40679C04E0E07E1A7FD3B091FCC14F0347F2CB3CD9FD8A03741CC277D3205C6A1EABEB24D8FD1A38AA29706C4C65E0F002383ACEDA695A37E2011CA5B3B68B521CE8D6ACDF45008D0CD3B2A107AAC4769A09068EB648FFB378D461103372D8A0537D5F3954C63D6834D983AB7E9E735F1044C72768E0486CDF998AFAE8CAC2E15DF707C3419AC1CDF2BF54050EEFA8C744F329381F65315C2971000E5A3628CDFA5BB0E1B0CC359A0AD6034EF895205619C53B86231FE9EE8E163674BDB9AE37B7D09514E0D0F516BF7A8BA4BF0B52EE3726083AAACD2A15A732AE263A1C228663FDA786C7260090499E757F10A9081CBED18F8B86E39F103DE63F2DFA2DD907EB468C168E194F8A3258374CCB066235D4C050B78DCEAD92C4BAE15655BBDF6DB958D7C56BE32F2ED3BB3B52D88830AF6E075A7D5DC075C6ADEB6331B173E3AF0AFB7054E3CE3A2575C64D5F686B43FFC0FF4B62AC77279D390369FE521DDA6B35D6616EE418641F8E238123DBBBFED34F521238C66E15BE314F889366ED026C3C6B5A3862028E194F8912D38D7261203854B16CB86960B63884F28E826080F3464446CD9AC2C8C81038EBCC146C0BFE436E7EFEFE9CBCBC2FABBB60CBF54FF1CE1F43F1DCC807B8AE539C3AA71391CEDFD50EC9E5522EA78E9E3B90BE017914B20EF2909688CB6013CA8CE773241B38B845BD1BDD4BE76B3E4219718589AB9D3BDDF4893610780FFFF7C558F776BDE1C4E41DC8A755A87E653913C20E8F130EB118B6F263B03BFBC6AAA4A39F589303AFF3D6E60F7D66785459FFE9A5008E9F5311380A001B4D26E188F9C5CF88B225CFC40C1CFDB0AAA5F5C5B78BECBC7C00C2E1988D281A1661426090E5DF5F6BD5A9F38F26CD9AED3DE5D453270D1F31E286F73FF8E0DCCFF7EF3FEB8B2FBF3CF5ABAFBEEAF7E5575FF5AFE632E08B2FBEE8B67EFDFAA21A99994580AE2240180F670B25F10A345B11AE51CBFA0D324BE2392A3C43824B698F81F01C8FDA10BA69B4445E06DC42BE668C834E34168E3161F42D9C3EA6CBEFDC0C8FBB86F2BC140EE6F7419E80043D4B285CFF686B578B62AC7B3B70F04C17D60DF35D95EAA809F2CB894B24C0C1830FA9FB55E93D655E6BB8018E1A70AFEC00708854030EDFF827857FDC56D161CE1ED17FD9B3A204D0118B85A36CC1D3A2E3AD53452D7F83C06A94308A106C90324103D68B5A75EBFED0AE7DFB7DD75E7BEDDD1F7EF861DF83070F76F9DFFFFED7F1D0A143EDADA3DD79BCFB4969227C671E699FBF72D52AA359B3660680C34059C532CB75736F1BD423E3414236EA20962946D8EF8170369E19E74ED24DDEF535C1AD20D100C75DBA0EA3B62A51FF09DB33217FB10184D9B622B01A7256CFF34FD25DBF094AB49246021C93AA72B9B9018E9E008EBFA4227078011B4D276F17FD963D07EB466CC0513A6F8FE8356183F01E17D8A63C9C1204830DD3559291F143CF5EBD1E5BBE72E53928E036165074C4DF4E692E5DF0FECD211954BCA1C386A1B802FFB2727313D5F9AC7253970E1D287DC21321A9722266A2CAA7AAA61B0D70DC53953BEB14CA3B67E6AB21471C70180C3A1CDAD78BF88ED6C1AAAA7FF1C837DF9F2ED94880634A552E3347E028D8F0B921C5B3E1F3E9000E916AC0E11DFF94A837E129D10581A2FD011CA570A7446BE1289EBB4394CCDE2E1A979D6FC1C6E1F350DC9A0A199F41D8687AECB1AF4C9936ED9A7FFEF39F27A070DBA63960D801AB33CAA303A4402ADEB871E38CDF5C7C71A2A083A6BCAFC3356807EB06039C8655E5869D0679D7C051F983F515D0B33FBB695F0E6DECDFB8EFAA34D0D35060A2810313CF72D800741C03E078275581A3E9D41DA2CC840D048BC6001C25D828ACC32D9344567E6DEC20EA2E6EA3422343402846CCFF5CF49BDFCC7AEDF5D7FB62306DA14123A835A71BCAE63848057F1EDC4E89B0765C837AAA70289BCB1958959E45A44927AE81A3F2818383692F08834C5D59856DD7312E242F4DF4D5093C3470D88063308043A42270F860DDE834EFE99881A3EFDC9DA2D7D42DA25E9BCEA286E94AC98DC81F69AD3CF976E4E8D177FDE31FFFA0FB84560DCEE4D3DD7D12ECFD5936742FD555CD6BBFFCF28BB163C70EE3B4D34F0F583BE2D39986F58F3ACCBCDEC4B319D418AF3CE8741253961A381253AED1E86B4FB497B0AB2D1CDADA4FB8AF348DDB9A060E1B7078011C23001CDFC0A572285582467D13B689A3A7EC10C5CB9E1725315A38081C6DAF1D552148D46DF01357A00038BE7E64CB964118305B59EE020D1AE1618B568E26329643058F03070E18C5252506B68F3750BE158441A611744E9C39BDE6C6DC6B9B75E960B6D419C842D5B7068ED4AA276EEA158D956344046D3A92F65F15AED5C061030E03C0C14DC00AB0F1D705D869742F36FEFABEB2CF52F10238DACEDD2B4A97C7081C737688DE33B08FC7F1ED5CB952D40645D8C8CDCDFD76E3A64D9763C064BC860E0A0D0F1A12C6183CCA153AB94E4144FFFDEF7F8D1F7FFCD138A1756BE3D8E38E338E6DDEDC943A0505E6CA16971D546B5CB73F1C70D83AC957F17F8FCBF4DDE6435F97988151034762CA355A7DA555301A8BE24EDCE74FD336A781230870985B9D9B27C8AEFDB83D4E8B5D86C3DB3EF0ADFE40F857BD2FFC2BDF13F556BC2BEA2D7F47142E7F4B142D7D53142D79433458FCBAA80F69B0E855D170C12BA2E17CCACBA2C13CC8DC1745D19CE74D299CF59C289CF9AC289CF10C649FF04F7F1AB257F8A7EE11FE29BB857FF22EC84EE19FB45DF8266E17850F6C17BD9662654A8CC0518295296DAF1FED8ACA55732097BD666767FF3C6FFEFC7B306072D585B66A445E06B472143A0147B0EF4E3BE38C48DC2DA7A213FB2E42E01885EBF5F2D7D41AC8820D801A3852AF9EB87CFC87706DCEE65AE1867CED357004AC432E761AADD2F1654E7DBB1A342A2D1C2A70003A3E32BCAB3FA8EF5DF5C13D008E6D008E1F92051C1E58378E9FB5C774A7C46AE160B068BD365D44165698C846122EA8903B867235CAF90307CEFFF5975F081B3A5E2372D820A0D1CA41CB50A65BE838E5B4D322018EEB50A7E5FB6F84AB575CCB65B0C569DAF1453BABADCCFB3470A41E707009F9FA0881837DEFC0346D77DAC2E1C2C22181C3007018808D6CDFCAF7FA0138E6D65BF6CE5709B570C0B241E0E8BCF05951B6E2C59880A364C15ED1F9DEF922B7AE2722774A4666A668DCB4E98B1F7EF411074DED46890E36A44588B0969F20E0B8199D1897B7860C02563AC71FF199A7C956E620AA9FEDBEFC3570B82FAB64EAD520B4A1FF84830E9B2BF3F6346D771A384CE0D8F485BA0F8779909BE252B1038701E030001C065C2A27162E7DEB7AB854F625C2A5E20370349C8255254B9E8F1938FA2D7B49342E1DE8EA60B6F2410BD68DECDCDC83AB56AFBEC88A41D0AE94D88083568E466E81A377DFBE9158386E8A1038BEC2F5ADD2B4E34BE68014AF6769E0484DE0601BFA3C42E0588CEB73D2B0ED69E0308163F39726747836EE370A78A68A7BE030001C0680C307E0E88B188E87EA2F7AEDE778C570144CDC265ACE46B0A869DD78216A0B47C9BCDDA20F0E68F3363F5164661CDE55349CD99D4B605BB769B3E5E79F7FE636DD1A36E25306DCEEDCDC79349C7CFDF5D746B3638F3532B07AC545E714297070BB661EF2E6266D7D4DE59793068ECAAF03A776C018A81722040E1EE6978E4BD1357004050E9E20CBC0D1B51F87B27048E030001C0680A31582460FC50B3868E1E8B0E019D17FE54BA22406E0285DF48CE874F71C51ABA861D8E5B06AC3C1F4FAE0A64D9B68DD38490347DC808B6E29D76E95135AB532B075BC9B019F2E159E85E2D6A5C26B7950959BB4F535955F4E1A382ABF0E82B5831D110207B7F74EC76DCE357084058E07011C6B3E32B04AC5C02A15C67094BB540A97BD0DD078CBA8BFD8840DCA15F15AA5E29BB443349CBA539CBCE439D16F456CC0D17FC52BE2F88137E0E8F96C53D838C2593730AB1618EC367FF7DD775C5DC1EDB9B585237E65503F9C7543FEDEF28413DC02C7D5A8D7F25D46C3D5AFD54132D054C344D528030D1CA95B4F1B3470B8EA473470440C1CABDE37A183311C040E0B34F8370332375EC051F0C00ED16CE61E5102770A0346A3B670CCDF25FA2D7F511CDDF37473B589DB1930AEFD75CEDCB9B7FCFAEBAFDC4D54078BC60F3618387A7C0280239A65B1DC1320574387ABCEB2B2C14C0347EA02C7D31A385CB5210D1CB1000782468DA2656F49E8A809E078235EC0E101709C301707B5AD7A09B11BD10347E9C2BDA2F7D44745619BAED656E6E1D73F73654A764ECEC76FBDFDF66918181973A0AD1BF12B0302075D5435DD404704160E6EFC153678CDB627002D229D3470B8EA2C3570A4EE805F9975C3A5B1AF44081C0FEB188EF0E39055A6D5701F0EA7A05119C36177A928160E0247E172B85596BE69D45FF2462680E3A77800870F1B7FD5C3C65FED173E23FAC50A1C8BF7896E23578A82262DC3068CCA46434BC889EDDA6DDCBF7F3F07471D301A3FD820B8C932ADE306388E3AFA68B72B5518BCF672B88ECFE17C8707357068E0D03A10B50E70F3AF3F856B77EAEFF83C01928E1BEE690B8765E1C8C02A950CAC52C9C02A950CAC52C9C0592A19081ACDC0D6E61988E1C8400C4706623832B0F157065C2A1970A964003832B00F470680230341A35D001CBFC4053826ED120DA6EE12DDB81C762557A8446FE1285BFABCE878E70C91EF2B1435336BB88ADF2070E0C8F929382F45EF2A1A5FD8502D450DDC00C7071F7C60E4D7AEED768BF3E5E13A3E19DBA15C472BC7857AC0897AC049D6EC5ABB5452D3C232146D2792606DF6C137A4697BD3C06101C75F011C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001C07001CFF8ED7D6E6DE493BC551D3778BBE5C0E1B2370F45BF68238E9E68922A7761D6CF895191638AC9D457F5EBD66CD1D56AC8176A7C41F3A68E568E206380E1D3A6464E23C159767AA101CFEED063A6C33AE8FF1FF63D3B4134C1630C4FA1C0D1CA9071C5EB49967A3686FFDD2B4AD69E0B080E3BF000E01E010008E4A3F9E9EC0D11401A303D6BC6C068DC662E12070B4BB69BCC8CECF770D1C191919FF58B376ED0D1810B915B7068EF8974157946B4B37C0C183DD7AF4EC69604F143703164F8CFD348A0E9020FA14A47E9A76846ECAB6B2AFD1C0917AC07109DA4BF971026C772E568771C3BD13D2B49D69E0B080E3602A01870FC071FC9CA7C580D571000E2CA96D75C53DA20636FCAA99137C49AC1CA478505B66CD9A9FE108FAF3312072858A068EF89701771C6D0D7175AECAF73FFCE0368E8383E2F4288183D0C1D95A8734ED0C2B1B28C23D5F03476A0107E1FCED28DA1AF7E0E0C4205C7D57C7DF3570A42270D49BB24BB4C5865FFD5663FF8D182D1CFD57BE2C5A5E7C5BD825B136E0D8FFF0238F5CA0812361B045974A5BB71B807DBE7F7F24C0D1C2AD5BC5218094D0410BC91D902669DA29A66A47AF8123B506E90551C006DBD7AD69DCAE3470A41A70F8703C7D2180A3E3226CF8152FE0B8E4760D1CF1B752C462F92170B483B85AA9F2E9679F45021C1C3017A99D6128536F10E860C7F82E8441A80C703B03C283DE8E81344D4329488141420347EA00C7BD6EDB97ED3ABA53DAA5802E5516546BE04845E0289ABA5B74C1EA122E898D8B854303472C7090887B091CDC4CAD9E9B380E9C65632C5DBA143B9CBBDAE29C9D09A1E04B37333087552BE59BC359F71FC45F9E2CCBA57F4C939D66BA09AD3E6F4036427E076959098386068ED4008EBB50F73FBB695B7628C1FF9742D27139AC041C0D1CA9081CF5011C3D71764A99068E440CF6A990268183F92874031CBCE6D9679F8DD4CAC180B6F2E57AECFC8205B4A9DF3B7492760049F7FFFF8232FA09F22AE4164883240D221A382A17387CA8E71510D67FD81D9B1D2C87FF87FBD2FDEC220D1C1A380203916C4456D0A88EE148AC0B86C041717DA6CA6BAFBD663469D2C4EDF258CE286A5B1D640540D0D07158D7E30457DF219D0720CD126CF5D0C05139C041D0381BF29E93BEB8589522DB9FDE602F70601D836643029BAD9CABE54EA329B34A85311C0D60E1E8CD3354B4852315AC1189CA030FC573B51787B48260A972A4568EA3D1785FB377946EA0435B3D220693CF2C8B479D04814734C0410B4C65F9EBABF273EBA2DC18B37425647B30300DD58E6CF7FC05FFE7D10355B94CE291770D1CA968E168386D0F02465F16A5ABB0C3683C56A9E8188E4441432CE912381ABB75A9F0BAE93366048023373792C6DF191D5D85BD39D819460A1DFAFA8A6516C23AF2B835584552476EAE8D0638D6232F976A095B06743F5E0B19039905D90AA9702E51B859791840BF5DC386095B1A38521638B0E997068E842D4B8D0514E2756FC4C0F1D9E79F1BA79D769A51A3460D3703947A0D23E339033F22FE4283446CF015043C3EC1F7E7C479908906387E451EB8319596D065C0EDFDC3C626B9692B0EE96CC277E91C28AAF6431A383470E8188E4ADADC2C62E0A095E3AEBBEF8ED4AD221B3C57AEEC8AC63CECA6A34DF76B1CCAF500BEBB268ED0110D70841D44DD0CB4FA1A7750EA504E5CD9A4F7B339EC4AD2C0A18143034755028E7FFEF39F46CFDEBDA3850E0F3AC03990FF68F07037884402520E65CA25C583E2041D1A385C5821E2094731D6FDF7C84BB738D57DA416CD54BD5E0387060E0D1C55093868E5B8F9D65B8D1CC471B83CD0CDA9F319888EF0AD709D73241DAEBEB6623B52CAF6EFF85C1A8781C71570E87A883F48862B53877644D8382D0E759EAAE0106DBE3470A422703440D068F1CA9710C3A137FEAA241888579C46A874225EA5A20698D66FD0205A2B87EC2C78D2E528C89BE1C043FF1ED920E6505E1FC4C1B4AE812305839D1DEA9AB152DC9937DA41B93ADFA781231581831B7FF5D01B7F2563D0AFCC67F0C4D8A32259A5A25E3B032B56B2E3D3A971E92C77CF64647E85A3ED3568441F64EB50768FC4380869E04831E070A8631E7E78528CF5AC81A3A2EB4CEFC3E15FF99EA8B7E25D516FF93BA270F95BA268E99BA268C91BA2C1E2D7457D488345AF8A860B5E110DE7535E160DE641E6BE288AE63C6F4AE1ACE744E1CC6745E18C6720FB847FFAD390BDC23F758FE03E1C7AA7D16ABD3A859013F14EA34E6082BDCE6371ABD83B36EE3D500CB909B212F27B087747D4818721CA204273FB05310C461A382A11385CB48379B8E6A818EAB73A8386DEDA1C960DD9871B059BBF4CA98DBF78964A377D964A655A1F12FDEC9881E3D0A143C6135BB7C6EA5609D6C9F1F8EC86109E3CCB7D3CD255CEC5BBF3F0BA35A1E02B820DA0E85A89F668720D1C95041C6160E323FC7E1E244BC34658379276A9A4A24B459F169B16168E9340BC75A375A9F0BEBFFCE52F46EDDAB5D3616654D9EF9883C1845B5C5F0CF9D8690072B9C535CFE188F67872D7C0E16236AEAD56B159EEB8BFC90F9009907A1A34C28286B670A4AA85C30F974A3D1C4F7FD2C267E3773CFD6FEF88E878FA1A9999FA2C95C49FA5D216D0503B16E0E0BD3B77EE4C9495A3B207F9547D3E6769F42BFF531DD823B0723048976944FA7EAE8043C346425D805C4EFE07C808C8B151D461A4755EDDAED7168E54B3701038FC93778996739F16FD57C7BE4AA5DFF21745DB6B47899AD959A266564D7366E3D439CA8E2A332B8B70F2B775EBD70FC680D6AA1AAF1249B4DB2454FA5D50AE6D2059B102C7BBEFBE6BB4EFD0C140BD55B7CE29D5DF875B86FFE8063A6C10F02FFC9FF746FA7E1A3862B34A446BD5611DBF0DD90CB91A92A8B37222D587AA78BD068E54040EEFA49DE2D8597BC429D8DE3CD6B354FA2D7B419C74F3449153BB8EA85933332870C81363B1B70381E3D7152B56DC89C1B0A5068E84B877B8428530572356E0E0FD80436DE5887C008F47877D1D06A043122822B0722C491270FC09CFA14585C27D57B4842E0382C54B902D90C590FB205CE27A4C14F5150FFDAA6E6968E04855E0387AC66E51827D384A57BE284A61A528C132D9D2E5CF8B9265CF89D225CF429E11258B9F11A58B9F16258B287B45C942C8FCBDA278FE6E4B7689B265CF8B0EB74F13791EBFC8B480239C9503A39758BD7AF5280C66C769E0480870D0C2D12C1EB0C134162E5AA481A37280A3863530853C6E5BC2BC62E9E051E7911E671F8D85639265FAA7F9FF382D61CBA039CA882B4DA20DECAD6E8010EFF7D1C06101C77F0B367D213C1BF78B82873E139EF59F0A2FC4B3EE0FC2F3E0C7C2B3E623E1A3ACFE40F857BD2F12B92C962E15DFA45D38A27E97E88E952A6531024729A0A4CBB025A2CE51C78ACC0C2364C7283B4402C780534E59FBA73FFF99818D1D347424043A1AC50B38162D5EAC81A37280831D722BC8570A4C043D8957B986F11F03229C3547031C7744F88C780F303ABDCAD3CB542C7B0D1C1670FC15C07100C07100C07100C07100C07100C07100C07100C07100C07100C07100C07100C07100FB701CC03E1C07B00FC701ECC37100FB70FC3B1EFB7098C081188EC2293B45C745081CA59523060B4729AC1EBD263F2CEAB5EE246A002442997FE56F19999922BF56ADD7DF7CEBADFE1814DB69E0882B7070496C7B88275EC03163E64C0D1C95DBB173B542A4568E1B2384816880E39E089F918A8394CE53E5EA763CCB3FBD80233BAB7CEF0DB5AFE73E1C19008E0C004706802303C09101E0C8007064003832001C19008E0C004706802303C09101E0C8007064003832001C19008E2E008E5F62DDF84B068D328EA3CDBC7DA27F8CC051B200AE99057B4483CE2522230C70D8E2387EDEBA75EB20ECF7D05A0347DC818396A39C5881E3E79F7F36962F5F6E64447E5C7D3C3B119D564E4E1906F67F84830EF5777C8E7407450D1CD567E04DD736931EC09155D3C8CACA34B2EB7883028701E030001C0680C3007018000E03C06100380C008701E030001C0680C3007018000E03C061142E7FDB007018F597BC9109E0F8295EC051F0C00E711C0247CB78A64A0C168EE2793BC58055AF8AA6032E16191919AE6761BCB667AF5E4BFEF18F7F74D46E95B8030721CE511923F9FEFB1F7ED0968DD418841A00205E8E103856E0FAEC082C101A3852A3AED31516E2F1DED51C38728D2CC42D6417141A39854D8CFCF667C61F388A96BD6500342835216FC40B38BC008EA3A7ED123D19C7B122FAA0510247D992E745BB6B478BDC020F0247832F8D5583DBB85A05AE95FF7BEFBDF7E856E18CBC32979156A767D3A512F5192A12487EF9E51763C4C89106F64C894747A0D3886D3063F0E8BA0881632FAE2FD2C011F1F260ADABB1E96A65965F35060EC2866164D7F519F9279D6EE477B930FEC051B8EC6DA3C192372470640038E6C60B38FC93778A7A9376884ED800AC3FAC1CD1AE522170942CD82B7A4CD820EA366E1E367054850EA3460D71E965978DD3C01177D8AA13892523D8B5346FC470447D65763CD5F1D97322040E1EF4C5EDE3DD9685B670B82F2BB765AAAF4B6E99565FE0A809CB461D0B363A9E67C2467C2C1C70A7F82C974AD1D272EB86848E41F1048E8289DB446B6C00460B476994CB62091CC57368E57841D4EFD45764D638EC566107196A13305A39F26AD5FA2376B3A49543AF56898F9587D6A298F7DFB8F8924B0C58AB748799DC0E335479CF8F10389EC1F574C5B8AD430D1CEECBCA6D99EAEB925BA6D5133818AF51D76BE4D1B2D1F1DC72D8880E38D6228663ED478617F11BDE5588E15080C38CE1007430860341A3848E66008E5F62392D56068DD2C2E17D60BBE956E96DB955A2D9874302472956BCB4855BC5DC000CBB89865AAD52C1CA81588EDE7DFB6E80099F5B715727D74665BC0BDD294D63B56E5C3E689019BBA1AD1BAE07EB640C2C1A38923B7825A34E53FB1958059195970FA915905C98F5B3B35339CFD50F381020CAE050D38DD2F19C0AB0111970306074DD27808D8880A365FD45AF7D112FE0F00338BC13B78BAE8B9EB3AC1C916FFC2581A3782EC065DAE3D88FA319761C0DC47104B370A8C0C1ADCE01283F0D193AF4460C947AABF3D8A08B1B7EC57460DB0F3FFE689CDCA3870E164DADC18D311CDC9DD2D5B273EBBA0DF85B5B5B38520A1A5379B036573E944BCD1A46362023EFC4FE18E4CE3267D6B9C77609FC4E1049ADF621F353BD80C35A8962C24607D481E54651FF3A4D2ECD152A051B3E37C543E12A95C880E32458386E8285E3B578BA54FC93B68B8209DB449B39D8493446974ADF393BCC5D489B9F7F5D44C0C1CE912B568A8A8AF63FF6D863A759D0218F57AF0C2B41557D26CB8C56A2A8CF4FF9FEFBEF8DFE030668D848BDCE94BB86BE1B2170CCC5F519110C0CDAA5927AF59EE0811D160B2EB1C4CA872C0286BF11E4A88078EA1BF9AD4B2B9AF03B0F0474744E65E8A826C061AD4691311B1DCE76848DE0160E0B3622048ECC7ACBDE391D2E955970A9FC05C021E2B5F1170F6FA34B85C0E10370349ABC43F4C116E565516C6D2E2D1C048EBE88E53879EC5A91EF2B1430BD85B470D8B763E6EEA3CD9B377FEDF3FDFB7B6BE888CAB5D40DE5C6DD453382B954E6CE9B67CC9C352BA89C79F6D901D8A0E934ED3ADF949E09FF16F5F17384C03132C23AD4C0914E3A4F2B05DA7AB6A7C8C839AA9591D3A8A591DF09C1889DCFB7642066D5F681EE0CAC8E50A123E5DC2BD50038ACD528848D76CE6E94F0168EC880C387A0D19BB00FC756C470FC848DBF048043240C38E052F1003A3A2DD8173B70CC0674CCDB259A9D7EB9A8A16C73EEC6B5C26B081DDDBA77DFF6DDF7DF736F8E13754C4744E0410B87E371F4F3172E34AE1C3CD8848970FF346CA41C78D442DB78341C6CD800FE575C7F91068E94ABCBD400796C099D55ABAE91DBAC235C26FD024B2C091A0E26FB23BF0374E0DA3C5A3A520FD0AA3E7098AB51AC00510260983A7176A9B8038ED6081A9D8F8DBFDE43E0E82F000E01E010C9000E5A399A4EDB19D5E16D152C1C048EB93B45775839EA343C26EC616E72058B1AEF41E868DFB1E3CB2FBDF452995E2EEB1A38783A6C73A7D529F3E6CF37579BE820D02A3BF85C80F671301C70A8BFE3F31790F6110E08DAC2917A03687C07755A3510F499D7E26423AF750940E302072B4660B96558E978767CF3169FB2AFDAC0C10051ECB361AE46E95471354AB0FA8814387210347AAA67ED875BBD6B3EFC2E5987B75570A9C0C2E10770F8273C257A2CC2E9B0119E166B078E3EB3B78B6258395A5F76B7C8CCC41259CBB512CACAE1E45E39BA71E33767CF99733156AFF05C104A558DAD4846BE192CEA57956FEFDEBD46E3C68D8DFCDAB50D6CB0968A9D83CE53F84EB605DACD1FC2C186C369B18FE19E4C0D1C551632E3D736648027FEE621E833AFEDA981D50E21E202C2C2068104F7E7B5EC85D88F94EA5BAA2E70B09E184753EFE80008BA81BEA03B8D56B470642268F428048DDE8C552AAF616BF35F937D5AAC1370F8001CC7CFE071F3911D4F7F24706C1325008EDE133789A276DD2B9CAF120974F080372CCBFCEB55575F3DEEEBAFBF667C421B883EE8ED48F0A275A325A42681036565EC7DFA69231390818DD50CAC028A5FE7157E80D4CF8A5F1979D05EB646011B74A70C8D1036586FDAC211BFBAABFC7660AD26C9AE55C78CD108ECDF80950EB182861C08091C6D0718D9F9B55369A96CD5040E5A36584FDE8611D74F380B4703AC529900E0F863651E4FEF041CDEF14F89A2894F899EB072F45BFAAC285DF28C28C1D1F3A58BB182651165AF28C1C9B05C89523C7FB725BB60CD086CFC65068DC2A5D267F636FCDD26FA2DDC273ADD3953E4797CD80C2CF429B2EAE660153A585847E862F117163E3B73E6CC5BDF7DF7DD1E28E016D66A0CC67924C37A90CACF60DC06A5888AF7CEBBEF1A5E9F4FAF32A9FA03471BB483A76C6E1237C7D23350FB4F10DE1FE9A0A78123F2328BB48C137CBD5C75C260509CB751FFD8406C46BC20C33EEBC68E97792D7A1A5938B5332B272502CDAB1870A0CC68D5288FD970E746892468F46400C7DF011C22D58083160EDFB8ADA2056239062CA7952336E0289EB54D94CDDB234EB8F0669165EEB59119766F0E07D3B0790FAD1D048FA38E3966EFB4E9D387EDDEBDBB9F15B340F8E04165B47CA4A3DB85D68D565F7DF555CDD9587DD2E89863F42A93AA3D6878A1EF37403E8D1236D85E3646011BDAC251B5F526B03706067E13341A1E1F30C96319AB5BD37C54D7D1CAD1A69F799898B9BCB6F2CBB00A01875CFA8A4DBD5CAC46893686231BC0B13C5581C30BE0289AF0A43879C1D3A23FAC1CB158388A673E254A60F12899B94D1CDDEB0C339E835B99AB01A24EDB9E07B376F03E4207C557AFDEDBD87A7BF37D43878E9B3E7DFAA075EBD79FFAFAEBAF73A67F6C9A49B36FBFFDD6E8D4B97360F14906D6D3EB25ADA9D0F1459207BA4EBA43EE843C6D078D48DC90B8F65F9093A2ECF8B585A3F207CC48F4E6F0B5E6AA933A466ED3F62600E477BD28E03E71190710D37558E1C2E7A68895A3EA00875C8DD2EEB4C072E428EBCAD1A5E2E191F487E52C00C78154B470F8C73F290AC63C219A4FDD6E5A384C89D2A542E0A094CEDE25FA3EF0B068D8A918568EC33B9086EB4843BA59B05198051FFFAB51B3E6FFD5F5783E6F76DC71EF63D3AA57FB9F724ABAC86B78D7DF9FD4A1C33E94C55E80064F070D25BBF07BDB280723D9B94D0BF38C7079D0BF1F59476FA34CFFE8041A6EDA88EDBED931D4AF068EAA061C72D549F36E465EABE2D8569D4439E099C1A3585591ED6B689E666A5A3A2895B31B69D5000E7307510FCA2D36D808BAF1970D38B2001C2FA42A7078C76E15F5C63E213ACFDD1388E58811384AA63F25CA60E9E8396AB5F0346E213215D78A9B0ED5BE7456ED606931017094BB5CA40524DDFE061BAC1CBE2F8E61402274BC14C1B3CAAD59FA9EC35B92BB2D8B70D63F07F7E397483B92D361EDB3690D1C550138E4408E60F0BC669D11B8794A60D589C3391BD1CE9A23BE8FCFC64C3D0F3B93E6B529C3DE1E0302FB74203E21C967AFA43E703040B4B60767A30036E250676E2C1CDCDAFC2600C7FF3CEBFE20B04A45A4CA2A155A3818C7E11DFDB868FCC093A20F023FCB16EF8B2A68545A38081C25D3B78AD259DB45F7614B45018EB0E7A66091BA57428187DB4E3CCDAFFB1FDEBF778CC0B127CDCB30291015056CFC17F5725E8C75AB8123D58103B0C1552109597512AD85A37CD58AB5028601AA944EE76363B14E8165B3C9B376A43670D0F2236123C8D92891C29E3370E0EC149E9FA2484300C7D7A90A1CFE318F033A1E1327CEE0B1F3F1010E424719A163E812E16FDE36001DCA216F91583B42C579E80131E86C5A038772F8592AEA891BD00812583D01EF53530347C42B73A28B99A80C3081CF3FA7B0893990276CD549ACD061BF9F67AF6037D3241EF896A2C061AD46016C986E9438AE1A720B1C3CBC6D76EA02C713C207E0A837F67171F2BCDDA2348A65B1760B0781A364DA13A2DFDCDDA2EFF88DE2E86E034CE83037070B730AA6DB8E585F9773C4D249A56CE30E1CBABC8F2CEF449789032871DBF3484E850D36C86A0B47B2418287A631EE41951CFBF92481D50C39454D630A2E8C74E61C9FEBADB357081DA6A523E167AFA4207058AB5168D96080681CDC286197C5F2645807698A8DBF7E4E45978A1F81A3FE318F090FA0E398094F88E2380247C9D4C745BF5958BD32E951D1E2AC2B454EADDA474087EC5413DD79A743FA1A38920F0589D0AB201619AE6A6914A3654302486A0207E300CC813988983B5DDAF6808035E088EBF99D1350844BBFFCB90003E91A704A3F541ECDD358914FAE20334F67455A786E6EE3B6466E93930E4BD30E813C4A00B1AECD296A16D8EA3A4E66F8F8C0848BEDCF4D8B47E0EC15D3D2C1B24E2CD4A51E7070350A2D1B31AE468968592CC0C208225B531938E856F18CDA225A4E41E027834723D8F82B988583568ED2A98F89B2694F9AD2F1C60988EB4030A9B23998BD734D44079E2E696AE0A8FAC01104369EC4F7F5E3D881A71E707050E60163C7F7C40653DD8F94E37B19B947B731B2B82C94B36773D50682299BE3AC10FBF5F84EFE6E9619AF0508844C5F4DE3843EE639171C341DD377CA9FFCCECA274F34CA69701CB604EF83FCF508582CE82291021704B70B37F38E6BB20B1BE3A8786C75CD5D42E368864F2E705860521ED39150E8482DE0C8B6CE466987EDE46358FA1AAABE9C5D2AC181A37FAA038717C0E187749CB94394D1D2E172A7D1D0C0F1B8289DFC98289DF284289BF194E83572B5687EDA65A6B5A3664D6C698E8DC2B2720EEFD9116D7C47BA4045A8F7D4C051358123448C09B72E9F01A91B47D848BD8DBF08034D3B0606630EB84E6275E25CA991833328729BB433574804566DD8EF39C7FC8D818C356B6402545AE3FF58E1C1813C58FAEAF77896B9FA022B319CD30F9247A621F3D90A07A69907730134CCADC61DAC0432EFBC86B3624A55870DF99E78A7F240D2C4583A52073808C0519C8D12290C460A1C1E1CDEF68A67ED47C2B706B2FA0381D362054E8B15C93C2D9687B771A751B94A45BA5468E1F001363CF73F221A8C7954749FB34BF45BE06E6B7337C05102E82899FC282C1E008FA95B45B7BBE78906ED7B8ADCDA75001E35E06AA951E1F0371DEB11F9E0A98123F232AB4C500D13CCFA0D7EBF0C921167D84831E0A0B522C7C8835521E8C0AC0ED61C904F82E9DE3A542C68A76D0EDC584DC1413CDCB54E304097462C83BF7CBEDBE04CF37949DAC0CB6D9E62BDAE1302498FB1AC52F1878ED4000EBAC2B09A28DB533FE1F5E77C96CADA8F8D0267C9C0F7B7A73A70F846123A1E16478F7B5CF4451069D9823D61CF52890438081D2593B698F05106F8E878ED387154D77EA2766123D3E2811D7B2B1C751FA6534ECAD2C52A9887B8078D56C132A8AABAC13D36E6C5D98512761F0E17F57B4F02C0C7DCB532B771BBC46FCD1DEBE0A9EF8F7C874CF3FC95EE019756FCB7433F02385CE8F094F8E9B0B21AC50C108DFC6C94B8583882C0868490E6008EBFA4B28583C0E18595A360F866711C8348011D250B78805BF0C3DBA2018EE2071E11C5131F116570B5F49BB14374B96DBA38EE944B4551AB4E22AFC057BEB5B9B9A4D6B66BA90BC5AAAA834DBCF2AD8123C597C53AE8F0FBF86E11A47DFC3AC5A04B478F88E170D1A6E20F1CDC6BA2565DC430F44E4A871D6907AFAF771B2C1AE23A2E972574E4E5C77B8F8E4A048EC4AE46892C6874ED4706A02298D4C46F53BC6B3E4C59970A81C337F29100740CDB245A4C7CC2048E9204014709A0A378C2C32678F447EC48DF31EB4587AB4789E34F1F2C8EEA5226FCC7B6113970BBC81D456901A1104470227B4861706A68C9B07ECF103570681C0F8EAB0CC1B1F2F1020D359D58771A7DC1C52094887CA7539A1FA08C9742AE82B44C0268484B47119E75C4A17161EA7B58DCF38700500656E677FD4D608583B62254C33240BD76FB8D91EDAD8F388720AB87A273B71038B644D847CD8A8B0E9BAB510AB01A257101A24E6DC139862334701044FA03380EA46A0C870A1C5E58393C808E132661B5C982C458382470144FD82C4A2800907E848FA94F8AE2D1EB44CFBB178ACED74F101DAEBA5FB43AE77AD1BCDFC5A2F9804BC4D19D4B45C3763D203DADBFFCDC433490D2169F4DE91E9013BB8BFA96149D78B250A57EABCE3F356ADCE4D9868D1AEE6AD8A8D1EE64CA51471FBDD7E3F33D8958824D680C9BE3241B90CE093136AEFB71FF6371CA4FBCDEAB2AA7B31665391232047209843BC1368764C6584FD12C3F64102ACFCA6187EDA64C1FC77567C7359F3C63829DF689FD638B95D09092FA90C2335870FE4B766E5E3CAD1C39D0C73B22D061EA3963A2A2692F87EF41807345D8481E283B03C79A0F0D4F68C906703C1927E0385438EBB96F0B673EFBBFC219CF88C219FB847FFAD390BDC23F758FF04FD92DFC937741760AFFA4EDC23771BB081734AA02870FC051307C93F0023A5A033A4AE6EF14C573768ABE736089C099297D666FC3DF6DE6C16DE689B1D6D6E672E3AFC0B2D8C02A1519342A6338A44BC50E1CC5E3378992711B4D291DBF59944D00803CB045F49F84E5B5FC7ED43A513A7ABD281EB652F41DB214B24CF4C1DF3EF72E11BD2DE975CF6280CA62D103B062CA5D0B4C39F977903BE68B6E77CCB364AEE874CB6CD1F7EE059F6FDCFDD2595F7FFDF5C990DE4994E26FBEF9A6D3B5D75DE7CFC8C8E0864EF1945807B23CE48703533CF394CE697146165B6717BFFB1988CAFCD47159BFD483ECA8F26F6E0005E1BE1452F0FFEC5AD60C3109BE6F6D3989836B2456B0433D73D54F16A1C3A60B316C12961B810EB3EF21A444D806AD25D8BC0F6EA1BC567DADD551898FD9B0EB6DB4C06178577F701D80E3971856A9FCA368CEF3AF40AE0070D40370EC4A147078001CB47278876D14AD1E003CCC85A5636E7280A364EC06513286F21064BD091A2510FE2D1B4559674AE9A80745E9C8B5A2E4FE80148F5823FA42FA0C5F654A6FC0491F48AFA1907B57889E43968B1EA62C135D7FB758F4BB7FD5A7CF7EF075092AB40DA47D92A4139ED3129275D7DD779B27CE47DE18226D3CFA7A5DC649D2012B50303BBF96B9C7447E47AC1A914B3FF9974B4663590512EB00A8EF4FBE6584F5ADEA0074C2DC7F043A928503EA52AE6D52870147D979B5027BA9C8D54E95B49AC811380012860B698C6BDE8F0238F63798F7F2830DE6BED80FB06150001C0680A30B80E35F89B07048E02818BA5178876E102D273C665A384A60E948B485E348E05817B0705046023200179492FBD7889211AB45F1F080F41D06D080F41EBAC2945EF72D17BD21048D9EF72C133DEE592ABA9BB24474B973A1281BBEE2D3BDEF7CDE0F15DA0E421048B474C5335A41F2A84477FEEE771A38229E792469E04CD57C71274753E0174FDE8159E10705E605B119D9757C38C6BC5160A9A0068BE40FEE5505A8CC03E0CEC2B2D2A2C08EB1A9A2CF26306333BA26ED8DFC2E17247CC9AB1B2B5C2CC06178577D3019C0F1ABCB7D38F6359CFFCAA886F35F6E05E030001C266C28C0610038462512383CB07014DCB741D4B9F72171EC982DA237B62C2F9E9358974A35050EC24673488E54200D1C690E0FAEA126B0142F70DE463323A7FEB1464EC3164616567AB073ACDC19224CCFDC05147931B7E7666C063BEAAA32F0E97C565E5D99407A060EAC6B7A589FA94B479C3593A47EC2DAC82BB729616360CA04343B0207408230E1465A0338FE110C38EA2F7EFDBF90D50D16BD7A59C305AF1400380C0087710470CC7C96B041C92B9CBEEFB978C770480B0781C3030B47C1908744DD7BD78BA3476E16DD673C094BC7F684C5705433E0E80C85E902690CA9A92A4F72810303837A7E83FD6C0AD7835F921ABFCE4FE0FC10EE63C0EDB231989BB32EEECA892587F95D2F3203F2B2F2E01B6727AD9E0762EE7D603B7B2411E5497D4227CD4D9ECC25AE5895A0AD1A29103751A5200A9630A9CFD02173C330735BFA841F027724A8739B7D9C7563E62785564FC50A1C066063A303707C5AB4E48D31808D9E902C008701E0006C04018E804B25001DD3F77504707C19CFA0513B707886103AD68B3AF7AC1345C31E129DB1A2A4D40A1C8D77D06835020E824647489193D2240D38383BCE45E013FC911C18B27D0D03831408A47267C71A5E82963FEB862E0AD495E947E62E9B66472807B4C0815979272098EDB8AE38FBA35B40D4FA4DD44C519E518299601ECE10312D1AE60999C98BDCD71694EA0636D01DEA1074C9DC342CFE1B8685EEEB246C10E8530CD81C8103004190702BFD2470F897BFF372BDE56F0D2E5CFAE6D1000E03B0614A50E0980D970AC48AE190C0D105C0F15D3280A300568EDA77AF15FE21EB449B718F8812AC5229C55929E60A15EB78FA5857A95413E0A065E344488193C2243C8643CE10303870039EBC36FD0E1F24857329CCA86B0C5666F47865CD281231EBAE4A693ACDE2F81DEAC4AC1F483EEA8A601174FB6B76D23C65549E09C20E93F58B95015C111238F02C8EB3459E7F72542BE893B5AC55AF3649B9012AD506CC88F3C3F3588EEF11082895FA1B6F3D2EEF2702E7A198960DF33C9CD4DB663E1EC091E55BF9DE589CA5722A802317C06100388C70C0511F311CF58F048ECEB0707C9168978AB4701038EADEF3A0A87BF783C273D75A71ECFD1B454F1ED036FD4951AA818341A7B46AF0EFB176178A5D71EEBCF30E5BD028949F642FC569F094DB05CB19001BA27A8F65B5E0DA77D304CF06640FE093FFB782FA38A3C886052470B43666D66E67176A5EC2DD63CF67483008560EF67755CAAA4219D0A540EB4904D7072D4FDB3362B11AD8F388B3188EA83BC2466B1C00264F0F8D2632DEAC5F8008AC224CCB844AC7FA09533E2AA898FE6DC490346A691DB6468B46759B65EBF749993AE5F6E8CDD92FE599BBD24A296F2FC102A68FE80F43F411ECEB4CD8B05C9529081BAC8F78008701E030001C0680C370051C735F321C80A3135C2A5F263A6894311C76E02800741038EADEB94634B8779DE8406BC7B4AD000F583A62DC87A38A5A3864AC46DB602E14BBE2DC77FF28D8CC19F8C763B403CB63B3BD0DCCC86D73873E0E127487D01F6F9AB1B90AC01BB8A6A09E5193F760E956B6B761E01E4A81DF0CC032CDEFAE072BFA512F30CFB6E0F1DC66E43812379FED140FC046CDBCB023605E9057E6C78C2338E27A2B76C496CF40DA0E2E1DA671443938948F7CDF207FE5EE86E5E519EA7A2BFF8EE5A9DE87773541C68CAA8FC01D6595A3594EE5F554CFB412D06552FE1D5678D0EA14D7F319B80F024E3035375F52CBDB5ECEF6F2814E51B74CBDE40A0213368E0F585B3468E83248860EA813236B7214E86F200C98B66288CA27174EFD61A8768FBEAE2A9CE79374E008048C1E011C9D10C3F145A2F7E19041A3C18083D0E1B963356495683162833879E216133ACA081D516EFC550581A39B15ABD1047FB383B950E4F7077FFEAFB172D336E3F41BEE376AB63ADDC8C5AC31A7DE3150FEB60806BC3060DA4394746EA3138C6CFF5106FAFAC02A004473E7D394DD05D7C05F9EEDC771DDC776310308CD7B4CB18EFA8EB843B07CA8D6FDE64A086C3F9D5DD76F1EB455BE0493B11F18BC72B08EDE0C14645EAC202B06361EBE9EA04100C932AFAD904F0C82390D9A9B1D4779DA1CC0B90AC3B11C1CCAA7FC7DE57B2B7F997E51938AE519EA7A2BFFCEE5A9A48BBA611DE5143631B27154FAE13818A7004DCB5AC4380CD421EBD28C7C57F3C10EB542BE42B84E22AE4F65B68E3A257498960ED61FE1C15ECEF6F2814EB1CE7824BC5996B46C68D8D0A0118B1EC6E35EB36FBCD0EC7BD8AF94EBB4533F13AACD97F795A91F7B9434E06860058D3A004757C4707C01E0C02EA389D9693458D0A874A9480B0781C37BE76AC82A51F7B695A2E877AB459B911B449F498F629B72091D3829D63A2DD6CD4EA3550838E83EA165A305C4130E34F8FB98F96B8D8BEF9C6018BE8E8671427FA39639E8582B0F4C1FA21278675A29CEC6CCF28440705E8555006719B5F8BBE9434F40B01E0717AE84402C8019394EF33F6610B9479D60E42248D1CC4B854041BC877A3D76E723B4E436ED1880127B3EF91DCE24C83DA6ADB965703607C026270506357B39042B9F501D18CBC69E4EC80ECF4D79A29CCD0E8FEBF3CF46DE6111C29E135C4552614F0C5AA3F01D7FE335E6CA8D0A019FC936DD07024ED9499BF58732772CE70AE54300856E31DF66596ACB86B6EC245B6F833DCF9A1CA10F625FC498223306C3A99F8907E454721A89078E45AF19F517BE6A34581858A562038EAE081AFD12C021520D38BCB072786E5B21BC90A3EE02788C7848F40578944DE116E781E3E9AB20705C860AB7CBE5F8EE0AC885106E1CC6E0501F24331474AC7D7CB771CE35C38C0B6E1B6B184DFB18C6B1C546AD8E6E8394E4805819448E06CE9800CCF0F34EE813000E0E400C5674841DE5FA960025FA4643CD8E3920336D2CF3248454EEE01C69A78A776347D7760082734F36B2EA780E2F3FC6677EC7DF025629B7751D691E22B9DEEAAC3544686B45250FA4F103384E0408C772B2E2BE3DA8FD75FCF2E3FEF96E9E9958E000681036820047E7FA739EDF8F8DBF44AA0287EFF69582E2BD75B9F0DDB24C34BA73A53871C47AD117E7A210384AACE3E9439DA59262160E1536081AFCFF459052C849103F242B1468FCFEDD8F8DB6FD0719FE6EE71B4693DE86711C8202AB6A6397AB22DCE6DFB482B81C6879ADEBB893F836EA98EBC3B462C07581D540E652550A5706992B4CB8C1518AE557E747D789D6810A0199A9DA4613001C6F1B45965543C286037074C44EA3266C5405E0F0C3CA41E0F0DEBC54F820F56F5F2E5A0F7B50F4C4C16CC53819B68C00621E511F382D563DBC2D858083EE124286048DF3F1B90F84DB93D385522314687CFBB71F8CC625971A3E804646CBFE464E5B9E23A1079E546DD871C997B965B322BA53D703BBD68194D581B4B370D45BFA9651C4BD3714CB868385A3038246F703384CD8A82AC0E10770103A081C048F821B170BFFCD4B44F37B56892EA336885EE37042ECC487712AECC3A294E0619D165BC9C041C8E036E4927EF9B983E53639067FEBD821E3FD4FBF3468C578EDBD4F2A48D3B2CB8CCCD6A718B9DCB449773ABA0CB40E681DD03A90523A106AC298CABF19D8AE3C22E1B2D8A2256F1AF517FCDE1136140B478786F35EFE1C711CA2AA0387F7A625C273E32251F7FA85A634BA75A9683564B5E834629DE831FA211C4BBF49F40778F038FAD2B13892BEFCB4D8841EDED61F8AC593620916275B70D15A51B6A6F87C447CC65FBEFBC158FBF00E63C353FB0C4F97730DE3985E86D1AC6F05C96D078B86EE607419681DD03AA0752025752095A12254DECC8DBB2212C2C6C2E0B041E068B8F095CE081ADD8FB3544475020ECF0D8B841752F7BA05A2F6B5F384177F1BDEBC5834BF7399687BEF2AD175F85AD11BC7D0F71BB741F41F0F198B23E979343D8FA88FE1B4D89EF72E153DEF5D86D363978A93EF5A2C4E1DB5FAB3E73FF892419FC743B85157434841B8988CE133571803AEBACF30BC1D0CE3E89EA6ABA496EE5052B243D1C0A75D785A07B40E04D3812A0B1CA6A522527170A328AE952E000EC0C62BA2BA028707560ECFF50B8407C051F79A79A2CE557384E7EAB9A2E8BAF9E2A81B178A66B72C122D6F5F22DADFBD5C74BD6FB5E8391CC7D1E358FAFEA31E34A56CD45A5136720D8EAA0F8879543DA4EFF095A6F419B60247D6AF107D86AE14BDEF451A7721ADDB1688D637CD114DAF9A260A2F1CF7C1F4C75E6C06A5E309AE21E331A898774D5E6C9C8A552646A3EE86D1A20C2B4C7430A0EECC7567AE7540EB4055D581AA0B1CA1E121A8DBC4297603DFB5807C0CE0006C547FE0A085C373ED7CE1057478AE992B0AAE9A2D0A06CF167507CF129E41B344BD2B6789227CD7F0EAD9E228CA55B344D36BE7881637CD13CD6F982B8EBB7E8E29C75E375B348334BD76A6294DAE99211A5F3543145E3659F82E7940782E9E28EA5C345ED4BA60ACC8396FB4C83863C43B05678EF06D7EE17DC7ED635565BC75FCBC80BB042B4CCCBD33DA9FE987DC04590C590E190CA9EBD0F0B2F05D1B486748A710D205BFE558F7F39EE3215DAD7B6B3AA4DB02DF75839C68FD56037FF91DEF09F51CE6A31DA48E751FEFE1B3EDF7F0BAA35C7624C75879E13D7CD750D68E42FC7EB2551EDE30D7DACB81FF67DACC3BDF3DDC7B1E6D2B4FA7F754D3E888EB6B87294FA6C1BAC9745936F6B2C8C07D65902990D5D6DF7383A4C53AED10A46E9A85793E7591F7B24EF85EB5425C1FAC3CF9AEAC4FA997F677E17DD4A550BACD345A439C74584D8FBAD0DE212DA6ED0991779611CB82CFA13485F0BB603A489D70CA2FEF655B70BAAF3EBE0FD7AEA41EF15A350DD603FB8665968CC2DF13C2D49DBC5FEA7F38BD956D3A1BE952BF82F5037C872297CF56DB34F53D549B762A1F99A7607AA7F657D4535967F6EF9D9E2BEB3B945EB11CFA43E6415640A642FAD9DF430347005CB220E3011CBFA61B7078011CDEABE7082FAC1D5E408617D0E11D3C5378AF98217C574C17BECBA709EF6553850FC2BFDE4BA708CF6F279B5270C924511752E737000B48AD8B2698927BC138917BFE58C8189143398F329AF26E8D334714E69E3AD4D8FAEAC7C6777FFFD711E0B1FEC9A70DDF89D8A00A819F4A4C06078CCF21FF83084B7EC6DF9721ECDCD546C201F64DC83F5D881C44D880B75BD7FF1D7F9D069727ADDFDFB39E978BBF5B5C3C83F9D80FE96DDD27D371CADF015CF331E472081B70B04E6796F2DCCFF03914A85CAB5C7B418834F92CB51C58862C4B7E5FECF23D2759D7B39395E519AA1EF8BE3D5C94E73F70CD1790DF8629177B7971405808F93744EA0DFFFE07F2384442A0BC8F03FDF741DE957AF109644090323C45B9F7277CBE2A4459872A4FBEEB0F1042B57DE0A70E5197C2E9F6EF714DBD10CFE7FB5E08F96B90B47EC4F7DB20CD1DD2C8C7776B94FB5EC2E760204B1DA64E04CB2FDFF56BC86D101528EF70F18E4C93E57CAB9247F605EC13D837C8FA3E84CF7CCE0D61CAC3AEFFE1CA98FA48D862BE43F503D471F619E784783ED350DBF497F87F30E8643E83950FCB83BA330192677B9EDA5F51C765FAEAF7AC77C288BD1DADB2EA23985EB11C7640ECED8CFF7F18520E5D1A38144B0980630280E3507577A9A8160E27E0F001387C83660AFFA019C20FE8F0033A286E80A3368023FFC2F1227FE038913710D04131A123001CD9E78E2AAC79CE48A3C659F71BB9E78F365EF9E86BE3CD0F3F2D078FE1B3561A46E35E46DE49E54ADF170AFB9DD281A803073FBF0169A234122AF71F425CAFDE7F9C755F03FC7D4EB967B443A3DB6BFDCE8E860D920D75B7CBE7B01328B5EE93E9D8DF43FDFFDF702D670B4EC0C141728FF25C36EA502071B372ED2541D294CF51CB8165283B0AE625547EE56F33ADF4092E6A7986BA97F52BCB939012EE3957877907B5CCD8F1864AEF41FCAE0E74EC84FF1BE69EAFF03B67AEF6BAB9D376DFBA10F9E4CC2FDC7BF2F705B6344AF07F4242B87B3F52EA2E18B412DE085EA1D27A1EBF4B0B944C87104A4850EF0B66A920705027C2E597BF53872564DFE7F21EDE778F5546849E17C3DC774618DD69E8220DF92E1C9CD97F507FDCE82DFB80B6419ECF0903077399F6AFF84CAB64B0BABBD745F9D0C2A35A9ED85FC97C52C755E050F3BFC4E1B91BACE7BD8FBF721222F3C6B6FE4298FCACC5EF84FFB096ED540592485D26AEAEB7761A9DA88123B1C001E8304C396FB46114DF0ED7499F72452CDF7E3CD0D838C3FB5051E67FE13367546FD9147CA2D5F0790F07495A09D87839BBA155840DCC2EFCED58AB7171A07D46499383ADD9401491833C2D2D7280DC6ADDC3B4F91C7614B2D3E0FF39D3E2777F84C88155A663CF9B3A2B631A6CE4F63CF0B9349D7EA33C87E9D05D10AC73A21B4AE6E9E210D7F17EB51C58861238084B4C432D43E6970396FACEF3ADF4D909C9F20C5507BCBF97529E9C55DBCBCF3E58FD1FAE91F516EC9DF93D5D70840379FF9FAC3C7DA07CC7999E6AF665277CD0FA5DCDB73D0FECCCD981CBE7F333E145BD8EE5172C7FB4D8C96B7F51CA553E5BFEC6FFB752D229C6E7BF58F7B2DC83E9B56A9D0A9607C227DB139FC5B4589F761DA40E13A4D4346845B097C74541DE950031C3F6AE7C06F3CDF756D361BB962ED2BBACDFE4FBA93AC6CF2C17F9DBEDD6B32FC35FD6994CF36D7C26F4CAF2E2F7AF41A49BD0A95CA8FF9C10301DD9A6659A521F987FE69DFA444B2881C3AEB74EF9E6F3834128DD43B4A8A8E5612F7735BF842C557F649EECF5A24E44A8A3329F2C3F1538D4FC7F81DFD8EFAACF7BC87ADEBBF86B078ED9B67CB37DB1DC396952F3732ED34C55A008972F570011245E23DCB25803CB62C757C7552A3268B4B22D1C2A70E49C791F8EF53EBD5C116D8A4EB3B4545A42C040086732F477DE6F357CFEFEA9D5F8EDC04158B911C281961DAC2A57E0FF72F666070EA6699F0DD981831D0D0780C156BAFCCB4E93F7D284CB59089FCB8EF03C881CBC653A07F01D3B5699275ECB015B76AE6CB84E33479AC2D58E95CFE30C2591C04180A065412D3F0E32B420A80307E1C60E2E7FC6773738943FD3E23BCB0E4CED10D961B37EF8FB20C8180867885217E82609051BFC8DE52E0770CEC0083634331F0FE18C4B96E164252D15383860F1D9CC03F550CEF2980776CA4C47E6A1293EBFA3E48FD7D012E1E492E03D2A70701092E5CA32A5454A0233D3A1BB413E47050EEA5A30BD3E0DBFA940E454567C26AD637C06C1F93796F079EABB3C82FFABEEBD5B6CEFC9FBA7D9AE91CF53818375CAB2E673F8EC4B210F40D85664BD4A8B2321EB4AA55C54985B81EF594E4C83569A961042C422251D4E409A40D8BE5966B4F8C86704B3C630CF2C33D60DEB9DE95387645D1030EE86B0CC9977B669C64B705220076CA9B752B779FF4A887405D3B56277E3F1B9ECD7ECB0407D0BA6E32A70B00DB24C99A7DF415E57D2A24542856237C0C177A00EBA010EEABD6C63EC07081F6C172C9753216C43F2BDD8E672C30DECA9FA7B4281C33A4B655C12F6E1F8C17BFF235FFB866F16D11CDEC6B354E4D6E6DC69D4BEF197DC87432E8B4D49E0387B7828E078C55258FA263900D91B20679A52A1CFB47E572D1C1CDCC375BCF60152A6C77BD5E7D981C3A933586DE587B37076784ED7C87438F322E8D8AF79C64A833103ECFCECBF8F50DE99D0C2FCB253A439D8E979F1B07004EBF8662A79E1EC51C2830A700427274B8D3D4DFB0CCCFE3B3B7A390BE40C9E168C50D0C1418765C3D99F5D77A823B29E195323F3A70207633CD4F409BA6F59F77100913139BCA62B44BA273880CA5978B0380E15383880DBDF83902C3B72C672380107752DD4FB87FB4D058EB1B6B4684593E543976563EB779AE8E5E0CFF795EFCCFA505D534EC041B851CB4C5EB35479966CC3F6BC1358991F42E26087F7A6DEC97645EB9F7D501FA63C8369852B1BF5F7A7AD7B090B8D1CEE0DA7B7D42D5A06987F5A3A4FB6A55113FF6780257F673F275D7A9FE173B0380E1538A87B6A7E0960CC2BD32304B4B77EB7E733988583F7D195463897E906B370702220F5643D3EF35DD4BC0CC0FF659BE584A151AA0245B87C25033832EBCF7D712CCE5249D44EA3DFF8466E3919C0D1D63B7CF38B69091C88E5C8E351EF8AA94D51587672DF590A4DF0701AB48AF13D3B2152BD6C782A7070F0761AD4ED1D8E3A40CA06F423EE550352C301473EAE970D93B3DB60FE5A990EA1849D833D2FD204CD81D26E65E13338239603E9B3D6E750311F89020ECEA255133C6759F25DD4F2240C49EB4EA88E3E5887A8DEB3CF7ADF6FF1B7A743D9A9D772D6CD7262077EBDC3B59C41323D061D4A33BB0A1C9C0DDA6155853DD515C319B7D41B0E508445FE9F333EA777568143C620A8D7F5C17DD40FA6B1494983FA4E50E5F7D4B548064EFBB52A7038B9E4E44C99F5D7C67A16071439E3E7EC59BAA7081E1E87FCA8160E5E439D0906137C27CED29DDE893377091CD28AA65E47D89631432C37BBBE7190E7EF1C1439F3765B6E7C5F99EE87F84CCB8BFD5E377ABBD1CA3FF3669F44D08DB4CBFA9D96A5FDD667F67DB2DCEDCF5481C3695232D24A8365262D649100C7015B3905038E57ADE710A408A9F67C12D25F86D075C9B65037DCC09EAABF2703380C00478DFAB39F1F87D3620FC5F9F0B63F79476DE906E030001C0680A3368063BC67D8A69F3CC3360ACFD00DC23364832818B25E843A9EBECA5B38001CF2F453A9688AD2B213973EE66026749A4C69C2E38C460648A9C0C1CEDFA92374031C6CACF394FC240238A40959CD8FB4DAF0DDED9D236317D8F1316FBF8770E6C6590CA1CB69E062BA89000ECE6609737290E567BA5D9C8083E66CE99B8F1538E48C8A1604278850D3A7BB4A9AB2395BEC0B5101827041D3AF3A330F071C72E0E37B4BE020AC4C57CA82667E3E8FD7B05C547784CC9F0A1CCCA7BD5C3830B393661AAADF5F050E5A1ADC0E9C4ED785030E39D0B2FE5A5BCFA2FE49C85C82CF12EAA87F4E3061070ECE78430D9E6ACC817A5D38E060FB7F58A9039AEFE97655EB9675CDFA550329C3955F34C0E164E979CACA1B419930A93EF768FC9F931B099173F09990CC72BE26481D87030E4E54A40B52EA891BE0505DB5B43CC97C3A010727157FB6F2CD09A15359B2FC3871E4B526D4A72A5084CB57B280C3007018008E07001C87E2743CFD9F7CA31E3D19C06128C06100380C00477700C7D3008E7FA50D7058A7953A00074DCD6C781C5CEE0DA2D04E4AAE02076769ECDCDB3B4813A5F3B1CFC865A7CA595C3DEBD9F1060E5A41382B28B0C487BF5D20F415B3F3718AE1E861FDC6DF696AE7FFE5A0BA2A4819250238CEB5EA455A10CEB63D5B2DCF2FF01B834E9DEA80310E7240763353BC1CD7CB4E91D6865003063B76353E807965C7CFCED8C934CEB454E0A0AB454D9F0315AD0D4C873AC9C19FBF13685FB4BE67DDB18395D6814FF0D9092A55E0602C92D401FE3DCAAA5B0973B72BF95081637B90326539077B3FF57D54E0A0FB49FD8D80280741BA03E43B5CA6943F67D1748148FD1BEF501F76E02050306DBE27CB8D79A5F95EBE2B83309DEA341C70F01EBA85643AFCCB0197AE8A4E104E4CC2C145B00133120B07FB0DF63F7C37BE23DB34DD48328092FD0967FDEAB34A947CB30CCF82480B99EA4E53EF09071CED9006DB1DCB8141B0BCD70D70D0BA42D717EFA325EB04EB5E27E0E880DFA405FA09B7E51B6E604FD5DF930D1C068063521C80E36BEFE8C7BA03388C20C06178866EAC09E098A181A37CF6C499BE6AAE0FD771A8C0A17640F6CF6C249CF5303D75805C8CFFD355C1818D1D08FDE9BC26DEC071D0EA0C1EC35FC60BEC801C503A1FE68F2E14F57D0729BFCBF800697ADF87DFD8D1D9CB27DEC0C1CE9B3E7B599ECCBFDD67EEE4A272AA0BA623FDBE6E804305AC60562FF5FD772BF9549FFF36BE67F9D97DE42A70D03A46EB1967CA04A36B21D2BF4EB090E67502861C9C5967F47DCFB29ECBFA748A4B50818360C9FAA7B02C3928A97965C72EDF49058E50BA3DD7410FEC7AA102C7225C4FD0E1BBD28C4FEB854C9FEF2467EDF2BDA8BBE7439A42BEB2AEA55BC0FE0C153808699C09D312C177DD0AA1295E3E8775C2013A5AE020BCC859BDBD6CE8D2B05B16C2F523FC3D520B07DF91A0CA32635DB24C640C03F3F4A8C3FBA9F040A0633B906EB31794B28F043818DF44F70C9FF9A5F54C37C041B8921656DE2B8347E98AE2FF099F324E8B79A59B8CDF3F607B2FEA0BCB4E155A3832521528C2E5AB3280C300704C2C9CF18C289CB14FF8A73F0DD92BFC53F708FF94DDC23F791764A7F04FDA2E7C13B70BFF846DC237E129E11FFFA4F08DDB2AFC631EFFCA3FF689937DA31F332A00C7F0CD86779869DD08C8D08D35BCF76D98E8B92F4D5C2AC12D1CF42B539949DCEC1CDD7410BCC62D7090DAE580AE0E9034C79E6B3D9BCFDF6C3D9B40C0FF7F1E242F4C2B92188E5003066738B40AA8EFCC064B170FEF63C746BF347F6727C6EFD849C9EFD4FBE20D1CB7E33974E3F0991C503943B3D78D5BE0600717097070B62867D4F35DE80467B7EAA0662F73CE8065FC06DF41050E420403613948B2A355EFA54E48C82204C8DFE42C5FB5C48C76C8A70A1CA1F48020A096AD5BE0708AC970020EE9B2A4A99F561AFADBA53B88F92274ABF997969B2FF0FD89100285FC8E69D85D672A70847A4FEAD385567AD10207EFBBC3564FEA33599FF698A8707D4AA4C011EA1D69D1A405537D26AD668F5879A6B54006D54AA0675F23AD0C910007A140EAACECAFDC0007219B7D887C0F19C7C400653B708472C91154D88FAA42D74E51B8813D557FAF2CE0C800704C2C9C1E31707C0DE8E801E83060E1380C1C88DF0060D8A5092C1C3F6A0B87B9B744228183332C270B07699E664FCEB8F87C765434294B1F7122818370454B8AD3AC98B33F0E08CCD3374A473444E92006D93A347652F1040E96037DFAB243DAE0F03C3ED32D70B08C13091CCC0B838939DB0C36185CADBC830A1CC1AEE78CF574E59EE14ADA322D5A442494516FEC7EFD70C0C1017D9CA29F72B0710B1C04D3708329070C091CC1DE956675D625D3E2202667DE1C103980F17B39FBA5FBEA54DB73C30107CB88B14804B450B1156E5C2ACC0BD3180CA12BCBE99D089FF27DC2950F7F8F0770B05CE8FE728A5F617E6599BE85CFD2A5C4004BE69F9624968D3DAFE15C2AD102C73E3C8BD048378CEC7B09EDD2EAA15A38420107FB56A7F26F9EAA40112E5F95051C06802313C03121020BC71FFD800D008751013846023602160DBB5C935641A3C12D1C72A91807E18B1D1A5DB00E43B570BC81FB18CCC641C72E1C3C6527A70E90B452B03355674B77E1FFF1B670D01CC9CE9AE657193342937D306B4E13FC264DFA8FE2B3F44BD3546C9F61AB65134FE0E020289F45F3357DC54EF5A096E797B8E694207540B74424311CBD70BDB4702C8840273C961EB0E3B40FB2CFE03B9AA0F91EE18083F57427445A450812349BB34CE8A7A7CB4796C7D7D6F7AFE22FDD156A39A9C0C10197BE7A96932C5B5A50ECEE1EDEAF02079FEBA4D7FC8EAE9170036A38E0E0E0DC5D49E75C7CFEC9CAA30A9A6C1BB4B8D11A729FEDB92A70102E38F0B27D11E2A50585312CE1F2EA1638643A4D91265D66AC5BFBC037CCC5F3643A910207DF7105642744B669F65F4E01B57C06DD653226896E1FF95CF677F2FB090EF98D04381897C174DD58386871649DFD5629B719F82CAD302A70F01A19EF31D99647BE8B1370F084F02A19385A99C061003832011C13FDD3F61C0AE552F14E78EA5BB854BA03388C238003B041578A4DB21034FAB1060EB381DC00E100CB86670F6A930D9324CFC0CB6C45E155E020A9DBCDBCE1064876881C508E861CB01A0E3B2E365C36A27859386862A5BF9CAE180E62ECB4993E07200E90F67C72F6281B31074DCE8C2832708BBFD17F6C0F4A8B1770D0B42B57C8F059EC88820D142A70F01E37417BC13A44F519B42CC88E787488E7ABF748A0E177D4938610CE20657973A09771122A707C8AEF2741C642E82AB90ED211A2CEC4793DEB91E5C1C1867521EB4582D1F7F88EA0100C383848335F04605A14E4CC72A0C3FBA9C0417375B8813AD4EF2A70D072C6819FEFC9B6C6E04EC6A6A8F78F54CA4CD53FD946986F0E4CF6B2A79EF03702F65910D6337559960F6358DA867917B7C061B79250EF3843A76B4CEA0D270E6ECB2D52E0A04582CFA4E5F45EEBBDF9EE8CC550FB28F97CC605C97CB14CE996A2FEA8B128B490A93ACC7BC30107814B5A22F9EC488083D7D2D222EF679E5EB2DE45050EBAD4A4EE1324D5321D8AFF13882912BC590E1A38D4DD48ADADCD0D6BE32F2E8B95AB541834CA180E5A38081C0680C3F04DDD3319C07128480CC7B7008E1E000EE348E0C0725867E01800E0F835AD8003BB8C52591D56A930284D065C11029C3A09C639C88E8E16005EA3020741C18D09D5C9C2C10E82334F3BA9C70B3818EC79BC95E702FC95BE700E84ECDCEDEFCBC0AC60A66FF9BD1ACC28EF8F0770B0239FAE3C9F838C7DD6AEE6572D4F0EA2AC93709DBC1BE0909D38CB4806F33AA54B603C197225E47A8767F37DA4C58A03A19C81AAC0F114BE771A24D4E7D19A2007CE5075C381251870DCADFC46DFB74C8783A41D1E55E008D626C295B3FC5D3589DB67A84E691066C3E91F5D2D32B68569A8160E963341437EAFA647DD8AC5A5C267326D02536B87FAEE86EF642C8F9CF1BB29A76880435ABF38E8BFA59499931E121AC39529833F09A36A7EC30107FB450903EBAC7B23B170F0591214D5FCA9C0C1364D38929324BBDB50D63363AD641A1A3862040EC33F65CF5407E0F80641A33D011C861D381830EA1901570A97C1DA65D8A68D69B50F07CE53C9EBFE5B28E6194EC0C141EBCF96B2721664EF7CA9D0631465FE8DD5B0E2011C3298949D183B4AB5D1C513385A2A1D09C140FAFD3948D37A233B1976DC347786EB9CF83B0725B5738A0770D002C0998E7C3E3BBC501D76A28063939507CE00D5380A7B5E3CF89D160AE69741904E79A5F582BFD3F42D830955E0D886EFD949877ACF3B5CD609DD83EA80AABA54D4B224C4BDA7A479A9EDF989028E7041A66C7B72D543281D646C11214CD55BD5C2A1BA16FA5A65CFF4A85BED439475380B875A9E84527B9D11E8E5E0FF55983A55EF8D0638545718DD37AA25C76E6D9556845065FA23D2B0076687030EC2B87CEE68EB7DDD02878CA9EA87FB187F120C38584E7459F3774E9E08F84E6D459DA868E08815387C53F6003A764F5656A97C8D552A3D011CC611C031F6096CF4F5B0336C0CDF740C623A7E4C2BE0C0E16D39E78C08B5B5394D7554680EC4D36C0A4D532967F4FC9DBE65194F6077A9A833AE608387DDC22181831D04FDB1C9000E9A62A5DB86EFAB0E44EC30A599959D3A5D02B47848D9A0E4913E7575705381E3DC309DAD1D14EAE17A76A0AB94F4DFC7E77003B19A0E5D2A323837D4E06DEF10EDD732DE831D1BEB8279F08579170283D40D7B87CDB4F759BFB35C25A4450A1CEBAD34684AA73B41AD93B9F8FF01EB773E4BB5F204030EE66B8852D66FE3B31C00F89B0A1CF170A9481F7C38E0609C909CCD7E697B4FBEF3B3569EE902A5BEB9010ED6B7DAB6E8D2719A2533AD70C041F3BED40D9AFFF36CBAC1C150CEF8698509A587F1048E4678966CD30480AB9567D36A21F3C47E4CD51D7E562D40B7D8F2AC02470FDB6FECBB18782EFB2CBA9CF94E910207DBC216251DA6A75A3898A61A30BDC4A15CD97F3EA3A4A181234EC091E19BBC6B0696C57E8365B1BD011C861D384CB70A56A86057514781B5632280E397B4038ED087B70D509495EE15CE9638B365C0923A13A479590E6A2A7070567631A43FE4149B301DE96E09061C6C54B7D91A5DA22C1C7C163B7ED951B0C391EFC44E45FA7A1950E834184BEB080741094CBC4E050EFAE759A6F6B260F9F0DAFA4A07412B0B67B69C75AB6E03065E72F6634F83D62039BB55D3A10F97D627A73A601A4DAC67AB1D22072EAED4E1EF84856B201C7C65D92C7528037B99B0D396711AAFE2B3745FF1BA114A5AD49163ADF422058E4FAC7408812738E4490EC48CEDE0A028F3180A385490669DAA819B2A7010629CEA8156045E170EC854974A38E0A00EC9B25CE4F09E0459F93B41CB0D70F01AB64D59A7B448395931DD0007C1581D64F93E32EEA1393EEF569EB3C285EEC8FCC76AE1603A6C2F6A9B9669B34DC80066C669D8F597564579DF3C7C56614C058EFBF01B5D28D405C6FD302DD95710F6E57D910207F3732B846D51E6C30E1CD479353896F14ED20DD91E9F1F57EE651A1A38E2041C0680231BC0D102C0611C011C88E3F071496C10D8C0F7F5011CEF0038445A0247BBD3829D16CB4E63AB4D69198427633BA8C46CB4672B0D56050E3616CE60B982809DBE2A4CE73CEB3E758024BCA803766BFC5F9AE7F9BC44024753A42FCD989C7D4A10A09F5F76221C48ED9D1383BC38EB67FE98577536AD0207D3B69703FF4FD75530E02010A8161E961B67664EE91092ECE970D00C5607AC17198BA176887C9E4C9F33575A10641E68620E1764C83C3020570DBEE34C93B35FCE70E5E0C8345742A4152112E06889FB987FA6C1F81BD594CEE7334D5AE564BE55774228E0E000C14151DEA75A3254E0609904D36B0E343DADBAB0EB8AFC7F24C021FDF0D441C6C5D8D36C8CEF2494EEC0675AEB788D3D86C3BE5A8330AB82A453A0AC1BE0E073EE54CA8CF5CB7A667DB3BDAAFACBC0D5606562FF3E1EC04108A7CE320FB41275B39E4FDD607932AFB414D89F7DB455BFBC8FEE543939E2752A70FC1DFF677BA42EF0B3FAAE839474A3010EF68BD4A560C0C1BC304644FECEB6CEFA64B9ABC1A2FC9D60D258AF5259F86AF98A972882460DCBA542E030001C8613701036CC788D119B1D05C071197EFF4F928063058EA76FECB976FE60CF35F31679AF99FB96F7EA3907BC57CDF98FF7AAD987BC836709DFE099C23768A6F00F9A21FC574C17FECBA799E2BD6CAAF05E3A45787E3BD994824B2689BA903ABF99684AAD8B2688DA90FC0BC78BFC81E344DEC0B1229772FE189173DE68CABB389ABEB0FC787AC470649F37C6C8E97FDB61E0687BAAD3602ACD926A63E2673656CE6654FAE760AB0282FD1EF5FFD247CE86F5BCD570B8A44B050E7666EA00F0A543E7C03CF31EB91C8C83B274F1D8DF87335339A03ACD8A69C19079A4FF93F74BF32A3BF5C10ECFA7DB48BD8FB323F95C9A63439581FC4D82822C0739E3E460E2E67E5EC31536F674C2DD2B7DEE7613BBD37D7C7FBA1CDC0E18E3C2E49D9DA26A412034484B11CDFDA15C470C049583EC6341F274B9F27CCEFEA4AB8BB351F97E4EEF73217E97B35F0E26AC03BE33AD3D127242952B071ECE7A439513AD8472F66A7757AAF7D1EAF08C955F0E902739A4CB8199ED8279628C447BEB1AB69D59D6F72C2B5A15D5B4F93BCB45BECB767C565D48F25A02B7BCC6EE5E90D730E6495A9482950DDD6C32A8D38D0E312F2F5ACFA6358B930FFB7DAADE5277ECE0C9EB659B62BEA642A80732268B130B5AF3ECE91628EFF31F7CA6E54B5EA3BADD82BD2BFB226921E57DC1F2A97ECF77B597FF42A5EC194BA7C69631DD6320FC3E943E128E596F991A3892011C70A584008E4C00C7E6249D16FB8BF7FA059D001C0680C3007018008E0C00470D00C729008EAF920E1CE78F35724EFDDD61E03871805347407F271BD0B710C66B70C6F00564A843436583603013AFE38C3E98F07739A322A4B03362274FB8B0FB80D921D06C4ECB0ACD8A4E79E43DBC97D7109038C376BAEE09EB1ACEBC5A385CC341E580957FCED238D8BC66DDC3861D0C64D80931FF7C2F0E26F2D91C18F97DA8B2E020C6EB6539F01D58861E08675AE1CA52A6CDD9AD9A4EB8FB3830CA01841D1FE320F86C35AF4C8300F71184D61A370385BC8620C61918CB53ED1039707260546780BC878305CB8279605E4201C764EB3ABE03630C9CF245FFB9AC4BE6430E00C5D6BD7CCEED0EF7F2B97BAD72A7AE73F6CEF47B433EB3BE0FA5D7BC86D7862AAB0BF03B6186E910CC825D4B3D7ECB7A2621D469C02638D075C0BAA255495A32F83D2D72FC9ECF92163BF5598CAF605B6059F05ED5F525AFA38E309F2C6BEA73B0BCF6C16F6F43543700EB9D83FA0B105A0223D11F0EBED469E68D6D90562D27E0907A4BDD71020EBA8EA41EECC267EA058183E54290512D92327D3E7BBCF56C3E5F2D3BEA8C533BE133A8D773206CBB6A5ED5F6A5E653FD9EEF6A070E5A6408E67CDECB907A0E65C0090EDD96322648B635D98FB04F33F3A28123D1C04157CA8887434957EFF087FF9424E07809C061D880C3007018000E3F80E3A3A403072D1C670C2957C4BCCEE72388F48C609D0267579CFD315EC0EFA0F872D0A0EF9FD7112882C945F88D8329EF61A363677519842650D562C2DF3950304D761C7CB653FE780FEFE5604F40E10CC5E93A0E04F21A697A56AFA30F942E22997FC2169FC967D3141F6C86C6CE94F9E77DAA8583F109FC3E545948D7123B4B9603F3C7F7E5B368B9A1BF39D4FDFC8D03585FEB9D653A6EEE93D0C5F2A31B80A67EF5594C831D961D0223193868465F0ED90A79183202E2347870E6C9B2601E9817BB1EA8CF2434F0BA73208DACF7B6E7A92EBE3FC32A3F0EC2126038C0D0BAC6FB9D0658A6C3192D7594C24199DF11A6995E28DDE66FBCC63E13B5E78DBA7F2E84F516CA45C5773BDFCA07759710E154F6275AF9A2AE3557AE2120B30EF92CD52D20D3A08E51E7A8DF7C4E1387F4A923CC277FA73E87AA7BF60B1C903941617D3F08B90A12896543A6CF77A54E336F0320AC4FFBB355BDA5EE482B967A1DDB037F635D520F58566CD32C17B6B360EFC3F7A68E505A29D75167ECED84F54E3D6F1824BD60F994DFB3CDF35DEDF5CBF7619EF93C5AE6D83F39E5977D24017E0384E5BED6BAA742BBD5C09148E098B8CDF001367CD8C23C8864E2FBB1B070882401C7459EEB171A1E5838BCD2C261C2C66C4A11E4E3A40307DD2A174CA8B2E45B551B90CE77D5DCF150D79BAE37AD03C9D781CADE69546EFC153C86032B55BCB46E003642486300C787BEE400C77EC04691091C26742CA43B45C246E50207AC1CBA1125BF11E932D765AE7540EB80D681F03A90D2C0E17F60076023B0E74618E0380FC02192041CE3BD372CCA8018DE1B169B6E15EF95B352033860E5D04A1F5EE97519E932D23AA07540EB40F27520A581C307E0E08EA2BE9170A7E090B620520BDF6F0690240338FE09D0E81A800D091CF3530A38B2CF1D8D152BD879B4EB45463E96C986F06BEADF220B7CD3E5A5CB4BEB80D601AD032E75C009E8521838001B631F47CC4648D820846441AE00703C0B0BC70F898CE1F0DEB8689DE7C645F910C3949B16C3A5926AC081588E81E38CBC5E83CC9D47357044144DAFCBCB6567A2F54AEB95D601AD03A174A0BA028769F9305D2EC3379700381EC43E1C1F2560E3AF5F011C83CB612395818301A4E7033A3A9E1B6AA58A1E5CF5E0AA7540EB80D601AD0309D18174008EC03E1DC3361D07E0B81BA7C56EF30CD970A860C87A5170EF7A51F79E074501C473D75A53BC77AE86AC12DE3B5609DFED2B4DF1DFB642F86F59267C949B970A2FE5A62502A0F10E80E3A80AC041E860C0680AC570946F0686F355728BAF4B8822E9998D9ED9681DD03AA07540EB40BA5B382470003A361A008E5A0543369CE319B27E0E80E3C7D88063F104CF8D70A1A882552A36D8A8DC552AB46CA872DE58ED56D1B3170D9D5A07B40E681D48BA0EA4938543028701E030001C19008E76B06EDC0279290A0BC7B788D7E86AC66CA87243AA0307AC1CFD6FD5D0A13B9BA477367AF6AB67BF5A07D25B07D219380C008701D8A078011CA7431E874BE55F2E5D2A5B011A35AA2270E49C3D1C830D761C0DBEEBA81E8C3490681DD03AA07540EB405C7540034700380CC006A50680E37800C744C4707C86F88D9F83C4701C440CC76F214605816BC5DA59D4FEB7F2761AB5BB54CCE0516C797EDA5D50A4B302E0A11B952E03AD035A07B40E681D48B00E68E0A8081C068003B2CA0070D4026CDC0CD98DA0D1BFD982463F0168645759E030B73C1F6FE496DD68E49FD85F37B20437320D74E96D46D6F5AFEB5FEB40F003E6AAC33E1CEAB2587BD0A88CE1505D2AD2C2A1028701D83005C0D11FC0310DAB54DEB456A98C3B023668EDA82A160E69E538FD1E2C933D476F06A6814343A7D601AD035A0712AE03DAC211DCC2A1028701E030001CCD001C9763596C7D88E12881C3DA52DBA522DD2C03C71B3967DE67E477385B4387EE6C12DED9E8599E9EE96B1D486F1DD0C011197018000E67D0E0F7150F6CB39FA5F249824F8B7D0FCB5F0B2B2C81758ADFB07F871D4873CEB8CFC82374E820523DE86AF0D23AA07540EB4082744003473C81C3D9BA41F02884BC0BE038E81B3CF3A06FD0CC83FE41330EFAAF987ED07FF93453BC974D3DE8BD74CA41CF6F279B5270C9A4837521757E33D1945A174D38581B927FE1F883F903C71DCC1B38F6602EE5FC310773CE1B4D791DB0512F62E02080E044D9EC3387C2D2C120D2F42670FDFEBAFEB50E681DD03A90181D70028EFF07EA739BD2D746A48E0000000049454E44AE426082, 0x89504E470D0A1A0A0000000D494844520000021C000000C30806000000C909C8AF0000000467414D410000B18E7CFB5193000000206348524D0000870F00008C0F0000FD520000814000007D790000E98B00003CE5000019CC733C857700000A396943435050686F746F73686F70204943432070726F66696C65000048C79D96775454D71687CFBD777AA1CD30025286DEBBC000D27B935E456198196028030E3334B121A2021145449A224850C480D150245644B1101454B007240828311845542C6F46D68BAEACBCF7F2F2FBE3AC6FEDB3F7B9FBECBDCF5A170092A72F9797064B0190CA13F0833C9CE911915174EC0080011E608029004C5646BA5FB07B0810C9CBCD859E2172025F0401F07A58BC0270D3D033804E07FF9FA459E97C81E89800119BB339192C11178838254B902EB6CF8A981A972C66182566BE284111CB893961910D3EFB2CB2A398D9A93CB688C539A7B353D962EE15F1B64C2147C488AF880B33B99C2C11DF12B1468A30952BE237E2D8540E33030014496C1770588922361131891F12E422E2E500E048095F71DC572CE0640BC49772494BCFE173131205741D962EDDD4DA9A41F7E464A5700402C300262B99C967D35DD252D399BC1C0016EFFC5932E2DAD24545B634B5B6B434343332FDAA50FF75F36F4ADCDB457A19F8B96710ADFF8BEDAFFCD21A0060CC896AB3F38B2DAE0A80CE2D00C8DDFB62D3380080A4A86F1DD7BFBA0F4D3C2F890241BA8DB1715656961197C3321217F40FFD4F87BFA1AFBE67243EEE8FF2D05D39F14C618A802EAE1B2B2D254DC8A767A433591CBAE19F87F81F07FE751E06419C780E9FC313458489A68CCB4B10B59BC7E60AB8693C3A97F79F9AF80FC3FEA4C5B91689D2F81150638C80D4752A407EED07280A1120D1FBC55DFFA36FBEF830207E79E12A938B73FFEF37FD67C1A5E225839BF039CE252884CE12F23317F7C4CF12A0010148022A9007CA401DE800436006AC802D70046EC01BF8831010095603164804A9800FB2401ED8040A4131D809F6806A50071A41336805C741273805CE834BE01AB8016E83FB60144C80676016BC060B10046121324481E421154813D287CC2006640FB941BE50101409C54209100F124279D066A8182A83AAA17AA819FA1E3A099D87AE4083D05D680C9A867E87DEC1084C82A9B012AC051BC30CD809F68143E0557002BC06CE850BE01D7025DC001F853BE0F3F035F8363C0A3F83E7108010111AA28A18220CC405F147A29078848FAC478A900AA4016945BA913EE426328ACC206F51181405454719A26C519EA850140BB506B51E5582AA461D4675A07A51375163A859D4473419AD88D647DBA0BDD011E8047416BA105D816E42B7A32FA26FA327D0AF31180C0DA38DB1C2786222314998B59812CC3E4C1BE61C6610338E99C362B1F2587DAC1DD61FCBC40AB085D82AEC51EC59EC107602FB0647C4A9E0CC70EEB8281C0F978FABC01DC19DC10DE126710B7829BC26DE06EF8F67E373F0A5F8467C37FE3A7E02BF4090266813EC08218424C2264225A1957091F080F0924824AA11AD8981442E7123B192788C789938467C4B9221E9915C48D124216907E910E91CE92EE925994CD6223B92A3C802F20E7233F902F911F98D0445C248C24B822DB141A246A2436248E2B9245E5253D24972B564AE6485E409C9EB92335278292D291729A6D47AA91AA99352235273D2146953697FE954E912E923D257A4A764B0325A326E326C99029983321764C62908459DE242615136531A29172913540C559BEA454DA21653BFA30E506765656497C986C966CBD6C89E961DA521342D9A172D85564A3B4E1BA6BD5BA2B4C4690967C9F625AD4B8696CCCB2D957394E3C815C9B5C9DD967B274F9777934F96DF25DF29FF5001A5A0A710A890A5B05FE1A2C2CC52EA52DBA5ACA5454B8F2FBDA7082BEA290629AE553CA8D8AF38A7A4ACE4A194AE54A57441694699A6ECA89CA45CAE7C46795A85A262AFC255295739ABF2942E4B77A2A7D02BE9BDF4595545554F55A16ABDEA80EA829AB65AA85ABE5A9BDA4375823A433D5EBD5CBD477D564345C34F234FA345E39E265E93A199A8B957B34F735E4B5B2B5C6BAB56A7D694B69CB69776AE768BF6031DB28E83CE1A9D069D5BBA185D866EB2EE3EDD1B7AB09E855EA25E8DDE757D58DF529FABBF4F7FD0006D606DC0336830183124193A19661AB6188E19D18C7C8DF28D3A8D9E1B6B184719EF32EE33FE6862619262D26872DF54C6D4DB34DFB4DBF477333D3396598DD92D73B2B9BBF906F32EF317CBF4977196ED5F76C78262E167B1D5A2C7E283A59525DFB2D572DA4AC32AD6AAD66A84416504304A1897ADD1D6CED61BAC4F59BFB5B1B411D81CB7F9CDD6D036D9F688EDD472EDE59CE58DCBC7EDD4EC9876F576A3F674FB58FB03F6A30EAA0E4C870687C78EEA8E6CC726C749275DA724A7A34ECF9D4D9CF9CEEDCEF32E362EEB5CCEB922AE1EAE45AE036E326EA16ED56E8FDCD5DC13DC5BDC673D2C3CD67A9CF3447BFA78EEF21CF152F26279357BCD7A5B79AFF3EEF521F904FB54FB3CF6D5F3E5FB76FBC17EDE7EBBFD1EACD05CC15BD1E90FFCBDFC77FB3F0CD00E5813F06320263020B026F0499069505E505F30253826F848F0EB10E790D290FBA13AA1C2D09E30C9B0E8B0E6B0F970D7F0B2F0D108E3887511D7221522B9915D51D8A8B0A8A6A8B9956E2BF7AC9C88B6882E8C1E5EA5BD2A7BD595D50AAB53569F8E918C61C69C8845C786C71E897DCFF4673630E7E2BCE26AE366592EACBDAC676C4776397B9A63C729E34CC6DBC597C54F25D825EC4E984E7448AC489CE1BA70ABB92F923C93EA92E693FD930F257F4A094F694BC5A5C6A69EE4C9F09279BD69CA69D96983E9FAE985E9A36B6CD6EC5933CBF7E137654019AB32BA0454D1CF54BF5047B8453896699F5993F9262B2CEB44B674362FBB3F472F677BCE64AE7BEEB76B516B596B7BF254F336E58DAD735A57BF1E5A1FB7BE6783FA86820D131B3D361EDE44D894BCE9A77C93FCB2FC579BC337771728156C2C18DFE2B1A5A550A2905F38B2D5766BDD36D436EEB681EDE6DBABB67F2C62175D2D3629AE287E5FC22AB9FA8DE93795DF7CDA11BF63A0D4B274FF4ECC4EDECEE15D0EBB0E974997E5968DEFF6DBDD514E2F2F2A7FB52766CF958A6515757B097B857B472B7D2BBBAA34AA7656BDAF4EACBE5DE35CD356AB58BBBD767E1F7BDFD07EC7FDAD754A75C575EF0E700FDCA9F7A8EF68D06AA83888399879F049635863DFB78C6F9B9B149A8A9B3E1CE21D1A3D1C74B8B7D9AAB9F988E291D216B845D8327D34FAE88DEF5CBFEB6A356CAD6FA3B5151F03C784C79E7E1FFBFDF0719FE33D2718275A7FD0FCA1B69DD25ED40175E474CC7626768E7645760D9EF43ED9D36DDBDDFEA3D18F874EA99EAA392D7BBAF40CE14CC1994F6773CFCE9D4B3F37733EE1FC784F4CCFFD0B11176EF506F60E5CF4B978F992FBA50B7D4E7D672FDB5D3E75C5E6CAC9AB8CAB9DD72CAF75F45BF4B7FF64F153FB80E540C775ABEB5D37AC6F740F2E1F3C33E43074FEA6EBCD4BB7BC6E5DBBBDE2F6E070E8F09D91E891D13BEC3B537753EEBEB897796FE1FEC607E807450FA51E563C527CD4F0B3EECF6DA396A3A7C75CC7FA1F073FBE3FCE1A7FF64BC62FEF270A9E909F544CAA4C364F994D9D9A769FBEF174E5D38967E9CF16660A7F95FEB5F6B9CEF31F7E73FCAD7F366276E205FFC5A7DF4B5ECABF3CF46AD9AB9EB980B947AF535F2FCC17BD917F73F82DE36DDFBBF077930B59EFB1EF2B3FE87EE8FEE8F3F1C1A7D44F9FFE050398F3FCBAC4E8D3000000097048597300000B0C00000B0C013F4022C80000685749444154785EED9D09B81C45B5F83B64630F5B2E842D6C21400859C8BE91842C2410082424610D10D640584410100185A0880A4F445114C5250FE1A128EFF1DC10F0CFE2131464472040504140882C210192F99F5FDBE75A69BBA7BB677AE6F6CC9CFB7DE79BB9D3D5D5D555A7AA7E75EA549577FAE9A77BB592458B1679A79D769A77EAA9A77A0B172EF4E594534EF14E3EF9645F4E3AE924EFC4134FF48E3FFEF87659B06081A7327FFE7CEFC8238F4C25471C718477F8E187FB72D86187F9326FDE3C6FEEDCB9BECC9933A75D0E3DF4500F993D7B76BBCC9A35CB5339E49043BC7272C0010778FBEFBF7F9CF4946B8F4E9F3E7DA52BD3A64D5BA93275EAD495C89429537C993C79F2CA499326ADDC77DF7D7D993061C2CA891327AE1C3F7EFCCA7DF6D9C79771E3C6F93276EC58E4A13163C66C21E23583C87B7943870EAD48468E1CE9F5EAD5CBEBDCB9B3D7AD5B3713CB03D301D301D38102E840A954F2C25233D800629A1538809132C0D126D79E11D828B922B0515211D82821021BBE08709404384A021BBE08709404384A021C25810D5FA453F6456003794C40A36733C086BCA33760C000AF4B972E1509A0D1B56B576B600AD0C018F019F09A0E980EA80E187004568E94168EE102165BC4593A0426E2A003E078BAC6C0F168A303C7E8D1A33D012B1F36000683066BA8ACB3321D301D681E1D30E048071C730432BE23F2E7830F3EF822112F4A0E3CF040038E0AA7741436F6DA6B2FDF328175C31A9AE66968AC2CAD2C4D074C070C38E281A34DFC37CE15B94BE41D818D1222A0F1BAC80671D01133AD62168E0410D169141A25F3BDB086C93A27D301D381E6D301038EB581A3B3388DEE2572ADC88B021A1F8994100738808E93A28063E6CC9966E1A8C0C221FE28FE348A59369AAF81B14EC3CAD474C074C07C38D65EA5B2A9F8704C13F99980C62A9112A2B011011CF70B5CAC0360B872D04107197064040E6063E0C081E6B3610E9E3685663A603AD0E43AD0EA168E3D6569EC6922F70B6C9410858D04E0784740634A1470C42C8FB529950810611A4561C34641360A321D301D301D686E1D6845E0E82A7B701C20F279018DD7810CF9F4612303709404369660D1889288D52A061C0E70D86A94E66E54ACD3B0F2351D301D88D28156028E1D64E3AF5365E3AF1F8B7C28C0D10E1A1502C79F0536F60803072B550C38E2371FB3D528D6105967643A603AD09A3AD00AC0B1B7EC347A95C0C6132225810D5F72008E92C0C662038E6C3B9BEA348AAD4669CD06C73A1A2B77D381D6D58166058EEEB2FDF974D9DAFC2722AF097094808D1A00C76F04387ABAD061168E78005107515B8DD2BA0D8E753656F6A603ADAB03CD081C9D0436168B7C20B051426A081C6B04368E085B3966CC98119E5669791F0E17366C07D1D66D70ACB3B1B2371D685D1D6838E038EEB8E3BCA38F3E3AE9F0B6FD05387CD8A8317030ADF23D91AE2E74001CA10DC05A1A38DCA5AFD6D8B46E6363656F656F3AD0DA3AD070C071ECB1C77A4047C289B13DE4FA23F5000E9942794D6063880207532A004768796C4B02873A88B2F49586C62C1BADDDD8586763E56F3AD0DA3AD0B0C0819583E3E7CBC802B572D4704AA524808195E352912E40870B1C0E74B41C70B84B5FCD67A3B51B19EB64ACFC4D074C07D08186040EAC1C480274EC2AC0B1B4D6532A0170BC269F3D818D307004D0B1B94CB13CD54AA7C5DA6A146B60AC93311D301D301D7075A06181E398638EF19032532BEBC8B52BEA041C583A4E8C008E4E021CEB086C4C1579A95580039F8D41830679DDBB77B7535F9B7CAB62EB50AC43311D301D48AB030D0F1CF3E7CFF7A75562C063B24CA7BC5B87291580E37E91CD4476111F8E630434AE13795864B9C0C6FB226B5A01381436CC67C31AA1B48D9085335D311D680D1D6814E0E8B660C1823E22FE540AA2160E3E995A11A888920DE4F7FFAE1370001D7F628A4580A324A0D12E021B25A4D981C3850D6B405AA301B172B672361D301D48AB038D001C9D0434BE24F2B2C8D828E0D0A99518E8385E7E7FBF461B7FA9D3A8FFA9D26AC061AB51ACC149DBE05838D315D381D6D58146008E2B8E3FFEF892C006B24C806374D8C2C1B48A3A904640C766F29BBFAD790D761A6D39E0183B76ACB7F7DE7BFB3E1A2A23478EF44F7D359F8DD66D48AC13B1B2371D301D48D281A203C795C086031C25818D97810E774A05E0408E3AEA28DF9F23023ABE20B0B1DA8023DBB9276382135E478D1AE50D1932C497FEFDFB7BDFFCE637BDDFFCE637ED72F1C517FB7B6C74EEDCD9DF6FC3C4F2C074C074C074C07420AC0345068E2B4E38E1843511C00174BC22C0314AA14381A38C2F471F818DD70D38928183E9112C1608DF478C18E11D7CF0C1DEF3CF3FEFCB9FFEF4A77F5B4BFDED6F7FDBE3CF1A186B604C074C074C074C07E274A088C0D1F9C4134FBC1CD810F1AD1B210B07C05112D8003A46021DAE85032B47942F87C0C64F0D38CA03C7D0A1433DAC192CEF9D3C79B2F7C0030F78EFBCF38EF7DE7BEF456ED8A2CA73FDF5D71B709865C780D374C074C074A0AC0E140D383A9F74D2498B05384A4839E008A0E3CF583AC2C0C112D908E89864C0110D1C4C95E0978185E8AAABAE2A0B17510A63C061231A1BD59A0E980E980E24E9409180A3D3C9279F7CB900870F1B2981A324B0B14CC4870EAC1B88EEC92180E1210A1FF2FD9179F3E69590B973E796E6CC99533AF4D043DB3FF93E7BF6EC7699356B5649E590430E292132BDE0CBCC9933D9D2BC619D4671FE1C366C98EF9371CA29A7788B172FCE0C1A66E1B00626A981B1EBA623A603A603AA0345028ECB05384A150007D0F192C80846E82E7038A0E18387C851061C633C6063F0E0C1BE83ED37BEF10DEFDD77DFAD18365020B3705883629D8AE980E980E940920E1405383E076C54011C25818D65021B235DE0D0152B6AE990CF6D04385E6F750B074B5871047DE9A597AA020DB370580393D4C0D875D311D301D3812259383E2B26FD353900474960E32F2223744AC55D222BB03152E44E818D95AD081C388322EC06FAF8E38F7BAFBEFA6A2EB061160E6B4CAC43311D301D301D48A3031D69E15867E1C285978AAC11E0F0AD1B555A38000E1F3A043886031D01706C28532B97096CBCD38A4EA34006AB4F58E67ADF7DF7796FBFFD766EA061160E6B64D2343216C6F4C474C074001DE828E0E87CEAA9A77E46A424C051CA19384A021B2F8B8C10E0E82FB0715F1DCF52F19D488BB2B5397B68B07917534A77DF7D77EEA061C0618D887524A603A603A6036975A0A380E3D2D34E3BCD878D1A0107D0F1A600C7B23A1E4F5FA8B354B068B0D4F5FBDFFF7ECD40C380C31A9AB40D8D85335D311D301DE808E0B86CD1A245A53A004709D86835E0D015289C7372F3CD37D71C36CC87C31A11EB484C074C074C07D2E840BD81E37260C38063BA7F54FDB469D3DA65EAD4A9A52953A69464874F5F264D9AE4CBC489137D993061822FE3C78F2F89E3A72FE3C68DF34520037954A64F7AB202E56B5FFB9A77D75D77D505360C38ACA149D3D05818D313D301D3817A02C7E2D34F3F7D8D01C73F41438163BFFDF62BEDBFFFFEED9B88E1FFA13E20FC4E380D0B9444C186804649E451B16AF4BCE69A6BEA061A36A5620D887522A603A603A6036975A01EC0D15540E33291D522BE75A3D92D1C071C70800F1108DF1522D8A1949532ACA659B06081BFC9193E2C38CFBA0EB461275A773334EE635B77F151F17748254EA0451C441FBBE28A2BB65ABD7A75A7A842ADE56FB6F1973538691B1C0B67BA623AD0BA3A500FE0E823A0F134B0D1CCC0E1AE4C61CB734080EDD36543321F2C80AC33CE38C317F2413F5D00C3AFC5850F60C45D2EEC2E1BE69C193D6B060091FB9E7DF0C107C749816E27B2A5C8FA225D6B091A66E168DD86C33A0D2B7BD301D381AC3A10091CD2097A59453A51AF8C0C956B4B9B11381434800CCE62C1F2C0393000C5C73EF6B1D259679D553AF3CC33DB614341230AC0AA010EB917E0982C053A4064A8C810913D44B615D95464DD5AC1875938ACE1C9DAF05878D319D381D6D38148E0900ED2CB2A09C0018C0C013A9A654A05D060CF0DA635E4C45ADF8A014C9C73CE396B814618366A0C1C93A440F712D93B10C063B8C830913D45B60FE0A3739EF061C0D17A0D87751656E6A603A60359752012386464EE651119C5FB80825524013C064998E71BD9878353621196DB0219582A3EFEF18F97CE3EFBEC7F030D60A3838143C1834FE06384C82091BE225B8B74CF033C0C38ACE1C9DAF05878D319D381D6D38148E000202A1119BD7B4839E810D81824E6FFA58DBA0F070E9FA49DA9923068F09B4EA1286C140838143E986AC1E2C1677F91DED54EB71870B45EC3619D8595B9E980E940561DC81538741A2601383CE9B007031D35DE6934B78DBF66CF9EEDAF2CC132832583691360031F0D15858D06008EB0D503F0C0EAB18348454EA6061CD6F0646D782CBCE98CE940EBE9404D8003F088B37430ED22B0E1C9AA8A21223E74D4E02C15DF79B39A9D460F39E490D2AC59B3FC38000D850C40C3B56C343870B8560FBE0F10E995153C0C385AAFE1B0CEC2CADC74C07420AB0ED41438A2A6581CE0F004368689BC5824E00032800D0E7CC347E3DC73CFF54541A34981C3B57A30DDC2EA96CD4452EDE961C0610D4FD686C7C29BCE980EB49E0ED405385C6B4708387CE810E07821C7E3E97DEB4625160E6083A5ADC71D779C3F7572DE79E7F9B011B66E34A185C3050E753065AA6547910D921C4B0D385AAFE1B0CEC2CADC74C07420AB0E1401383C018EBD05387CE87077D5D48DAD8E3FFE787F674EDD65938DAE1096A3CE9F3FDF1736D8C2CF02A90438800D760165FAE4139FF8443B6CB428702880B0A49665B65B94830E030E6B78B2363C16DE74C674A0F574A028C0E1096C001D2F76047060D50060D4AA0170E8544A8B03875A3B06074EA55DA214C680A3F51A0EEB2CACCC4D074C07B2EA401EC0D149566674D5BD3874A58AFA6F84FD387407537118653AC517B170001CC810018E17D8A913A98785838DBBF02151AB4618360C38FC4DC4985E611F8F7E221B8695C680C31A9EAC0D8F85379D311D683D1DC80338E6096CFC406486C046AFB4C0C14A9508E0F00438860A6CBC516BE00034700C65E32E7C35000D15D7BA61C0D1BE6BA982C7C0C0A1B4FD545A038ED66B38ACB3B032371D301DC8AA03D50207D68DDF3A7B503C25C07186C8A0240B47B034D6B56EF8560E018EC1021B2FD61238800D7C3E4837B061C0B11654841D48A3FEC7E2C1F2597F158B0187353C591B1E0B6F3A633AD07A3A502D708C937D28DE89D8F4EA6F021CD789CC16E9115EA5E2AE5471A653008EF504387E53AB299579F3E6F927B8E26CCA4A930B2EB860ADA914B37064020FA6583899B6B30147EB351CD65958999B0E980E64D58148E0487B8E8A80C6B7F544D43074704899583A3E92CFBB442E93A98B9DD981547D38DC2995C07F03E0B8B8964EA300072B5D000B60432D1BF5B470683E85370C0B9FBBA2A7C9B28DBA9E22ABDBC1E373E2EE5DC22A1EB9FF4F4F3FFDF45829D05D035F0BFC2D6A291C06C70A96AD7EF0831F78FC65553E0B6F0D96E980E980E940EBE84035C0B1AB749ACF250047FBB1ECD2813E2BF21D018EE96AE108F9700C15E078AF96C041C70C5C286CD412385C00238FB0A8B0AB2A4B76D9586CBFFDF6F365EAD4A9FF2653A64C29A94C9E3CB93469D2A476D977DF7D4BC8C48913DB65C28409FCF6AA4C155D217B887C52E4A23AC8A7788638F65E327EFCF8455DBA74394A1A8EA373942325AEB6823446DB4A3A0E143941E4CB22579B5495075F91FC1B5C65D97697FB67881C97A3CEE5A9BFCD1217F93B52843A50D441C53692B623448E315DC8B50DCE5387299FC8C342D39E147B8174A46B320087EFA029B0F18EC8C3325A97FE77E1A6229D64B4DE4560E357B5DA8783FD35808DF3CF3FBFF4C94F7ED2FF747D37F2B270B0AC16B0D003DB586A0B38ECB9E79EA55EBD7A957AF4E851DA68A38D4A1B6CB04169FDF5D7CF55D65B6FBD35D2E9AFEAD4A9D3CA3ACBAACE9D3BAF12657A3F677947E21BDD418D5C57796E1F91F345EE15794DE45D91952225935CF2E0B02ACB760BB9FFC1A04CF2D63D8BEF5FF5199D7F2BA8032FCAE78F44CE14D94984BF2240C8D4208D566EF9B7C379E5E97229A3CD2BB5706C28A0F1ABA87344F4F0B2604AC5B5702870F89B6B05D303AF08705C2CC071B9C0C68A5A0007B041C70F54001B5837F2060E5DD5C27BE11F3276ECD8D2D65B6F5D1208F03BA7AE5DBB9604067CE17B1E12EEF4F288B39A386AD009AF9638C7D5B941DB409E3756E42722EFD5E09D0C56FE056CF3AA2CDB9E72FFE35646B9C05F257AF981E4FDDD227344B6ACB22CAB8596E9F27C063D95BC87DD539F7C435F223790F464A49E2453043696E7001CFE3443ADCE5251D800081436F2040EB63C075E00A5830E3AA8D4B76FDF52F7EEDD4B6261F0A1C22A40550DC08741E75F6D6394F6FEF1F2BC9BACCCAA2AB32C3A9F07703C6AE555B7F22A57B69403D38DDB7710784C93E73212CFA27F16B6BEF985A5AC22E0E82E40722DD30745060EF6D860E92BB0F1A94F7D2A77E00060983A99366D5A69FBEDB72F89CFA40F1AA6F4B955FA7A0107A3B34B4520702BBFFAE5810147FDF2BA5E7AFD3BA943C78A74AA33781870145F97E2812361954A5F818DBF17193838529E33550022858DBC2C1C000CD333387EF6E9D3A724FE0B3E6C5867957B675D0FE0182EE5768F955DEE6597A63E187014BF9348538E51616E953A850F545AEB62B5E10C388AAF4B15014727E9C4CF00368A0A1C7A701B3E22175D7451E9C20B2FF4AD1B790007B081E3EB9021437CC74F40C3A64E6AD659D51A38A64883F8B2C146CDCA2FA9B332E0287E27915486E5AEFF49EAD6CC3A41870147F175291E3864A58517239B0868FCB6E8C0C1C66158365CEB4635C0A1E7ACE013B2EDB6DBB63B805A6755D3CEAA96C0719294DDDFADFC6A5A7E499D950147F13B89A4324CBACEEA96D3EA30C562C0517C5DAA0838F655CB46512D1CAC12C19113D870AD1B9502872E9F65BF0CAC1A4CA1584755978EAA56C0C17E1AAF5B19D6A50CCBD515038EE2771279B4756BA4AE7D4184A5E6D54E9DC4DD6FC0517C5DAA08387E5874E0207D6ADDA8163874F9ECA851A34AEBACB38E6FD9B08EAA6E1D552D80A3BF94DF735686752B43038EE27704F56AD3161B7014A2DED5ABBCC3CFC90C1C3BCA34CB8745050E9C4459628BDF461EC0A1960D850DF3D5A87B65C91B38D69706EF97061B752FC7B806CE2C1CAD0723A7D4083ACCC2517C5D8A070ED95FC20B8BC0C6E7D845B388C0C1F257D966DB9F4AB9F8E28BAB060E7C36880BD8600AA596B051CD665B8D786FC60E3FAF8DBF58A6F7F18CCFEEA89140AB3C97ADEBAB31B1B3F197EDC351FC8EC6D5E7B7A5CC265459EE513AB3BFC4F991D5EFC20C26A2DA3036728CDE87230238BAC96FCF14193858020B6CE461E10038468E1CD9BE33681E8AACBB8D0230ECD7C10A1744FE7F5376245DBAEEBAEBBED8EC22EFFDACBCF3D3929F69E40909B7774E8DD39E12CF3FF2284789831D487F2FF263911F88FCA749E63CB859F28CF339EA0D1C6C519F46F75A39CC539247AC30A9D5CE9D8F49DC9B5559F661BD6160F24791671BA87C359F81B02C830C9CDD691B1B49479F0906079B466E6D1E011C47C86FAB8A081C4CA570E01BD328790007F14C9F3EBD249D7FD53E1B0A17F2B97AC30D377C7B871D76B8530E6CFB9CF8969CFCC4134FCC5CBA74E98C175F7C71BF975E7A6992C8E42697292FBCF0C2F0254B96B4497EB4097CB40984B589229693BC1CCD6EC858A9C30D00E7A87086C41491ED4438C7634311A6694CB2E7015BC877A9B2D3A9C4C2F1E9047D4BD2C756B9CE6678EC1ACA792974E6E789FC5424AFB384AEABB2ECC3C021D1F9ED08E96EA432EA2DE965E092053838F810DD6FA4F7D4B4AE930638D611D8F819DB78171138589542BA3EFDE94FFBD68D6A2C1CC0069B866DBAE9A655AD46D1CDC0E4A0B637070C1870979CA8FAF1279F7C729F952B570EFDF0C30F07AF59B3666070B43BC7BB0F6811E19D39D27EFDEF7CE73BDE8E3BEEE80970789257D58C72D3DCDB4F2A27FE20592AB586C5C3FE57228CC63BE7DC48A649BB8589B78254021C675B19566C5542FF81EDAB445EADB03E69BD6254CFF927ADAEDF801256D22C6DD3E71A39DFD200C768818D578B081CF3E7CFF7CF31B9E4924BDAAD1B950207CB6639704EB729CFA804ED0A136C71FEE69831636EBBE1861B0E920CEE1700C560F9DCBBC565A8BCFF2E229D503C39D746B2EB9F7F72064DAD1A9FEF545896CC095F4E8BD0C815BC89D35E09709CD3C4F951ABFA13152F23F31B45AA39E0F03EB91FEB603DD35DB467F1FE4CC966018ECF37729E250287ECAEF94560A368C08165835360F1B770AD1B9500070EA2C8F0E1C32BDEA69C25B3C0868CDC7F7BE595571EFFEEBBEFEE2699DBBFC501230C5843243F0689F450C5BBF4D24BBD79F3E6D50A3ADAA4722ECB58A1A9FC38385DD0C815BB05D26EC0D1F19DF5D1A2677FADA07E51C756881CD7027A5A0E720C3864E0E9AE50D94E80E38F45050E4E990D5B372A010EAC1B1CF656A9DF060EA1D263BE3F77EEDCAB1F7AE8A17DA433ED63A0116BCD192E79B3B3C85AF37932ED540B6BC7F1D2A05572285B438F225AA41137E0E878E0A0331D238293699651BA86C52F64BD16D1D728F030E00801C7319C1F5244E0C0BA41DAAA050E2C1BAC70D965975D2A3AED15CB86F821BC220EAB67BFFDF6DB4C9F60D56024DFEAD32771EF4FDE30BDB4B16B5EFBE8A38FBC9FFDEC679E38ECFAE091532394757E9486F00F223835E695068BA7367969C0519B7CAD445F474B7DC9BADA82BAF68EC8C416AE6B061C21E0D8543AF50B05385E16595324A75156A6B02A45451D46B35A38008ED9B36757E424CAF256018E653FFAD18FE64B87B97B305D60A0910C5B58397AAB2F870B1ECB972FF7264C98E0377A92BF6B094EA6191A27464E0F5630F23267B6E27464E5CADB80A358E5C4A65E9558392ECC50A7B3D4FF46086BC011020E4F808329961E021BB345EEE4687A2C021D79960AFE1B3C5FAD1BBA1CB692552A586F64B96AE625B0C0864CC1BC72F3CD371F251D26FE1AE6149A0C1A0A63388FB24267DD2827A20F3EF8C07BEBADB7BCDD77DFDDDB79E79DDB65E38D37F657B6A46CA0F690704B333682BF93F09BA48C3F6D3A2C5C6D3A46038EDAE46BA5FA8A55B0128BE2CFE5BECD5BB4CE1970C40047FBE9B1D2D10F14F9A6C813800772D65967AD25679E79A6BFE2433FF9CEB1EEC8A2458B7CE1F878B62247F0C560B50982E582D35E1199D72F1D7FFCF1BE2C58B0C017A652F864092BCEA2D55838F0DD38F4D0433353797080DBAA6BAFBDF69C60D5855935D2C386E615568E9E51C011F75BC6E996FDA4117B2323705C2CE16DF96BB13AB2B80ED080A378E5C4F2F13733D63936E41B68C091DA3AD4D0FE65516DFB5ADB9A07160E17383C810D4F40634B018D73E4F30EF97CD3858E5A0207D60DC005D0A8D6C20170E0BB9165EBF2C041B4346BD6AC6B651A85259EE6AF911D36800EAC1C58863AA7850ED9342D8B7FC789D28865D97F8365B0E35BB4E1AB7454DB91F71970140F38A4FA745B92113818F0CD6AD17A67168E14160E050E4F2003E9263249E41A018D97008F5A0107E7A5001C1CAC8675A31AE0E02459E2931D40334DA7706A6CEFDEBDEF7BEAA9A7E8346D1AA532D8502B07B0B67E8D80E35469C458DE9AD682F59684E534D98EEC44EDD9E9F3DF80237D5ED553AFE64B1D7A3F43BDA37E9ED1A2F5CE8003E090BD2DDAAD1C652C1C0A1CEEE79E021B2789DC558B29150081A9169D4EA906380016F6DDC86ADD900DAA56DE78E38D73021F049B4AA90E38B0726C9D1638C68D1B97C5C2B1302370BC24E1776FD186AF9E1D525ECF32E028267050879ECF081C5F97F0DD5BB0EE19702870001D0A1B9CAD220EA3BE309D124CA944018727B0816C26C0B18F7CFEA77CAECACB8703EB0671A975A352E0602A8525B5EC2A8AF367DACAC112D87EFDFAFD68D5AA556CD36DB0914F1EB0DDB9BFF368922C5BB6CCDB69A79D3CB132A5E9B4B20207DB3573C85B9AB82D4CC7E7930147C79741543DC007EADEB46D6A108EC3FC5A7129BA01471C702874A4040E4FC000F0D85D3ED7E4051C58380005D99DD29F4EA9143858CD02BC6CB6D9669996C3CAF07AA5AC4AC1BA31C0802337E0625A2AF5B40A2B57582E9B020C9852E12C94B44049580EAA4A13B785E9F87C32E0E8F83288AB073FCB50EFA89F6CEFDD8ADB9C1B70A4010E71148DB47204D60D850D80E36860230FE0003658C18275E2339FF94C55C001B04C9E3CD99F4E493BA582EF867476B7BCF1C61BACAE607B6EB370E497075B265937F4FA6EBBED961638164823967597D1130D381A06B80C388A0B1C371970A4AA47061C598103F8089C47753A453F3B09705C931770B01C96A5B44CA7543BA5C2FD83070FCE746E8A5837565F73CD35A7AD5EBD9ADD44CD59343FD8C07174D71A004725CB62D913605D838E548D65475B790C388A0B1CBF36E04855870C38AA018E10787411E0F87D9EC0C10A18AC13D500070EA76C1A96652B73AC1BE22CFAF4238F3C324D3A467C0ECCBA915F1E001C4C517549031D192C1C6CFC95D5790D8BC8DE061CA91A4B038EE276F81D5936527DBAFD362370FC97F970A49EFA6DBE7D3870180D3B8DBA3E1CEE948A6BE108014767018E77F2000E36FA62F32FF5DFA80638F0DF6083B1ADB7DE3AB5C328A7C0F6EFDFFF874B972EA5733487D1FC600370D33CDD280D706CBBEDB66957AAE0BCF640C6868FF9E4EF1B701870980E54AC036CFEF5978CF56EB1846FC50DF7CCC21158383A097074920EBE938046BBC82A954E621DE82490D1FEC977018DB54440A39380C650F9FC282FE06039ACFA6F54031C389A1E7DF4D1A51E3D7AA476180538E4C8F9CF071B7D9975235FE0D0FCDC2A0D703CF1C413DE061B6C90768BF36F656CF8000EAC1C875A8753718753AFD1B54DA914D3C272BED49D2CCEDAD4B9935BB4BE197004C0F19A00C772018EE5021CED22C0B15C8063B94046FB27DF0538D612018DE5021A2BF2DADA1C87513D8ABE5A1F0EEE9F376F5E69FDF5D74FB5E157B0B3E8AAEF7EF7BB6706BE06061CF90307568EDE698063CD9A353E6CA43C530570585101743C2DF7ECD4A28D60BD80A1DAE71870140F3836953A734F05F56D528BD635038E00383E10E0F0A730F4687A3E3BEAB458800387D1C58B1757ED340A70CC9D3B9783D75203872CC37CFB7BDFFBDEC9D221B215B70147FE79304CF2B56F1AE0E060B7D1A3477BB2274A9A0E8B13639FADA00164D4F53F225BB6684398266F3B3A8C0147F180E330A92F598E13A09EB1E1DE6E2D5ACF0C3802E0585924E0C087036BC965975D563570B0A476C68C19A9FD3738A84D3AB7E7E408FA43A44364858A0147FE79C08EA37B88A43A57E5CD37DF4CEBC741A7F8C50A8183C690D1DAA0166D0C3B1A28929E6FC0512CE000CE1FA9A0AEB107070383A4F26EC6EB061C45040E1C46B1AEE80A956A7C388863DAB469A997C406C0B1F4D65B6F9D6DC05133D8624AA57FDA0DC0C479370B70F4A9705A45370CC34272A648EF166D148BDAD01B7014AB93FE6A05B0411D5BD4C2F5CA80A388C0C131F51CD866C051B30EBFA3AD3600C75E22A956AA3CF7DC735980830EF3BA0A1B437797D247250E9C507170DB5F8483DEB613D9A105A547013A09038EE200C7B915D62FA653F62A802E7514541B7014113858A172C105171870E43F95D1D1A0E19E1ACB666A5BA4F1E390B36CBCEBAFBF3EED8EA3342640C18B15368AE1ADD1574A3C9C2CCBD23FE2A4D16C35C1EAF37B911F8A7C4CA46F07741A061CC5008EB3A5EC575558B7AE97FB5A7139AC028E0147518183FD33F0BFA876958A4DA914D24A828503F8E89906380873CF3DF764B572E0D09675B95EDA73585A39DC4792AFEF88FC4EE43491ADEAD4891870742C706C26E57C8308E55F89FEFF4DEE6BF5B38B0C380C38D6AE3CE6C3511740013890D467AA3CF8E0835EEFDEBDD32E8F6544B161D04056D238DA3DE93B9537249F3F2BB2638DAD1E061C1D031C80C681228F55081A5A976C83BD7F1E5887D36C96F6A529771A2DD42A150E6DBBF8E28BCDC2D1BC532A583738142FD55E1C6A0591A5CA59AD1CDB4AE57E306305CFD21858D87F359ECF05168F8D6A041E95000716988E9AAF6FE4E76E2CF986CFD2B122FF9B43FD7955E2E0E88146CE933CD26EC051440B075B91331562532A75B13674945F07C0B17DDA2915C27DE94B5FF28143CEB9C952F987484357E9DE1C0614D94663E4D74F82CE2A4B19A5095B09702C91B41C619298074C3F9E20F26991AB456E17C97A2E51B9BA7286C1860F5B061C45050EF6E030E030E07081E4F9E79FF76489B32787EBA5E9A0DC3078C633023780A84F1E3C23797D50CE9D4C25C0B15AD2C0C65426E5F380EDFD6B55376E96B85BD951D46D870C380C38CC87A3833637CB6CE1003E647F96ACD32A5AE159B9F28B1A36ACB56AB01B35DEE592D7C7E7081D950047A3E65DB3A49B954DB69FCDBFA6920C380C380C381A0938DE7DF75D6FCC98319542C726D2007E59E47D038F9A8D68DDCE9225C5F373820E038EDA59216A01387F97721F9E53D967B5681635BC018701870147230107560E3967C793B371B2AC58093740B3A4217CD8A0A32ED0F10FC9E78939743C061C8D031CC0C6B41CCABCA8E05069BA0C388A081CAC5261FF0DF3E1687A1F8E4CAB545C7F8EADB6DAAA522B8736169C7479B1C81F0C3C6A0E1E4FE4605A37E0680CE0C0578A9D792BED949BF93E038E2202073B8D7EEA539F32E068EE65B19C18BB4D96552A6E5856AC645CAD12D790B17496DD33F1CC5F61F05133F8B8B5CA4EC880A3F8C0C1E18703AA2C67038EB5CBD9F6E138EBACB34AAE70B2EB19679CE19FF0CA2772FAE9A7FBB268D1225F386E7EE1C285BE9C72CA292596BE225833000C84335438B88DEFB6D368535B3732EF341A05269D3A75AA665A25DCB0B1F7C078918522DF16F93F117647ACC5FC76ABC639BB8ACEC880A3D8BAF81529DB6DAA28DF66060DDBDA5C2C1BDA867B72347DA136FE02383EF9C94FDA592ACD6BE1A81A38D6AC59E3DD7EFBEDD54EABC435721C9FDD4B849367D9C7A35565A6BC3B87D77D3727F8626AA5D2A3C90D388A091C4F49991E2CD2D56023711AC9A6548A38A562A7C536B575838DC6008E01221B573AA5C27DAFBEFAAAB7E1861BB6C2C8A8A3DFB1BB74266C713D4FE4E92AAC3E9CC351E9F1E4061CC5010EF637795364B1C816061A89A061168E225B38985639F7DC7373B3704C9F3EBD2443E154666CCE5211597AEBADB7CE964EAD5F07ADE0E8A8DD3FEBF55C80A3BFC886D50007F7FEFCE73FAF9595A3A33BF9A23E9F511AF3CAEF56081E38E91247D6F733E0E878E06039F99F442E14D9A98232CC5AE6CD16DE2C1C45B470001CF883B0DB68B5A7C572FFECD9B34B5DBB762D75E9D225113A08233DD8EB4B962C39463AB4DD0D386A626D191AC05CD76A81E3D1471FF5060D1AE449B9355BE354F4F761CBF0B72A808EF7E41EEECDFA7E061C1D031C94F12322B7882C10A9D5593959F5A111C31B701411388E3BEE38DFD174F1E2C5B900C7BC79F34AEBAFBF7E2AE0004C043856DF70C30D674967D8D780A326C0C10A15606E9D6A8183FB050ECDCA91BD03CFA3C13E513AA0351540C737EA041C7F91E7605141D877C5A47C1E0016F78BFC48E4EB22E789B0C475BB0ACA2B0FFD6AB6380C388A0A1CAC64C9631F8E4B2EB9A474E491479636DE7863A64A122D1C349E4CBFDC78E38D174B67B6B301474D80030BC78E79C006715C77DD75061C1D031CEB041D53AA7AE58009479D673DCEBE120BC7E702D33FE6FF9D4D12F36017C923569A54EAD8DB6C8090F7FB187004C0F181AC54F1FD26CE39E79C7691732B4A679F7D76E9631FFB58FB27DF6BBD2C76C18205FED2D80B2FBCB01D3A00078463EB1196CDAAB06707427856B7A85C70C1057E189C50B7DC72CB922CA34CD530021C53A74EFDDE5FFFFA571C1B071974D4043AB6CE0B38BEFEF5AF1B70740C70D020EF2EF252462B07FE1F53328E9A2B018E33333E23EF0EC6E2EB38BD2C62DE1B7004C0F19A00C772018EE5021CED22C0B15C8063B94046FB27DF0538D612F1B7582E7B6FACC86B1F0E800348008238A61E3F8C4A810310019076DE79E7D4C021A7919636D86083871E7EF8E1C9D229EE65C0912B70E0303A506493BC80E3AAABAE32E0E8D8869DD50AA960DE09774A4618A80438CEC9F88C22765296A68ED5ED3CF3BFA58043DC13DAF7DE70DB7AF6E1E88408707412E06817018E4E021C9D0432DA3FF92E1DF85A22A0D1498063A87C7E94C7C65F388DE2C78175A55AE0C0DA81E5A35FBF7EA957AA047E1CAB649F87F9B2DFC31E061CB9030796A3EED502C7AA55ABBC6F7DEB5B951C579F6723627175EBB6AF74EC6F67848EAC3B281A70344FC7DBAA75A6258003D0C0895F06EDB1C0017478021C9E0047BB7014B874FA9E4046FB27DF0538D612010D4FA4B3C83B7901C7B1C71EEB3B8EAA1F47A5160EA65558ED326AD4A8D4160E1A4EA65FE454D26FBCFDF6DB836D5A2577E000E2229531CBEF6FBEF9A659368AD1096D2575E6818CC0718384E72F6DE763C0913EAFD2E6A985AB6F9E363D70889FA4B7D1461B799B6EBAA9B7EBAEBBD61438BA0870FC3E2FE0C0C2C1D6E74C895433A50270E0F3C1D258D9242AD54A151A4EAC1C32B5F2B7C71E7B8C691546E4F5DAA3A2D99FC3944AC567A828907CF4D1479EE886878267E8B42C6C6D1A589C477F901138EE94F06D19CACE80A336656775A27EF9DAD4C0415BCC468C80C61E7BEC913F7004960DAC1B4827916BF2020EFC3810F5E3A8C6C2C1940AE7BAF4EAD52BB3954356B85C6AC0913B6C6D94C592111716F306E6BB0C9D9685AD5DE3FAE58CC0C1415F6C1F9FB64C0C38D2E755DA3CB570F5CDD3A6050E608329146063B7DD76F33F73B170B8D32921E0003AE6E7091CC71C738CBF42A65A0BC7F9E79FEF3B9D0A7561B548EDDC869543F6EFF8B3EC668995C356ABE463E5C15A54F5FE1B871D76986DF655DFC632A973BA362370DC2DE1998A498A57AF1B70A4CFABB4796AE1EA9BA74D091CEAAFD1A74F9FB560A362E0503F8EB0EF06FF2B740868F07D47F9F41D47AB392D16A751AC1BF87184A755B22E8B654A05E060792CD32A6C000648A46D1CF1E518376EDC4D62C2672BEE669FEEA8F5FB319DB243B5D68DA38F3EDAF7DD30EB46EACEBA1E1D8B01477D3BAF7A9469A19F41FD5F77DD75DBA57BF7EE854EAFF4394D071C9441946523B385038751751ACD001C7D05365EC80B38F0E3003A0006B572540A1C8007FB8AB01F479A2DCE1548082B99FACE79E79D778A7494B6D57975D0C5865F551DD8F6D65B6F7923478E3467D162756EF870B03B656A9097B037896C68168E424163A13B6C46D2AE001BB2DD81D7B76F5F7F64BDCD36DBF8D70B3C10692AE050CB067041192864B89F51834B7F858AAE4ED1952A1981638040C642B1703C98E7940A560E9D56A9C68703601160F037049B34695226E0D0152B6D6D6D4B6FBBEDB6690174E8F1EAB5B6083453FC7A605BC5E7A7FCFDEF7FF7A64C9962B0512CD8A09362D7D0473302C73512BE9301870147391D001EF00FA073EBD1A347BBB01262A79D765ACB84BFFBEEBB171D3A9A06385C9F8D38D8889D527197C266000E96C14E17B95AE4554023AF8DBF744A45A755D875942911AC1C955A38000EC0E3D4534F2D89E2661989F961D97D74975D767970E9D2A5630D3A2A9A5A1A2EF9C6EEA29DE2A654BEF295AF78575F7D75ACCC9831C3878D06309D167AA498A1934FFB1E874B9CAB3202C74519D3613E1CC503CDB4FA91391CA021FE76FE124B19EC793D7BF6F4000A57A23A3A5647A8A523A37E654E6305F1370570286C44F96C84AD1C91168E8CC0B199F86E2C14B95DE41D76F154D0A8157060E560B54AB5C0017430B53276ECD84CAB55B421053A468C1871878CB4D99B634FF3E9C8041E5838228FA3FFEA57BFEA4919FB3091F467B051B811F106523F7E9C1136564BF839191B6C038E16010E4063BDF5D6F3B6DE7A6B7FCA04880034A24CF651BF1176DB6DB7AD0740647D46C303870B1B69CAA41AE0D843E0E25A5935F2987C7EE49EA7526BE0C08F63E1C285159DA5A24EA3C0866BE510624E7D989BDB98021D721CFA03F7DF7FFFBEB65C363570703AEC2E51AB53AEBDF65ADF5C6A4EA0850389B48DE96CA91F2B3302C70B127EA00147C396795ADDC8144E7D2FB6DF7E7B6FC71D77F441A39CB9BE1C80E0D39151BFEA11BEA18183F2619F8D34968DB24EA3652C1CDDC561743F818CDB45DE60896A3D0E6F0B4FA9001C08F0A007B8A53DBC2D0C1C584AF84DCCF39996C886A163BBEDB6FBC397BFFCE579B27A8573419066F2B7C8FB5D7016DDDCA5DD3BEFBCD3A361C1C399114D011B074B53F288BA8F94DB9F32C2065394B78974CE58E666E1482E8F86D359850C3EB14AC8B4B5EF975129686847C7FDBD7BF72EDAD2F986050EDDAE7C934D3669DFD42B8DC5298D85A3B300C836E2347AAAC883021CABEB7D5A6C1C70B0D5795EC08155469432F5F92AE14695FD3CA4105E133F934B972D5B867F423F113BE8EDDFC10BEB465F912E289FE495F7EB5FFFDA77049325C7456B101AAEC1CED869E7F97E9BC8B36FAF0036984E39BF82741B70341170E86A12A64EF0D150C8A816345CE0005E88BF025DABD53D0D091CC006F988D36ED6F249028EADC46974B100C79F39A6BEA38EA78F020EFC38702265A509D0518D8583A915EE97FD1C4A1B6FBC71C5968EE090B7D2165B6C718F9C58BAE8D1471F1D2519DC47843D3BF0F3C8DB52D068F1E1B781B4A178923FDE669B6D66AB4C1ABFE3E8278DF8FF54001B5837FE22C2FD591B75038EEC7996358F6B1E5E579DE00CBAF9E69BFBBE19593BB134236BDDF1122B6A812CA80D071CE536F54A530E49C0314280E31FC046D180832995F9F3E7974E3BED34FF40B76A8103E860CBF3A953A7FA1B8165D99B23CADA816F879804EFFCE217BF78C12F7FF9CB4981CF02F0C14165583E5A71DA05EBC6EE2FBDF45217569F6032B55526993BDA9A7702193AFF4D25ECC922CF56081B00C70F333CCF7D77038E06060E77D5890CD07C07D0344E87693AB5B830800C4B67819B82ECCDD150C09165354A5C1924014737018E6F151938D80C0C5870AD1C1CF0860010584054F0D588F2E1E07E7C39747F8EC18307FB568E2C3B904635B8400722E4FE886CBD7D8BC47FA900C8FC254B96ECF7D0430F31D2DFA9C564C7575E79C51B3264880F1A4CA1D82A9386030EA64E468A9C25F2EB2A4003D8784F64800147C3E94055D0EBAE3A0100FAF5EB5733AB46B8E3C3F194D52E05B172340C70645D8D522970B001D80C91E545B47030AD72D45147F97B69546BE10038D481141F15A904555939B421065AD80E3D808F0FA5E0FE26735FCF4B457B5C36ADFA5D0BC983F2AEFF3770E0C0BB242FEE14D0E074D072F20BB9DEBFC2CE481BC42F243C23290D76FDDFCBE811C9D33F57091ABAEFCD7F5451BE66E168300B875A15C4C1BEEA5527955A3AB072B0AA02FF033A51D2A452852E560A600D011CEE344AB556A8240B07C0D155E4DEA20207D32A8007E9532B47A5160E173A801821E15CA0C3850F5172DF7AA2D68F56FCCCD0598DAFB211B83FC3B3326FFE667167DABA3C9CBF2F4AFE65391D36DCA81B70340070B8AB4ED8804B579DB82788560A0F95DEC7B3810EAC2B087B7B30BD4BC75A657B93F5FEC20307E527E78D655AFA5AAE5CD20007D0B150E4C322398DE2C30168001C5839D87D94A9132C1DD502874C23F9D32B279D7452FB11F6D54EAF58E794B973FA50F26C6C950DC0AF2CDF33E77B3DC0EB03299783AB2C5B038E820387AE66A8C5AA934A61C35DB582B543A583B6412F3470B8B09197236F5AE0E825C0B1ACA8C0A1D0C176EA6C759E077028740032B27EDB9F16A9C691D43ABECC1D9F0147B6C3CFEA010A793D63B1D4872E061CCDEBBBC174C5A69B6E5AD35527D54247F87EA003FF8E3A1EF85658E0200FD4B291176CA43A4B45370113D8F88F2203074B5A010FA645F2020EA003AB097B740C1830C0870EA6430C1E32C343257966C0D19CC0C1B6E7594E858D33539B85A3CE160E20222C51D0481896BB573BDF9F3750A4894F9D4AEB34BD5248E0A0FCF29C46493C2D564F860D7DEE20FFAF928DBFFCDD45F5B323771AD529154003E0606A853D3B589D52C92A15F5E1003454F00D61650BEF3B61C28492148441477D3A42038EFAE473253058E93DAC6AD9BA4ACB8602482181838E2AAA63D6DFA23AB2B8F051F99414BF1B97FA4F944B4FDC359EC30A32F774D6ADB6DACAEBD5AB57BB600D208D1A87860536F2D81D340D20D4228C6BE9C84957E3A0B970C0E1C2462D8031724A2506383CF9FDF6A203C791471ED9BE6A25EBB2D828E0003C800EBD26CB5B7DBF0EB374D4DCCA61C0D15CC0F1DFD2786F9963035E38E0A093A613660B6D36980A0BBF6FB9E596ED4B32757504AB36C261F9CD5D3DA19D79B9F8DD3876D86107FF9C0BD214157F54FAF437379D6CC6455C5C0B9FCECAFFFAAE84610A85ADAE1B193614605C9F8E1C75360C1E85020E3D1B05C7DE5AC046EC944A19E098DC08C081A503CB0B0EA459F6E128071C4C27011EECD9C10A9671E3C6F9D60EFC3ACCA1B426F061C0D11CC0C1D6E55F12D938E786BB50C0C1C81018A0A1A6C38D126DC469D0E998B116B042222E3CD758D941DC800AFF339F1E17DEFD9D67119E551869C287EFA573E0C034DD902B6E5589DEC7F358F981E439E75F0B0B46DA38EB001D85020EE034EBD92869F352C365B5706C22C0F15BA0A3A8532AC0C611471CE1AF60C13AC1D44ADA8DBF928003E84074BA854DC744294B72E0987FD22C62FE1DB9C1870147E303C7CB521F8E14E994336C30522C1470F07E8CF2D32CF7743BE4729DB3AEA0A013A7C1CEDA91EBFD593B85F04A8EB4F757FBBCB4CFA96738A0C3B54AE5ACC785000E2C1BEBAEBBAEBF036B561DCB5A1691C021D6012F463AC9EF67141D389856013A386B05FF0B9D5A49DA69342D70A8F3ACC2C7DCB9734B7BEDB55749E62E7D8B077B6B187C540D1E061C8D0B1CECB1F1959CA7500ABB0F07BB56E2DF502B3374D646DDC2EFEA035A1E0240329D54A3CDC13A1C38DCD5286960B9DA3CCD0A1C80C82E021CAF16D9C2A1C081BF057B69001A5839F2060EA66D105D428B7565ECD8B1253165968416DB37F7B225B515C1870147E301C7E30219D7890CCC792418E57457080B87EE55802F433D1AEC6A1B7CBB3F3B880092F8C16005C8F90C960E058E5AAE4689D3B348E01098F0CA4817B9F679ED6C8BB64A854E1FE070A1E3E4934F5E6B5A45CF4CD13354F433AB85239C0780075073FAE9A7970E3DF4D0D2F8F1E34BFDFBF72F0921FBFE1EE15D45019124C13935ADE82EA669C3E719AE467B9454BBD3E8BD36C55511EC65991A7C42F2F87A91E344FAD60134143EDAE459590F8DBB20EFF461DDC0B192F340AC33CFDE99374A9E51BE7292B8EF4F93A30E011C3FCAD8465D9DC7F315366AE9201A55B69500073032593ADBE5DAE19E75D6592557D8B7824DB8F493EF74C2C8A2458B7CE194D7850B17FA72CA29A7948002048B049B6D21279C7082BFCC35EA787A77A75177596C18380E3FFCF012960E9EC3D44AB9C3DBAA050ECD03B57A101FEF4CFA49C3ECD9B34B93274F2E8D1E3DBA3466CC181F466454142B329F560A8B1462294A4471DE110ABF471CD17E21CE6BBFACA7702AAE78A8B30AE166915B72929B249EDDAAAC5C9F92FB6FCB293D79BD5723C7F33DC9CB8B443E217298083BC1EE22D2B9CA72AAA411C70995B37268B0D3E4E94F24DC8179A653CDD1EACCD9289DA7A5333B18E1DB8013AD2E15CE498FBA4B3C6766D061F41C9FA84AEA4BFB3D1D051BB1AB54CAF870A86F473709F3DF3901C71A018E5704363EAC0570E0CB41670F78B0BA84A9955A59381438002D157E63FA4957B9F03F10028401412E6885612B0AB8705455D8C231560FB013407BFE8E3BEE98B16CD9B2112263EB28E35F7EF9E5BDE5F99B8BB5860D9DF2946A3BB2F5243D744C79A6A995E3624456556397E3FD38A2929E8D52962F7AC05FC5E9A7B351211E3647D2B341AC13CFDE89375A9E3165C6AA1F570F7238ED7ADD0C3A4CDB03A464D6619D0A625A0870D2D551F52E834A7C38143A4E14E0F8A88A2995B7A5C3FDADC8D1021C5B48C7FB8B5A01875A39D4D2E15A39B042E435A512051CAE9507C8506B8F7E777F53EB8F5A800024D70AA49620C0C485132044EE79F691471E992005DA4F64609D646F794E5F91AE2CA5E6AF92CA60F7646F402CCF6A9F67EA28B8DE7AEBF97B4CE8A15FBAFCB3929523F56EE0ED79F982909E36AB3A804EA01BE848CEFE1DB9B4A5A409280234707E559DADF56A944C3E1C292C1C40C7F6228F57001C4BA573FCBE4CA94C92CED443A423F50436868ABC97F7940A160E058E79F3E6F9D60EC006C8C0D2D151C01135C5C4341390E182866B0171810CEB875A40B078C8BDCF3EF8E08393A4F3DF4B0410A8B50C9367EC2EB21ED48ACE1870D4BE136C26D0604A4277CE2C52634D5AF0CD90E5EEFE31E6CDB8DCD340243F1051FD6059A9BBEB6A47D755F498FAC57E2F6CD9DE5190E1EA5A35160E4F46F4574847B33AA50FC75DD2C95E2CB0B1BB88271DA40F1B0E70001D17D71238800DA063CE9C39BE5F85C2464758381A1C38808D5D44BAAB021970186CA46D601532D8021B87CB2DB6D8C21F21D6E9FC8AB223474083B49036CCCE34D4D639E7D739376B5E6A678EDEA83EA34B69EB442DC2E9CEB745D2E148E010800026D2C81ED2D1BC1D071C325DF081C88D22474A07DB43C40336C2C021A0016C20EB0970FC264FA751D7C2A1C0C1BE194007FE0FF856A8A5232FA751D787236E4AA54181638828CC5091ED45BAB8CA536FE028D248A2168D4533C6A996031A65465DBA55362B00D4218F463AEA3C905AE787AE3E60932796B892A6228C089BB5836EC6F7425FD0697447B787AFB5DEC6C5AFB051B4BD61AA050EA0E48711C0F1AC40C6A745468B7415F1808D38E008A6547CE810E0182CC0F1625EAB54A280032B07D0C1D255AE03052E74B887B7E9592ABACBA87EBAFB9084A7959A1438008DC1226D514A532FE0D043A5988FA45263F2A6932AC2E8B8A31A97A23F97B2A18C282B9D470E3784FCCF4E9DB2E2C9DFF30071CBB756EF183EA384D1A0EDA761168D6A81081D429774D3B05AE96F54BC45858DD8552A29AD1B6A0199E4384B3E209DED3122DB0219AE64008EA1021B6FD40338B072B0541500C13FC22C1CB17E1F5836F614E911051BF5F2E1A073A023C2535C47C7AC1260744C679583C778879A40EBD928D5EB599409E583E89AFF38CB41F8CC0FCA987B286F5684E49D66AC1A6D6D6D6B9D51526D4763F71BACB83A800ED7133A5CD828A2852E0F0B4757018ECF88EC27A0B1AE8887240187384646F9700C110BC70BB59E52510B07C081954305E74BAC1561F0E0D0B616B57060D5C0F974A7F0144A587180D4B0D3A87AF9C73904465D777F53AB059D16267875CE0A9F45E13AF551B9F1C8E61EEE4FEB8CE83E37CD3D49EFE6768E7161C3CF8CFB5FE34A1BDE4D7FB97BAAE9C0C3F1EA2E8CFABB5AA2000D3D3DB49206D02DDBA47D10B2BC2BB0D1B367CFF6C3D60C140C146AA503E83F0325DA24C059254D1B92B6CEAB03B61E2058495DABD5FB273A8D66B470B4FB7A286C2401070EA311C0B1B758195EAC87D3681838143C66CD9AD5BE5F07532980478B4EA9A8AF46FFB829943070C8FE26EDE70DE87C383BF3E1B9CDA77A4CD3C9A9199B55005CE3186D4CEE745A7A0FF7F13B0E588C12D25620C261CAE46C0BEE271EAD8C7120A11BE1F06C4D0FBF4585E7F7703A35FE70071E970FE1DF496339C912BE5C7EBACF201CE925EE2CD3510A71E172C2C19229137D06659BF630B3B40D1D0DB742879BE6A4FC21AD9499EB1BA2B091F6D916CE80A41A1D70074BDA96697B03808477308D6A67CAB511B4758D709E4F1E168E3C8003D878A11EFB70001B71C081A503E840D8DB823D32143A5AC8C2313CF0D5E82D9FDDE2A650F4F755AB567937DD7493270EB87E674043CEBA74941FE729600100C074ADFE1651AB00381699A3B8F51E9D32A9743E9DFBF4A8705642200A360A12400EA30ED28BBF00E954DF021C1B35BC76CCDC4758379D3C0728A2F1203E052B1A8CA87C88CA1F7DD7A84FE2272D6E7E960BAFE98FCB4FD751933849236193FC605C3F0CCA52F34AE3538739376D6921314B434EFC6107D3703E87F3079DA2CC784FF2D260C3E0218BCED52AACB68DB43DE8306D91B621E17626A9CE6B5B57ABB4E6156F11806398388DFAB05104E0C0A70339F8E0837DC752F6BAD06916173A9AD06994E9132C1B7D443649020DAE5F7DF5D5BEA58ACAC15446B8D309CF65729DC63EBC0A40AD1295C245526550CF717C015885A0A35D3A4E9C14E990DC67931E7E73C3032C982BA39C0AF98D8D80E8C019ADD0B1B9AB30C2F9A08D4752BAF57AD6F069F3531B3CC2937605C2F0948C3A7C1246CB386DDA6B118E74A343949F8EEA92BCF11540B3E6652DD26F711AF0B83A806ED2DED016A1D371ED4C33E84D5D80431D4675958A33A5324CF6E178B19667A9945BA5A25329AE2F8702079F871C72882F2CA765DF0E2043FD391A1038BCA0B0E3360403367433AFCDE47BE772D071EBADB7FA560D5616D1B95249D20243DA0EB156154C81425745248D0E343C9D5C5287AB6119850321491D61ADDEB19278B55C70D464CE594DBD3AE5C46F5C2BCA2642BCA30B1295BCB3DD639D7FD174A09975BAA6C0E18286BB4A25008E21323A5E5AEBC3DBAA010E9D5E51F0C0E2017860F100385CE8081F5EE72E8D8DDAC6BC03F6E188030E400308614BF4CD45BA96030DD93EDD9B306182B7D75E7BF9A081A9BA6815366D7A74554496F069A709D451326DDC450AA7508585072843746550DAF72FD2FB585A0C2A4C078AA10335018E28D00801C760810E1F361A0138000FA0836916045F0FF5F1003E986A71F7E228E83E1C0A1CEA100A640C12E12C14A650D629071AAFBDF69A3762C4081F34983E61A46B9D4F312A71AD1AD32847B75A3DCBE26D6E5DB2F2B5F2450772050E5D0A9B001C83808D7A1D4F9F87854381C3858E830E3AC8878FA38E3ACA87262C162E7C14C4C2A1D3244C9568610319ECA9B19DC846610578E699673CAC187FFCE31FD79251A346F9235DA609ACF1B0C6C374C074C074C07420AB0E440247CAC3DBF4D4587F950A4B61D9B2BC1C6CC8B54112E6793D0DB5D12C1C2E70CC9C39B30474CC9831C317AC1E6C95CEB25E604A8FA5E733BCBDB94EA7F0A927C4724F0E87B74D9602E5A45800634460C1D8433E77700AFADFFC335E7FFD75EF965B6EF17EFAD39F7A7BEEB9A7EF88874F862B5834B22A9785B706C974C074C074C0744075201238DCFD34D27C77B72E2F031C43E41A27C5FA9D6CA35B3814380E3CF0401F3C0E38E080D2FEFBEF5FE27F2C225856D848CC05109D76893A923E2B70E8E6687C2E58B000A8794E2C139C16BBAB081B75F512E991E493F1F9CF7FDE93B4FA2B4D58C1615325D6385807613A603AD0F83AE076EE4529CF48E0D003D6B27C26583686021BE1117D3358381438F844B076001ED3A74FF73F81110004875385102081953980970B1FE1FC718FA927BCFABB0031F890309DC39E22C0CFE4C9939F58B264C98E52A09CE05AD61F8342BFF4D24B3DB9DF5F86C572ACB42B4C8AA2B8968EC66F10AD0CAD0C4D076AA303E18EBD28F91C091C09F090346D12BEDE47E27B3A6A55463302874207160F04F098366D5ABBF01B500288A83055A387C9E9B2DCF00A19FC45000BE29A32654A69D2A449A589132796C68F1F5F1A3B766C69F8F0E17F94CFCDEEBCF3CE48C71C0AFAA28B2EF2AFF1C974092B4C02C7CFCD4521178A7C5DE45B22C7886C1CA1A45DE5B77E224344F62E2343E55AF7E07EEEE16F58706F978878FBC86FC345F60CAEAD239FFCC63DE59E433AF612D928B88F7B7876F81EC26D13F1DCA869A2ED82B4700FEF5A6E2AA9A75C1F11E4C7A60961C3F9C0FFC44DDA79F7A4F7DC3608AFF144BDA71BC76009BF61427E12077F9D53E64D382F3AC97DFB8A7C5EE4C6E073664C5C94E9A098B2D931E1F9E822F75226BCD70665C2C7E527EF4A79AA5E86DF85FBD0A572BA4D1C7B8844E9B01B1FBA3030222EE2DEA44CDAC923F282E7203B88F05B9C0EA21351E9E55EEA42D47D5BCAEFC322CA214AFF08EBC64139D0367C33908BE573B732E973EF4DABB75AA7BB49BCE8575C3BC03BB4A57CB65BA7E596B2753A2A7F344D717AE7B657E8A99659F8F7A8F2D0F22EA757E4C36491AF88DC2072A5C8A4B8F728E7FC5FEE1AF165B9376BF8B8B8B3024552F8AE021B9789AC6E050B47183874AA45AD1E2E80ECB7DF7EA5A953A796F493EFC00422160B1F2AF6DD775F5F6429AA2FFBECB34F69DCB871BE001A8E3C2AAB487AB292E4DE7BEFF5962F5FDEAE3CB7DD769B0F16387CEAA7E3934187F1BCC88722A54056C9E7032234EE6E25A183FD83C8BB29443B112AF0FF06E1FF219F519DCB7F07D71F0B9EB7AE7CFE28C53348C75291B1C17D1A4F54FA964B98A7458E12A102C735E2573BCF7D4EBE970395139CB0B3CBC4C9B3DC7C200FC94B7E1F9FF23D3F17846F73F2B35C39F0BEA352E4E7DB12E60591C313F2259C5FDD24FCD7445688A8DEF0F9BEC84F441402F53E3AFABFC7BC2B7AF18CC894983C9CEADCFB8E7C3FAE4C5E97CB4FDEF54D11A03ADCF1A343E852926EFF9F84D9A2CCF379DF43455E8B89EB2DF9FD0E915D22E2585F7EFBAE73DFFDF23D0E64D16174222EBDBCEB3291D3455CA03C33C53B1227F9BCC849236D016D026D8396F71AF9CE734E4EC88FB0FE27E531FA086C91EE72ED003A4E9B715099E713875BA75F94FFE3A09374C6E50FF981EE2C16592FF43CB7BD42C7357EF777CA1D1809D7A3EF04E511A757E4C3CF445638F94EFEF3FF7F89B4B971660186282B4896FB796E96F0F5020E0592C5021C6B9AD58743A754D20007D011B67C001B49C0A1160DA023023C1E1D33664C4F56938C1C39D21320F11E7BEC31EFF1C71FF7AEBCF24ADF111405D1CF4049F791CF37428AEC761EBF976BBD1D8546B9FF5426BC7BEFCEC17D5BC9E76F9C7B2E89A8747706D76968482715F597299F43233031B84FE371D311FEFEBA8465B410051C7492BF729E4BA52E0712A73A610F8B89539FE3E60379A80D056929975EBD7655103FE0E2E667B97B295FCD4FA02FE9390B12DEC1CD331ADE72F17D5FAEBB1D1D8DF00709F7BC24D78745A4E1ACD07D3F28934E467E49EFC9F5AF86E29820FF030949F73EE5945D1CB4026F8057B9B8FE9F5C570B94C603840209EE7D71960A80039D484A2FD7D16185ECF352DEC37DE7047904F4DC9770DFFE09BAD32B451CFA2E74CEB41FE84F1ABDA50DE81FF37C060C74E61AF76AF98E5532AEECCE4D913F58785CCB13ED95A6131D7781C34DFF37229E7B53F0BCC7E55307219A36EAFABD09E9F99E5CEFA6F1560300C491E5FEACE1EB0D1C80C7E5061CFF848D5A01874087A73270E0407FEA44B71D47419CBD3318E13DE928F37BF2FD7E9187430A7E7950F1A9046D225809A8BC8C6EB08A50C1C2C2B59D824A40477BB713279D6D7B0509C268278FA5453BC8DB837B889BE7D05068A3C1FF8CB4F8EDCF22DAB16A3CE1B4B9A332E2A09287D3C073319DBEEC3C8778982E886B9C9886D234CD2B138EFBDD7C200FDB82F0C01271B879487AE9B0DC77BE36084F23A4F959AE0CB87F8C939F7744E45FB8B3FA9B84D1728B7B677E670A0E38D0FBFF12A4E909E737467AAED99746786570DD4D77380D34E634E0FA7CBE032F6E38F22F2E7D58EC34EC474EBEEAB3F51AFFEFEEC4335EBEBF1ADC4BBEC7E9B56B9D8A4B03F0497DE259C445798675101D06A4DC38B02284F3634ECCBB02105F0ABD2BCF20DDBCB71BCFFDF2BF4E919E1D5CD3F773758CEFE48B5E3B2378F691F24999699C8FC877A057F38BDF1F14D169C2A87C41FF1910108FD6698D53F581F49376F4094B28C07187F35CB7BD71D3CDF3E32094A9222C2A6E7E84F3DD4D2F90E5EA8FA6295C2EEE40041DD574927F2E70B8E97F41AED1EEBACFFBCFE0798FCA671838FE23946EEA17F9CEA0C94DCF4C8D330B3034BB85C3B77408705CD68CAB548A62E17081034B4748B9DDFF314BABD20201B34418C930DFF9A9A0E273FDD9A0F28781E349F9FD14113A5A1A58578E96FF75F416060EE20C8F86C2C041434307704C102F9FF707E9C5847B6EF05C1AC28345DA82F7D47896CBFF34AC9A26D24887AD8D1415376AE48829DC6D58492B23945A0207008165C1CDBF39F23F1604B7E3006EC2E0F257F90D737638FFF99F77D606CC6D1069EC291FAECF17F9B4082344D505A649CAE90DD7C877EDC0198101369899F963C4A579788513970B1C74583C9B34A0873ACA230D34CAFC691A7690EF7F74D247182C11515312DCE302079D90E6CD1CF98E454A819978986ED0E7B8C0717F90B628BD9E26D75C208ACA2BEE5B11A419709E1B08CF73DFE556F9DF9DDE3B2DF49EA4F10BA130FA3C17382853F29AE7F0EC23443E2B425DD172558B239075AC932F2ECCDD20BF934FC48195A6AF0810719D13CFE5F2BDB708F59B3CC3E2A3CF88B3C69066F28CB2A1DC891F1DD2B200303E2E823E9076EA34FE12DD44EE08E257BD55DDE6FE6F8BE85430532BE1693C9E4BBB168605F42D4EC75DE0A00E92A7A4E963220F39716191D038D20207EF800EA6010EF45EEB18ED00F0C11FF9B29F087548DF8B3AE7EBA401874046C4592A97D66159EC9BB22A6459AD36FE0A2F8B2D22708C1E3DBA5CC7F1DB4061999BA4030A8765A4A90A7D4070BD4D3EB591A0734F6A78C31DA4C6C7BDEEF3C2C01195EE1B83F4300AA7C18B0AA3F130F20274C261EE0EE2C06780C62F7CFD42E79D8116D2CBFBF68A795E1E168EB832BACA490BA347850717E000A76E316973E30D3788E167D2D0EB2890113C168C72BA73799036467F61DD4147B49CF1A9D1F4B9C0818F871B3FA0FB70701F1D88FAE4106698884E4FD081EA283CCE8FC3050E3AF0F07B00C9DA90E3CB11051CE85AB9F74FBAE602C76742716145D3FC61CA72FBE03A267AEDFC795F7D67CAC39D9A8A028E15A13CD330D73BCFD23A1C4E3BC04A7A80C46322DE1BBDD37A85F52FDCA95FE03C83B892F2C6BDFEEBE05E6061EB887B93F4B69BDC836580F463E91C118AA38BFC8F8325D769E7744AEF39F91EE7C7E102C7B0507C001869253E206060703D2D70701F5369C0B9E6439C85838180EAC912F9CEBBB8793745FED73ACB80A13DFF92A0236319F9CF8C8AB3DCEF71CFA8C72A9528E0E82C4B3E3FA3CB3E6B7078DBCB471E79E408818DFE871F7EF87D22FE016C48D2F1F4EEE16DBA52246AA7D1A20307B0C1215B6EC153D8C1FF34726F040A0D78748B5090F1F21B8D1054AF15AF4DBE2B70D0794775EAE106C7ED20B502BD25F7BA0EA949C0B1BE84D78AC9E8366EBE56E3014A681CC2695113341D65D8CAC23318119346AEDF137C2FE7F3512BE060144D1A34BF1865E9BBB8F949595026498D7C5C83E8DE7757F0BC57E47374429C8CBA491B0DF84911611941121F4E876A667781E30EF93D0CAB2EECB95331739C7CA0830216793623BEA8F77681437D10DC70E3E43EF483386E76E240DF01557E47D792F2B4DC751738A2A6E474A44CF9F50B9E4587A2758BD1B34E4F011E9B44A4C7B57010069D898309DE89517A549A19B92B70A815CD0D076CABCF10F9D6168A874E9EEB4B441879A7CD37DE57E37D52BE637909DF9B466F7F18A49FB48507114C23FD22B88E656969F09DB64FF33DFC4C1738A2062517057190676A21CB021CCB43F914071CBF0B9E034801A9E17402E90F883075495DD029B3442B4786322A0B1BC413072271CFE828E0E058F3756459ECA5226B72068EBF086C0C17F137B412D8D850E432818D775A0D38C285EE00C71CB9A673CC7126744CA6FC31A25107A936F9AE8D228D7F5443980638A8AC5F71D2570BE05013B29B1EB5DAF0EEE1C611DF8527834AFE7FF2C9C88D510CD015D571116F2D8083D12C30A7B0C177A65DA2800373767B4353A62149D370EB880A0B421444B8F9C874959AB2192DEE23E202047081E9D71D99270187767CBCB70207B0F245272F30F3F33CC2902FEE7484A6CF050ED219D6473A661A69E270E7FD5DE0C0D290B6E38C0A97041CDAD1527E7B04CF42FF1432BF21DF15EAD0BF28980803C7948834BB9DA7EB73E0A6390938A8FFFFE59401E67BA65DDDB2A5AC295FD7913229FF2A018E284BCFFF046903948149F7B9DBCAFF0C6E1422BF2CDF8164F2F9F898324E020E062A3A05A97A920638DCA95A2C4F9ACE28E06050F1D720DD0C08A3F292FC63E0485885FAB5C2C5593AB2E876521C8D041C9EC006F259018E3572CC790961532BDD45F384134EF04F6745D84D1361F74E15B6129F3F7FBE2F471F7D341B61FD456404B0E10007D0E1096C8C14F9B55838DEC3CAC1BE1749C7D337BA85237CB89A031C989AA978742EE76650C03609ABC0C1288DC67D6084F4761A9FF0885C1B5546715B04CFCE1B38B082302AE811C866F2395484B9621A9F281F8E51C135AE636AE77FED54BF139347B5008E9941B9A805E1C0D0B3DDFC7C41AEE1741A5506F83868879C06388E92F0DA28626D28D761D0B0BBFE01A495869FC638CA344E5C2E7030D5E2C64F4785B58178D0493A7FAE03B4F705BF537634B06A1D7846BE4741A50B1CF822A90EF0B94D50B60A736738E97081E37F63F2947C8E7B3FF77D5CE0B83CF4AE00A276824C07E83B1CE9E43FA368A64054FF2E8B288F30700014C4CD7B926FA415F3BDBE2B4E9851659A041CDCC3B490C6C3271D2E53157B8B303049828BB80E338B858376A32D7837DE913ACDD49B3A50D29E30EA779F35C14937793843442D64EE749A7B4F1270EC257150EFC8079C60B9370D70605D5911DC471BBA5B706F14700C926B6A81FE6985F9EBBF53D2F48A5E8F7B461250A48DBF5CB8A47D35AABACEEEA5C1F1F40A1C9E00C7E772008E65021B23D93D330638808E2E021B5F32E0681F3D31D277CDF5490D07155E81C36D80C2DFA9248C7A88CFED20BF2EFF335541C74603C27C3A61F2068E954163709B7CE22FF03391E5416527ADA48F2914F77DE73BD7D53F404DEF77C9351AF170FEE40D1C34DE7F70D241FAC373E65153545165413C3AEF9B06385CC08AB37AB9EFFF4B279DEEF31F91DFC9BFF01CB90B1C58C7F863A40C189D20A2F3EB80859AD7010CED9C2933E6BEAF0E9E4B7946F925B8C0015852FE087949A7E4A695865DDFC9058E72BA7D4D841E84F5C2058EEB243CA0C3BB62C6C77AA1F1F34E3A6AD7F742770F11D941E4A5202CD302E167B8C001A43112C612C1BBDE2E82295E9F4399D041570A1CC08B8EEAC379C39446D8B290D48E703DAB8583770454C933CA923C511F06D2F4E388F773E101A0A31EE8B4D9BD4EDE67010EFC9B989EE1992F06CF4C031CC0955A58B9579D47970471019FEAA7455AD587E7B3A1F7425FC83B57B0704459FBAA028E24EB06E96A54E0F004382EAFC2C2F1925839468895C3DFAE5B8103CB4660DD0036907504362E37E0F0977AA2F42B44681CD3341084691349031C50BB76E86E0789397666F06C9E7F4BF06C8080FF9F8F490B7165F1E128D76130C2C12AE0BE331596291EEEA3611B115CA711E3371A29FDCDBD2F6FE038439EC3340ECFA4436584162E9BB4C04103970538182DEA88FADA143AC1E8D6EDD4C279CE08D835F5BAC00144E0084B274943EBDE8B4E286401017A4D47F9AE25E6928874BAC0514E0F0001376FD30247944F461470E89425A67EAC34CCB7EB7410E902BADDF4ABE5E605F97D4F113A10FD8D38C253672E70947B4FF4E9D020BE4A8183FBCE0C9593FB4CCA33EC1395D4A664058E72EF8845130BA6FB4CAC66B70669C65A807E735D819EB646AD0C59800328509DD5F62A0D7000D9B421FA1E77C877EEBB31F8CD058E725372800AEDA82B4CEDB485DEDF7FA7B44090F6DE70B8B4F117CDC2017074023A2A98525926B0314AC4870D173802C850D8E0B3B7C0C65B061C35070E465851168E25F23B664F465C543C1A2A4CCA3A475C4BE05821CFC19212352A66F44787409A5E761AA24F380DC4FC884A992770900FCCE96B837453542320BFA5050EF2B896C04183364C84D1665C67B0C079071738E2C233629DEEDCF349276E8D0B8B8842197A139ED74F020E3AF44B45543FB5B3490B1C806952674A87A1C011F7AE803B65495C74623AF2A643A423E2F725C1FB337DB55FE8B949C0411EE18B04A095F3AD4833A5425A88E31811A6B2A2DE09F8D4F749CA1FAEE7011CE40BD35F5322CA84F46A9E3E2CDF754A09074BD28F2589BC09A735694AA552E0B84B9E0534320DC3F3578800ED6AF5480B1CB4AD51F94FBDF8B77C4F0B04E17B93A652347CDAF88B081C404767018EC5197C38FE2C7E1C3E6C8481230236008EE35B69954A191F0E469FAAF4F3A21435E6B736F95D2D1CBF97EF38B30D8B103A4F6DE4DC0E122B058DA93B5A3A5BFECFDBC28139728908E657F519C1641F67CDE92DD7D4A4FF63F9AEF3D2988AC3236CB752E7091C7482FA2CCCD7CC154735DC6E7EBE2861A6C69401D312597C38C64878B5707C35834E6C12E8010D67B893BD5B7EC304CD7B240107E57496885A450009CCE6E409F3F44CF9687E2C0B7EFF9D7C325DE1E6930B1C74B8CCD5934F9AB75850C2D33DDCEF0207CF1D16234C8D2475A849C041E73CD28967A67C7F2748A30B9AD40D2C6E5843CE0B3DD7050EE0828E97FA05C4AB05051F96A4B4A6050E8D670789932933CA36DCF15D90E2791A4F56E0E01D6F10F9B988D6E915F23DCAA19667305DA63E494CFBE87369EFF4F7C511E9CD021CF865106F1A0B071647CAEC7027DFBE24DFD50AE30207617837F2F78A501A799728E0D8292AEFD30241F8DE56010E4F80A3B300C7E5E230BAA69CD3A880C62B2223457CD8708143A752429F5D05389E36E0F02BC8C92274B054BCCB631A09487E884837E77A9B7C57E080D4C366DEA40E9206910E655B91E541C5A1E1A2E25289F2B270606265BE9CA9183A311A6DE2A703A2830CA793D1A356623A4D4646883A6E718DF9E3B0535A5EC08169F749270D3444711D850B1CDC93C6692FAE41749F8165411BE24BCA3CDFBDC79D37EE26F7F4126104A9F94D47AF7E122E703C2BBF7F4EE433224C959C283258C41D89139E7224EFE96C280B2D1705A3BFCB6F80421C70D049932E0058F576857C9F15F17E2E7060AE4EEAA8CB5D778103CB191D3FEF79B9C86C117C53DCFB2F72F2CCD53FAD23E4011D5338EFD113AE01D8334428677459F3071F96FE09EF921638C25612F48E113A5363AA370C1CD2E65B56E0C022C133B14C9D1BBC37EF8E2F46B788E7E217A4E9224F9996427F5C5F142C6461DF8724E000B8D412C9B3B3000761B1B4E8FDA4E9FEE05D5CE0604A4D751F9074F3F47CF91F204614BCC987DC80232D6C90AE2C61E3C257E5149A74D26C8CD328D60D5F04383C010E4F56A65C0174C4AC52013646011B1980638A00C7EA56028E70257456A91C22D7D4E10A08886A24F073D0860E0B0061DA44B4E10614D29850A32C1C34108C3CC3A49E1770E0ECC91F69EE21A273E1748434EEE1F7C5312BCEF4ADBFBBCE8C7A7F1EC04143FE45E7F97432E151BB9B5E373F290BCA24A9914F031CE70669208FD499372A5E807184C8B12227453C9BF7518B151DA18E405DE0F81FF91D1D2897EE61725D3BCE726543C712071C1F77AE31F7ADF1D04986E1D1058EB83A9194CF7ADD9D830F8F50A3E2006693F48FA916F56D210ED7C2413E031AFABB1B1FBA55CD940ACF246E80698F88321B2EBFA92F8F8EF8D3E45325C0A1D62F3AFD879D3C8BD243A031294F71FE0446DDF4260107EDA2C2C00F827BB35838789682A29B3E1738DA240C70A483A4F0B4A19633BE561A476AE02857EFD2388ABAF7371370001D574600C7CBB22C76B4C246183862AC1B4CA7FCB095F6E1608BF33DF7DC73AD8AEF00079DD65F03656514146E7CB9EFD38E32CF0D948C8A502D70A833298D180DA55BE9F2048EBE4EC5000C74DE9FF463BDD1BCA1E1C6DC99D438719D4EC9CDD33C80030B00231D7D3E0D5EB906BB56C0717390064680AE1F45382D9BC8752C14A41727C8A8B462BDE03AA66F75267481E30EF99D46BADC7B9E99B24C981E743B54774AC5CD4B20EE3127CE2342CFAF157024399952F774D543391DC4B76858486F5D0B873BB5B04F90F7C4876E0D2C93D749160E373FCF8D8807A0D7CEFFA5843275CBBB12E070A7C298BE712D39616BAB5A11CAE5E95B1247D8313B093880717DEE25C1FBA6050EF5A99A24F7E17F12071CE41353D65C67F004E047D51577A05233E02857A6CD061CBEA5C3D9876319B021E25B36C2168E60A32F7F654A48B613D878ABD58023616B734C7528341DF117424A85A994113DD7995B567F8236F9AEC0C1948A3BE28AEB3CC2160E050E1A08E663EB011C986275DA86F7753B221A4C35B3D2A8332580C543E526278DCCA9BB9D9B0B1C33CB554CB91606852DE4371AD0EF38F13F2EDF933A62379E27257CD8F931AA1CC20D62380CFE1E346C940569D82CE15DEE707423DC6013F75DC175F255212D2B702C09E2C094CE74825B26D7C8FFCB83EB3CABCD496F1C7090AE4F3879FD887CD70E806B2E70E431A5B22278561270E027A4A3D91743EFC93BDF13C4C31428FAE682721C7050DE6EDD624A276A944C5C49C081795F75E37EF9BE9E9306EEA733D4113F569872109927706C2DCFD23A0D002C709E8DD542D3443BE6EA0EDF5D0BD069A134BBC0312A748DB60BC7736DB39872E69DB2020775E1474E3CC4E75A3888D37598FE4644BED27EDEEDC451357064B56E90A666048E4EB2E1D797445E16190B6C848103F060496C9C75437EBF5C60E3A356038E84C3DBA638CACAF40A8D17235B1C96DC9120E665EDD4DAE4BB0207A3B279229345A6868478E818A93871C0C1B5D34395AE56160E9E45C3AF0D050D8EBE138D8ACEF5E25018D519AB7564895C5760229C0B1C97CBFFE469382FC81FC26E29A20D0479C8C89651B73B6D80E325A39F701C58838645C4C31C2ED6A7A832208EDEC13D6E8348C7C54A1DAE030BC78BD0F96ADE5C1F9107E13CA1D1563F8DDFC977FE34CC854E5CE88836845981E399201E2070B7883469478C6F079DA23EBF1C70B8204D99BA8E9B2E70003151E5801581704940E64EA92401073AA479795DC47BCE74AE035A69808330D44D2D532C525156CC34C00118BB9D2CEFA37E0FBBC8F75F3ACFB92185EE68FAABB570100FF5C5ADD31A377502BF0DAEE1A711D65FAC8A7ADF57E4BB0B632E709C27D798424117F0FB212E6D2B9E74EECB0A1CA46791087551D311060E74DE758EC5DFA95BF02E03E5F327CEBDC45133E0280722699D528BBA4AC5F5E1C0BAE18B804637913E223E6C8481230136B614E0F863AB9DA5C2940AC0D1A74F9FB811078DC6ED21A5C5094F7D3B50622AED814E856D93EF0A1C541646B0AC20A0D17785780E0EEE733B5AE0C5EDB0F790FFD53CCFF36A091C3B48FC6AC65C21DF150498E7D746848E349C5F387931EA277DA4953CD0302E701077381FF8FFAF11F9A0C00110B8161EF28D9159543C4052185CE834E3CA8072515F0CB741E4791A3F23572C089A064CCC494E86A401875CD7F98E91E6FD228C70B5F324CE6F8BA815210B70301D46FA8903FF1BD794CEF38913AB9CA6DB9D4E28071C742C748A7A9F6BC97081833C89D3EB27E5DAE8A02CE2EA5616E0D079787410BF98709CDBCB6F0AA53F93EF58EB0813F6E108AFD600665D908C72944D031C3CE72C27CF285FCA99F2A6BEBAFA8BE36A5C9E847FCF033886C9F3D059D280956878F07C7483FC24AD580AC2CFDE36285FEE633A550747847381E31FF23FF5115DE0BBFBAEF39D782B010EDAC5279D38C3C0415AF011D16752D7294FF2DD7516E53A60829EFC5BDE67B1406485079E97F59EA8F045711A758103E8F0250C1C09B081D5E34891F7EB041C37C8A9B1DBCF9831E398030E38E03A91874596EFBFFFFEEF8BAC993E7D7AC99569D3A69554A64E9D5A42A64C99E2CBE4C9934B93264D2AEDBBEFBEBE4C9830A13471E2C4D2F8F1E34BFBECB38F2FE3C68DF365ECD8B1C8A302193DDDE3E9E5376FC89021DE2EBBEC12D708D099AA59D2AD4C7CA7B2329A71E9BF4DFE7701217C8FFBBFCE9153B1FE5F507158D2E502078D99DB01BC185569827B7439189DB24EF184DF8B91A976A851A3622C189A46E63FB95FCDAB34EAC7443C9F6923F73E4647FA5CCCB1E5F240AF2928683EE888934622CDFD8461854D389EA47BCF0DEE099BD8A3EEE3FD997248DB615C9A90761A45D7820034A8A508737FB9A9231C41B593BD2D264D4739CF67F4A7535D8C46F5FDA2DEE750B9AEA35F3A136DA8B1F628E494CB573A1E46BDE5F2092BA18E5EC3D395EE7D581DEE0ED24B073920225E3A66EA0569C24762601086BA7375F03B798555D18D9BEBE48BBECBFFCA77770A49C302DC1A263CBDA061F079528B525CDEDC2161D4A9338D0E9196FB826763CD62F011BECFD55B74270C9E84D73A45BAAE14410FD4276B857CC79A178EB787F33EEFCB772C5F1AC69D768B7B57DA22B590725F5C3ADDDF79D770FE7FCDC97B7CE95CDF32E2DD4E84DFCBE923704CB9C54D99750A77F211F9E1BF7B5678A8E49E66078ECE021BB7D4E9B4D88F0436F616F104383C010DA493C83A021B53455EEA08E018366C5839E040D198EFA402BD2282BF0623861744CE8F504C2A04CE4C8463441F275CD711559B7CBF4384461EB808CF01D3206036C7B202E5473556DCC3BD84019018614785FB69108691579F8830742ACB83F4334AA3B37930B8878A1D07323442A49FF7A233D167D331F27BB9BCA01323BCE603EF401E6E22C2482B292F356E46B76E3C49F7D1316A0742C3871F04CF76D34A1C00DC5322586BD274141A06106304467EBA0D221D271DA33B02E41E3A0BF28234909672C07145108E77C0C7202A5DCC9F6B59920EED00C607F7F29C3322EEE5B9F81FA9AE337A27FEB122CF05BF97D36BC210B65C5ECD96EBC00CF100667161D1E387836702A1511D36E0C0D401E9C5AAA4960C7EC722C7EF3C4B2D76EEB346C8EFD405F2827BF90BA7051D219DE435FA1C97D67172ED1111771A80725F2172AF0883972CFA43E78B4E9336EA2056AD28E050BD4577A28083A923D5835FC877F402E0205F0099B6887879F665C1B379BE9B77E84C543DE119E8F59745A8BB6E5ADDFAE5A6D3FD9D770D03071619C09CE73D20B245445A19E0306DB942C4AD67DA8ED0A695CBF76E727D2DE8880B6FC0F1AF2995480B077B6FE0285A4686096CFCA54EC0713FB011020E1F3C0436361779AA2380836995DD77DF3D4D43C0E88AD1DF7E229BC72825159EB97FC20114713247AED199F25C2A1D8DD59122C344C2244E47419C341C3C3B2AADDCC3BD74F6000A2394A87074041A464DCF6E382A1F53449A7E608B67F26C4CF17123341A53D2CF7DAE858379537E2F97173AB544DE910FA48FF7E559587B986F2E773FD7E8C0F609DE59E349739F4217F9C73400A67EF759C441831586C034FAA26130A37F4BE47691FF12B95024AAF360E4495E9006D2123722235EA0817007896C1DBC77384D1BCBEFFB07F94727AC00D326DFB1AE713F7F51EFC288764E2074CA8401A689AF9C6E738D30E19168F819E8FE4C11CAADDC1415EF7648900E741788884AEF9E41BAD0B55D9C30003265C8B3DC69018D031D43E7D06F9ED33B227E748474723DD20FC0B98776810E99010AE5FD7D91E344B25836346DBC2B3A4DDAA688509EE17777F516DD512B961B8EFAC0B53922E80179459D265FA86771BACC7BA323C8EE4E38F9FA6FF5847247CF7BC5C417974EFD9D3ACFBB86CB97F721CDA401CB5CB798F8692301F89B44C8F7EF05F7A4A9B794CD062E4CC4E589014719E0606A05D0D07353223E3BCB6F9F0136EA041C7314361C0B07B081B4893C5D6FE0607A45A65EBCBDF7DEDBDB79E79DB374221636DB68CDF2CBF2CB74C074C0742041071A724AE5B8E38EF357A5245837B617E07852C2D40338960A6CB4852D1C016C742870E0C7316AD428AF5FBF7EE51C48ADA25863693A603A603A603A50531D6838E048091BC0C8C1021CA53A01C765071D745027110F013CC49AA1D68D0E050EB5720C1C3830C997A3A68A56C6B469CFB546CE74C074C074A00574A02181C33D1136664A6503F9FD1660A30EC0F1AE40C630850D3E9952291270E8CA953DF6D8C3AC1C2D50A90DEE32392F5A476775C274A04E3AD070C081A36819BF0DBDD655C21C2DB0718FC89BB5F4E110C0F881C8FA45070E593EEB0D1830C02A569D2A9675FAD6E99B0E980E980EACAD03CD0A1C3E78045B9D4F10E0F8BEECC3F1540D761A5D2DA0718C0B1B45B670E0CFB1DB6EBB19741874980E980E980E980ED45D075A0138FC2DCF05367616F9B89C167B87C89AB973E796E6CC99533AF4D043DB3FF93E7BF6EC7699356B5649E590430E2921071F7CB02F3367CE2C095CFC51649B3070B014B688532A4CAD0C1A34A8EE4A66946F233DD301D301D301D38156020EA0C313D8D84060E320912F0B70BC5525702C0EC34684C368873B8D86771FB58A6F15DF74C074C074C074A0DE3AD08AC0E1096C209D0438F612394DE47EC023A385E395B0B368CC0A95420107F03174E850B3729839D574C074C074C074A0AE3AD0CAC0E10968A86C2AB0315DE42732A5F29E4EAB244CA9DC2E80B14EA35938008E8463EBEBAA80F5266C7B9E8DEA4C074C074C073A46070C3802E810D8F044D611D8D855E47291E7043856C5F870AC141F8EC3453C57800F67B3AFC2ECC3E14EA9F01DE7D1E1C3877B7DFBF635B8B0118EE980E980E980E9405D74C080636DE0F00434543610D83855E49722AF879C469F11D0E8D6A8C00174B04CD6B63CEF18CAB7D195E5BBE980E9402BEA8001473C7078021A2A930538BE20F2876095CAA561D8E0FF46B170A89563C48811BE95A34F9F3E75A1DB56AC60F6CED6B1980E980E980EFC53070C38D2018727B081EC28C07194C896225E9434C2948A4EB160E5E03459830E6B10AD41341D301D301DA8B50E187064038E48C850F0088EA28FF2E3E0B4D8676A7C5AEC6302123DC3FE1A49FFBBD0516B65B3F8AD41331D301D301D685D1D30E0C8113862AC1B00484F9147053856BA326DDAB4952A53A74E5D894C9932C597C99327AF9C3469D2CA7DF7DDD797091326AC9C3871E2CAF1E3C7AF9423E77D1158F0459C409187042EB648028CA8EB3891AAA5C31A83D66D0CACECADEC4D074C076AA90351C0F1FF01CDC9A9C9236A98440000000049454E44AE426082, '52035', '51005', '31015', '31085', '54050', '58005', '2013-02-11 15:34:10', '2013-03-07 17:01:03', '2013-03-07 17:01:03');

-- ----------------------------
-- Table structure for `signatories`
-- ----------------------------
DROP TABLE IF EXISTS `signatories`;
CREATE TABLE `signatories` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `Username` varchar(30) default '',
  `RoleId` int(10) default '0',
  `CashLimit` decimal(20,2) default '0.00',
  `BankLimit` decimal(20,2) default '0.00',
  `Company` varchar(10) default '',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`),
  KEY `signusername` (`Username`),
  KEY `signcompany` (`Company`),
  CONSTRAINT `signcompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE,
  CONSTRAINT `signusername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of signatories
-- ----------------------------
INSERT INTO `signatories` VALUES ('3', 'jsph', '3', '0.00', '0.00', 'CSPT-FZE', '2013-03-05 17:13:40');

-- ----------------------------
-- Table structure for `stockadjustmentdetails`
-- ----------------------------
DROP TABLE IF EXISTS `stockadjustmentdetails`;
CREATE TABLE `stockadjustmentdetails` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `ReferenceNo` varchar(30) default '',
  `PartCode` varchar(30) default '',
  `LocationCode` varchar(30) default '',
  `StockDate` date default '1900-01-01',
  `Multiplier` int(11) default '1',
  `Quantity` int(11) default '0',
  `UnitCostUSD` decimal(20,2) default '0.00',
  `Remarks` varchar(255) default '',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`),
  KEY `adjdpartcode` (`PartCode`),
  KEY `adjdreferenceno` (`ReferenceNo`),
  KEY `adjdlocationcode` (`LocationCode`),
  CONSTRAINT `adjdlocationcode` FOREIGN KEY (`LocationCode`) REFERENCES `locations` (`LocationCode`) ON UPDATE CASCADE,
  CONSTRAINT `adjdpartcode` FOREIGN KEY (`PartCode`) REFERENCES `parts` (`PartCode`) ON UPDATE CASCADE,
  CONSTRAINT `adjdreferenceno` FOREIGN KEY (`ReferenceNo`) REFERENCES `stockadjustments` (`ReferenceNo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of stockadjustmentdetails
-- ----------------------------
INSERT INTO `stockadjustmentdetails` VALUES ('1', 'ADJ-CSPT-FZE-00001', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00001', '2013-03-13', '1', '30', '10.00', '', '2013-03-18 14:26:33');
INSERT INTO `stockadjustmentdetails` VALUES ('2', 'ADJ-CSPT-FZE-00001', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00002', '2013-03-13', '-1', '30', '10.00', '', '2013-03-18 14:26:33');
INSERT INTO `stockadjustmentdetails` VALUES ('3', 'ADJ-CSPT-FZE-00002', 'PART-CSPT-FZE-00002', 'CSPT-FZE-00003', '2013-03-18', '1', '400', '143.00', '', '2013-03-18 15:01:36');
INSERT INTO `stockadjustmentdetails` VALUES ('4', 'ADJ-CSPT-FZE-00002', 'PART-CSPT-FZE-00003', 'CSPT-FZE-00005', '2013-03-18', '1', '10', '4.08', '', '2013-03-18 15:01:36');
INSERT INTO `stockadjustmentdetails` VALUES ('7', 'ADJ-CSPT-FZE-00003', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00001', '2013-03-13', '-1', '20', '10.00', 'stock transfer', '2013-03-18 15:38:17');
INSERT INTO `stockadjustmentdetails` VALUES ('8', 'ADJ-CSPT-FZE-00003', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00005', '2013-03-13', '1', '20', '10.00', 'stock transfer', '2013-03-18 15:38:17');
INSERT INTO `stockadjustmentdetails` VALUES ('11', 'ADJ-CSPT-FZE-00004', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00003', '2013-03-17', '1', '30', '10.12', 'flooding some samples.', '2013-03-18 16:21:34');
INSERT INTO `stockadjustmentdetails` VALUES ('12', 'ADJ-CSPT-FZE-00004', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00001', '2013-03-17', '1', '20', '10.12', 'flooding some samples.', '2013-03-18 16:21:34');
INSERT INTO `stockadjustmentdetails` VALUES ('13', 'ADJ-CSPT-FZE-00005', 'PART-CSPT-FZE-00001', 'CSPT-FZE-00001', '2013-03-18', '1', '30', '10.00', 'sample for voiding', '2013-03-18 16:29:32');
INSERT INTO `stockadjustmentdetails` VALUES ('14', 'ADJ-CSPT-FZE-00006', 'PART-CSPT-FZE-00003', 'CSPT-FZE-00003', '2013-03-17', '1', '13', '4.56', 'sample', '2013-03-18 16:45:25');
INSERT INTO `stockadjustmentdetails` VALUES ('16', 'ADJ-CSPT-FZE-00008', 'PART-CSPT-FZE-00002', 'CSPT-FZE-00003', '2013-03-18', '-1', '18', '143.00', 'sample for parts update', '2013-03-19 08:30:45');
INSERT INTO `stockadjustmentdetails` VALUES ('17', 'ADJ-CSPT-FZE-00009', 'PART-CSPT-FZE-00002', 'CSPT-FZE-00003', '2013-03-18', '-1', '2', '143.00', 'sample again', '2013-03-19 08:39:23');
INSERT INTO `stockadjustmentdetails` VALUES ('19', 'ADJ-CSPT-FZE-00011', 'PART-CSPT-FZE-00002', 'CSPT-FZE-00003', '2013-03-18', '-1', '10', '143.00', 'sample again & sample again', '2013-03-19 08:47:06');
INSERT INTO `stockadjustmentdetails` VALUES ('20', 'ADJ-CSPT-FZE-00012', 'PART-CSPT-FZE-00003', 'CSPT-FZE-00005', '2013-03-18', '1', '35', '4.08', 'sample', '2013-03-19 09:09:31');
INSERT INTO `stockadjustmentdetails` VALUES ('21', 'ADJ-CSPT-FZE-00012', 'PART-CSPT-FZE-00003', 'CSPT-FZE-00001', '2013-03-17', '1', '10', '4.10', 'sample', '2013-03-19 09:09:31');

-- ----------------------------
-- Table structure for `stockadjustments`
-- ----------------------------
DROP TABLE IF EXISTS `stockadjustments`;
CREATE TABLE `stockadjustments` (
  `ReferenceNo` varchar(30) NOT NULL default '',
  `Dated` date default '1900-01-01',
  `Summary` varchar(255) default '',
  `Username` varchar(30) default '',
  `Closed` tinyint(4) default '0',
  `Approved` tinyint(4) default '0',
  `Cancelled` tinyint(4) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `DateApproved` date default '1900-01-01',
  `DateCancelled` date default '1900-01-01',
  `DateClosed` date default '1900-01-01',
  `ApprovedBy` varchar(30) default '',
  `CancelledBy` varchar(30) default '',
  `ClosedBy` varchar(30) default '',
  `ApprovalRemarks` varchar(255) default '',
  `CancellationRemarks` varchar(255) default '',
  `ClosingRemarks` varchar(255) default '',
  `Company` varchar(10) default '',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`ReferenceNo`),
  KEY `adjusername` (`Username`),
  KEY `adjapprover` USING BTREE (`ApprovedBy`),
  KEY `adjcanceller` USING BTREE (`CancelledBy`),
  KEY `adjclosing` USING BTREE (`ClosedBy`),
  KEY `adjcompany` (`Company`),
  CONSTRAINT `adjcompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE,
  CONSTRAINT `adjusername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of stockadjustments
-- ----------------------------
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00001', '2013-03-18', '1st sample stock adjustment', 'jsph', '1', '1', '0', '2013-03-18 14:26:14', '2013-03-18', '1900-01-01', '2013-03-18', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-18 14:55:00');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00002', '2013-03-18', '2nd stock adjustments', 'jsph', '1', '1', '0', '2013-03-18 15:01:16', '2013-03-18', '1900-01-01', '2013-03-18', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-18 15:02:06');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00003', '2013-03-18', '3rd sample', 'jsph', '1', '1', '0', '2013-03-18 15:38:03', '2013-03-18', '1900-01-01', '2013-03-18', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-18 15:40:33');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00004', '2013-03-18', '4th sample', 'jsph', '1', '1', '0', '2013-03-18 16:21:27', '2013-03-18', '1900-01-01', '2013-03-18', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-18 16:22:13');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00005', '2013-03-18', '5th sample', 'jsph', '1', '0', '1', '2013-03-18 16:29:31', '1900-01-01', '2013-03-18', '2013-03-18', '', 'jsph', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-18 16:29:46');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00006', '2013-03-18', '6th sample', 'jsph', '1', '0', '1', '2013-03-18 16:45:25', '1900-01-01', '2013-03-18', '2013-03-18', '', 'jsph', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-18 16:45:47');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00008', '2013-03-19', '8th sample', 'jsph', '1', '1', '0', '2013-03-19 08:30:45', '2013-03-19', '1900-01-01', '2013-03-19', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-19 08:30:54');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00009', '2013-03-19', '9th sample', 'jsph', '1', '1', '0', '2013-03-19 08:39:23', '2013-03-19', '1900-01-01', '2013-03-19', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-19 08:39:36');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00011', '2013-03-19', '11th sample', 'jsph', '1', '1', '0', '2013-03-19 08:46:53', '2013-03-19', '1900-01-01', '2013-03-19', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-19 08:47:41');
INSERT INTO `stockadjustments` VALUES ('ADJ-CSPT-FZE-00012', '2013-03-19', 'sample again', 'jsph', '1', '1', '0', '2013-03-19 09:09:31', '2013-03-19', '1900-01-01', '2013-03-19', 'jsph', '', 'jsph', '', '', '', 'CSPT-FZE', '2013-03-19 09:09:49');

-- ----------------------------
-- Table structure for `stockledger`
-- ----------------------------
DROP TABLE IF EXISTS `stockledger`;
CREATE TABLE `stockledger` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `PartCode` varchar(30) default '',
  `PurchaseDate` date default '1900-01-01',
  `Dated` date default '1900-01-01',
  `ReferenceNo` varchar(30) default '',
  `TransactionType` int(11) default '0',
  `LocationCode` varchar(30) default '',
  `SupplierCode` varchar(30) default '',
  `CustomerCode` varchar(30) default '',
  `In` int(11) default '0',
  `Out` int(11) default '0',
  `Incoming` int(11) default '0',
  `Outgoing` int(11) default '0',
  `UnitCost` decimal(20,2) default '0.00',
  `UnitCostUSD` decimal(20,2) default '0.00',
  `Currency` varchar(10) default 'USD',
  `Rate` double(20,4) default '100.0000',
  `SalesPrice` decimal(20,2) default '0.00',
  `SalesPriceUSD` decimal(20,2) default '0.00',
  `TotalCost` decimal(20,2) default '0.00',
  `TotalCostUSD` decimal(20,2) default '0.00',
  `TotalSalesPrice` decimal(20,2) default '0.00',
  `TotalSalesPriceUSD` decimal(20,2) default '0.00',
  `Username` varchar(30) default '',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`),
  KEY `slpartcode` (`PartCode`),
  KEY `slcurrency` (`Currency`),
  KEY `sllocationcode` (`LocationCode`),
  KEY `slsuppliercode` USING BTREE (`SupplierCode`),
  KEY `slcustomercode` USING BTREE (`CustomerCode`),
  KEY `slreferenceno` USING BTREE (`ReferenceNo`),
  KEY `slusername` (`Username`),
  CONSTRAINT `slcurrency` FOREIGN KEY (`Currency`) REFERENCES `currencies` (`Currency`) ON UPDATE CASCADE,
  CONSTRAINT `slpartcode` FOREIGN KEY (`PartCode`) REFERENCES `parts` (`PartCode`) ON UPDATE CASCADE,
  CONSTRAINT `slusername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of stockledger
-- ----------------------------
INSERT INTO `stockledger` VALUES ('1', 'PART-CSPT-FZE-00001', '2013-03-13', '2013-03-13', 'Beginning', '0', 'CSPT-FZE-00001', '', '', '50', '0', '0', '0', '10.00', '10.00', 'USD', '100.0000', '0.00', '0.00', '500.00', '500.00', '0.00', '0.00', 'jsph', '2013-03-16 11:06:48');
INSERT INTO `stockledger` VALUES ('2', 'PART-CSPT-FZE-00001', '2013-03-13', '2013-03-13', 'Beginning', '0', 'CSPT-FZE-00002', '', '', '30', '0', '0', '0', '10.00', '10.00', 'USD', '100.0000', '0.00', '0.00', '300.00', '300.00', '0.00', '0.00', 'jsph', '2013-03-16 11:06:50');
INSERT INTO `stockledger` VALUES ('3', 'PART-CSPT-FZE-00001', '2013-03-13', '2013-03-18', 'ADJ-CSPT-FZE-00001', '3', 'CSPT-FZE-00001', '', '', '30', '0', '0', '0', '10.00', '10.00', 'USD', '100.0000', '0.00', '0.00', '300.00', '300.00', '0.00', '0.00', 'jsph', '2013-03-18 14:55:00');
INSERT INTO `stockledger` VALUES ('4', 'PART-CSPT-FZE-00001', '2013-03-13', '2013-03-18', 'ADJ-CSPT-FZE-00001', '4', 'CSPT-FZE-00002', '', '', '0', '30', '0', '0', '10.00', '10.00', 'USD', '100.0000', '0.00', '0.00', '-300.00', '-300.00', '0.00', '0.00', 'jsph', '2013-03-18 14:55:00');
INSERT INTO `stockledger` VALUES ('5', 'PART-CSPT-FZE-00002', '2013-03-18', '2013-03-18', 'ADJ-CSPT-FZE-00002', '3', 'CSPT-FZE-00003', '', '', '400', '0', '0', '0', '143.00', '143.00', 'USD', '100.0000', '0.00', '0.00', '57200.00', '57200.00', '0.00', '0.00', 'jsph', '2013-03-18 15:02:06');
INSERT INTO `stockledger` VALUES ('6', 'PART-CSPT-FZE-00003', '2013-03-18', '2013-03-18', 'ADJ-CSPT-FZE-00002', '3', 'CSPT-FZE-00005', '', '', '10', '0', '0', '0', '4.08', '4.08', 'USD', '100.0000', '0.00', '0.00', '40.80', '40.80', '0.00', '0.00', 'jsph', '2013-03-18 15:02:06');
INSERT INTO `stockledger` VALUES ('7', 'PART-CSPT-FZE-00001', '2013-03-13', '2013-03-18', 'ADJ-CSPT-FZE-00003', '4', 'CSPT-FZE-00001', '', '', '0', '20', '0', '0', '10.00', '10.00', 'USD', '100.0000', '0.00', '0.00', '-200.00', '-200.00', '0.00', '0.00', 'jsph', '2013-03-18 15:40:33');
INSERT INTO `stockledger` VALUES ('8', 'PART-CSPT-FZE-00001', '2013-03-13', '2013-03-18', 'ADJ-CSPT-FZE-00003', '3', 'CSPT-FZE-00005', '', '', '20', '0', '0', '0', '10.00', '10.00', 'USD', '100.0000', '0.00', '0.00', '200.00', '200.00', '0.00', '0.00', 'jsph', '2013-03-18 15:40:33');
INSERT INTO `stockledger` VALUES ('9', 'PART-CSPT-FZE-00001', '2013-03-17', '2013-03-18', 'ADJ-CSPT-FZE-00004', '3', 'CSPT-FZE-00003', '', '', '30', '0', '0', '0', '10.12', '10.12', 'USD', '100.0000', '0.00', '0.00', '303.60', '303.60', '0.00', '0.00', 'jsph', '2013-03-18 16:22:13');
INSERT INTO `stockledger` VALUES ('10', 'PART-CSPT-FZE-00001', '2013-03-17', '2013-03-18', 'ADJ-CSPT-FZE-00004', '3', 'CSPT-FZE-00001', '', '', '20', '0', '0', '0', '10.12', '10.12', 'USD', '100.0000', '0.00', '0.00', '202.40', '202.40', '0.00', '0.00', 'jsph', '2013-03-18 16:22:13');
INSERT INTO `stockledger` VALUES ('11', 'PART-CSPT-FZE-00002', '2013-03-18', '2013-03-19', 'ADJ-CSPT-FZE-00008', '4', 'CSPT-FZE-00003', '', '', '0', '18', '0', '0', '143.00', '143.00', 'USD', '100.0000', '0.00', '0.00', '-2574.00', '-2574.00', '0.00', '0.00', 'jsph', '2013-03-19 08:30:54');
INSERT INTO `stockledger` VALUES ('12', 'PART-CSPT-FZE-00002', '2013-03-18', '2013-03-19', 'ADJ-CSPT-FZE-00009', '4', 'CSPT-FZE-00003', '', '', '0', '2', '0', '0', '143.00', '143.00', 'USD', '100.0000', '0.00', '0.00', '-286.00', '-286.00', '0.00', '0.00', 'jsph', '2013-03-19 08:39:36');
INSERT INTO `stockledger` VALUES ('13', 'PART-CSPT-FZE-00002', '2013-03-18', '2013-03-19', 'ADJ-CSPT-FZE-00011', '4', 'CSPT-FZE-00003', '', '', '0', '10', '0', '0', '143.00', '143.00', 'USD', '100.0000', '0.00', '0.00', '-1430.00', '-1430.00', '0.00', '0.00', 'jsph', '2013-03-19 08:47:41');
INSERT INTO `stockledger` VALUES ('14', 'PART-CSPT-FZE-00003', '2013-03-18', '2013-03-19', 'ADJ-CSPT-FZE-00012', '3', 'CSPT-FZE-00005', '', '', '35', '0', '0', '0', '4.08', '4.08', 'USD', '100.0000', '0.00', '0.00', '142.80', '142.80', '0.00', '0.00', 'jsph', '2013-03-19 09:09:49');
INSERT INTO `stockledger` VALUES ('15', 'PART-CSPT-FZE-00003', '2013-03-17', '2013-03-19', 'ADJ-CSPT-FZE-00012', '3', 'CSPT-FZE-00001', '', '', '10', '0', '0', '0', '4.10', '4.10', 'USD', '100.0000', '0.00', '0.00', '41.00', '41.00', '0.00', '0.00', 'jsph', '2013-03-19 09:09:49');

-- ----------------------------
-- Table structure for `suppliers`
-- ----------------------------
DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE `suppliers` (
  `SupplierCode` varchar(30) NOT NULL default '',
  `SupplierNo` varchar(10) default '',
  `SupplierName` varchar(175) default '',
  `Currency` varchar(10) default 'USD',
  `Active` tinyint(4) default '1',
  `Address` longtext,
  `Country` varchar(175) default '',
  `Phone` varchar(175) default '',
  `Email` varchar(175) default '',
  `Mobile` varchar(175) default '',
  `Fax` varchar(175) default '',
  `POC` varchar(175) default '',
  `SupplierType` int(11) default '0',
  `VolumetricDivisor` decimal(20,2) default '0.00',
  `PaymentTerm` varchar(175) default '',
  `AccountCode` bigint(20) default '0',
  `PrepaymentAccountCode` bigint(20) default '0',
  `UDF1` varchar(175) default '',
  `UDFValue1` varchar(255) default '',
  `UDF2` varchar(175) default '',
  `UDFValue2` varchar(255) default '',
  `UDF3` varchar(175) default '',
  `UDFValue3` varchar(255) default '',
  `UDF4` varchar(175) default '',
  `UDFValue4` varchar(255) default '',
  `UDF5` varchar(175) default '',
  `UDFValue5` varchar(255) default '',
  `UDF6` varchar(175) default '',
  `UDFValue6` varchar(255) default '',
  `Notes` longtext,
  `Company` varchar(10) default '',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`SupplierCode`),
  KEY `supcurrency` (`Currency`),
  KEY `suppaymentterm` (`PaymentTerm`),
  KEY `supcompany` (`Company`),
  KEY `supaccountcode` (`AccountCode`),
  KEY `supprepayaccountcode` (`PrepaymentAccountCode`),
  CONSTRAINT `supaccountcode` FOREIGN KEY (`AccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE,
  CONSTRAINT `supcompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON UPDATE CASCADE,
  CONSTRAINT `supcurrency` FOREIGN KEY (`Currency`) REFERENCES `currencies` (`Currency`) ON UPDATE CASCADE,
  CONSTRAINT `suppaymentterm` FOREIGN KEY (`PaymentTerm`) REFERENCES `paymentterms` (`PaymentTerm`) ON UPDATE CASCADE,
  CONSTRAINT `supprepayaccountcode` FOREIGN KEY (`PrepaymentAccountCode`) REFERENCES `accounts` (`AccountCode`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of suppliers
-- ----------------------------

-- ----------------------------
-- Table structure for `updateditems`
-- ----------------------------
DROP TABLE IF EXISTS `updateditems`;
CREATE TABLE `updateditems` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `TableName` varchar(255) default '',
  `OldValue` varchar(255) default '',
  `NewValue` varchar(255) default '',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`DetailId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of updateditems
-- ----------------------------
INSERT INTO `updateditems` VALUES ('1', 'partnames', 'Tires', 'Tyres', '2013-03-16 15:49:26');
INSERT INTO `updateditems` VALUES ('2', 'partnames', 'Tyres', 'Tires', '2013-03-16 15:49:29');
INSERT INTO `updateditems` VALUES ('3', 'partnames', 'Combination Wrench 10mm', 'Combination Wrench', '2013-03-16 15:49:33');
INSERT INTO `updateditems` VALUES ('4', 'partnames', 'Combination Wrench', 'Wrench', '2013-03-16 15:49:36');
INSERT INTO `updateditems` VALUES ('5', 'partnames', 'Wrench', 'Combination Wrench', '2013-03-16 15:49:39');
INSERT INTO `updateditems` VALUES ('6', 'partnames', 'Combination Wrench', 'Wrench', '2013-03-16 15:49:41');
INSERT INTO `updateditems` VALUES ('7', 'partnames', 'Wrench', 'Combination Wrench', '2013-03-16 15:49:45');
INSERT INTO `updateditems` VALUES ('8', 'partnames', 'Combination Wrench', 'Wrench', '2013-03-16 15:49:47');
INSERT INTO `updateditems` VALUES ('9', 'partnames', 'Wrench', 'Combination Wrench', '2013-03-16 15:49:50');
INSERT INTO `updateditems` VALUES ('10', 'partnames', 'Combination Wrench', 'Wrench', '2013-03-16 15:49:55');
INSERT INTO `updateditems` VALUES ('11', 'partnames', 'Wrench', 'Combination Wrench', '2013-03-16 15:49:58');
INSERT INTO `updateditems` VALUES ('12', 'partnames', 'Combination Wrench', 'Wrench', '2013-03-16 15:50:00');
INSERT INTO `updateditems` VALUES ('13', 'partnames', 'Wrench', 'Combination Wrench', '2013-03-16 15:50:04');
INSERT INTO `updateditems` VALUES ('14', 'partnames', 'Combination Wrench', 'Wrench', '2013-03-16 15:57:48');
INSERT INTO `updateditems` VALUES ('15', 'partnames', 'Wrench', 'Combination Wrench', '2013-03-16 15:58:08');

-- ----------------------------
-- Table structure for `usercompanies`
-- ----------------------------
DROP TABLE IF EXISTS `usercompanies`;
CREATE TABLE `usercompanies` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `Username` varchar(30) default NULL,
  `Company` varchar(10) default '',
  PRIMARY KEY  (`DetailId`),
  KEY `ucusername` (`Username`),
  KEY `uccompany` (`Company`),
  CONSTRAINT `uccompany` FOREIGN KEY (`Company`) REFERENCES `companies` (`Company`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ucusername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of usercompanies
-- ----------------------------

-- ----------------------------
-- Table structure for `usercustomers`
-- ----------------------------
DROP TABLE IF EXISTS `usercustomers`;
CREATE TABLE `usercustomers` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `Username` varchar(30) default '',
  `CustomerCode` varchar(30) default '',
  PRIMARY KEY  (`DetailId`),
  KEY `ucususername` (`Username`),
  KEY `ucuscustomercode` (`CustomerCode`),
  CONSTRAINT `ucuscustomercode` FOREIGN KEY (`CustomerCode`) REFERENCES `customers` (`CustomerCode`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ucususername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of usercustomers
-- ----------------------------

-- ----------------------------
-- Table structure for `userlogs`
-- ----------------------------
DROP TABLE IF EXISTS `userlogs`;
CREATE TABLE `userlogs` (
  `DetailId` bigint(20) NOT NULL auto_increment,
  `Username` varchar(30) default '',
  `DateAndTime` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `Action` int(11) default '0',
  `ReferenceNo` varchar(30) default '',
  `Description` longtext,
  `Amount` decimal(20,2) default '0.00',
  `Currency` varchar(10) default 'USD',
  `AmountUSD` decimal(20,2) default '0.00',
  `ComputerName` varchar(150) default '',
  `IPAddress` varchar(30) default '',
  PRIMARY KEY  (`DetailId`),
  KEY `logcurrency` (`Currency`),
  KEY `logusername` (`Username`),
  CONSTRAINT `logcurrency` FOREIGN KEY (`Currency`) REFERENCES `currencies` (`Currency`) ON UPDATE CASCADE,
  CONSTRAINT `logusername` FOREIGN KEY (`Username`) REFERENCES `users` (`Username`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1693 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of userlogs
-- ----------------------------
INSERT INTO `userlogs` VALUES ('1', 'jsph', '2013-02-11 11:30:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('2', 'jsph', '2013-02-11 15:34:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('3', 'jsph', '2013-02-11 15:44:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('4', 'jsph', '2013-02-11 15:46:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('5', 'jsph', '2013-02-11 15:50:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('6', 'jsph', '2013-02-11 15:51:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('7', 'jsph', '2013-02-11 15:52:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('8', 'jsph', '2013-02-11 15:54:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('9', 'jsph', '2013-02-11 16:06:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('10', 'jsph', '2013-02-12 07:28:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('11', 'jsph', '2013-02-12 07:29:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('12', 'jsph', '2013-02-12 07:55:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('13', 'jsph', '2013-02-12 07:56:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('14', 'jsph', '2013-02-12 07:58:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('15', 'jsph', '2013-02-12 09:24:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('16', 'jsph', '2013-02-12 09:45:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('17', 'jsph', '2013-02-12 09:55:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('18', 'jsph', '2013-02-12 10:01:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('19', 'jsph', '2013-02-12 10:15:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('20', 'jsph', '2013-02-12 11:29:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('21', 'jsph', '2013-02-12 11:32:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('22', 'jsph', '2013-02-12 11:35:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('23', 'jsph', '2013-02-12 11:41:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('24', 'jsph', '2013-02-12 11:43:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('25', 'jsph', '2013-02-12 11:45:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('26', 'jsph', '2013-02-12 12:00:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('27', 'jsph', '2013-02-12 12:04:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('28', 'jsph', '2013-02-12 12:21:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('29', 'jsph', '2013-02-12 12:23:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('30', 'jsph', '2013-02-12 12:28:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('31', 'jsph', '2013-02-12 12:28:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('32', 'jsph', '2013-02-12 14:18:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('33', 'jsph', '2013-02-12 14:21:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('34', 'jsph', '2013-02-12 14:24:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('35', 'jsph', '2013-02-12 14:26:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('36', 'jsph', '2013-02-12 14:28:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('37', 'jsph', '2013-02-12 14:33:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('38', 'jsph', '2013-02-12 14:37:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('39', 'jsph', '2013-02-12 14:51:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('40', 'jsph', '2013-02-12 14:52:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('41', 'jsph', '2013-02-12 15:31:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('42', 'jsph', '2013-02-12 15:33:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('43', 'jsph', '2013-02-12 15:35:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('44', 'jsph', '2013-02-12 15:37:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('45', 'jsph', '2013-02-12 15:39:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('46', 'jsph', '2013-02-12 15:43:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('47', 'jsph', '2013-02-12 15:43:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('48', 'jsph', '2013-02-13 07:47:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('49', 'jsph', '2013-02-13 07:48:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('50', 'jsph', '2013-02-13 07:52:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('51', 'jsph', '2013-02-13 07:57:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('52', 'jsph', '2013-02-13 09:07:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('53', 'jsph', '2013-02-13 09:11:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('54', 'jsph', '2013-02-13 09:13:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('55', 'jsph', '2013-02-13 09:13:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('56', 'jsph', '2013-02-13 09:14:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('57', 'jsph', '2013-02-13 09:22:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('58', 'jsph', '2013-02-13 09:31:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('59', 'jsph', '2013-02-13 09:31:42', '12', '', 'Performed database backup into : C:\\\\Users\\\\user\\\\Desktop\\\\SCMSIV_BACKUP_13_02_2013_09_31_31.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('60', 'jsph', '2013-02-13 09:32:57', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_09_32_53.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('61', 'jsph', '2013-02-13 09:34:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('62', 'jsph', '2013-02-13 09:36:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('63', 'jsph', '2013-02-13 09:37:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('64', 'jsph', '2013-02-13 09:38:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('65', 'jsph', '2013-02-13 09:38:30', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_09_38_26.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('66', 'jsph', '2013-02-13 09:39:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('67', 'jsph', '2013-02-13 09:41:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('68', 'jsph', '2013-02-13 09:42:13', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_09_41_38.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('69', 'jsph', '2013-02-13 09:42:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('70', 'jsph', '2013-02-13 09:47:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('71', 'jsph', '2013-02-13 09:47:22', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_09_47_18.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('72', 'jsph', '2013-02-13 09:50:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('73', 'jsph', '2013-02-13 10:02:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('74', 'jsph', '2013-02-13 10:02:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('75', 'jsph', '2013-02-13 10:12:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('76', 'jsph', '2013-02-13 10:12:44', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('77', 'jsph', '2013-02-13 11:05:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('78', 'jsph', '2013-02-13 11:05:54', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_05_30.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('79', 'jsph', '2013-02-13 11:06:18', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_06_15.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('80', 'jsph', '2013-02-13 11:06:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('81', 'jsph', '2013-02-13 11:09:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('82', 'jsph', '2013-02-13 11:10:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('83', 'jsph', '2013-02-13 11:19:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('84', 'jsph', '2013-02-13 11:20:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('85', 'jsph', '2013-02-13 11:24:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('86', 'jsph', '2013-02-13 11:24:33', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_24_29.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('87', 'jsph', '2013-02-13 11:25:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('88', 'jsph', '2013-02-13 11:32:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('89', 'jsph', '2013-02-13 11:32:35', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_32_32.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('90', 'jsph', '2013-02-13 11:34:31', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('91', 'jsph', '2013-02-13 11:52:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('92', 'jsph', '2013-02-13 11:52:59', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_52_55.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('93', 'jsph', '2013-02-13 11:53:47', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_52_55.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('94', 'jsph', '2013-02-13 11:53:58', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_53_55.s4b.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('95', 'jsph', '2013-02-13 11:54:39', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_54_35.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('96', 'jsph', '2013-02-13 11:56:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('97', 'jsph', '2013-02-13 11:58:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('98', 'jsph', '2013-02-13 11:59:01', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_11_58_56.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('99', 'jsph', '2013-02-13 12:01:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('100', 'jsph', '2013-02-13 12:02:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('101', 'jsph', '2013-02-13 12:02:27', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_12_02_14.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('102', 'jsph', '2013-02-13 12:07:35', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_12_07_32.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('103', 'jsph', '2013-02-13 12:08:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('104', 'jsph', '2013-02-13 14:59:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('105', 'jsph', '2013-02-13 15:58:55', '13', '', 'Restored database from file : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_14_59_49.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('106', 'jsph', '2013-02-13 15:58:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('107', 'jsph', '2013-02-13 16:00:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('108', 'jsph', '2013-02-13 16:00:29', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_13_02_2013_16_00_26.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('109', 'jsph', '2013-02-14 12:29:33', '13', '', 'Restored database from file : Restore Point : localhost\\scmsiv as of 13-Feb-2013 04:01:00 PM.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('110', 'jsph', '2013-02-14 12:29:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('111', 'jsph', '2013-02-14 12:29:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('112', 'jsph', '2013-02-14 12:36:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('113', 'jsph', '2013-02-14 13:18:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('114', 'jsph', '2013-02-14 13:21:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('115', 'jsph', '2013-02-14 15:54:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('116', 'jsph', '2013-02-14 15:55:46', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_14_02_2013_15_55_37.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('117', 'jsph', '2013-02-15 07:43:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('118', 'jsph', '2013-02-16 12:32:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('119', 'jsph', '2013-02-16 12:32:46', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_16_02_2013_12_32_39.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('120', 'jsph', '2013-02-16 12:33:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('121', 'jsph', '2013-02-17 11:41:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('122', 'jsph', '2013-02-17 11:42:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('123', 'jsph', '2013-02-17 11:43:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('124', 'jsph', '2013-02-17 11:44:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('125', 'jsph', '2013-02-17 11:44:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('126', 'jsph', '2013-02-17 11:45:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('127', 'jsph', '2013-02-17 11:46:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('128', 'jsph', '2013-02-17 11:47:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('129', 'jsph', '2013-02-17 13:13:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('130', 'jsph', '2013-02-17 13:15:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('131', 'jsph', '2013-02-17 13:39:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('132', 'jsph', '2013-02-17 13:42:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('133', 'jsph', '2013-02-17 15:18:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('134', 'jsph', '2013-02-17 15:21:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('135', 'jsph', '2013-02-17 15:27:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('136', 'jsph', '2013-02-17 15:30:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('137', 'jsph', '2013-02-17 16:31:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('138', 'jsph', '2013-02-17 17:03:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('139', 'jsph', '2013-02-17 17:04:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('140', 'jsph', '2013-02-17 17:06:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('141', 'jsph', '2013-02-17 17:09:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('142', 'jsph', '2013-02-17 17:10:44', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('143', 'jsph', '2013-02-17 17:15:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('144', 'jsph', '2013-02-17 17:53:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('145', 'jsph', '2013-02-25 11:40:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('146', 'jsph', '2013-02-25 11:42:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('147', 'jsph', '2013-02-25 11:53:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('148', 'jsph', '2013-02-25 12:35:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('149', 'jsph', '2013-02-25 12:36:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('150', 'jsph', '2013-02-25 12:43:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('151', 'jsph', '2013-02-25 12:43:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('152', 'jsph', '2013-02-25 12:45:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('153', 'jsph', '2013-02-25 12:46:37', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('154', 'jsph', '2013-02-25 12:47:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('155', 'jsph', '2013-02-25 12:48:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('156', 'jsph', '2013-02-25 12:50:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('157', 'jsph', '2013-02-25 12:52:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('158', 'jsph', '2013-02-25 13:02:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('159', 'jsph', '2013-02-25 13:03:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('160', 'jsph', '2013-02-25 13:08:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('161', 'jsph', '2013-02-25 13:09:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('162', 'jsph', '2013-02-25 13:21:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('163', 'jsph', '2013-02-25 13:21:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('164', 'jsph', '2013-02-25 14:24:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('165', 'jsph', '2013-02-25 14:25:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('166', 'jsph', '2013-02-25 14:26:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('167', 'jsph', '2013-02-25 14:32:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('168', 'jsph', '2013-02-25 16:24:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('169', 'jsph', '2013-02-25 16:30:16', '1', '', 'Updated the application settings.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('170', 'jsph', '2013-02-25 16:32:20', '1', '', 'Updated the application settings.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('171', 'jsph', '2013-02-25 16:33:09', '1', '', 'Updated the application settings.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('172', 'jsph', '2013-02-25 16:33:28', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('173', 'jsph', '2013-02-25 16:34:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('174', 'jsph', '2013-02-25 16:35:54', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('175', 'jsph', '2013-02-25 17:31:50', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('176', 'jsph', '2013-02-25 17:33:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('177', 'jsph', '2013-02-25 17:34:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('178', 'jsph', '2013-02-25 17:34:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('179', 'jsph', '2013-02-25 17:35:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('180', 'jsph', '2013-02-25 17:36:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('181', 'jsph', '2013-02-25 17:36:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('182', 'jsph', '2013-02-25 17:37:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('183', 'jsph', '2013-02-25 17:37:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('184', 'jsph', '2013-02-25 18:56:02', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('185', 'jsph', '2013-02-26 14:51:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('186', 'jsph', '2013-02-26 14:53:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('187', 'jsph', '2013-02-26 14:59:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('188', 'jsph', '2013-02-26 15:09:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('189', 'jsph', '2013-02-26 15:10:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('190', 'jsph', '2013-02-26 15:13:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('191', 'jsph', '2013-02-26 15:21:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('192', 'jsph', '2013-02-26 15:22:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('193', 'jsph', '2013-02-26 15:23:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('194', 'jsph', '2013-02-26 15:24:28', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('195', 'jsph', '2013-02-26 15:26:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('196', 'jsph', '2013-02-26 15:27:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('197', 'jsph', '2013-02-26 15:35:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('198', 'jsph', '2013-02-26 15:39:44', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('199', 'jsph', '2013-02-26 15:42:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('200', 'jsph', '2013-02-26 15:46:13', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('201', 'jsph', '2013-02-26 17:03:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('202', 'jsph', '2013-02-26 17:04:32', '0', '', 'Added a new system user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('203', 'jsph', '2013-02-26 17:08:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('204', 'jsph', '2013-02-26 17:10:38', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('205', 'jsph', '2013-02-26 17:12:31', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('206', 'jsph', '2013-02-26 17:13:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('207', 'jsph', '2013-02-26 17:15:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('208', 'jsph', '2013-02-26 17:16:33', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('209', 'jsph', '2013-02-26 17:17:14', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('210', 'jsph', '2013-02-26 17:17:21', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('211', 'jsph', '2013-02-26 17:17:27', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('212', 'jsph', '2013-02-26 17:18:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('213', 'jsph', '2013-02-26 17:23:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('214', 'jsph', '2013-02-26 17:24:30', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('215', 'jsph', '2013-02-26 17:26:18', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('216', 'jsph', '2013-02-26 17:28:18', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('217', 'jsph', '2013-02-26 17:28:44', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('218', 'jsph', '2013-02-26 17:29:02', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('219', 'jsph', '2013-02-26 17:29:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('220', 'jsph', '2013-02-27 07:58:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('221', 'jsph', '2013-02-27 08:01:43', '2', '', 'Removed Super User (dqadmin) from the user accounts list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('222', 'jsph', '2013-02-27 08:09:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('223', 'jsph', '2013-02-27 08:12:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('224', 'jsph', '2013-02-27 08:15:40', '1', '', 'Updated user account : jsph.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('225', 'jsph', '2013-02-27 08:19:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('226', 'jsph', '2013-02-27 08:24:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('227', 'jsph', '2013-02-27 08:28:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('228', 'jsph', '2013-02-27 08:29:31', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('229', 'jsph', '2013-02-27 08:44:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('230', 'jsph', '2013-02-27 08:47:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('231', 'jsph', '2013-02-27 10:50:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('232', 'jsph', '2013-02-27 10:54:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('233', 'jsph', '2013-02-27 10:54:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('234', 'jsph', '2013-02-27 10:55:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('235', 'jsph', '2013-02-27 10:56:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('236', 'jsph', '2013-02-27 10:57:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('237', 'jsph', '2013-02-27 11:17:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('238', 'jsph', '2013-02-27 11:21:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('239', 'jsph', '2013-02-27 11:22:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('240', 'jsph', '2013-02-27 11:25:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('241', 'jsph', '2013-02-27 11:26:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('242', 'jsph', '2013-02-27 11:32:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('243', 'jsph', '2013-02-27 11:39:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('244', 'jsph', '2013-02-27 11:48:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('245', 'jsph', '2013-02-27 14:53:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('246', 'jsph', '2013-02-27 14:56:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('247', 'jsph', '2013-02-27 14:57:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('248', 'jsph', '2013-02-27 15:02:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('249', 'jsph', '2013-02-27 15:35:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('250', 'jsph', '2013-02-27 15:39:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('251', 'jsph', '2013-02-27 15:41:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('252', 'jsph', '2013-02-27 15:42:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('253', 'jsph', '2013-02-27 15:45:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('254', 'jsph', '2013-02-27 15:57:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('255', 'jsph', '2013-02-27 15:58:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('256', 'jsph', '2013-02-27 16:02:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('257', 'jsph', '2013-02-27 16:04:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('258', 'jsph', '2013-02-27 16:09:13', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('259', 'jsph', '2013-02-27 16:13:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('260', 'jsph', '2013-02-27 16:22:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('261', 'jsph', '2013-02-27 16:26:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('262', 'jsph', '2013-02-27 17:12:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('263', 'jsph', '2013-02-27 17:23:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('264', 'jsph', '2013-02-27 17:26:49', '0', '', 'Added a new system user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('265', 'jsph', '2013-02-27 17:32:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('266', 'jsph', '2013-02-27 17:41:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('267', 'jsph', '2013-02-27 17:49:40', '1', '', 'Updated user account : dq admin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('268', 'jsph', '2013-02-27 17:50:43', '1', '', 'Updated user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('269', 'jsph', '2013-02-27 17:51:22', '1', '', 'Updated user account : dq admin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('270', 'jsph', '2013-02-27 17:51:49', '1', '', 'Updated user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('271', 'jsph', '2013-02-27 17:52:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('272', 'jsph', '2013-02-28 07:34:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('273', 'jsph', '2013-02-28 07:35:19', '2', '', 'Removed Super User (dq admin) from the user accounts list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('274', 'jsph', '2013-02-28 07:38:15', '0', '', 'Added a new system user account : dq admin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('275', 'jsph', '2013-02-28 07:38:42', '1', '', 'Updated user account : dq admin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('276', 'jsph', '2013-02-28 07:49:04', '1', '', 'Updated user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('277', 'jsph', '2013-02-28 07:51:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('278', 'jsph', '2013-02-28 07:53:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('279', 'jsph', '2013-02-28 07:54:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('280', 'jsph', '2013-02-28 07:55:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('281', 'jsph', '2013-02-28 07:58:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('282', 'jsph', '2013-02-28 08:00:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('283', 'jsph', '2013-02-28 08:03:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('284', 'jsph', '2013-02-28 08:04:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('285', 'jsph', '2013-02-28 08:08:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('286', 'jsph', '2013-02-28 08:12:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('287', 'jsph', '2013-02-28 08:23:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('288', 'jsph', '2013-02-28 08:24:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('289', 'jsph', '2013-02-28 08:24:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('290', 'jsph', '2013-02-28 08:25:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('291', 'jsph', '2013-02-28 08:27:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('292', 'jsph', '2013-02-28 08:28:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('293', 'jsph', '2013-02-28 08:31:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('294', 'jsph', '2013-02-28 08:32:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('295', 'jsph', '2013-02-28 08:34:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('296', 'jsph', '2013-02-28 08:34:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('297', 'jsph', '2013-02-28 08:37:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('298', 'jsph', '2013-02-28 08:39:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('299', 'jsph', '2013-02-28 09:00:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('300', 'jsph', '2013-02-28 09:00:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('301', 'jsph', '2013-02-28 10:10:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('302', 'jsph', '2013-02-28 10:11:34', '1', '', 'Updated user account : dq admin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('303', 'jsph', '2013-02-28 10:13:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('304', 'jsph', '2013-02-28 10:23:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('305', 'jsph', '2013-02-28 10:25:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('306', 'jsph', '2013-02-28 10:31:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('307', 'jsph', '2013-02-28 10:35:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('308', 'jsph', '2013-02-28 11:33:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('309', 'jsph', '2013-02-28 11:35:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('310', 'jsph', '2013-02-28 12:52:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('311', 'jsph', '2013-02-28 12:54:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('312', 'jsph', '2013-02-28 13:05:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('313', 'jsph', '2013-02-28 13:06:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('314', 'jsph', '2013-02-28 13:13:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('315', 'jsph', '2013-02-28 13:14:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('316', 'jsph', '2013-02-28 13:23:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('317', 'jsph', '2013-02-28 13:27:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('318', 'jsph', '2013-02-28 13:39:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('319', 'jsph', '2013-02-28 13:41:37', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('320', 'jsph', '2013-02-28 13:47:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('321', 'jsph', '2013-02-28 13:53:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('322', 'jsph', '2013-02-28 15:20:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('323', 'jsph', '2013-02-28 15:21:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('324', 'jsph', '2013-02-28 15:42:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('325', 'jsph', '2013-02-28 15:45:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('326', 'jsph', '2013-02-28 15:55:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('327', 'jsph', '2013-02-28 15:56:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('328', 'jsph', '2013-02-28 15:57:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('329', 'jsph', '2013-02-28 15:58:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('330', 'jsph', '2013-02-28 16:07:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('331', 'jsph', '2013-02-28 16:25:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('332', 'jsph', '2013-02-28 16:35:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('333', 'jsph', '2013-02-28 16:38:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('334', 'jsph', '2013-02-28 20:33:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('335', 'jsph', '2013-02-28 20:37:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('336', 'jsph', '2013-02-28 20:44:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('337', 'jsph', '2013-03-01 09:05:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('338', 'jsph', '2013-03-02 09:13:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('339', 'jsph', '2013-03-02 09:17:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('340', 'jsph', '2013-03-02 09:25:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('341', 'jsph', '2013-03-02 09:26:13', '0', '', 'Added a new department : Product & Procurement.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('342', 'jsph', '2013-03-02 09:26:30', '0', '', 'Added a new department : Finance.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('343', 'jsph', '2013-03-02 09:27:12', '0', '', 'Added a new department : Sales.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('344', 'jsph', '2013-03-02 09:27:34', '1', '', 'Updated department : Finance to Finance Dept..', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('345', 'jsph', '2013-03-02 09:27:50', '1', '', 'Updated department : Finance Dept. to Finance.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('346', 'jsph', '2013-03-02 09:31:33', '0', '', 'Added a new department : Systems Support.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('347', 'jsph', '2013-03-02 09:58:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('348', 'jsph', '2013-03-02 10:52:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('349', 'jsph', '2013-03-02 11:02:22', '2', '', 'Delete Systems Support from departments list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('350', 'jsph', '2013-03-02 11:03:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('351', 'jsph', '2013-03-02 11:06:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('352', 'jsph', '2013-03-02 11:06:48', '0', '', 'Added a new department : Systems Support.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('353', 'jsph', '2013-03-02 11:07:02', '2', '', 'Delete Systems Support from departments list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('354', 'jsph', '2013-03-02 11:07:15', '0', '', 'Added a new department : Systems Support.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('355', 'jsph', '2013-03-02 11:07:47', '1', '', 'Updated user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('356', 'jsph', '2013-03-02 11:08:12', '0', '', 'Added a new department : Executive Management.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('357', 'jsph', '2013-03-02 11:09:14', '0', '', 'Added a new department : IT Department.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('358', 'jsph', '2013-03-02 11:10:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('359', 'jsph', '2013-03-02 11:13:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('360', 'jsph', '2013-03-02 11:13:34', '2', '', 'Delete Systems Support from departments list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('361', 'jsph', '2013-03-02 11:14:59', '2', '', 'Removed Super User (dqadmin) from the user accounts list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('362', 'jsph', '2013-03-02 11:36:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('363', 'jsph', '2013-03-02 12:14:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('364', 'jsph', '2013-03-02 12:18:05', '2', '', 'Removed Super User (dqadmin) from the user accounts list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('365', 'jsph', '2013-03-02 12:18:54', '0', '', 'Added a new system user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('366', 'jsph', '2013-03-02 12:19:11', '2', '', 'Delete IT Department from departments list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('367', 'jsph', '2013-03-02 12:20:09', '0', '', 'Added a new department : Systems Support.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('368', 'jsph', '2013-03-02 12:20:35', '2', '', 'Removed Super User (dqadmin) from the user accounts list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('369', 'jsph', '2013-03-02 12:21:00', '0', '', 'Added a new system user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('370', 'jsph', '2013-03-02 12:22:26', '0', '', 'Added a new department : IT Department.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('371', 'jsph', '2013-03-02 12:25:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('372', 'jsph', '2013-03-03 11:28:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('373', 'jsph', '2013-03-03 11:29:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('374', 'jsph', '2013-03-03 11:30:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('375', 'jsph', '2013-03-03 11:31:09', '0', '', 'Added a new position : Systems Administrator.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('376', 'jsph', '2013-03-03 11:31:57', '1', '', 'Updated user account : dqadmin.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('377', 'jsph', '2013-03-03 11:37:51', '0', '', 'Added a new position : IT Manager.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('378', 'jsph', '2013-03-03 11:38:08', '0', '', 'Added a new position : Chief Executive Officer.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('379', 'jsph', '2013-03-03 11:38:22', '0', '', 'Added a new position : Accounting Manager.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('380', 'jsph', '2013-03-03 11:38:34', '2', '', 'Delete Chief Executive Officer from positions list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('381', 'jsph', '2013-03-03 11:39:28', '0', '', 'Added a new position : Chief Executive Manager.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('382', 'jsph', '2013-03-03 11:40:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('383', 'jsph', '2013-03-03 11:42:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('384', 'jsph', '2013-03-03 11:43:23', '1', '', 'Updated position : Chief Executive Manager to Chief Executive Officer.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('385', 'jsph', '2013-03-03 11:45:43', '0', '', 'Added a new position : Vice President.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('386', 'jsph', '2013-03-03 11:46:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('387', 'jsph', '2013-03-03 11:49:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('388', 'jsph', '2013-03-03 11:52:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('389', 'jsph', '2013-03-03 12:49:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('390', 'jsph', '2013-03-03 12:50:19', '0', '', 'Added a new banking company : Banco de Oro.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('391', 'jsph', '2013-03-03 12:51:21', '0', '', 'Added a new banking company : BPI - Bank of Philippine Islands.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('392', 'jsph', '2013-03-03 12:51:34', '0', '', 'Added a new banking company : BDO - Banco de Oro.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('393', 'jsph', '2013-03-03 12:54:02', '1', '', 'Updated banking company : Banco de Oro to Mashreq.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('394', 'jsph', '2013-03-03 12:56:09', '0', '', 'Added a new banking company : HSBC.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('395', 'jsph', '2013-03-03 13:05:17', '1', '', 'Updated banking company : BDO - Banco de Oro to BDO.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('396', 'jsph', '2013-03-03 13:05:30', '1', '', 'Updated banking company : BPI - Bank of Philippine Islands to BPI.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('397', 'jsph', '2013-03-03 13:05:45', '0', '', 'Added a new banking company : East West Bank.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('398', 'jsph', '2013-03-03 13:06:06', '0', '', 'Added a new banking company : RAK Bank.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('399', 'jsph', '2013-03-03 13:06:17', '0', '', 'Added a new banking company : Nordea.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('400', 'jsph', '2013-03-03 13:09:06', '2', '', 'Delete BDO from banking companies list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('401', 'jsph', '2013-03-03 13:09:33', '0', '', 'Added a new banking company : BDO.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('402', 'jsph', '2013-03-03 13:14:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('403', 'jsph', '2013-03-03 14:06:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('404', 'jsph', '2013-03-03 14:07:43', '0', '', 'Added a new customer group : COM-All Commercial Customers.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('405', 'jsph', '2013-03-03 14:08:04', '0', '', 'Added a new customer group : GO-Government Organizations.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('406', 'jsph', '2013-03-03 14:08:23', '0', '', 'Added a new customer group : GRP1-Customer Atemp Only.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('407', 'jsph', '2013-03-03 14:08:56', '0', '', 'Added a new customer group : GRP2-Customer No lemon.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('408', 'jsph', '2013-03-03 14:09:43', '1', '', 'Updated customer group : COM-All Commercial Customers to COM - All Commercial Customers.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('409', 'jsph', '2013-03-03 14:09:57', '1', '', 'Updated customer group : GO-Government Organizations to GO - Government Organizations.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('410', 'jsph', '2013-03-03 14:10:14', '1', '', 'Updated customer group : GRP1-Customer Atemp Only to GRP1 - Customer Atemp Only.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('411', 'jsph', '2013-03-03 14:10:28', '1', '', 'Updated customer group : GRP2-Customer No lemon to GRP2 - Customer No lemon.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('412', 'jsph', '2013-03-03 14:13:59', '2', '', 'Delete GO - Government Organizations from customer groups list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('413', 'jsph', '2013-03-03 14:14:30', '0', '', 'Added a new customer group : GO - Government Organizations.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('414', 'jsph', '2013-03-03 14:15:45', '1', '', 'Updated customer group : GRP1 - Customer Atemp Only to GRP1 - Customer ATEMP Only.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('415', 'jsph', '2013-03-03 14:16:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('416', 'jsph', '2013-03-03 14:28:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('417', 'jsph', '2013-03-03 14:30:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('418', 'jsph', '2013-03-03 15:18:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('419', 'jsph', '2013-03-03 15:21:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('420', 'jsph', '2013-03-03 16:49:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('421', 'jsph', '2013-03-03 16:52:53', '0', '', 'Added a new location : WIP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('422', 'jsph', '2013-03-03 16:57:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('423', 'jsph', '2013-03-03 16:58:26', '0', '', 'Added a new location : SIT.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('424', 'jsph', '2013-03-03 16:58:54', '0', '', 'Added a new location : LIT.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('425', 'jsph', '2013-03-03 16:59:50', '0', '', 'Added a new location : 1A1.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('426', 'jsph', '2013-03-03 17:01:09', '2', '', 'Delete 1A1 from locations list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('427', 'jsph', '2013-03-03 17:01:40', '0', '', 'Added a new location : 1A1.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('428', 'jsph', '2013-03-03 17:04:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('429', 'jsph', '2013-03-03 17:24:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('430', 'jsph', '2013-03-03 17:32:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('431', 'jsph', '2013-03-04 07:24:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('432', 'jsph', '2013-03-04 07:25:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('433', 'jsph', '2013-03-04 07:37:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('434', 'jsph', '2013-03-04 07:39:37', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('435', 'jsph', '2013-03-04 08:08:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('436', 'jsph', '2013-03-04 08:09:30', '0', '', 'Added a new vehicle make : 4RUNNER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('437', 'jsph', '2013-03-04 08:10:01', '0', '', 'Added a new vehicle make : LEXUS.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('438', 'jsph', '2013-03-04 08:10:17', '0', '', 'Added a new vehicle make : MITSUBISHI.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('439', 'jsph', '2013-03-04 08:10:51', '0', '', 'Added a new vehicle make : NISSAN.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('440', 'jsph', '2013-03-04 08:11:04', '0', '', 'Added a new vehicle make : SUZUKI.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('441', 'jsph', '2013-03-04 08:11:20', '0', '', 'Added a new vehicle make : TOYOTA.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('442', 'jsph', '2013-03-04 08:11:43', '0', '', 'Added a new vehicle make : VOVO.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('443', 'jsph', '2013-03-04 08:11:55', '1', '', 'Updated vehicle make : VOVO to VOLVO.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('444', 'jsph', '2013-03-04 08:12:49', '0', '', 'Added a new vehicle make : YAMAHA.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('445', 'jsph', '2013-03-04 08:13:14', '0', '', 'Added a new vehicle make : DODGE.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('446', 'jsph', '2013-03-04 08:13:39', '0', '', 'Added a new vehicle make : CHEVROLET.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('447', 'jsph', '2013-03-04 08:16:39', '0', '', 'Added a new vehicle make : ALL.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('448', 'jsph', '2013-03-04 08:27:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('449', 'jsph', '2013-03-04 08:28:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('450', 'jsph', '2013-03-04 08:37:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('451', 'jsph', '2013-03-04 10:05:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('452', 'jsph', '2013-03-04 10:06:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('453', 'jsph', '2013-03-04 10:24:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('454', 'jsph', '2013-03-04 10:25:11', '0', '', 'Added a new parts category : AGP Glass.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('455', 'jsph', '2013-03-04 10:25:29', '0', '', 'Added a new parts category : ARB.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('456', 'jsph', '2013-03-04 10:25:40', '0', '', 'Added a new parts category : Batteries.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('457', 'jsph', '2013-03-04 10:25:49', '2', '', 'Delete Batteries from parts categories list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('458', 'jsph', '2013-03-04 10:26:01', '0', '', 'Added a new parts category : Batteries.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('459', 'jsph', '2013-03-04 10:26:19', '0', '', 'Added a new parts category : Battery.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('460', 'jsph', '2013-03-04 10:26:36', '2', '', 'Delete Batteries from parts categories list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('461', 'jsph', '2013-03-04 10:26:42', '2', '', 'Delete Battery from parts categories list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('462', 'jsph', '2013-03-04 10:27:06', '0', '', 'Added a new parts category : Batteries.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('463', 'jsph', '2013-03-04 10:27:33', '1', '', 'Updated parts category : Batteries to Battery.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('464', 'jsph', '2013-03-04 10:27:48', '1', '', 'Updated parts category : Battery to Batteries.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('465', 'jsph', '2013-03-04 10:28:19', '0', '', 'Added a new parts category : Consumables.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('466', 'jsph', '2013-03-04 10:28:34', '0', '', 'Added a new parts category : Genuine Spare Parts.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('467', 'jsph', '2013-03-04 10:28:53', '0', '', 'Added a new parts category : Others.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('468', 'jsph', '2013-03-04 10:29:07', '0', '', 'Added a new parts category : Tools and Equipments.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('469', 'jsph', '2013-03-04 10:29:22', '0', '', 'Added a new parts category : Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('470', 'jsph', '2013-03-04 10:30:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('471', 'jsph', '2013-03-04 10:33:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('472', 'jsph', '2013-03-04 10:34:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('473', 'jsph', '2013-03-04 11:43:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('474', 'jsph', '2013-03-04 11:44:07', '0', '', 'Added a new additional charge : Customs Clearance.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('475', 'jsph', '2013-03-04 11:44:48', '0', '', 'Added a new additional charge : Admin Cost.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('476', 'jsph', '2013-03-04 11:45:34', '0', '', 'Added a new additional charge : Freight Cost.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('477', 'jsph', '2013-03-04 11:45:53', '0', '', 'Added a new additional charge : Insurance Cost.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('478', 'jsph', '2013-03-04 11:46:45', '0', '', 'Added a new additional charge : Customs Duty.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('479', 'jsph', '2013-03-04 11:47:38', '1', '', 'Updated additional charge : Customs Duty to Destination Customs Duty.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('480', 'jsph', '2013-03-04 11:48:15', '0', '', 'Added a new additional charge : Customs Duty.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('481', 'jsph', '2013-03-04 11:52:40', '0', '', 'Added a new additional charge : Document & Handling.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('482', 'jsph', '2013-03-04 11:53:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('483', 'jsph', '2013-03-04 11:57:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('484', 'jsph', '2013-03-04 11:58:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('485', 'jsph', '2013-03-04 12:34:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('486', 'jsph', '2013-03-04 12:41:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('487', 'jsph', '2013-03-04 12:43:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('488', 'jsph', '2013-03-04 12:43:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('489', 'jsph', '2013-03-04 12:52:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('490', 'jsph', '2013-03-04 12:53:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('491', 'jsph', '2013-03-04 15:26:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('492', 'jsph', '2013-03-04 15:27:10', '0', '', 'Added a new bank miscellaneous : Bank Interest.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('493', 'jsph', '2013-03-04 15:28:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('494', 'jsph', '2013-03-04 15:29:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('495', 'jsph', '2013-03-04 15:31:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('496', 'jsph', '2013-03-04 15:32:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('497', 'jsph', '2013-03-04 15:33:26', '1', '', 'Updated bank miscellaneous : Bank Interest to Bank Interest Received.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('498', 'jsph', '2013-03-04 15:33:39', '1', '', 'Updated bank miscellaneous : Bank Interest Received to Bank Interest.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('499', 'jsph', '2013-03-04 15:34:07', '0', '', 'Added a new bank miscellaneous : Bank Charges.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('500', 'jsph', '2013-03-04 15:37:00', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('501', 'jsph', '2013-03-04 15:42:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('502', 'jsph', '2013-03-04 15:44:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('503', 'jsph', '2013-03-04 15:51:04', '2', '', 'Delete Bank Charges from bank miscellaneous list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('504', 'jsph', '2013-03-04 15:51:29', '0', '', 'Added a new bank miscellaneous : Bank Charges.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('505', 'jsph', '2013-03-04 16:15:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('506', 'jsph', '2013-03-04 16:28:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('507', 'jsph', '2013-03-04 16:30:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('508', 'jsph', '2013-03-05 08:48:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('509', 'jsph', '2013-03-05 08:51:33', '1', '', 'Updated currency : AFA to AFS.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('510', 'jsph', '2013-03-05 08:52:09', '1', '', 'Updated currency : AFS to AFA.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('511', 'jsph', '2013-03-05 08:52:59', '0', '', 'Added a new currency : SGD.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('512', 'jsph', '2013-03-05 08:55:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('513', 'jsph', '2013-03-05 08:55:55', '2', '', 'Delete SGD (Singaporean Dollar) from currencies list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('514', 'jsph', '2013-03-05 08:58:37', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('515', 'jsph', '2013-03-05 09:04:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('516', 'jsph', '2013-03-05 09:05:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('517', 'jsph', '2013-03-05 10:27:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('518', 'jsph', '2013-03-05 10:31:49', '0', '', 'Added a new currency denomination : .10 PHP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('519', 'jsph', '2013-03-05 10:34:26', '2', '', 'Delete .10PHP from currency denominations list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('520', 'jsph', '2013-03-05 10:34:52', '0', '', 'Added a new currency denomination : .10 PHP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('521', 'jsph', '2013-03-05 10:35:41', '2', '', 'Delete .10PHP from currency denominations list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('522', 'jsph', '2013-03-05 10:36:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('523', 'jsph', '2013-03-05 10:41:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('524', 'jsph', '2013-03-05 10:43:18', '0', '', 'Added a new currency denomination : 0.10 PHP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('525', 'jsph', '2013-03-05 10:43:35', '2', '', 'Delete 0.10PHP from currency denominations list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('526', 'jsph', '2013-03-05 10:44:41', '0', '', 'Added a new currency denomination : 0.10 PHP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('527', 'jsph', '2013-03-05 10:44:49', '1', '', 'Updated currency denomination : 0.10 PHP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('528', 'jsph', '2013-03-05 10:44:54', '1', '', 'Updated currency denomination : 0.10 PHP.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('529', 'jsph', '2013-03-05 10:53:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('530', 'jsph', '2013-03-05 11:19:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('531', 'jsph', '2013-03-05 11:20:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('532', 'jsph', '2013-03-05 13:03:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('533', 'jsph', '2013-03-05 13:04:17', '0', '', 'Added a new payment term : Net Cash.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('534', 'jsph', '2013-03-05 13:06:00', '0', '', 'Added a new payment term : 15 Days PDC.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('535', 'jsph', '2013-03-05 13:07:05', '1', '', 'Updated payment term : 15 Days PDC to 30 Days PDC.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('536', 'jsph', '2013-03-05 13:08:04', '0', '', 'Added a new payment term : 15 Days PDC.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('537', 'jsph', '2013-03-05 13:09:31', '0', '', 'Added a new payment term : COD.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('538', 'jsph', '2013-03-05 13:17:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('539', 'jsph', '2013-03-05 13:18:47', '2', '', 'Delete COD from payment terms list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('540', 'jsph', '2013-03-05 13:19:53', '0', '', 'Added a new payment term : CAD.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('541', 'jsph', '2013-03-05 13:20:07', '1', '', 'Updated payment term : CAD.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('542', 'jsph', '2013-03-05 13:32:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('543', 'jsph', '2013-03-05 16:23:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('544', 'jsph', '2013-03-05 16:26:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('545', 'jsph', '2013-03-05 16:27:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('546', 'jsph', '2013-03-05 16:29:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('547', 'jsph', '2013-03-05 16:31:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('548', 'jsph', '2013-03-05 16:35:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('549', 'jsph', '2013-03-05 16:36:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('550', 'jsph', '2013-03-05 16:37:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('551', 'jsph', '2013-03-05 16:54:32', '0', '', 'Added a new signatory : Joseph Lambert Reyes as approving personnel.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('552', 'jsph', '2013-03-05 16:56:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('553', 'jsph', '2013-03-05 16:58:00', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('554', 'jsph', '2013-03-05 16:59:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('555', 'jsph', '2013-03-05 17:00:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('556', 'jsph', '2013-03-05 17:03:09', '0', '', 'Added a new signatory : Joseph Lambert Reyes as checking personnel.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('557', 'jsph', '2013-03-05 17:03:18', '1', '', 'Updated signatory : Super User as checking personnel.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('558', 'jsph', '2013-03-05 17:03:42', '1', '', 'Updated signatory : Super User as approving personnel.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('559', 'jsph', '2013-03-05 17:04:03', '2', '', 'Delete Super User (Approving Personnel) from signatories list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('560', 'jsph', '2013-03-05 17:09:46', '2', '', 'Delete Joseph Lambert Reyes (Approving Personnel) from signatories list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('561', 'jsph', '2013-03-05 17:13:41', '0', '', 'Added a new signatory : Joseph Lambert Reyes as approving personnel.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('562', 'jsph', '2013-03-05 17:17:45', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('563', 'jsph', '2013-03-05 17:20:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('564', 'jsph', '2013-03-05 17:22:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('565', 'jsph', '2013-03-05 17:24:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('566', 'jsph', '2013-03-05 17:28:40', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_05_03_2013_17_28_27.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('567', 'jsph', '2013-03-05 17:29:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('568', 'jsph', '2013-03-05 17:33:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('569', 'jsph', '2013-03-05 17:36:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('570', 'jsph', '2013-03-06 07:26:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('571', 'jsph', '2013-03-06 07:29:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('572', 'jsph', '2013-03-06 08:00:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('573', 'jsph', '2013-03-06 08:00:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('574', 'jsph', '2013-03-06 08:00:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('575', 'jsph', '2013-03-06 08:00:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('576', 'jsph', '2013-03-06 09:02:42', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('577', 'jsph', '2013-03-06 09:03:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('578', 'jsph', '2013-03-06 09:06:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('579', 'jsph', '2013-03-06 09:10:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('580', 'jsph', '2013-03-06 09:10:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('581', 'jsph', '2013-03-06 09:14:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('582', 'jsph', '2013-03-06 09:14:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('583', 'jsph', '2013-03-06 09:16:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('584', 'jsph', '2013-03-06 10:03:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('585', 'jsph', '2013-03-06 10:04:07', '0', '', 'Added a new unit of measurement : Bag.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('586', 'jsph', '2013-03-06 10:04:12', '0', '', 'Added a new unit of measurement : Bottle.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('587', 'jsph', '2013-03-06 10:04:31', '0', '', 'Added a new unit of measurement : Box.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('588', 'jsph', '2013-03-06 10:04:37', '0', '', 'Added a new unit of measurement : Bucket.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('589', 'jsph', '2013-03-06 10:04:53', '1', '', 'Updated unit of measurement : Bottle to Btl.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('590', 'jsph', '2013-03-06 10:05:01', '1', '', 'Updated unit of measurement : Btl to Bottle.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('591', 'jsph', '2013-03-06 10:05:57', '0', '', 'Added a new unit of measurement : Pc(s).', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('592', 'jsph', '2013-03-06 10:06:07', '0', '', 'Added a new unit of measurement : Gallon.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('593', 'jsph', '2013-03-06 10:06:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('594', 'jsph', '2013-03-06 10:06:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('595', 'jsph', '2013-03-06 10:07:00', '2', '', 'Delete Gallon from measurements list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('596', 'jsph', '2013-03-06 10:07:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('597', 'jsph', '2013-03-06 10:17:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('598', 'jsph', '2013-03-06 10:18:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('599', 'jsph', '2013-03-06 10:18:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('600', 'jsph', '2013-03-06 10:19:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('601', 'jsph', '2013-03-06 10:29:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('602', 'jsph', '2013-03-06 10:29:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('603', 'jsph', '2013-03-06 10:29:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('604', 'jsph', '2013-03-06 10:29:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('605', 'jsph', '2013-03-06 10:30:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('606', 'jsph', '2013-03-06 10:31:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('607', 'jsph', '2013-03-06 11:29:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('608', 'jsph', '2013-03-06 11:30:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('609', 'jsph', '2013-03-06 11:32:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('610', 'jsph', '2013-03-06 11:35:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('611', 'jsph', '2013-03-06 11:35:34', '0', '', 'Added a new vehicle model : COROLLA.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('612', 'jsph', '2013-03-06 11:38:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('613', 'jsph', '2013-03-06 11:40:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('614', 'jsph', '2013-03-06 11:40:43', '2', '', 'Delete TOYOTA - COROLLA from models list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('615', 'jsph', '2013-03-06 11:44:00', '2', '', 'Delete TOYOTA - COROLLA from models list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('616', 'jsph', '2013-03-06 11:44:08', '0', '', 'Added a new vehicle model : COROLLA.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('617', 'jsph', '2013-03-06 11:45:48', '0', '', 'Added a new vehicle model : FORTUNER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('618', 'jsph', '2013-03-06 11:46:01', '1', '', 'Updated vehicle model : TOYOTA - HIACE.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('619', 'jsph', '2013-03-06 11:47:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('620', 'jsph', '2013-03-06 11:48:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('621', 'jsph', '2013-03-06 11:49:13', '2', '', 'Delete TOYOTA - HIACE from models list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('622', 'jsph', '2013-03-06 11:54:02', '0', '', 'Added a new vehicle model : FORTUNER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('623', 'jsph', '2013-03-06 11:54:34', '1', '', 'Updated vehicle model : TOYOTA - HIACE.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('624', 'jsph', '2013-03-06 13:05:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('625', 'jsph', '2013-03-06 13:05:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('626', 'jsph', '2013-03-06 13:05:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('627', 'jsph', '2013-03-06 13:06:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('628', 'jsph', '2013-03-06 13:06:48', '0', '', 'Added a new vehicle model : FORTUNER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('629', 'jsph', '2013-03-06 13:07:23', '1', '', 'Updated vehicle model : TOYOTA - FORTUNER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('630', 'jsph', '2013-03-06 13:07:27', '1', '', 'Updated vehicle model : TOYOTA - HILUX.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('631', 'jsph', '2013-03-06 13:08:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('632', 'jsph', '2013-03-06 13:09:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('633', 'jsph', '2013-03-06 13:14:30', '0', '', 'Added a new vehicle model : FORTUNER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('634', 'jsph', '2013-03-06 13:14:47', '1', '', 'Updated vehicle model : TOYOTA - LAND CRUISER.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('635', 'jsph', '2013-03-06 13:16:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('636', 'jsph', '2013-03-06 13:18:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('637', 'jsph', '2013-03-06 13:25:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('638', 'jsph', '2013-03-06 13:44:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('639', 'jsph', '2013-03-06 13:45:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('640', 'jsph', '2013-03-06 13:46:21', '0', '', 'Added a new part name : Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('641', 'jsph', '2013-03-06 13:47:19', '0', '', 'Added a new part name : Combination Wrench 10mm.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('642', 'jsph', '2013-03-06 13:48:00', '1', '', 'Updated part name : Combination Wrench 10mm to Combination Wrench 10MM.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('643', 'jsph', '2013-03-06 13:48:09', '1', '', 'Updated part name : Combination Wrench 10MM to Combination Wrench 10mm.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('644', 'jsph', '2013-03-06 13:48:32', '0', '', 'Added a new part name : Pinion.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('645', 'jsph', '2013-03-06 13:48:38', '2', '', 'Delete Tires from part names list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('646', 'jsph', '2013-03-06 13:48:55', '0', '', 'Added a new part name : Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('647', 'jsph', '2013-03-06 13:48:59', '1', '', 'Updated part name : Tires to Tyres.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('648', 'jsph', '2013-03-06 13:49:06', '1', '', 'Updated part name : Tyres to Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('649', 'jsph', '2013-03-06 13:49:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('650', 'jsph', '2013-03-06 13:54:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('651', 'jsph', '2013-03-06 13:54:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('652', 'jsph', '2013-03-06 13:54:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('653', 'jsph', '2013-03-06 13:55:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('654', 'jsph', '2013-03-06 14:06:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('655', 'jsph', '2013-03-06 14:06:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('656', 'jsph', '2013-03-06 15:50:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('657', 'jsph', '2013-03-06 15:50:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('658', 'jsph', '2013-03-06 15:51:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('659', 'jsph', '2013-03-06 15:51:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('660', 'jsph', '2013-03-06 15:52:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('661', 'jsph', '2013-03-06 15:52:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('662', 'jsph', '2013-03-06 15:53:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('663', 'jsph', '2013-03-06 15:53:28', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('664', 'jsph', '2013-03-06 15:55:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('665', 'jsph', '2013-03-06 15:57:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('666', 'jsph', '2013-03-06 16:05:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('667', 'jsph', '2013-03-06 16:13:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('668', 'jsph', '2013-03-06 16:14:34', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('669', 'jsph', '2013-03-06 16:17:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('670', 'jsph', '2013-03-06 16:17:42', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('671', 'jsph', '2013-03-06 16:18:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('672', 'jsph', '2013-03-06 16:19:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('673', 'jsph', '2013-03-06 16:21:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('674', 'jsph', '2013-03-06 16:21:21', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('675', 'jsph', '2013-03-06 16:21:25', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('676', 'jsph', '2013-03-06 16:21:26', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('677', 'jsph', '2013-03-06 16:21:31', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('678', 'jsph', '2013-03-06 16:21:33', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('679', 'jsph', '2013-03-06 16:21:34', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('680', 'jsph', '2013-03-06 16:21:35', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('681', 'jsph', '2013-03-06 16:21:36', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('682', 'jsph', '2013-03-06 16:21:45', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('683', 'jsph', '2013-03-06 16:21:46', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('684', 'jsph', '2013-03-06 16:21:48', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('685', 'jsph', '2013-03-06 16:21:49', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('686', 'jsph', '2013-03-06 16:21:52', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('687', 'jsph', '2013-03-06 16:21:53', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('688', 'jsph', '2013-03-06 16:21:54', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('689', 'jsph', '2013-03-06 16:22:55', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('690', 'jsph', '2013-03-06 16:23:00', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('691', 'jsph', '2013-03-06 16:23:05', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('692', 'jsph', '2013-03-06 16:23:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('693', 'jsph', '2013-03-06 16:27:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('694', 'jsph', '2013-03-06 16:28:19', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('695', 'jsph', '2013-03-06 16:28:27', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('696', 'jsph', '2013-03-06 16:29:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('697', 'jsph', '2013-03-06 16:30:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('698', 'jsph', '2013-03-06 16:31:46', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('699', 'jsph', '2013-03-06 16:31:48', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('700', 'jsph', '2013-03-06 16:31:50', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('701', 'jsph', '2013-03-06 16:31:51', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('702', 'jsph', '2013-03-06 16:32:02', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('703', 'jsph', '2013-03-06 16:32:06', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('704', 'jsph', '2013-03-06 16:32:13', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('705', 'jsph', '2013-03-06 17:00:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('706', 'jsph', '2013-03-06 17:00:55', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('707', 'jsph', '2013-03-06 17:06:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('708', 'jsph', '2013-03-06 17:12:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('709', 'jsph', '2013-03-06 17:13:09', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('710', 'jsph', '2013-03-06 17:13:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('711', 'jsph', '2013-03-06 17:51:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('712', 'jsph', '2013-03-06 17:55:09', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('713', 'jsph', '2013-03-06 17:55:18', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('714', 'jsph', '2013-03-06 17:56:52', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('715', 'jsph', '2013-03-06 18:00:36', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('716', 'jsph', '2013-03-06 18:00:41', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('717', 'jsph', '2013-03-06 18:00:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('718', 'jsph', '2013-03-07 09:28:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('719', 'jsph', '2013-03-07 09:28:40', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('720', 'jsph', '2013-03-07 09:29:07', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('721', 'jsph', '2013-03-07 09:29:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('722', 'jsph', '2013-03-07 10:02:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('723', 'jsph', '2013-03-07 10:04:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('724', 'jsph', '2013-03-07 10:08:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('725', 'jsph', '2013-03-07 10:09:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('726', 'jsph', '2013-03-07 10:10:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('727', 'jsph', '2013-03-07 10:26:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('728', 'jsph', '2013-03-07 10:50:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('729', 'jsph', '2013-03-07 10:51:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('730', 'jsph', '2013-03-07 10:51:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('731', 'jsph', '2013-03-07 11:47:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('732', 'jsph', '2013-03-07 11:48:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('733', 'jsph', '2013-03-07 11:48:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('734', 'jsph', '2013-03-07 11:49:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('735', 'jsph', '2013-03-07 11:50:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('736', 'jsph', '2013-03-07 11:51:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('737', 'jsph', '2013-03-07 11:53:42', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('738', 'jsph', '2013-03-07 11:54:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('739', 'jsph', '2013-03-07 11:55:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('740', 'jsph', '2013-03-07 12:29:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('741', 'jsph', '2013-03-07 12:31:34', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('742', 'jsph', '2013-03-07 12:34:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('743', 'jsph', '2013-03-07 12:35:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('744', 'jsph', '2013-03-07 12:37:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('745', 'jsph', '2013-03-07 12:37:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('746', 'jsph', '2013-03-07 12:38:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('747', 'jsph', '2013-03-07 12:40:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('748', 'jsph', '2013-03-07 12:41:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('749', 'jsph', '2013-03-07 12:41:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('750', 'jsph', '2013-03-07 12:44:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('751', 'jsph', '2013-03-07 12:50:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('752', 'jsph', '2013-03-07 12:54:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('753', 'jsph', '2013-03-07 13:03:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('754', 'jsph', '2013-03-07 13:10:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('755', 'jsph', '2013-03-07 13:17:44', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xls.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('756', 'jsph', '2013-03-07 13:22:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('757', 'jsph', '2013-03-07 13:32:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('758', 'jsph', '2013-03-07 13:32:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('759', 'jsph', '2013-03-07 13:34:35', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('760', 'jsph', '2013-03-07 13:35:19', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('761', 'jsph', '2013-03-07 13:37:45', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('762', 'jsph', '2013-03-07 13:40:05', '7', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('763', 'jsph', '2013-03-07 13:41:15', '7', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('764', 'jsph', '2013-03-07 13:43:16', '7', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('765', 'jsph', '2013-03-07 13:44:45', '7', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xml.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('766', 'jsph', '2013-03-07 13:45:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('767', 'jsph', '2013-03-07 13:47:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('768', 'jsph', '2013-03-07 13:48:31', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('769', 'jsph', '2013-03-07 13:48:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('770', 'jsph', '2013-03-07 13:52:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('771', 'jsph', '2013-03-07 14:16:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('772', 'jsph', '2013-03-07 14:17:22', '0', '', 'Added a new department : Administration.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('773', 'jsph', '2013-03-07 14:20:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('774', 'jsph', '2013-03-07 14:22:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('775', 'jsph', '2013-03-07 14:24:51', '0', '', 'Added a new position : Area Sales Manager.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('776', 'jsph', '2013-03-07 14:25:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('777', 'jsph', '2013-03-07 14:53:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('778', 'jsph', '2013-03-07 15:00:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('779', 'jsph', '2013-03-07 15:18:58', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('780', 'jsph', '2013-03-07 15:19:02', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('781', 'jsph', '2013-03-07 15:19:44', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('782', 'jsph', '2013-03-07 15:19:46', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('783', 'jsph', '2013-03-07 15:19:48', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('784', 'jsph', '2013-03-07 15:19:53', '14', '', 'Checked Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('785', 'jsph', '2013-03-07 15:19:54', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('786', 'jsph', '2013-03-07 15:20:01', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('787', 'jsph', '2013-03-07 15:20:02', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('788', 'jsph', '2013-03-07 15:32:13', '13', '', 'Restored database from file : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_07_03_2013_15_20_17.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('789', 'jsph', '2013-03-07 15:32:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('790', 'jsph', '2013-03-07 15:32:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('791', 'jsph', '2013-03-07 15:33:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('792', 'jsph', '2013-03-07 16:21:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('793', 'jsph', '2013-03-07 16:21:48', '0', '', 'Added a new parts category : Oils and Lubricants.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('794', 'jsph', '2013-03-07 16:22:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('795', 'jsph', '2013-03-07 16:30:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('796', 'jsph', '2013-03-07 16:31:33', '0', '', 'Added a new vehicle make : GMC.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('797', 'jsph', '2013-03-07 16:34:12', '0', '', 'Added a new vehicle make : HYUNDAI.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('798', 'jsph', '2013-03-07 16:36:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('799', 'jsph', '2013-03-07 16:41:43', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('800', 'jsph', '2013-03-07 16:41:48', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('801', 'jsph', '2013-03-07 16:44:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('802', 'jsph', '2013-03-07 16:56:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('803', 'jsph', '2013-03-07 17:01:03', '13', '', 'Restored database from file : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_07_03_2013_16_56_48.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('804', 'jsph', '2013-03-07 17:01:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('805', 'jsph', '2013-03-07 17:01:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('806', 'jsph', '2013-03-07 17:09:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('807', 'jsph', '2013-03-07 17:11:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('808', 'jsph', '2013-03-07 17:11:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('809', 'jsph', '2013-03-07 17:25:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('810', 'jsph', '2013-03-07 17:25:33', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xls.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('811', 'jsph', '2013-03-07 17:30:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('812', 'jsph', '2013-03-07 17:31:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('813', 'jsph', '2013-03-07 17:32:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('814', 'jsph', '2013-03-08 13:38:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('815', 'jsph', '2013-03-08 13:38:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('816', 'jsph', '2013-03-08 13:38:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('817', 'jsph', '2013-03-08 13:38:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('818', 'jsph', '2013-03-09 07:31:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('819', 'jsph', '2013-03-09 07:34:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('820', 'jsph', '2013-03-09 08:22:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('821', 'jsph', '2013-03-09 08:22:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('822', 'jsph', '2013-03-09 08:24:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('823', 'jsph', '2013-03-09 08:24:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('824', 'jsph', '2013-03-09 08:26:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('825', 'jsph', '2013-03-09 08:26:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('826', 'jsph', '2013-03-09 09:30:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('827', 'jsph', '2013-03-09 09:31:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('828', 'jsph', '2013-03-09 11:20:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('829', 'jsph', '2013-03-09 11:23:11', '0', '', 'Added a database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('830', 'jsph', '2013-03-09 11:25:53', '1', '', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('831', 'jsph', '2013-03-09 11:26:03', '1', '', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('832', 'jsph', '2013-03-09 11:31:11', '0', '', 'Added a database script : SQL-CSPT-FZE-00002.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('833', 'jsph', '2013-03-09 11:31:29', '1', '', 'Updated database script : SQL-CSPT-FZE-00002.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('834', 'jsph', '2013-03-09 11:31:31', '1', '', 'Updated database script : .', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('835', 'jsph', '2013-03-09 11:32:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('836', 'jsph', '2013-03-09 11:50:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('837', 'jsph', '2013-03-09 11:50:55', '2', '', 'Deleted script : SQL-CSPT-FZE-00002 from the database script list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('838', 'jsph', '2013-03-09 11:54:12', '1', '', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('839', 'jsph', '2013-03-09 11:58:17', '1', '', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('840', 'jsph', '2013-03-09 11:58:31', '1', 'SQL-CSPT-FZE-00001', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('841', 'jsph', '2013-03-09 11:58:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('842', 'jsph', '2013-03-09 12:22:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('843', 'jsph', '2013-03-09 12:25:18', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('844', 'jsph', '2013-03-09 12:25:45', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('845', 'jsph', '2013-03-09 12:31:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('846', 'jsph', '2013-03-10 08:32:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('847', 'jsph', '2013-03-10 08:45:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('848', 'jsph', '2013-03-10 09:23:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('849', 'jsph', '2013-03-10 09:24:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('850', 'jsph', '2013-03-10 09:27:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('851', 'jsph', '2013-03-10 09:27:29', '8', 'SQL-CSPT-FZE-00001', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('852', 'jsph', '2013-03-10 09:30:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('853', 'jsph', '2013-03-10 09:30:18', '8', 'SQL-CSPT-FZE-00001', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('854', 'jsph', '2013-03-10 09:47:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('855', 'jsph', '2013-03-10 09:47:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('856', 'jsph', '2013-03-10 11:44:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('857', 'jsph', '2013-03-10 11:47:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('858', 'jsph', '2013-03-10 11:47:53', '1', 'SQL-CSPT-FZE-00001', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('859', 'jsph', '2013-03-10 11:47:56', '8', 'SQL-CSPT-FZE-00001', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('860', 'jsph', '2013-03-10 11:48:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('861', 'jsph', '2013-03-10 11:52:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('862', 'jsph', '2013-03-10 11:52:22', '8', 'SQL-CSPT-FZE-00001', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('863', 'jsph', '2013-03-10 11:53:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('864', 'jsph', '2013-03-10 14:20:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('865', 'jsph', '2013-03-10 14:20:42', '8', 'SQL-CSPT-FZE-00001', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('866', 'jsph', '2013-03-10 14:21:00', '2', 'SQL-CSPT-FZE-00001', 'Deleted script : SQL-CSPT-FZE-00001 from the database script list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('867', 'jsph', '2013-03-10 14:22:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('868', 'jsph', '2013-03-10 14:23:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('869', 'jsph', '2013-03-10 14:23:37', '10', 'SQL-CSPT-FZE-00001', 'Imported database script from : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('870', 'jsph', '2013-03-10 14:24:24', '2', 'SQL-CSPT-FZE-00001', 'Deleted script : SQL-CSPT-FZE-00001 from the database script list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('871', 'jsph', '2013-03-10 14:24:28', '10', 'SQL-CSPT-FZE-00001', 'Imported database script from : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('872', 'jsph', '2013-03-10 14:26:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('873', 'jsph', '2013-03-10 14:28:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('874', 'jsph', '2013-03-10 14:29:05', '2', 'SQL-CSPT-FZE-00001', 'Deleted script : SQL-CSPT-FZE-00001 from the database script list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('875', 'jsph', '2013-03-10 14:29:11', '10', 'SQL-CSPT-FZE-00001', 'Imported database script from : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('876', 'jsph', '2013-03-10 14:46:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('877', 'jsph', '2013-03-10 14:52:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('878', 'jsph', '2013-03-10 14:52:49', '8', 'SQL-CSPT-FZE-00001', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00001.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('879', 'jsph', '2013-03-10 14:53:42', '1', 'SQL-CSPT-FZE-00001', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('880', 'jsph', '2013-03-10 14:53:52', '1', 'SQL-CSPT-FZE-00001', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('881', 'jsph', '2013-03-10 14:54:02', '1', 'SQL-CSPT-FZE-00001', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('882', 'jsph', '2013-03-10 14:56:34', '1', 'SQL-CSPT-FZE-00001', 'Updated database script : SQL-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('883', 'jsph', '2013-03-10 14:57:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('884', 'jsph', '2013-03-10 17:34:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('885', 'jsph', '2013-03-10 17:35:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('886', 'jsph', '2013-03-11 07:38:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('887', 'jsph', '2013-03-11 07:38:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('888', 'jsph', '2013-03-11 07:40:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('889', 'jsph', '2013-03-11 07:41:36', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_07_41_30.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('890', 'jsph', '2013-03-11 07:41:38', '19', 'SQL-CSPT-FZE-00001', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('891', 'jsph', '2013-03-11 07:48:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('892', 'jsph', '2013-03-11 08:01:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('893', 'jsph', '2013-03-11 08:01:44', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_08_01_42.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('894', 'jsph', '2013-03-11 08:01:46', '19', 'SQL-CSPT-FZE-00001', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('895', 'jsph', '2013-03-11 08:04:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('896', 'jsph', '2013-03-11 08:08:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('897', 'jsph', '2013-03-11 08:08:18', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_08_08_16.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('898', 'jsph', '2013-03-11 08:08:20', '19', 'SQL-CSPT-FZE-00001', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('899', 'jsph', '2013-03-11 08:08:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('900', 'jsph', '2013-03-11 08:13:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('901', 'jsph', '2013-03-11 08:14:09', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_08_14_06.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('902', 'jsph', '2013-03-11 08:14:11', '19', 'SQL-CSPT-FZE-00001', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('903', 'jsph', '2013-03-11 08:14:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('904', 'jsph', '2013-03-11 08:42:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('905', 'jsph', '2013-03-11 08:43:34', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_08_43_31.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('906', 'jsph', '2013-03-11 08:43:36', '19', 'SQL-CSPT-FZE-00001', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('907', 'jsph', '2013-03-11 08:43:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('908', 'jsph', '2013-03-11 08:43:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('909', 'jsph', '2013-03-11 08:45:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('910', 'jsph', '2013-03-11 08:46:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('911', 'jsph', '2013-03-11 08:46:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('912', 'jsph', '2013-03-11 08:48:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('913', 'jsph', '2013-03-11 08:49:26', '0', 'SQL-CSPT-FZE-00002', 'Added a database script : SQL-CSPT-FZE-00002.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('914', 'jsph', '2013-03-11 08:49:31', '8', 'SQL-CSPT-FZE-00002', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00002.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('915', 'jsph', '2013-03-11 08:49:49', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_08_49_47.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('916', 'jsph', '2013-03-11 08:49:51', '19', 'SQL-CSPT-FZE-00002', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('917', 'jsph', '2013-03-11 08:49:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('918', 'jsph', '2013-03-11 08:49:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('919', 'jsph', '2013-03-11 08:51:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('920', 'jsph', '2013-03-11 08:52:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('921', 'jsph', '2013-03-11 08:54:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('922', 'jsph', '2013-03-11 10:04:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('923', 'jsph', '2013-03-11 10:05:31', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_10_05_28.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('924', 'jsph', '2013-03-11 10:05:33', '19', 'SQL-CSPT-FZE-00002', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('925', 'jsph', '2013-03-11 10:05:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('926', 'jsph', '2013-03-11 10:05:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('927', 'jsph', '2013-03-11 10:06:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('928', 'jsph', '2013-03-11 10:13:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('929', 'jsph', '2013-03-11 10:14:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('930', 'jsph', '2013-03-11 10:15:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('931', 'jsph', '2013-03-11 10:17:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('932', 'jsph', '2013-03-11 10:20:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('933', 'jsph', '2013-03-11 10:41:07', '14', '', 'Analyzed Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('934', 'jsph', '2013-03-11 10:41:13', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('935', 'jsph', '2013-03-11 10:45:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('936', 'jsph', '2013-03-11 13:50:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('937', 'jsph', '2013-03-11 13:51:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('938', 'jsph', '2013-03-11 13:51:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('939', 'jsph', '2013-03-11 13:52:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('940', 'jsph', '2013-03-11 13:53:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('941', 'jsph', '2013-03-11 13:53:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('942', 'jsph', '2013-03-11 13:53:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('943', 'jsph', '2013-03-11 13:54:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('944', 'jsph', '2013-03-11 13:54:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('945', 'jsph', '2013-03-11 13:55:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('946', 'jsph', '2013-03-11 13:56:00', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('947', 'jsph', '2013-03-11 13:56:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('948', 'jsph', '2013-03-11 13:58:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('949', 'jsph', '2013-03-11 13:58:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('950', 'jsph', '2013-03-11 13:58:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('951', 'jsph', '2013-03-11 13:58:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('952', 'jsph', '2013-03-11 14:02:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('953', 'jsph', '2013-03-11 14:03:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('954', 'jsph', '2013-03-11 14:09:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('955', 'jsph', '2013-03-11 14:11:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('956', 'jsph', '2013-03-11 14:12:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('957', 'jsph', '2013-03-11 14:12:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('958', 'jsph', '2013-03-11 14:17:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('959', 'jsph', '2013-03-11 14:18:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('960', 'jsph', '2013-03-11 14:19:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('961', 'jsph', '2013-03-11 14:19:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('962', 'jsph', '2013-03-11 14:19:50', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('963', 'jsph', '2013-03-11 14:20:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('964', 'jsph', '2013-03-11 14:20:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('965', 'jsph', '2013-03-11 14:21:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('966', 'jsph', '2013-03-11 14:22:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('967', 'jsph', '2013-03-11 14:22:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('968', 'jsph', '2013-03-11 14:23:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('969', 'jsph', '2013-03-11 14:28:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('970', 'jsph', '2013-03-11 14:29:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('971', 'jsph', '2013-03-11 14:33:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('972', 'jsph', '2013-03-11 14:33:52', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('973', 'jsph', '2013-03-11 14:34:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('974', 'jsph', '2013-03-11 14:42:54', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('975', 'jsph', '2013-03-11 14:44:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('976', 'jsph', '2013-03-11 14:45:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('977', 'jsph', '2013-03-11 14:48:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('978', 'jsph', '2013-03-11 14:50:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('979', 'jsph', '2013-03-11 14:50:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('980', 'jsph', '2013-03-11 14:51:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('981', 'jsph', '2013-03-11 14:52:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('982', 'jsph', '2013-03-11 14:52:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('983', 'jsph', '2013-03-11 14:52:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('984', 'jsph', '2013-03-11 14:55:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('985', 'jsph', '2013-03-11 14:56:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('986', 'jsph', '2013-03-11 14:56:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('987', 'jsph', '2013-03-11 14:57:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('988', 'jsph', '2013-03-11 14:57:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('989', 'jsph', '2013-03-11 14:59:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('990', 'jsph', '2013-03-11 14:59:28', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('991', 'jsph', '2013-03-11 15:06:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('992', 'jsph', '2013-03-11 15:06:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('993', 'jsph', '2013-03-11 15:08:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('994', 'jsph', '2013-03-11 15:09:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('995', 'jsph', '2013-03-11 15:10:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('996', 'jsph', '2013-03-11 15:10:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('997', 'jsph', '2013-03-11 15:13:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('998', 'jsph', '2013-03-11 15:13:52', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('999', 'jsph', '2013-03-11 15:19:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1000', 'jsph', '2013-03-11 15:19:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1001', 'jsph', '2013-03-11 15:20:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1002', 'jsph', '2013-03-11 15:20:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1003', 'jsph', '2013-03-11 15:20:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1004', 'jsph', '2013-03-11 15:21:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1005', 'jsph', '2013-03-11 15:21:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1006', 'jsph', '2013-03-11 15:22:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1007', 'jsph', '2013-03-11 15:46:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1008', 'jsph', '2013-03-11 15:47:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1009', 'jsph', '2013-03-11 15:49:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1010', 'jsph', '2013-03-11 15:49:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1011', 'jsph', '2013-03-11 15:52:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1012', 'jsph', '2013-03-11 15:54:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1013', 'jsph', '2013-03-11 16:00:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1014', 'jsph', '2013-03-11 16:00:42', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1015', 'jsph', '2013-03-11 16:01:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1016', 'jsph', '2013-03-11 16:02:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1017', 'jsph', '2013-03-11 16:10:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1018', 'jsph', '2013-03-11 16:10:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1019', 'jsph', '2013-03-11 16:10:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1020', 'jsph', '2013-03-11 16:11:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1021', 'jsph', '2013-03-11 16:11:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1022', 'jsph', '2013-03-11 16:11:31', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1023', 'jsph', '2013-03-11 16:11:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1024', 'jsph', '2013-03-11 16:11:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1025', 'jsph', '2013-03-11 16:13:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1026', 'jsph', '2013-03-11 16:13:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1027', 'jsph', '2013-03-11 16:19:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1028', 'jsph', '2013-03-11 16:20:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1029', 'jsph', '2013-03-11 16:21:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1030', 'jsph', '2013-03-11 16:21:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1031', 'jsph', '2013-03-11 16:22:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1032', 'jsph', '2013-03-11 16:24:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1033', 'jsph', '2013-03-11 16:26:00', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1034', 'jsph', '2013-03-11 16:26:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1035', 'jsph', '2013-03-11 16:26:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1036', 'jsph', '2013-03-11 16:27:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1037', 'jsph', '2013-03-11 16:28:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1038', 'jsph', '2013-03-11 16:28:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1039', 'jsph', '2013-03-11 16:28:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1040', 'jsph', '2013-03-11 16:31:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1041', 'jsph', '2013-03-11 16:31:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1042', 'jsph', '2013-03-11 16:31:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1043', 'jsph', '2013-03-11 16:37:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1044', 'jsph', '2013-03-11 16:38:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1045', 'jsph', '2013-03-11 16:46:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1046', 'jsph', '2013-03-11 16:46:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1047', 'jsph', '2013-03-11 16:46:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1048', 'jsph', '2013-03-11 16:47:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1049', 'jsph', '2013-03-11 16:48:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1050', 'jsph', '2013-03-11 16:48:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1051', 'jsph', '2013-03-11 16:49:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1052', 'jsph', '2013-03-11 16:50:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1053', 'jsph', '2013-03-11 16:50:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1054', 'jsph', '2013-03-11 16:50:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1055', 'jsph', '2013-03-11 16:51:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1056', 'jsph', '2013-03-11 16:51:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1057', 'jsph', '2013-03-11 16:51:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1058', 'jsph', '2013-03-11 16:51:34', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1059', 'jsph', '2013-03-11 16:51:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1060', 'jsph', '2013-03-11 16:52:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1061', 'jsph', '2013-03-11 16:52:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1062', 'jsph', '2013-03-11 16:52:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1063', 'jsph', '2013-03-11 16:53:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1064', 'jsph', '2013-03-11 16:53:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1065', 'jsph', '2013-03-11 16:54:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1066', 'jsph', '2013-03-11 16:55:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1067', 'jsph', '2013-03-11 17:00:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1068', 'jsph', '2013-03-11 17:00:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1069', 'jsph', '2013-03-11 17:06:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1070', 'jsph', '2013-03-11 17:07:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1071', 'jsph', '2013-03-11 17:15:45', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1072', 'jsph', '2013-03-11 17:16:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1073', 'jsph', '2013-03-11 17:19:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1074', 'jsph', '2013-03-11 17:24:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1075', 'jsph', '2013-03-11 17:24:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1076', 'jsph', '2013-03-11 17:24:54', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1077', 'jsph', '2013-03-11 17:25:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1078', 'jsph', '2013-03-11 17:25:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1079', 'jsph', '2013-03-11 17:26:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1080', 'jsph', '2013-03-11 17:27:23', '8', 'SQL-CSPT-FZE-00002', 'Exported database script into : C:\\Users\\user\\Desktop\\SQL-CSPT-FZE-00002.sql4x.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1081', 'jsph', '2013-03-11 17:27:45', '12', '', 'Performed database backup into : C:\\Users\\user\\Desktop\\SCMSIV_BACKUP_11_03_2013_17_27_42.scmsiv.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1082', 'jsph', '2013-03-11 17:27:48', '19', 'SQL-CSPT-FZE-00002', 'Executed a database script.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1083', 'jsph', '2013-03-11 17:27:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1084', 'jsph', '2013-03-11 17:27:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1085', 'jsph', '2013-03-11 17:28:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1086', 'jsph', '2013-03-11 17:31:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1087', 'jsph', '2013-03-11 17:33:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1088', 'jsph', '2013-03-12 07:36:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1089', 'jsph', '2013-03-12 07:39:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1090', 'jsph', '2013-03-12 07:43:00', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1091', 'jsph', '2013-03-12 07:44:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1092', 'jsph', '2013-03-12 10:08:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1093', 'jsph', '2013-03-12 10:09:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1094', 'jsph', '2013-03-12 10:09:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1095', 'jsph', '2013-03-12 10:10:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1096', 'jsph', '2013-03-12 10:11:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1097', 'jsph', '2013-03-12 10:13:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1098', 'jsph', '2013-03-12 10:14:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1099', 'jsph', '2013-03-12 10:15:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1100', 'jsph', '2013-03-12 10:15:54', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1101', 'jsph', '2013-03-12 10:21:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1102', 'jsph', '2013-03-12 10:21:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1103', 'jsph', '2013-03-12 10:21:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1104', 'jsph', '2013-03-12 10:22:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1105', 'jsph', '2013-03-12 10:22:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1106', 'jsph', '2013-03-12 10:23:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1107', 'jsph', '2013-03-12 10:25:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1108', 'jsph', '2013-03-12 10:25:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1109', 'jsph', '2013-03-12 10:26:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1110', 'jsph', '2013-03-12 10:26:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1111', 'jsph', '2013-03-12 10:33:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1112', 'jsph', '2013-03-12 10:34:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1113', 'jsph', '2013-03-12 10:34:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1114', 'jsph', '2013-03-12 10:34:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1115', 'jsph', '2013-03-12 10:35:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1116', 'jsph', '2013-03-12 10:35:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1117', 'jsph', '2013-03-12 10:36:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1118', 'jsph', '2013-03-12 10:36:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1119', 'jsph', '2013-03-12 10:36:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1120', 'jsph', '2013-03-12 10:37:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1121', 'jsph', '2013-03-12 10:42:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1122', 'jsph', '2013-03-12 10:43:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1123', 'jsph', '2013-03-12 10:44:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1124', 'jsph', '2013-03-12 10:45:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1125', 'jsph', '2013-03-12 10:45:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1126', 'jsph', '2013-03-12 11:01:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1127', 'jsph', '2013-03-12 11:02:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1128', 'jsph', '2013-03-12 11:02:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1129', 'jsph', '2013-03-12 11:02:44', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1130', 'jsph', '2013-03-12 11:03:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1131', 'jsph', '2013-03-12 11:08:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1132', 'jsph', '2013-03-12 11:09:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1133', 'jsph', '2013-03-12 11:12:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1134', 'jsph', '2013-03-12 11:13:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1135', 'jsph', '2013-03-12 11:14:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1136', 'jsph', '2013-03-12 11:14:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1137', 'jsph', '2013-03-12 11:14:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1138', 'jsph', '2013-03-12 11:48:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1139', 'jsph', '2013-03-12 11:48:37', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1140', 'jsph', '2013-03-12 11:48:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1141', 'jsph', '2013-03-12 11:49:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1142', 'jsph', '2013-03-12 12:00:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1143', 'jsph', '2013-03-12 12:31:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1144', 'jsph', '2013-03-12 12:32:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1145', 'jsph', '2013-03-12 12:33:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1146', 'jsph', '2013-03-12 12:37:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1147', 'jsph', '2013-03-12 12:38:51', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1148', 'jsph', '2013-03-12 12:50:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1149', 'jsph', '2013-03-12 12:50:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1150', 'jsph', '2013-03-12 13:00:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1151', 'jsph', '2013-03-12 13:05:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1152', 'jsph', '2013-03-12 13:18:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1153', 'jsph', '2013-03-12 13:19:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1154', 'jsph', '2013-03-12 13:37:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1155', 'jsph', '2013-03-12 13:38:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1156', 'jsph', '2013-03-12 13:38:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1157', 'jsph', '2013-03-12 13:39:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1158', 'jsph', '2013-03-12 13:39:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1159', 'jsph', '2013-03-12 13:41:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1160', 'jsph', '2013-03-12 13:43:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1161', 'jsph', '2013-03-12 13:45:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1162', 'jsph', '2013-03-12 13:55:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1163', 'jsph', '2013-03-12 13:56:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1164', 'jsph', '2013-03-12 13:57:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1165', 'jsph', '2013-03-12 13:58:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1166', 'jsph', '2013-03-12 14:11:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1167', 'jsph', '2013-03-12 14:13:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1168', 'jsph', '2013-03-12 14:14:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1169', 'jsph', '2013-03-12 14:14:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1170', 'jsph', '2013-03-12 14:15:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1171', 'jsph', '2013-03-12 14:15:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1172', 'jsph', '2013-03-12 14:21:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1173', 'jsph', '2013-03-12 14:21:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1174', 'jsph', '2013-03-12 14:37:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1175', 'jsph', '2013-03-12 14:37:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1176', 'jsph', '2013-03-12 14:38:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1177', 'jsph', '2013-03-12 14:39:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1178', 'jsph', '2013-03-12 14:44:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1179', 'jsph', '2013-03-12 14:48:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1180', 'jsph', '2013-03-12 14:49:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1181', 'jsph', '2013-03-12 14:49:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1182', 'jsph', '2013-03-12 15:10:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1183', 'jsph', '2013-03-12 15:12:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1184', 'jsph', '2013-03-12 15:15:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1185', 'jsph', '2013-03-12 15:15:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1186', 'jsph', '2013-03-12 15:17:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1187', 'jsph', '2013-03-12 15:18:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1188', 'jsph', '2013-03-12 15:18:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1189', 'jsph', '2013-03-12 15:19:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1190', 'jsph', '2013-03-12 16:31:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1191', 'jsph', '2013-03-12 16:33:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1192', 'jsph', '2013-03-12 17:13:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1193', 'jsph', '2013-03-12 17:14:02', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1194', 'jsph', '2013-03-12 17:27:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1195', 'jsph', '2013-03-12 17:29:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1196', 'jsph', '2013-03-12 17:29:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1197', 'jsph', '2013-03-13 07:21:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1198', 'jsph', '2013-03-13 07:43:45', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1199', 'jsph', '2013-03-13 07:45:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1200', 'jsph', '2013-03-13 07:46:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1201', 'jsph', '2013-03-13 07:46:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1202', 'jsph', '2013-03-13 07:47:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1203', 'jsph', '2013-03-13 07:49:44', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xls.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1204', 'jsph', '2013-03-13 07:50:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1205', 'jsph', '2013-03-13 09:28:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1206', 'jsph', '2013-03-13 09:29:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1207', 'jsph', '2013-03-13 09:33:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1208', 'jsph', '2013-03-13 09:34:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1209', 'jsph', '2013-03-13 09:35:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1210', 'jsph', '2013-03-13 09:35:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1211', 'jsph', '2013-03-13 09:37:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1212', 'jsph', '2013-03-13 09:45:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1213', 'jsph', '2013-03-13 09:47:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1214', 'jsph', '2013-03-13 09:48:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1215', 'jsph', '2013-03-13 09:53:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1216', 'jsph', '2013-03-13 09:53:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1217', 'jsph', '2013-03-13 09:55:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1218', 'jsph', '2013-03-13 09:55:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1219', 'jsph', '2013-03-13 09:57:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1220', 'jsph', '2013-03-13 11:34:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1221', 'jsph', '2013-03-13 11:45:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1222', 'jsph', '2013-03-13 12:46:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1223', 'jsph', '2013-03-13 12:49:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1224', 'jsph', '2013-03-13 12:49:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1225', 'jsph', '2013-03-13 12:49:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1226', 'jsph', '2013-03-13 12:52:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1227', 'jsph', '2013-03-13 13:01:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1228', 'jsph', '2013-03-13 13:03:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1229', 'jsph', '2013-03-13 13:04:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1230', 'jsph', '2013-03-13 13:05:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1231', 'jsph', '2013-03-13 13:12:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1232', 'jsph', '2013-03-13 13:15:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1233', 'jsph', '2013-03-13 13:19:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1234', 'jsph', '2013-03-13 13:20:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1235', 'jsph', '2013-03-13 13:21:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1236', 'jsph', '2013-03-13 13:21:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1237', 'jsph', '2013-03-13 13:21:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1238', 'jsph', '2013-03-13 13:23:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1239', 'jsph', '2013-03-13 13:50:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1240', 'jsph', '2013-03-13 13:51:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1241', 'jsph', '2013-03-13 13:57:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1242', 'jsph', '2013-03-13 13:58:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1243', 'jsph', '2013-03-13 13:59:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1244', 'jsph', '2013-03-13 14:01:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1245', 'jsph', '2013-03-13 14:02:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1246', 'jsph', '2013-03-13 14:03:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1247', 'jsph', '2013-03-13 14:06:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1248', 'jsph', '2013-03-13 15:43:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1249', 'jsph', '2013-03-13 15:43:31', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1250', 'jsph', '2013-03-13 15:44:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1251', 'jsph', '2013-03-13 15:46:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1252', 'jsph', '2013-03-13 15:48:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1253', 'jsph', '2013-03-13 15:57:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1254', 'jsph', '2013-03-13 15:57:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1255', 'jsph', '2013-03-13 15:59:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1256', 'jsph', '2013-03-13 16:00:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1257', 'jsph', '2013-03-13 16:00:31', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1258', 'jsph', '2013-03-13 16:01:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1259', 'jsph', '2013-03-13 16:02:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1260', 'jsph', '2013-03-13 16:04:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1261', 'jsph', '2013-03-13 16:09:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1262', 'jsph', '2013-03-13 16:09:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1263', 'jsph', '2013-03-13 16:10:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1264', 'jsph', '2013-03-13 16:17:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1265', 'jsph', '2013-03-13 16:20:52', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1266', 'jsph', '2013-03-13 16:20:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1267', 'jsph', '2013-03-13 16:21:12', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1268', 'jsph', '2013-03-13 16:27:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1269', 'jsph', '2013-03-13 16:28:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1270', 'jsph', '2013-03-13 16:29:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1271', 'jsph', '2013-03-13 16:31:06', '1', '', 'Updated part name : Combination Wrench 10mm to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1272', 'jsph', '2013-03-13 16:31:08', '1', '', 'Updated part name : Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1273', 'jsph', '2013-03-13 16:32:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1274', 'jsph', '2013-03-13 16:32:03', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1275', 'jsph', '2013-03-13 16:39:51', '1', '', 'Updated part name : Combination Wrench to Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1276', 'jsph', '2013-03-13 16:40:25', '1', '', 'Updated part name : Wrench to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1277', 'jsph', '2013-03-13 16:42:02', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1278', 'jsph', '2013-03-13 16:45:50', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1279', 'jsph', '2013-03-13 16:46:12', '1', '', 'Updated part name : Combination Wrench to Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1280', 'jsph', '2013-03-13 16:46:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1281', 'jsph', '2013-03-13 16:46:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1282', 'jsph', '2013-03-13 16:51:55', '1', '', 'Updated part name : Wrench to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1283', 'jsph', '2013-03-13 16:53:20', '1', '', 'Updated part name : Combination Wrench to Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1284', 'jsph', '2013-03-13 16:53:38', '1', '', 'Updated part name : Wrench to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1285', 'jsph', '2013-03-13 16:53:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1286', 'jsph', '2013-03-13 16:53:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1287', 'jsph', '2013-03-13 17:10:31', '1', '', 'Updated part name : Combination Wrench to Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1288', 'jsph', '2013-03-13 17:10:47', '1', '', 'Updated part name : Wrench to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1289', 'jsph', '2013-03-13 17:10:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1290', 'jsph', '2013-03-13 17:28:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1291', 'jsph', '2013-03-13 17:28:34', '1', '', 'Updated part name : Combination Wrench to Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1292', 'jsph', '2013-03-13 17:29:07', '1', '', 'Updated part name : Wrench to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1293', 'jsph', '2013-03-13 17:31:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1294', 'jsph', '2013-03-14 09:01:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1295', 'jsph', '2013-03-14 09:02:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1296', 'jsph', '2013-03-14 09:03:28', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1297', 'jsph', '2013-03-14 09:17:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1298', 'jsph', '2013-03-14 09:19:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1299', 'jsph', '2013-03-14 09:24:43', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1300', 'jsph', '2013-03-14 09:25:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1301', 'jsph', '2013-03-14 09:25:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1302', 'jsph', '2013-03-14 09:26:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1303', 'jsph', '2013-03-14 09:49:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1304', 'jsph', '2013-03-14 09:50:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1305', 'jsph', '2013-03-14 09:54:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1306', 'jsph', '2013-03-14 09:56:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1307', 'jsph', '2013-03-14 11:23:50', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1308', 'jsph', '2013-03-14 11:24:25', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1309', 'jsph', '2013-03-14 11:24:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1310', 'jsph', '2013-03-14 11:25:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1311', 'jsph', '2013-03-14 11:26:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1312', 'jsph', '2013-03-14 11:27:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1313', 'jsph', '2013-03-14 11:32:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1314', 'jsph', '2013-03-14 11:33:02', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1315', 'jsph', '2013-03-14 11:34:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1316', 'jsph', '2013-03-14 11:34:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1317', 'jsph', '2013-03-14 11:35:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1318', 'jsph', '2013-03-14 11:36:13', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1319', 'jsph', '2013-03-14 11:36:16', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1320', 'jsph', '2013-03-14 11:37:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1321', 'jsph', '2013-03-14 11:37:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1322', 'jsph', '2013-03-14 11:37:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1323', 'jsph', '2013-03-14 11:37:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1324', 'jsph', '2013-03-14 11:44:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1325', 'jsph', '2013-03-14 11:44:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1326', 'jsph', '2013-03-14 11:46:43', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1327', 'jsph', '2013-03-14 11:46:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1328', 'jsph', '2013-03-14 11:47:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1329', 'jsph', '2013-03-14 11:51:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1330', 'jsph', '2013-03-14 11:52:31', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1331', 'jsph', '2013-03-14 11:53:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1332', 'jsph', '2013-03-14 11:53:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1333', 'jsph', '2013-03-14 11:58:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1334', 'jsph', '2013-03-14 12:33:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1335', 'jsph', '2013-03-14 12:33:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1336', 'jsph', '2013-03-14 12:38:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1337', 'jsph', '2013-03-14 12:45:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1338', 'jsph', '2013-03-14 12:46:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1339', 'jsph', '2013-03-14 12:52:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1340', 'jsph', '2013-03-14 12:53:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1341', 'jsph', '2013-03-14 12:53:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1342', 'jsph', '2013-03-14 12:55:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1343', 'jsph', '2013-03-14 13:17:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1344', 'jsph', '2013-03-14 13:18:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1345', 'jsph', '2013-03-14 13:18:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1346', 'jsph', '2013-03-14 13:19:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1347', 'jsph', '2013-03-14 13:20:03', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1348', 'jsph', '2013-03-14 13:20:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1349', 'jsph', '2013-03-14 13:21:26', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1350', 'jsph', '2013-03-14 13:22:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1351', 'jsph', '2013-03-14 13:25:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1352', 'jsph', '2013-03-14 13:31:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1353', 'jsph', '2013-03-14 13:32:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1354', 'jsph', '2013-03-14 13:32:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1355', 'jsph', '2013-03-14 13:33:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1356', 'jsph', '2013-03-14 13:34:02', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1357', 'jsph', '2013-03-14 13:38:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1358', 'jsph', '2013-03-14 13:43:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1359', 'jsph', '2013-03-14 13:46:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1360', 'jsph', '2013-03-14 13:48:27', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1361', 'jsph', '2013-03-14 14:33:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1362', 'jsph', '2013-03-14 14:34:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1363', 'jsph', '2013-03-14 14:35:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1364', 'jsph', '2013-03-14 14:36:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1365', 'jsph', '2013-03-14 14:48:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1366', 'jsph', '2013-03-14 14:49:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1367', 'jsph', '2013-03-14 15:12:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1368', 'jsph', '2013-03-14 15:13:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1369', 'jsph', '2013-03-14 15:20:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1370', 'jsph', '2013-03-14 15:22:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1371', 'jsph', '2013-03-14 15:23:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1372', 'jsph', '2013-03-14 15:38:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1373', 'jsph', '2013-03-14 15:38:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1374', 'jsph', '2013-03-14 15:39:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1375', 'jsph', '2013-03-14 15:39:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1376', 'jsph', '2013-03-14 15:40:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1377', 'jsph', '2013-03-14 15:40:38', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1378', 'jsph', '2013-03-14 15:45:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1379', 'jsph', '2013-03-14 15:47:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1380', 'jsph', '2013-03-14 15:47:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1381', 'jsph', '2013-03-14 15:58:13', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1382', 'jsph', '2013-03-14 15:58:50', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1383', 'jsph', '2013-03-14 16:00:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1384', 'jsph', '2013-03-14 16:01:09', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1385', 'jsph', '2013-03-14 16:11:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1386', 'jsph', '2013-03-14 16:15:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1387', 'jsph', '2013-03-14 16:21:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1388', 'jsph', '2013-03-14 16:21:32', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1389', 'jsph', '2013-03-14 16:22:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1390', 'jsph', '2013-03-14 16:24:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1391', 'jsph', '2013-03-14 16:24:58', '0', '', 'Added a new part name : Oil Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1392', 'jsph', '2013-03-14 16:25:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1393', 'jsph', '2013-03-14 16:26:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1394', 'jsph', '2013-03-14 16:27:39', '0', '', 'Added a new brand : FORCE.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1395', 'jsph', '2013-03-14 16:28:24', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1396', 'jsph', '2013-03-14 16:29:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1397', 'jsph', '2013-03-14 16:30:24', '0', '', 'Added a new brand : DAIHATSU.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1398', 'jsph', '2013-03-14 16:31:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1399', 'jsph', '2013-03-14 16:39:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1400', 'jsph', '2013-03-14 16:40:45', '0', '', 'Added a new model : FT.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1401', 'jsph', '2013-03-14 16:41:43', '2', '', 'Delete FORCE - FT from models list.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1402', 'jsph', '2013-03-14 16:43:35', '0', '', 'Added a new model : FT.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1403', 'jsph', '2013-03-14 16:43:54', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1404', 'jsph', '2013-03-14 16:45:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1405', 'jsph', '2013-03-14 16:46:10', '0', '', 'Added a new unit of measurement : Kg.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1406', 'jsph', '2013-03-14 16:49:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1407', 'jsph', '2013-03-16 07:16:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1408', 'jsph', '2013-03-16 07:16:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1409', 'jsph', '2013-03-16 07:26:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1410', 'jsph', '2013-03-16 07:27:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1411', 'jsph', '2013-03-16 08:10:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1412', 'jsph', '2013-03-16 08:12:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1413', 'jsph', '2013-03-16 08:22:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1414', 'jsph', '2013-03-16 08:22:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1415', 'jsph', '2013-03-16 08:23:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1416', 'jsph', '2013-03-16 08:24:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1417', 'jsph', '2013-03-16 08:25:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1418', 'jsph', '2013-03-16 08:27:01', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1419', 'jsph', '2013-03-16 09:09:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1420', 'jsph', '2013-03-16 09:10:53', '0', '', 'Added a new part name : Bearing Clutch.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1421', 'jsph', '2013-03-16 09:14:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1422', 'jsph', '2013-03-16 09:16:24', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1423', 'jsph', '2013-03-16 09:17:35', '0', '', 'Added a new brand : PIRELLI.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1424', 'jsph', '2013-03-16 09:20:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1425', 'jsph', '2013-03-16 09:21:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1426', 'jsph', '2013-03-16 09:22:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1427', 'jsph', '2013-03-16 09:23:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1428', 'jsph', '2013-03-16 09:29:27', '0', 'PART-CSPT-FZE-00002', 'Added a new part : 235-85-R16 - Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1429', 'jsph', '2013-03-16 09:30:28', '1', 'PART-CSPT-FZE-00002', 'Updated part : 235-85-R16 - Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1430', 'jsph', '2013-03-16 09:30:46', '1', 'PART-CSPT-FZE-00002', 'Updated part : 235-85-R16 - Tires.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1431', 'jsph', '2013-03-16 09:30:53', '1', 'PART-CSPT-FZE-00001', 'Updated part : 75513 - Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1432', 'jsph', '2013-03-16 10:07:41', '0', '', 'Added a new part name : Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1433', 'jsph', '2013-03-16 10:07:54', '0', '', 'Added a new brand : FORD.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1434', 'jsph', '2013-03-16 10:08:07', '0', '', 'Added a new model : EXPEDITION.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1435', 'jsph', '2013-03-16 10:08:23', '0', 'PART-CSPT-FZE-00003', 'Added a new part : 7W7Z7052A - Seal (Seal).', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1436', 'jsph', '2013-03-16 10:16:22', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1437', 'jsph', '2013-03-16 10:21:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1438', 'jsph', '2013-03-16 10:22:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1439', 'jsph', '2013-03-16 10:22:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1440', 'jsph', '2013-03-16 10:22:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1441', 'jsph', '2013-03-16 11:25:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1442', 'jsph', '2013-03-16 11:27:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1443', 'jsph', '2013-03-16 11:28:59', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1444', 'jsph', '2013-03-16 11:30:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1445', 'jsph', '2013-03-16 11:32:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1446', 'jsph', '2013-03-16 11:33:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1447', 'jsph', '2013-03-16 11:34:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1448', 'jsph', '2013-03-16 11:44:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1449', 'jsph', '2013-03-16 11:48:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1450', 'jsph', '2013-03-16 11:49:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1451', 'jsph', '2013-03-16 11:54:23', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1452', 'jsph', '2013-03-16 11:55:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1453', 'jsph', '2013-03-16 11:59:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1454', 'jsph', '2013-03-16 12:01:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1455', 'jsph', '2013-03-16 12:08:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1456', 'jsph', '2013-03-16 12:35:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1457', 'jsph', '2013-03-16 12:37:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1458', 'jsph', '2013-03-16 12:38:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1459', 'jsph', '2013-03-16 12:43:31', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1460', 'jsph', '2013-03-16 13:28:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1461', 'jsph', '2013-03-16 13:29:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1462', 'jsph', '2013-03-16 13:30:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1463', 'jsph', '2013-03-16 15:45:59', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1464', 'jsph', '2013-03-16 15:57:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1465', 'jsph', '2013-03-16 15:57:48', '1', '', 'Updated part name : Combination Wrench to Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1466', 'jsph', '2013-03-16 15:58:08', '1', '', 'Updated part name : Wrench to Combination Wrench.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1467', 'jsph', '2013-03-16 16:21:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1468', 'jsph', '2013-03-16 16:30:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1469', 'jsph', '2013-03-16 16:30:54', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1470', 'jsph', '2013-03-16 16:33:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1471', 'jsph', '2013-03-16 16:34:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1472', 'jsph', '2013-03-16 16:44:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1473', 'jsph', '2013-03-16 16:47:36', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1474', 'jsph', '2013-03-16 16:55:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1475', 'jsph', '2013-03-16 16:56:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1476', 'jsph', '2013-03-16 21:07:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1477', 'jsph', '2013-03-16 21:08:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1478', 'jsph', '2013-03-17 07:39:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1479', 'jsph', '2013-03-17 07:39:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1480', 'jsph', '2013-03-17 07:40:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1481', 'jsph', '2013-03-17 07:46:19', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1482', 'jsph', '2013-03-17 10:38:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1483', 'jsph', '2013-03-17 10:39:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1484', 'jsph', '2013-03-17 10:39:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1485', 'jsph', '2013-03-17 10:40:00', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1486', 'jsph', '2013-03-17 10:40:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1487', 'jsph', '2013-03-17 10:40:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1488', 'jsph', '2013-03-17 10:46:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1489', 'jsph', '2013-03-17 10:46:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1490', 'jsph', '2013-03-17 15:00:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1491', 'jsph', '2013-03-17 15:01:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1492', 'jsph', '2013-03-17 15:02:46', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1493', 'jsph', '2013-03-17 15:04:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1494', 'jsph', '2013-03-17 15:06:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1495', 'jsph', '2013-03-17 15:11:56', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1496', 'jsph', '2013-03-17 15:18:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1497', 'jsph', '2013-03-17 15:21:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1498', 'jsph', '2013-03-17 15:22:35', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1499', 'jsph', '2013-03-17 15:25:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1500', 'jsph', '2013-03-17 15:25:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1501', 'jsph', '2013-03-17 15:29:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1502', 'jsph', '2013-03-17 15:39:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1503', 'jsph', '2013-03-17 15:40:32', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1504', 'jsph', '2013-03-17 15:43:25', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1505', 'jsph', '2013-03-17 15:44:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1506', 'jsph', '2013-03-17 15:44:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1507', 'jsph', '2013-03-17 15:45:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1508', 'jsph', '2013-03-17 15:48:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1509', 'jsph', '2013-03-17 15:49:11', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1510', 'jsph', '2013-03-17 15:50:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1511', 'jsph', '2013-03-17 15:52:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1512', 'jsph', '2013-03-17 16:02:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1513', 'jsph', '2013-03-17 16:03:46', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1514', 'jsph', '2013-03-17 16:21:04', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1515', 'jsph', '2013-03-17 16:23:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1516', 'jsph', '2013-03-17 16:24:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1517', 'jsph', '2013-03-17 16:26:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1518', 'jsph', '2013-03-17 16:42:07', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1519', 'jsph', '2013-03-17 16:42:48', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1520', 'jsph', '2013-03-17 16:45:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1521', 'jsph', '2013-03-17 16:47:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1522', 'jsph', '2013-03-17 16:50:17', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1523', 'jsph', '2013-03-17 17:08:45', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1524', 'jsph', '2013-03-17 17:09:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1525', 'jsph', '2013-03-17 17:16:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1526', 'jsph', '2013-03-17 17:18:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1527', 'jsph', '2013-03-17 17:20:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1528', 'jsph', '2013-03-17 17:21:30', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1529', 'jsph', '2013-03-17 17:24:16', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1530', 'jsph', '2013-03-18 07:28:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1531', 'jsph', '2013-03-18 07:33:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1532', 'jsph', '2013-03-18 07:58:49', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1533', 'jsph', '2013-03-18 08:01:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1534', 'jsph', '2013-03-18 08:06:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1535', 'jsph', '2013-03-18 08:16:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1536', 'jsph', '2013-03-18 14:02:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1537', 'jsph', '2013-03-18 14:02:44', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1538', 'jsph', '2013-03-18 14:13:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1539', 'jsph', '2013-03-18 14:23:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1540', 'jsph', '2013-03-18 14:26:33', '0', 'ADJ-CSPT-FZE-00001', 'Added a new stock adjustment : ADJ-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1541', 'jsph', '2013-03-18 14:28:12', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1542', 'jsph', '2013-03-18 14:28:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1543', 'jsph', '2013-03-18 14:29:54', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1544', 'jsph', '2013-03-18 14:31:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1545', 'jsph', '2013-03-18 14:32:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1546', 'jsph', '2013-03-18 14:44:20', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1547', 'jsph', '2013-03-18 14:46:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1548', 'jsph', '2013-03-18 14:50:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1549', 'jsph', '2013-03-18 14:53:31', '1', 'ADJ-CSPT-FZE-00001', 'Approved stock adjustment : ADJ-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1550', 'jsph', '2013-03-18 14:55:00', '17', 'ADJ-CSPT-FZE-00001', 'Closed stock adjustment : ADJ-CSPT-FZE-00001.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1551', 'jsph', '2013-03-18 15:01:36', '0', 'ADJ-CSPT-FZE-00002', 'Added a new stock adjustment : ADJ-CSPT-FZE-00002.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1552', 'jsph', '2013-03-18 15:01:52', '1', 'ADJ-CSPT-FZE-00002', 'Approved stock adjustment : ADJ-CSPT-FZE-00002.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1553', 'jsph', '2013-03-18 15:02:06', '17', 'ADJ-CSPT-FZE-00002', 'Closed stock adjustment : ADJ-CSPT-FZE-00002.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1554', 'jsph', '2013-03-18 15:14:51', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1555', 'jsph', '2013-03-18 15:16:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1556', 'jsph', '2013-03-18 15:21:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1557', 'jsph', '2013-03-18 15:25:26', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1558', 'jsph', '2013-03-18 15:32:31', '0', 'ADJ-CSPT-FZE-00004', 'Added a new stock adjustment : ADJ-CSPT-FZE-00004.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1559', 'jsph', '2013-03-18 15:38:17', '0', 'ADJ-CSPT-FZE-00003', 'Added a new stock adjustment : ADJ-CSPT-FZE-00003.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1560', 'jsph', '2013-03-18 15:39:56', '1', 'ADJ-CSPT-FZE-00003', 'Approved stock adjustment : ADJ-CSPT-FZE-00003.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1561', 'jsph', '2013-03-18 15:40:34', '17', 'ADJ-CSPT-FZE-00003', 'Closed stock adjustment : ADJ-CSPT-FZE-00003.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1562', 'jsph', '2013-03-18 15:44:47', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1563', 'jsph', '2013-03-18 15:44:57', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1564', 'jsph', '2013-03-18 15:53:06', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1565', 'jsph', '2013-03-18 15:56:48', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1566', 'jsph', '2013-03-18 15:59:52', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1567', 'jsph', '2013-03-18 16:01:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1568', 'jsph', '2013-03-18 16:01:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1569', 'jsph', '2013-03-18 16:08:15', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1570', 'jsph', '2013-03-18 16:08:30', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1571', 'jsph', '2013-03-18 16:08:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1572', 'jsph', '2013-03-18 16:11:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1573', 'jsph', '2013-03-18 16:14:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1574', 'jsph', '2013-03-18 16:18:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1575', 'jsph', '2013-03-18 16:21:34', '0', 'ADJ-CSPT-FZE-00004', 'Added a new stock adjustment : ADJ-CSPT-FZE-00004.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1576', 'jsph', '2013-03-18 16:21:57', '1', 'ADJ-CSPT-FZE-00004', 'Approved stock adjustment : ADJ-CSPT-FZE-00004.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1577', 'jsph', '2013-03-18 16:22:14', '17', 'ADJ-CSPT-FZE-00004', 'Closed stock adjustment : ADJ-CSPT-FZE-00004.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1578', 'jsph', '2013-03-18 16:23:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1579', 'jsph', '2013-03-18 16:29:32', '0', 'ADJ-CSPT-FZE-00005', 'Added a new stock adjustment : ADJ-CSPT-FZE-00005.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1580', 'jsph', '2013-03-18 16:29:47', '1', 'ADJ-CSPT-FZE-00005', 'Cancelled stock adjustment : ADJ-CSPT-FZE-00005.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1581', 'jsph', '2013-03-18 16:45:25', '0', 'ADJ-CSPT-FZE-00006', 'Added a new stock adjustment : ADJ-CSPT-FZE-00006.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1582', 'jsph', '2013-03-18 16:45:47', '1', 'ADJ-CSPT-FZE-00006', 'Cancelled stock adjustment : ADJ-CSPT-FZE-00006.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1583', 'jsph', '2013-03-18 16:54:45', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1584', 'jsph', '2013-03-18 17:00:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1585', 'jsph', '2013-03-18 17:02:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1586', 'jsph', '2013-03-18 17:05:36', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1587', 'jsph', '2013-03-18 17:06:57', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1588', 'jsph', '2013-03-18 17:21:42', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1589', 'jsph', '2013-03-18 17:25:00', '0', 'ADJ-CSPT-FZE-00007', 'Added a new stock adjustment : ADJ-CSPT-FZE-00007.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1590', 'jsph', '2013-03-18 17:25:01', '1', 'ADJ-CSPT-FZE-00007', 'Added a new stock adjustment : ADJ-CSPT-FZE-00007.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1591', 'jsph', '2013-03-18 17:25:06', '2', 'ADJ-CSPT-FZE-00007', 'Deletes stock adjustment : ADJ-CSPT-FZE-00007.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1592', 'jsph', '2013-03-18 17:26:24', '5', '', 'Exported user logs into : C:\\Users\\user\\Desktop\\userlogs.xls.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1593', 'jsph', '2013-03-18 17:27:05', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1594', 'jsph', '2013-03-18 17:33:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1595', 'jsph', '2013-03-18 17:34:29', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1596', 'jsph', '2013-03-18 17:35:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1597', 'jsph', '2013-03-18 17:36:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1598', 'jsph', '2013-03-19 07:44:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1599', 'jsph', '2013-03-19 07:47:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1600', 'jsph', '2013-03-19 07:48:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1601', 'jsph', '2013-03-19 08:29:18', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1602', 'jsph', '2013-03-19 08:30:46', '0', 'ADJ-CSPT-FZE-00008', 'Added a new stock adjustment : ADJ-CSPT-FZE-00008.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1603', 'jsph', '2013-03-19 08:30:50', '1', 'ADJ-CSPT-FZE-00008', 'Approved stock adjustment : ADJ-CSPT-FZE-00008.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1604', 'jsph', '2013-03-19 08:30:54', '17', 'ADJ-CSPT-FZE-00008', 'Closed stock adjustment : ADJ-CSPT-FZE-00008.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1605', 'jsph', '2013-03-19 08:31:14', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1606', 'jsph', '2013-03-19 08:32:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1607', 'jsph', '2013-03-19 08:34:44', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1608', 'jsph', '2013-03-19 08:38:23', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1609', 'jsph', '2013-03-19 08:39:23', '0', 'ADJ-CSPT-FZE-00009', 'Added a new stock adjustment : ADJ-CSPT-FZE-00009.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1610', 'jsph', '2013-03-19 08:39:32', '1', 'ADJ-CSPT-FZE-00009', 'Approved stock adjustment : ADJ-CSPT-FZE-00009.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1611', 'jsph', '2013-03-19 08:39:36', '17', 'ADJ-CSPT-FZE-00009', 'Closed stock adjustment : ADJ-CSPT-FZE-00009.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1612', 'jsph', '2013-03-19 08:39:49', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1613', 'jsph', '2013-03-19 08:39:55', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1614', 'jsph', '2013-03-19 08:40:34', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1615', 'jsph', '2013-03-19 08:43:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1616', 'jsph', '2013-03-19 08:44:09', '0', 'ADJ-CSPT-FZE-00010', 'Added a new stock adjustment : ADJ-CSPT-FZE-00010.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1617', 'jsph', '2013-03-19 08:44:46', '2', 'ADJ-CSPT-FZE-00010', 'Deletes stock adjustment : ADJ-CSPT-FZE-00010.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1618', 'jsph', '2013-03-19 08:46:53', '0', 'ADJ-CSPT-FZE-00011', 'Added a new stock adjustment : ADJ-CSPT-FZE-00011.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1619', 'jsph', '2013-03-19 08:47:06', '1', 'ADJ-CSPT-FZE-00011', 'Added a new stock adjustment : ADJ-CSPT-FZE-00011.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1620', 'jsph', '2013-03-19 08:47:31', '1', 'ADJ-CSPT-FZE-00011', 'Approved stock adjustment : ADJ-CSPT-FZE-00011.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1621', 'jsph', '2013-03-19 08:47:42', '17', 'ADJ-CSPT-FZE-00011', 'Closed stock adjustment : ADJ-CSPT-FZE-00011.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1622', 'jsph', '2013-03-19 08:51:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1623', 'jsph', '2013-03-19 09:09:31', '0', 'ADJ-CSPT-FZE-00012', 'Added a new stock adjustment : ADJ-CSPT-FZE-00012.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1624', 'jsph', '2013-03-19 09:09:43', '1', 'ADJ-CSPT-FZE-00012', 'Approved stock adjustment : ADJ-CSPT-FZE-00012.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1625', 'jsph', '2013-03-19 09:09:49', '17', 'ADJ-CSPT-FZE-00012', 'Closed stock adjustment : ADJ-CSPT-FZE-00012.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1626', 'jsph', '2013-03-19 09:21:33', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1627', 'jsph', '2013-03-19 09:25:05', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1628', 'jsph', '2013-03-19 09:54:39', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1629', 'jsph', '2013-03-19 09:55:17', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1630', 'jsph', '2013-03-19 09:59:31', '14', '', 'Optimized Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1631', 'jsph', '2013-03-19 10:00:06', '14', '', 'Repaired Table', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1632', 'jsph', '2013-03-19 10:05:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1633', 'jsph', '2013-03-19 10:29:35', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1634', 'jsph', '2013-03-19 10:29:50', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1635', 'jsph', '2013-03-19 10:30:14', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1636', 'jsph', '2013-03-19 10:30:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1637', 'jsph', '2013-03-19 10:31:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1638', 'jsph', '2013-03-19 10:37:20', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1639', 'jsph', '2013-03-19 10:44:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1640', 'jsph', '2013-03-19 10:45:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1641', 'jsph', '2013-03-19 10:46:01', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1642', 'jsph', '2013-03-19 10:46:28', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1643', 'jsph', '2013-03-19 10:47:33', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1644', 'jsph', '2013-03-19 10:47:56', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1645', 'jsph', '2013-03-19 10:48:45', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1646', 'jsph', '2013-03-19 10:50:09', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1647', 'jsph', '2013-03-19 10:54:28', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1648', 'jsph', '2013-03-19 11:17:06', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1649', 'jsph', '2013-03-19 11:47:21', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1650', 'jsph', '2013-03-19 11:57:27', '0', 'PART-CSPT-FZE-00004', 'Added a new part : 7W7Z7052B - Seal (Seal).', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1651', 'jsph', '2013-03-19 12:34:06', '0', 'PART-CSPT-FZE-00005', 'Added a new part : 7W7Z7052C - Seal (Seal).', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1652', 'jsph', '2013-03-19 12:35:13', '1', 'PART-CSPT-FZE-00005', 'Updated part : 7W7Z7052C - Seal (Seal).', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1653', 'jsph', '2013-03-19 12:41:10', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1654', 'jsph', '2013-03-19 13:22:08', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1655', 'jsph', '2013-03-19 13:25:37', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1656', 'jsph', '2013-03-19 13:26:08', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1657', 'jsph', '2013-03-19 13:30:34', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1658', 'jsph', '2013-03-19 13:42:21', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1659', 'jsph', '2013-03-19 13:42:53', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1660', 'jsph', '2013-03-19 14:14:40', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1661', 'jsph', '2013-03-19 15:03:41', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1662', 'jsph', '2013-03-19 15:16:38', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1663', 'jsph', '2013-03-19 15:17:27', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1664', 'jsph', '2013-03-19 15:19:40', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1665', 'jsph', '2013-03-19 15:20:15', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1666', 'jsph', '2013-03-19 15:46:29', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1667', 'jsph', '2013-03-19 15:50:18', '1', 'PART-CSPT-FZE-00003', 'Un-set 7W7Z7052B - Seal as supersession of 7W7Z7052A - Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1668', 'jsph', '2013-03-19 15:52:58', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1669', 'jsph', '2013-03-19 15:53:12', '1', 'PART-CSPT-FZE-00003', 'Added 7W7Z7052B - Seal as supersession of 7W7Z7052A - Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1670', 'jsph', '2013-03-19 15:54:18', '1', 'PART-CSPT-FZE-00003', 'Un-set 7W7Z7052C - Seal as supersession of 7W7Z7052A - Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1671', 'jsph', '2013-03-19 15:54:35', '1', 'PART-CSPT-FZE-00003', 'Added 7W7Z7052C - Seal as supersession of 7W7Z7052A - Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1672', 'jsph', '2013-03-19 15:55:18', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1673', 'jsph', '2013-03-19 15:56:39', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1674', 'jsph', '2013-03-19 15:57:07', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1675', 'jsph', '2013-03-19 15:57:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1676', 'jsph', '2013-03-19 15:59:45', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1677', 'jsph', '2013-03-19 16:09:44', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1678', 'jsph', '2013-03-19 16:10:12', '1', 'PART-CSPT-FZE-00003', 'Un-set 7W7Z7052B - Seal as supersession of 7W7Z7052A - Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1679', 'jsph', '2013-03-19 16:15:02', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1680', 'jsph', '2013-03-19 16:15:58', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1681', 'jsph', '2013-03-19 16:19:19', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1682', 'jsph', '2013-03-19 16:21:11', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1683', 'jsph', '2013-03-19 16:26:22', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1684', 'jsph', '2013-03-19 16:27:09', '1', 'PART-CSPT-FZE-00003', 'Added 7W7Z7052B - Seal as supersession of 7W7Z7052A - Seal.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1685', 'jsph', '2013-03-19 16:31:41', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1686', 'jsph', '2013-03-19 16:40:13', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1687', 'jsph', '2013-03-19 16:40:55', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1688', 'jsph', '2013-03-19 16:44:47', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1689', 'jsph', '2013-03-19 16:45:49', '0', 'PART-CSPT-FZE-00006', 'Added a new part : 7W7Z7052D - Seal (Seal).', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1690', 'jsph', '2013-03-19 16:49:04', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1691', 'jsph', '2013-03-19 16:49:10', '15', '', 'Logs into the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');
INSERT INTO `userlogs` VALUES ('1692', 'jsph', '2013-03-19 16:50:53', '16', '', 'Logs off from the application.', '0.00', 'USD', '0.00', 'JLREYES', '127.0.0.1');

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Username` varchar(30) NOT NULL,
  `Password` varchar(150) default '',
  `FirstName` varchar(150) default '',
  `MiddleName` varchar(150) default '',
  `LastName` varchar(150) default '',
  `Position` varchar(150) default '',
  `Department` varchar(150) default '',
  `Active` tinyint(5) default '0',
  `Role` varchar(150) default '',
  `Privileges` varchar(1500) default '',
  `AllCustomers` tinyint(5) default '0',
  `AllCompanies` tinyint(4) default '0',
  `DateCreated` datetime default '1900-01-01 00:00:00',
  `LastModified` timestamp NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `Voided` tinyint(4) default '0',
  `DateVoided` datetime default NULL,
  PRIMARY KEY  (`Username`),
  KEY `userposition` (`Position`),
  KEY `userdepartment` (`Department`),
  CONSTRAINT `userdepartment` FOREIGN KEY (`Department`) REFERENCES `departments` (`Department`) ON UPDATE CASCADE,
  CONSTRAINT `userposition` FOREIGN KEY (`Position`) REFERENCES `positions` (`Position`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('dqadmin', 'p4RydzCxq44=', 'Super', '', 'User', 'Systems Administrator', 'Systems Support', '1', 'O8/vaUGdSRrLWRROYgeQVA==', '111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111', '1', '1', '2013-03-02 12:20:59', '2013-03-03 11:31:56', '0', null);
INSERT INTO `users` VALUES ('jsph', '5CVGoAnZhE/U8LyjKoXpnA==', 'Joseph Lambert', '', 'Reyes', 'Project Team Leader', 'Systems Development', '1', 'O8/vaUGdSRrLWRROYgeQVA==', '111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111', '1', '1', '2013-02-11 11:30:22', '2013-02-26 17:29:02', '0', null);

-- ----------------------------
-- Procedure structure for `AnalyzeTables`
-- ----------------------------
DROP PROCEDURE IF EXISTS `AnalyzeTables`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AnalyzeTables`()
BEGIN
DECLARE done INT DEFAULT 0;
DECLARE tablename varchar(150) DEFAULT '';
DECLARE currenttables longtext;
DECLARE curtables CURSOR FOR
SELECT tbl.TABLE_NAME FROM information_schema.`TABLES` AS tbl WHERE (tbl.TABLE_SCHEMA = DATABASE());
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
OPEN curtables;
 REPEAT
   FETCH curtables INTO tablename;
    IF NOT done THEN
				IF (currenttables IS NULL) THEN
					SET currenttables = tablename;
				ELSE
					IF (currenttables NOT LIKE '') THEN
						SET currenttables = CONCAT(currenttables, ', ', tablename);
					ELSE
						SET currenttables = tablename;
					END IF;
				END IF;
    END IF;
  UNTIL done END REPEAT;
CLOSE curtables;
SET @sqlstatement = CONCAT('ANALYZE TABLE ', currenttables);
PREPARE querystatement FROM @sqlstatement;
EXECUTE querystatement;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `CheckTables`
-- ----------------------------
DROP PROCEDURE IF EXISTS `CheckTables`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckTables`()
BEGIN
DECLARE done INT DEFAULT 0;
DECLARE tablename varchar(150) DEFAULT '';
DECLARE currenttables longtext;
DECLARE curtables CURSOR FOR
SELECT tbl.TABLE_NAME FROM information_schema.`TABLES` AS tbl WHERE (tbl.TABLE_SCHEMA = DATABASE());
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
OPEN curtables;
 REPEAT
   FETCH curtables INTO tablename;
    IF NOT done THEN
				IF (currenttables IS NULL) THEN
					SET currenttables = tablename;
				ELSE
					IF (currenttables NOT LIKE '') THEN
						SET currenttables = CONCAT(currenttables, ', ', tablename);
					ELSE
						SET currenttables = tablename;
					END IF;
				END IF;
    END IF;
  UNTIL done END REPEAT;
CLOSE curtables;
SET @sqlstatement = CONCAT('CHECK TABLE ', currenttables);
PREPARE querystatement FROM @sqlstatement;
EXECUTE querystatement;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `CreateTriggerList`
-- ----------------------------
DROP PROCEDURE IF EXISTS `CreateTriggerList`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateTriggerList`()
BEGIN
DECLARE done INT DEFAULT 0;
DECLARE tablename varchar(150) DEFAULT '';
DECLARE currentstatement longtext;
DECLARE pk varchar(255) DEFAULT '';
DECLARE curtables CURSOR FOR
SELECT tbl.TABLE_NAME FROM information_schema.`TABLES` AS tbl WHERE (tbl.TABLE_SCHEMA = DATABASE()) AND (tbl.TABLE_NAME NOT IN('deleteditems', 'locks', 'updateditems', 'userlogs'));
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
SET @sqlstatement = '';
SET currentstatement = '';
SET pk = '';
OPEN curtables;
 REPEAT
   FETCH curtables INTO tablename;
    IF NOT done THEN
			SET pk = IFNULL((GetPrimaryKey(tablename)), '');
			
			IF (RTRIM(pk) NOT LIKE '') THEN
				SET currentstatement = '';
				SET currentstatement = CONCAT('DROP TRIGGER IF EXISTS `', tablename,'deleteitems`;
																			 DELIMITER ;;
																			 CREATE TRIGGER `', tablename,'deleteitems` AFTER DELETE ON `', tablename,'`
																			 FOR EACH ROW
																			 BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 (''', tablename,''', CAST(OLD.`', pk,'` AS char(255)));
																			 END;;
																			 DELIMITER ;
																			 DROP TRIGGER IF EXISTS `', tablename,'removedeleteitems`;
																			 DELIMITER ;;
																			 CREATE TRIGGER `', tablename, 'removedeleteitems` AFTER INSERT ON `', tablename,'`
																			 FOR EACH ROW
																			 BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE ''', tablename,''') AND (`Value` LIKE CAST(NEW.`', pk,'` AS char(255)));
																			 END;;
																			 DELIMITER ;
																			 DROP TRIGGER IF EXISTS `', tablename,'updateitems`;
																			 DELIMITER ;;
																			 CREATE TRIGGER `', tablename, 'updateitems` AFTER UPDATE ON `', tablename,'`
																			 FOR EACH ROW
																			 BEGIN
																				 IF (OLD.`', pk,'` <> NEW.`', pk,'`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 (''', tablename,''', OLD.`', pk,'`, NEW.`', pk,'`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE ''', tablename,''') AND (`Value` LIKE CAST(NEW.`', pk,'` AS char(255))); 
																				   ',
																					 CASE WHEN tablename LIKE 'brand' THEN CONCAT('UPDATE `parts` SET LastModified = NOW() WHERE (`Brand` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'currencies' THEN CONCAT('UPDATE `currencydenominations` SET LastModified = NOW() WHERE (`Currency` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'currencies' THEN CONCAT('UPDATE `currencyrates` SET LastModified = NOW() WHERE (`Currency` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'departments' THEN CONCAT('UPDATE `users` SET LastModified = NOW() WHERE (`Department` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'measurements' THEN CONCAT('UPDATE `parts` SET LastModified = NOW() WHERE (`Unit` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																				   CASE WHEN tablename LIKE 'models' THEN CONCAT('UPDATE `parts` SET LastModified = NOW() WHERE (`Model` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,																					 
																					 CASE WHEN tablename LIKE 'partnames' THEN CONCAT('UPDATE `parts` SET LastModified = NOW() WHERE (`PartName` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'partcategories' THEN CONCAT('UPDATE `partnames` SET LastModified = NOW() WHERE (`PartCategory` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'positions' THEN CONCAT('UPDATE `users` SET LastModified = NOW() WHERE (`Position` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'users' THEN CONCAT('UPDATE `signatories` SET LastModified = NOW() WHERE (`Username` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					 CASE WHEN tablename LIKE 'users' THEN CONCAT('UPDATE `userlogs` SET LastModified = NOW() WHERE (`Username` IN(CAST(OLD.`', pk,'` AS char(255)), CAST(NEW.`', pk,'` AS char(255))));') ELSE '' END,
																					'
																				 END IF;
																			 END;;
																			 DELIMITER ;
																			 ');


				SET @sqlstatement = CONCAT(@sqlstatement, currentstatement);
			END IF;
    END IF;
  UNTIL done END REPEAT;
CLOSE curtables;


SELECT @sqlstatement AS `Sql`;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `OptimizeTables`
-- ----------------------------
DROP PROCEDURE IF EXISTS `OptimizeTables`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `OptimizeTables`()
BEGIN
DECLARE done INT DEFAULT 0;
DECLARE tablename varchar(150) DEFAULT '';
DECLARE currenttables longtext;
DECLARE curtables CURSOR FOR
SELECT tbl.TABLE_NAME FROM information_schema.`TABLES` AS tbl WHERE (tbl.TABLE_SCHEMA = DATABASE());
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
OPEN curtables;
 REPEAT
   FETCH curtables INTO tablename;
    IF NOT done THEN
				IF (currenttables IS NULL) THEN
					SET currenttables = tablename;
				ELSE
					IF (currenttables NOT LIKE '') THEN
						SET currenttables = CONCAT(currenttables, ', ', tablename);
					ELSE
						SET currenttables = tablename;
					END IF;
				END IF;
    END IF;
  UNTIL done END REPEAT;
CLOSE curtables;
SET @sqlstatement = CONCAT('OPTIMIZE TABLE ', currenttables);
PREPARE querystatement FROM @sqlstatement;
EXECUTE querystatement;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `RepairTables`
-- ----------------------------
DROP PROCEDURE IF EXISTS `RepairTables`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RepairTables`()
BEGIN
DECLARE done INT DEFAULT 0;
DECLARE tablename varchar(150) DEFAULT '';
DECLARE currenttables longtext;
DECLARE curtables CURSOR FOR
SELECT tbl.TABLE_NAME FROM information_schema.`TABLES` AS tbl WHERE (tbl.TABLE_SCHEMA = DATABASE());
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
OPEN curtables;
 REPEAT
   FETCH curtables INTO tablename;
    IF NOT done THEN
				IF (currenttables IS NULL) THEN
					SET currenttables = tablename;
				ELSE
					IF (currenttables NOT LIKE '') THEN
						SET currenttables = CONCAT(currenttables, ', ', tablename);
					ELSE
						SET currenttables = tablename;
					END IF;
				END IF;
    END IF;
  UNTIL done END REPEAT;
CLOSE curtables;
SET @sqlstatement = CONCAT('REPAIR TABLE ', currenttables);
PREPARE querystatement FROM @sqlstatement;
EXECUTE querystatement;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for `GetPrimaryKey`
-- ----------------------------
DROP FUNCTION IF EXISTS `GetPrimaryKey`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetPrimaryKey`(tablename varchar(255)) RETURNS varchar(150) CHARSET latin1
RETURN
(
SELECT
CAST(CASE WHEN tablename LIKE 'models' THEN 'ModelCode' WHEN tablename LIKE 'locations' THEN 'LocationCode' ELSE cols.COLUMN_NAME END AS char(255)) AS `Primary Key`
FROM
information_schema.`COLUMNS` AS cols
WHERE
cols.TABLE_SCHEMA = DATABASE() AND
cols.TABLE_NAME = tablename AND
cols.COLUMN_KEY = 'PRI'
LIMIT 1
)
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `accountsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `accountsremovedeleteitems` AFTER INSERT ON `accounts` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'accounts') AND (`Value` LIKE CAST(NEW.`AccountCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `accountsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `accountsupdateitems` AFTER UPDATE ON `accounts` FOR EACH ROW BEGIN
																				 IF (OLD.`AccountCode` <> NEW.`AccountCode`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('accounts', OLD.`AccountCode`, NEW.`AccountCode`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'accounts') AND (`Value` LIKE CAST(NEW.`AccountCode` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `accountsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `accountsdeleteitems` AFTER DELETE ON `accounts` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('accounts', CAST(OLD.`AccountCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `additionalchargesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `additionalchargesremovedeleteitems` AFTER INSERT ON `additionalcharges` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'additionalcharges') AND (`Value` LIKE CAST(NEW.`AdditionalCharge` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `additionalchargesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `additionalchargesupdateitems` AFTER UPDATE ON `additionalcharges` FOR EACH ROW BEGIN
																				 IF (OLD.`AdditionalCharge` <> NEW.`AdditionalCharge`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('additionalcharges', OLD.`AdditionalCharge`, NEW.`AdditionalCharge`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'additionalcharges') AND (`Value` LIKE CAST(NEW.`AdditionalCharge` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `additionalchargesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `additionalchargesdeleteitems` AFTER DELETE ON `additionalcharges` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('additionalcharges', CAST(OLD.`AdditionalCharge` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `bankmiscellaneousremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `bankmiscellaneousremovedeleteitems` AFTER INSERT ON `bankmiscellaneous` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'bankmiscellaneous') AND (`Value` LIKE CAST(NEW.`BankMiscellaneous` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `bankmiscellaneousupdateitems`;
DELIMITER ;;
CREATE TRIGGER `bankmiscellaneousupdateitems` AFTER UPDATE ON `bankmiscellaneous` FOR EACH ROW BEGIN
																				 IF (OLD.`BankMiscellaneous` <> NEW.`BankMiscellaneous`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('bankmiscellaneous', OLD.`BankMiscellaneous`, NEW.`BankMiscellaneous`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'bankmiscellaneous') AND (`Value` LIKE CAST(NEW.`BankMiscellaneous` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `bankmiscellaneousdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `bankmiscellaneousdeleteitems` AFTER DELETE ON `bankmiscellaneous` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('bankmiscellaneous', CAST(OLD.`BankMiscellaneous` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `banksremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `banksremovedeleteitems` AFTER INSERT ON `banks` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'banks') AND (`Value` LIKE CAST(NEW.`Bank` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `banksupdateitems`;
DELIMITER ;;
CREATE TRIGGER `banksupdateitems` AFTER UPDATE ON `banks` FOR EACH ROW BEGIN
																				 IF (OLD.`Bank` <> NEW.`Bank`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('banks', OLD.`Bank`, NEW.`Bank`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'banks') AND (`Value` LIKE CAST(NEW.`Bank` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `banksdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `banksdeleteitems` AFTER DELETE ON `banks` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('banks', CAST(OLD.`Bank` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `brandsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `brandsremovedeleteitems` AFTER INSERT ON `brands` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'brands') AND (`Value` LIKE CAST(NEW.`Brand` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `brandsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `brandsupdateitems` AFTER UPDATE ON `brands` FOR EACH ROW BEGIN
																				 IF (OLD.`Brand` <> NEW.`Brand`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('brands', OLD.`Brand`, NEW.`Brand`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'brands') AND (`Value` LIKE CAST(NEW.`Brand` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `brandsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `brandsdeleteitems` AFTER DELETE ON `brands` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('brands', CAST(OLD.`Brand` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `companiesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `companiesremovedeleteitems` AFTER INSERT ON `companies` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'companies') AND (`Value` LIKE CAST(NEW.`Company` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `companiesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `companiesupdateitems` AFTER UPDATE ON `companies` FOR EACH ROW BEGIN
																				 IF (OLD.`Company` <> NEW.`Company`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('companies', OLD.`Company`, NEW.`Company`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'companies') AND (`Value` LIKE CAST(NEW.`Company` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `companiesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `companiesdeleteitems` AFTER DELETE ON `companies` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('companies', CAST(OLD.`Company` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currenciesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `currenciesremovedeleteitems` AFTER INSERT ON `currencies` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'currencies') AND (`Value` LIKE CAST(NEW.`Currency` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currenciesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `currenciesupdateitems` AFTER UPDATE ON `currencies` FOR EACH ROW BEGIN
																				 IF (OLD.`Currency` <> NEW.`Currency`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('currencies', OLD.`Currency`, NEW.`Currency`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'currencies') AND (`Value` LIKE CAST(NEW.`Currency` AS char(255))); 
																				   UPDATE `currencydenominations` SET LastModified = NOW() WHERE (`Currency` IN(CAST(OLD.`Currency` AS char(255)), CAST(NEW.`Currency` AS char(255))));UPDATE `currencyrates` SET LastModified = NOW() WHERE (`Currency` IN(CAST(OLD.`Currency` AS char(255)), CAST(NEW.`Currency` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currenciesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `currenciesdeleteitems` AFTER DELETE ON `currencies` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('currencies', CAST(OLD.`Currency` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currencydenominationsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `currencydenominationsremovedeleteitems` AFTER INSERT ON `currencydenominations` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'currencydenominations') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currencydenominationsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `currencydenominationsupdateitems` AFTER UPDATE ON `currencydenominations` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('currencydenominations', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'currencydenominations') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currencydenominationsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `currencydenominationsdeleteitems` AFTER DELETE ON `currencydenominations` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('currencydenominations', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currencyratesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `currencyratesremovedeleteitems` AFTER INSERT ON `currencyrates` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'currencyrates') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currencyratesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `currencyratesupdateitems` AFTER UPDATE ON `currencyrates` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('currencyrates', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'currencyrates') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `currencyratesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `currencyratesdeleteitems` AFTER DELETE ON `currencyrates` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('currencyrates', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `customergroupsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `customergroupsremovedeleteitems` AFTER INSERT ON `customergroups` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'customergroups') AND (`Value` LIKE CAST(NEW.`CustomerGroup` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `customergroupsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `customergroupsupdateitems` AFTER UPDATE ON `customergroups` FOR EACH ROW BEGIN
																				 IF (OLD.`CustomerGroup` <> NEW.`CustomerGroup`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('customergroups', OLD.`CustomerGroup`, NEW.`CustomerGroup`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'customergroups') AND (`Value` LIKE CAST(NEW.`CustomerGroup` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `customergroupsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `customergroupsdeleteitems` AFTER DELETE ON `customergroups` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('customergroups', CAST(OLD.`CustomerGroup` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `customersremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `customersremovedeleteitems` AFTER INSERT ON `customers` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'customers') AND (`Value` LIKE CAST(NEW.`CustomerCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `customersupdateitems`;
DELIMITER ;;
CREATE TRIGGER `customersupdateitems` AFTER UPDATE ON `customers` FOR EACH ROW BEGIN
																				 IF (OLD.`CustomerCode` <> NEW.`CustomerCode`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('customers', OLD.`CustomerCode`, NEW.`CustomerCode`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'customers') AND (`Value` LIKE CAST(NEW.`CustomerCode` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `customersdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `customersdeleteitems` AFTER DELETE ON `customers` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('customers', CAST(OLD.`CustomerCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `departmentsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `departmentsremovedeleteitems` AFTER INSERT ON `departments` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'departments') AND (`Value` LIKE CAST(NEW.`Department` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `departmentsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `departmentsupdateitems` AFTER UPDATE ON `departments` FOR EACH ROW BEGIN
																				 IF (OLD.`Department` <> NEW.`Department`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('departments', OLD.`Department`, NEW.`Department`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'departments') AND (`Value` LIKE CAST(NEW.`Department` AS char(255))); 
																				   UPDATE `users` SET LastModified = NOW() WHERE (`Department` IN(CAST(OLD.`Department` AS char(255)), CAST(NEW.`Department` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `departmentsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `departmentsdeleteitems` AFTER DELETE ON `departments` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('departments', CAST(OLD.`Department` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `keysettingsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `keysettingsremovedeleteitems` AFTER INSERT ON `keysettings` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'keysettings') AND (`Value` LIKE CAST(NEW.`TableName` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `keysettingsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `keysettingsupdateitems` AFTER UPDATE ON `keysettings` FOR EACH ROW BEGIN
																				 IF (OLD.`TableName` <> NEW.`TableName`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('keysettings', OLD.`TableName`, NEW.`TableName`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'keysettings') AND (`Value` LIKE CAST(NEW.`TableName` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `keysettingsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `keysettingsdeleteitems` AFTER DELETE ON `keysettings` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('keysettings', CAST(OLD.`TableName` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `locationsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `locationsremovedeleteitems` AFTER INSERT ON `locations` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'locations') AND (`Value` LIKE CAST(NEW.`LocationCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `locationsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `locationsupdateitems` AFTER UPDATE ON `locations` FOR EACH ROW BEGIN
																				 IF (OLD.`LocationCode` <> NEW.`LocationCode`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('locations', OLD.`LocationCode`, NEW.`LocationCode`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'locations') AND (`Value` LIKE CAST(NEW.`LocationCode` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `locationsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `locationsdeleteitems` AFTER DELETE ON `locations` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('locations', CAST(OLD.`LocationCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `measurementsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `measurementsremovedeleteitems` AFTER INSERT ON `measurements` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'measurements') AND (`Value` LIKE CAST(NEW.`Unit` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `measurementsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `measurementsupdateitems` AFTER UPDATE ON `measurements` FOR EACH ROW BEGIN
																				 IF (OLD.`Unit` <> NEW.`Unit`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('measurements', OLD.`Unit`, NEW.`Unit`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'measurements') AND (`Value` LIKE CAST(NEW.`Unit` AS char(255))); 
																				   UPDATE `parts` SET LastModified = NOW() WHERE (`Unit` IN(CAST(OLD.`Unit` AS char(255)), CAST(NEW.`Unit` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `measurementsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `measurementsdeleteitems` AFTER DELETE ON `measurements` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('measurements', CAST(OLD.`Unit` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `modelsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `modelsremovedeleteitems` AFTER INSERT ON `models` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'models') AND (`Value` LIKE CAST(NEW.`ModelCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `modelsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `modelsupdateitems` AFTER UPDATE ON `models` FOR EACH ROW BEGIN
																				 IF (OLD.`ModelCode` <> NEW.`ModelCode`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('models', OLD.`ModelCode`, NEW.`ModelCode`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'models') AND (`Value` LIKE CAST(NEW.`ModelCode` AS char(255))); 
																				   UPDATE `parts` SET LastModified = NOW() WHERE (`Model` IN(CAST(OLD.`ModelCode` AS char(255)), CAST(NEW.`ModelCode` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `modelsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `modelsdeleteitems` AFTER DELETE ON `models` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('models', CAST(OLD.`ModelCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partcategoriesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `partcategoriesremovedeleteitems` AFTER INSERT ON `partcategories` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'partcategories') AND (`Value` LIKE CAST(NEW.`PartCategory` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partcategoriesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `partcategoriesupdateitems` AFTER UPDATE ON `partcategories` FOR EACH ROW BEGIN
																				 IF (OLD.`PartCategory` <> NEW.`PartCategory`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('partcategories', OLD.`PartCategory`, NEW.`PartCategory`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'partcategories') AND (`Value` LIKE CAST(NEW.`PartCategory` AS char(255))); 
																				   UPDATE `partnames` SET LastModified = NOW() WHERE (`PartCategory` IN(CAST(OLD.`PartCategory` AS char(255)), CAST(NEW.`PartCategory` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partcategoriesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `partcategoriesdeleteitems` AFTER DELETE ON `partcategories` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('partcategories', CAST(OLD.`PartCategory` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partnamesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `partnamesremovedeleteitems` AFTER INSERT ON `partnames` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'partnames') AND (`Value` LIKE CAST(NEW.`PartName` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partnamesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `partnamesupdateitems` AFTER UPDATE ON `partnames` FOR EACH ROW BEGIN
																				 IF (OLD.`PartName` <> NEW.`PartName`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('partnames', OLD.`PartName`, NEW.`PartName`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'partnames') AND (`Value` LIKE CAST(NEW.`PartName` AS char(255))); 
																				   UPDATE `parts` SET LastModified = NOW() WHERE (`PartName` IN(CAST(OLD.`PartName` AS char(255)), CAST(NEW.`PartName` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partnamesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `partnamesdeleteitems` AFTER DELETE ON `partnames` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('partnames', CAST(OLD.`PartName` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `partsremovedeleteitems` AFTER INSERT ON `parts` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'parts') AND (`Value` LIKE CAST(NEW.`PartCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `partsupdateitems` AFTER UPDATE ON `parts` FOR EACH ROW BEGIN
																				 IF (OLD.`PartCode` <> NEW.`PartCode`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('parts', OLD.`PartCode`, NEW.`PartCode`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'parts') AND (`Value` LIKE CAST(NEW.`PartCode` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `partsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `partsdeleteitems` AFTER DELETE ON `parts` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('parts', CAST(OLD.`PartCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `paymenttermsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `paymenttermsremovedeleteitems` AFTER INSERT ON `paymentterms` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'paymentterms') AND (`Value` LIKE CAST(NEW.`PaymentTerm` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `paymenttermsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `paymenttermsupdateitems` AFTER UPDATE ON `paymentterms` FOR EACH ROW BEGIN
																				 IF (OLD.`PaymentTerm` <> NEW.`PaymentTerm`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('paymentterms', OLD.`PaymentTerm`, NEW.`PaymentTerm`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'paymentterms') AND (`Value` LIKE CAST(NEW.`PaymentTerm` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `paymenttermsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `paymenttermsdeleteitems` AFTER DELETE ON `paymentterms` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('paymentterms', CAST(OLD.`PaymentTerm` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `positionsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `positionsremovedeleteitems` AFTER INSERT ON `positions` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'positions') AND (`Value` LIKE CAST(NEW.`Position` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `positionsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `positionsupdateitems` AFTER UPDATE ON `positions` FOR EACH ROW BEGIN
																				 IF (OLD.`Position` <> NEW.`Position`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('positions', OLD.`Position`, NEW.`Position`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'positions') AND (`Value` LIKE CAST(NEW.`Position` AS char(255))); 
																				   UPDATE `users` SET LastModified = NOW() WHERE (`Position` IN(CAST(OLD.`Position` AS char(255)), CAST(NEW.`Position` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `positionsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `positionsdeleteitems` AFTER DELETE ON `positions` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('positions', CAST(OLD.`Position` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `scriptsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `scriptsremovedeleteitems` AFTER INSERT ON `scripts` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'scripts') AND (`Value` LIKE CAST(NEW.`ReferenceNo` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `scriptsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `scriptsupdateitems` AFTER UPDATE ON `scripts` FOR EACH ROW BEGIN
																				 IF (OLD.`ReferenceNo` <> NEW.`ReferenceNo`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('scripts', OLD.`ReferenceNo`, NEW.`ReferenceNo`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'scripts') AND (`Value` LIKE CAST(NEW.`ReferenceNo` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `scriptsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `scriptsdeleteitems` AFTER DELETE ON `scripts` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('scripts', CAST(OLD.`ReferenceNo` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `settingsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `settingsremovedeleteitems` AFTER INSERT ON `settings` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'settings') AND (`Value` LIKE CAST(NEW.`Company` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `settingsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `settingsupdateitems` AFTER UPDATE ON `settings` FOR EACH ROW BEGIN
																				 IF (OLD.`Company` <> NEW.`Company`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('settings', OLD.`Company`, NEW.`Company`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'settings') AND (`Value` LIKE CAST(NEW.`Company` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `settingsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `settingsdeleteitems` AFTER DELETE ON `settings` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('settings', CAST(OLD.`Company` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `signatoriesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `signatoriesremovedeleteitems` AFTER INSERT ON `signatories` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'signatories') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `signatoriesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `signatoriesupdateitems` AFTER UPDATE ON `signatories` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('signatories', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'signatories') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `signatoriesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `signatoriesdeleteitems` AFTER DELETE ON `signatories` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('signatories', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockadjustmentdetailsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `stockadjustmentdetailsremovedeleteitems` AFTER INSERT ON `stockadjustmentdetails` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'stockadjustmentdetails') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockadjustmentdetailsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `stockadjustmentdetailsupdateitems` AFTER UPDATE ON `stockadjustmentdetails` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('stockadjustmentdetails', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'stockadjustmentdetails') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockadjustmentdetailsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `stockadjustmentdetailsdeleteitems` AFTER DELETE ON `stockadjustmentdetails` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('stockadjustmentdetails', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockadjustmentsremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `stockadjustmentsremovedeleteitems` AFTER INSERT ON `stockadjustments` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'stockadjustments') AND (`Value` LIKE CAST(NEW.`ReferenceNo` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockadjustmentsupdateitems`;
DELIMITER ;;
CREATE TRIGGER `stockadjustmentsupdateitems` AFTER UPDATE ON `stockadjustments` FOR EACH ROW BEGIN
																				 IF (OLD.`ReferenceNo` <> NEW.`ReferenceNo`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('stockadjustments', OLD.`ReferenceNo`, NEW.`ReferenceNo`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'stockadjustments') AND (`Value` LIKE CAST(NEW.`ReferenceNo` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockadjustmentsdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `stockadjustmentsdeleteitems` AFTER DELETE ON `stockadjustments` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('stockadjustments', CAST(OLD.`ReferenceNo` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockledgerremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `stockledgerremovedeleteitems` AFTER INSERT ON `stockledger` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'stockledger') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockledgerupdateitems`;
DELIMITER ;;
CREATE TRIGGER `stockledgerupdateitems` AFTER UPDATE ON `stockledger` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('stockledger', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'stockledger') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `stockledgerdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `stockledgerdeleteitems` AFTER DELETE ON `stockledger` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('stockledger', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `suppliersremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `suppliersremovedeleteitems` AFTER INSERT ON `suppliers` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'suppliers') AND (`Value` LIKE CAST(NEW.`SupplierCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `suppliersupdateitems`;
DELIMITER ;;
CREATE TRIGGER `suppliersupdateitems` AFTER UPDATE ON `suppliers` FOR EACH ROW BEGIN
																				 IF (OLD.`SupplierCode` <> NEW.`SupplierCode`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('suppliers', OLD.`SupplierCode`, NEW.`SupplierCode`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'suppliers') AND (`Value` LIKE CAST(NEW.`SupplierCode` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `suppliersdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `suppliersdeleteitems` AFTER DELETE ON `suppliers` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('suppliers', CAST(OLD.`SupplierCode` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usercompaniesremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `usercompaniesremovedeleteitems` AFTER INSERT ON `usercompanies` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'usercompanies') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usercompaniesupdateitems`;
DELIMITER ;;
CREATE TRIGGER `usercompaniesupdateitems` AFTER UPDATE ON `usercompanies` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('usercompanies', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'usercompanies') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usercompaniesdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `usercompaniesdeleteitems` AFTER DELETE ON `usercompanies` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('usercompanies', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usercustomersremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `usercustomersremovedeleteitems` AFTER INSERT ON `usercustomers` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'usercustomers') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usercustomersupdateitems`;
DELIMITER ;;
CREATE TRIGGER `usercustomersupdateitems` AFTER UPDATE ON `usercustomers` FOR EACH ROW BEGIN
																				 IF (OLD.`DetailId` <> NEW.`DetailId`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('usercustomers', OLD.`DetailId`, NEW.`DetailId`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'usercustomers') AND (`Value` LIKE CAST(NEW.`DetailId` AS char(255))); 
																				   
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usercustomersdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `usercustomersdeleteitems` AFTER DELETE ON `usercustomers` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('usercustomers', CAST(OLD.`DetailId` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usersremovedeleteitems`;
DELIMITER ;;
CREATE TRIGGER `usersremovedeleteitems` AFTER INSERT ON `users` FOR EACH ROW BEGIN
																				 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'users') AND (`Value` LIKE CAST(NEW.`Username` AS char(255)));
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usersupdateitems`;
DELIMITER ;;
CREATE TRIGGER `usersupdateitems` AFTER UPDATE ON `users` FOR EACH ROW BEGIN
																				 IF (OLD.`Username` <> NEW.`Username`) THEN
																					 INSERT INTO `updateditems`
																					 (`TableName`, `OldValue`, `NewValue`)
																					 VALUES
																					 ('users', OLD.`Username`, NEW.`Username`);
																					 DELETE FROM `deleteditems` WHERE (`TableName` LIKE 'users') AND (`Value` LIKE CAST(NEW.`Username` AS char(255))); 
																				   UPDATE `signatories` SET LastModified = NOW() WHERE (`Username` IN(CAST(OLD.`Username` AS char(255)), CAST(NEW.`Username` AS char(255))));UPDATE `userlogs` SET LastModified = NOW() WHERE (`Username` IN(CAST(OLD.`Username` AS char(255)), CAST(NEW.`Username` AS char(255))));
																				 END IF;
																			 END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `usersdeleteitems`;
DELIMITER ;;
CREATE TRIGGER `usersdeleteitems` AFTER DELETE ON `users` FOR EACH ROW BEGIN
																				 INSERT INTO `deleteditems`
																				 (`TableName`, `Value`)
																				 VALUES
																				 ('users', CAST(OLD.`Username` AS char(255)));
																			 END
;;
DELIMITER ;
