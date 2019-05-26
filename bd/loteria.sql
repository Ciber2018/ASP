-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 26-05-2019 a las 17:59:15
-- Versión del servidor: 10.1.30-MariaDB
-- Versión de PHP: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `loteria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evento`
--

CREATE TABLE `evento` (
  `ID` varchar(20) NOT NULL,
  `fecha` varchar(20) NOT NULL,
  `hora` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `evento`
--

INSERT INTO `evento` (`ID`, `fecha`, `hora`) VALUES
('Evento Laravel', '2019/05/28', '10:45'),
('Evento1', '2019/05/25', '09:00'),
('Evento2', '2019/05/25', '09:25'),
('EventoNegocio', '2019/05/25', '09:00'),
('Evet23', '2019/05/25', '10:45');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tarjeta`
--

CREATE TABLE `tarjeta` (
  `numeroID` int(11) NOT NULL,
  `estado` text NOT NULL,
  `ID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tarjeta`
--

INSERT INTO `tarjeta` (`numeroID`, `estado`, `ID`) VALUES
(20, 'W', 'Evento1'),
(30, 'L', 'Evento1'),
(59, 'L', 'Evento1'),
(70, 'L', 'Evento1'),
(85, 'L', 'Evento1'),
(100, 'L', 'Evento2'),
(150, 'L', 'Evento2'),
(200, 'W', 'Evento2'),
(250, 'L', 'Evento2'),
(280, 'L', 'Evento2'),
(320, 'L', 'EventoNegocio'),
(350, 'L', 'EventoNegocio'),
(380, 'L', 'EventoNegocio'),
(400, 'W', 'EventoNegocio'),
(450, 'L', 'EventoNegocio'),
(500, 'L', 'Evet23'),
(600, 'L', 'Evet23'),
(900, 'L', 'Evet23'),
(1000, 'W', 'Evet23'),
(1050, 'L', 'Evet23'),
(2000, 'W', 'Evento Laravel'),
(2050, 'L', 'Evento Laravel'),
(2100, 'L', 'Evento Laravel'),
(2300, 'L', 'Evento Laravel'),
(2500, 'L', 'Evento Laravel');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `evento`
--
ALTER TABLE `evento`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID` (`ID`);

--
-- Indices de la tabla `tarjeta`
--
ALTER TABLE `tarjeta`
  ADD PRIMARY KEY (`numeroID`),
  ADD KEY `ID` (`ID`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tarjeta`
--
ALTER TABLE `tarjeta`
  ADD CONSTRAINT `tarjeta_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `evento` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
