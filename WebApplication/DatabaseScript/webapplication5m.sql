-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Feb 03, 2020 alle 09:50
-- Versione del server: 10.1.36-MariaDB
-- Versione PHP: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `webapplication5m`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `article`
--

CREATE TABLE `article` (
  `Id` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `ImageUrl` varchar(255) DEFAULT NULL,
  `Author` varchar(255) NOT NULL,
  `Text` text NOT NULL,
  `Date` datetime NOT NULL,
  `InsertDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LastModifiedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `article`
--

INSERT INTO `article` (`Id`, `Title`, `ImageUrl`, `Author`, `Text`, `Date`, `InsertDate`, `LastModifiedDate`) VALUES
(1, 'such as cookies ', NULL, 'dal contenuto ', 'dal sedicesimo secolo, quando un anonimo tipografo prese una cassetta di caratteri e li assemblò per preparare un testo campione. È sopravvissuto non solo a più di cinque secoli, ma anche al passaggio alla videoimpaginazione, pervenendoci sostanzialmente inalterato. Fu reso popolare, negli anni ’60, con la diffusione dei fogli di caratteri trasferibili “Letraset”, che contenevano passaggi del Lorem Ipsum, e più recentemente da software di impaginazione come', '2019-12-01 00:00:00', '2019-12-09 10:12:12', NULL),
(2, 'tilizzo del Lorem Ipsum', NULL, 'Aldus PageMaker', 'ofessore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del \"de Finibus Bonorum et Malorum\" di Cicerone. Questo testo è un trattato', '2019-12-02 00:00:00', '2019-12-09 10:12:17', NULL),
(3, 'Scrivici una email ', NULL, 'Pinco Pallo', 're veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi', '2019-12-03 00:00:00', '2019-12-09 10:14:28', NULL);

-- --------------------------------------------------------

--
-- Struttura della tabella `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `RegistrationDate` datetime NOT NULL,
  `IsConfirmed` bit(1) NOT NULL,
  `InsertDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LastModifiedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `user`
--

INSERT INTO `user` (`Id`, `Username`, `Password`, `Name`, `Email`, `RegistrationDate`, `IsConfirmed`, `InsertDate`, `LastModifiedDate`) VALUES
(1, 'admin', 'admin', 'Administrator', 'admin@iispascal.it', '2020-01-20 09:41:46', b'0', '2020-01-20 09:41:46', NULL),
(2, 'user', 'user', 'Normal user', 'user@iispascal.it', '2020-01-20 09:41:46', b'0', '2020-01-20 09:41:46', NULL),
(3, 'dsfds', '1', 'sad', 'adminds@iispascal.it', '0001-01-01 00:00:00', b'0', '2020-01-31 12:40:39', NULL);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`Id`);

--
-- Indici per le tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `article`
--
ALTER TABLE `article`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
