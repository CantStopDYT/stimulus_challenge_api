CREATE TABLE `Pledge` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Email` varchar(150) DEFAULT NULL,
  `ZipCode` varchar(10) NOT NULL,
  `NonProfit` int(11) DEFAULT NULL,
  `SmallBiz` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
