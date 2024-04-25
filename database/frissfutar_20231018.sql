-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Okt 16. 15:02
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `etel_rendeles_teszt2`
--
DROP DATABASE IF EXISTS `etel_rendeles_teszt2`;
CREATE DATABASE IF NOT EXISTS `etel_rendeles_teszt2` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `etel_rendeles_teszt2`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `felhasznalo_nev` varchar(30) NOT NULL,
  `jelszo` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `afa_kulcsok`
--

CREATE TABLE `afa_kulcsok` (
  `id` int(11) NOT NULL,
  `megnevezes` varchar(5) NOT NULL,
  `kulcs` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo_adatok`
--

CREATE TABLE `felhasznalo_adatok` (
  `id` int(11) NOT NULL,
  `teljes_nev` varchar(100) NOT NULL,
  `telefonszam` varchar(20) NOT NULL,
  `email` varchar(60) NOT NULL,
  `jelszo` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `fizetesi_modok`
--

CREATE TABLE `fizetesi_modok` (
  `id` int(11) NOT NULL,
  `megnevezes` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `fizetesi_modok`
--

INSERT INTO `fizetesi_modok` (`id`, `megnevezes`) VALUES
(1, 'készpénz'),
(2, 'bankkártya'),
(3, 'SZÉP-kártya');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `mennyisegi_egysegek`
--

CREATE TABLE `mennyisegi_egysegek` (
  `id` int(11) NOT NULL,
  `megnevezes` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendeles`
--

CREATE TABLE `rendeles` (
  `id` int(11) NOT NULL,
  `felhasznalo_adatok_id` int(11) NOT NULL,
  `teljes_nev` varchar(100) NOT NULL,
  `cim` varchar(150) NOT NULL,
  `fizetesi_modok_id` int(11) NOT NULL,
  `rendeles_statusza_id` int(11) NOT NULL,
  `rendeles_datumido` datetime NOT NULL,
  `szallitas_datum` date NOT NULL,
  `szallitas_megj` varchar(50) NOT NULL,
  `brutto_vegosszeg` int(8) NOT NULL,
  `netto_vegosszeg` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendeles_statusza`
--

CREATE TABLE `rendeles_statusza` (
  `id` int(11) NOT NULL,
  `rendeles_allapot` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `rendeles_statusza`
--

INSERT INTO `rendeles_statusza` (`id`, `rendeles_allapot`) VALUES
(1, 'rendelés felvéve'),
(2, 'rendelés készen áll '),
(3, 'kiszállítva');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendeles_tetelei`
--

CREATE TABLE `rendeles_tetelei` (
  `id` int(11) NOT NULL,
  `rendeles_id` int(11) NOT NULL,
  `termek_id` int(11) NOT NULL,
  `megnevezes` varchar(100) NOT NULL,
  `mennyiseg` int(11) NOT NULL,
  `netto_egyseg_ar` int(11) NOT NULL,
  `afakulcs` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szallitasi_cim`
--

CREATE TABLE `szallitasi_cim` (
  `id` int(11) NOT NULL,
  `felhasznalo_adatok_id` int(11) NOT NULL,
  `telepules_id` int(11) NOT NULL,
  `utca_hazszam` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `telepulesek`
--

CREATE TABLE `telepulesek` (
  `id` int(11) NOT NULL,
  `i_szam` varchar(4) NOT NULL,
  `telepules` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek`
--

CREATE TABLE `termek` (
  `id` int(11) NOT NULL,
  `termek_csoport_id` int(11) NOT NULL,
  `megnevezes` varchar(100) NOT NULL,
  `leiras` varchar(100) NOT NULL,
  `kep` varchar(80) NOT NULL,
  `netto_egyseg_ar` int(11) NOT NULL,
  `mennyisegi_egysegek_id` int(11) NOT NULL,
  `afa_kulcs_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek_csomag`
--

CREATE TABLE `termek_csomag` (
  `id` int(11) NOT NULL,
  `megnevezes` varchar(30) NOT NULL,
  `leiras` varchar(200) NOT NULL,
  `kep` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek_csomag_reszletei`
--

CREATE TABLE `termek_csomag_reszletei` (
  `id` int(11) NOT NULL,
  `termek_csomag_id` int(11) NOT NULL,
  `termek_id` int(11) NOT NULL,
  `mennyiseg` int(11) NOT NULL,
  `netto_egyseg_ar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek_csoport`
--

CREATE TABLE `termek_csoport` (
  `id` int(11) NOT NULL,
  `termek_kategoria_id` int(11) NOT NULL,
  `megnevezes` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `termek_csoport`
--

INSERT INTO `termek_csoport` (`id`, `termek_kategoria_id`, `megnevezes`) VALUES
(1, 1, 'Hamburgerek'),
(2, 1, 'Frissensültek'),
(3, 1, 'Tészták'),
(4, 1, 'Levesek'),
(5, 1, 'Gyrosok'),
(6, 1, 'Pizzák'),
(7, 1, 'Mártások'),
(8, 1, 'Saláták'),
(9, 1, 'Köretek'),
(10, 1, 'Desszertek'),
(11, 2, 'Szénsavas üdítők'),
(12, 2, 'Gyümölcslevek'),
(13, 2, 'Energiaitalok'),
(14, 2, 'Szeszes italok'),
(15, 2, 'Teák'),
(16, 2, 'Ásványvizek');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek_kategoria`
--

CREATE TABLE `termek_kategoria` (
  `id` int(11) NOT NULL,
  `megnevezes` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `termek_kategoria`
--

INSERT INTO `termek_kategoria` (`id`, `megnevezes`) VALUES
(1, 'Étel'),
(2, 'Ital');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `afa_kulcsok`
--
ALTER TABLE `afa_kulcsok`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `felhasznalo_adatok`
--
ALTER TABLE `felhasznalo_adatok`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `fizetesi_modok`
--
ALTER TABLE `fizetesi_modok`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `mennyisegi_egysegek`
--
ALTER TABLE `mennyisegi_egysegek`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `rendeles`
--
ALTER TABLE `rendeles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `felhasznalo_adatok_id` (`felhasznalo_adatok_id`),
  ADD KEY `fizetesi_modok_id` (`fizetesi_modok_id`),
  ADD KEY `rendeles_statusza_id` (`rendeles_statusza_id`);

--
-- A tábla indexei `rendeles_statusza`
--
ALTER TABLE `rendeles_statusza`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `rendeles_tetelei`
--
ALTER TABLE `rendeles_tetelei`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rendeles_id` (`rendeles_id`),
  ADD KEY `termek_id` (`termek_id`);

--
-- A tábla indexei `szallitasi_cim`
--
ALTER TABLE `szallitasi_cim`
  ADD PRIMARY KEY (`id`),
  ADD KEY `felhasznalo_adatok_id` (`felhasznalo_adatok_id`),
  ADD KEY `telepules_id` (`telepules_id`);

--
-- A tábla indexei `telepulesek`
--
ALTER TABLE `telepulesek`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `termek`
--
ALTER TABLE `termek`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mennyisegi_egysegek_id` (`mennyisegi_egysegek_id`),
  ADD KEY `termek_csoport_id` (`termek_csoport_id`),
  ADD KEY `afa_kulcs_id` (`afa_kulcs_id`);

--
-- A tábla indexei `termek_csomag`
--
ALTER TABLE `termek_csomag`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `termek_csomag_reszletei`
--
ALTER TABLE `termek_csomag_reszletei`
  ADD PRIMARY KEY (`id`),
  ADD KEY `termek_csomag_id` (`termek_csomag_id`),
  ADD KEY `termek_id` (`termek_id`);

--
-- A tábla indexei `termek_csoport`
--
ALTER TABLE `termek_csoport`
  ADD PRIMARY KEY (`id`),
  ADD KEY `termek_kategoria_id` (`termek_kategoria_id`);

--
-- A tábla indexei `termek_kategoria`
--
ALTER TABLE `termek_kategoria`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `afa_kulcsok`
--
ALTER TABLE `afa_kulcsok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `felhasznalo_adatok`
--
ALTER TABLE `felhasznalo_adatok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `fizetesi_modok`
--
ALTER TABLE `fizetesi_modok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `mennyisegi_egysegek`
--
ALTER TABLE `mennyisegi_egysegek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `rendeles`
--
ALTER TABLE `rendeles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `rendeles_statusza`
--
ALTER TABLE `rendeles_statusza`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `rendeles_tetelei`
--
ALTER TABLE `rendeles_tetelei`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `szallitasi_cim`
--
ALTER TABLE `szallitasi_cim`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `telepulesek`
--
ALTER TABLE `telepulesek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `termek`
--
ALTER TABLE `termek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `termek_csomag`
--
ALTER TABLE `termek_csomag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `termek_csomag_reszletei`
--
ALTER TABLE `termek_csomag_reszletei`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `termek_csoport`
--
ALTER TABLE `termek_csoport`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT a táblához `termek_kategoria`
--
ALTER TABLE `termek_kategoria`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `rendeles`
--
ALTER TABLE `rendeles`
  ADD CONSTRAINT `rendeles_ibfk_1` FOREIGN KEY (`felhasznalo_adatok_id`) REFERENCES `felhasznalo_adatok` (`id`),
  ADD CONSTRAINT `rendeles_ibfk_2` FOREIGN KEY (`fizetesi_modok_id`) REFERENCES `fizetesi_modok` (`id`),
  ADD CONSTRAINT `rendeles_ibfk_3` FOREIGN KEY (`rendeles_statusza_id`) REFERENCES `rendeles_statusza` (`id`);

--
-- Megkötések a táblához `rendeles_tetelei`
--
ALTER TABLE `rendeles_tetelei`
  ADD CONSTRAINT `rendeles_tetelei_ibfk_1` FOREIGN KEY (`rendeles_id`) REFERENCES `rendeles` (`id`),
  ADD CONSTRAINT `rendeles_tetelei_ibfk_2` FOREIGN KEY (`termek_id`) REFERENCES `termek` (`id`);

--
-- Megkötések a táblához `szallitasi_cim`
--
ALTER TABLE `szallitasi_cim`
  ADD CONSTRAINT `szallitasi_cim_ibfk_1` FOREIGN KEY (`felhasznalo_adatok_id`) REFERENCES `felhasznalo_adatok` (`id`),
  ADD CONSTRAINT `szallitasi_cim_ibfk_2` FOREIGN KEY (`telepules_id`) REFERENCES `telepulesek` (`id`);

--
-- Megkötések a táblához `termek`
--
ALTER TABLE `termek`
  ADD CONSTRAINT `termek_ibfk_1` FOREIGN KEY (`mennyisegi_egysegek_id`) REFERENCES `mennyisegi_egysegek` (`id`),
  ADD CONSTRAINT `termek_ibfk_2` FOREIGN KEY (`termek_csoport_id`) REFERENCES `termek_csoport` (`id`),
  ADD CONSTRAINT `termek_ibfk_3` FOREIGN KEY (`afa_kulcs_id`) REFERENCES `afa_kulcsok` (`id`);

--
-- Megkötések a táblához `termek_csomag_reszletei`
--
ALTER TABLE `termek_csomag_reszletei`
  ADD CONSTRAINT `termek_csomag_reszletei_ibfk_1` FOREIGN KEY (`termek_csomag_id`) REFERENCES `termek_csomag` (`id`),
  ADD CONSTRAINT `termek_csomag_reszletei_ibfk_2` FOREIGN KEY (`termek_id`) REFERENCES `termek` (`id`);

--
-- Megkötések a táblához `termek_csoport`
--
ALTER TABLE `termek_csoport`
  ADD CONSTRAINT `termek_csoport_ibfk_1` FOREIGN KEY (`termek_kategoria_id`) REFERENCES `termek_kategoria` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
