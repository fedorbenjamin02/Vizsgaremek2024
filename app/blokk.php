
<!DOCTYPE html>
<html lang="hu">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Friss Futár - Rendelés befejezése</title>
    <!--fontawesome a betűtípushoz és az ikonokhoz-->
    <script src="https://kit.fontawesome.com/ae360af17e.js" crossorigin="anonymous"></script>
    <!---->
    <link rel="stylesheet" href="css/rendelesDark.css">
    <script defer src="js/rendeles.js"></script>
</head>

<body id="body"> 
    <div id="hidden">
    <?php 
        include_once "kosar_adatok.php";
        $kosar = $_SESSION["kosar"];
        $adatok_megadott = $_SESSION["adatok_megadasa"];
    ?>
    </div>
        <div class="rendeles-vege-content">
            <?php 
            echo "<div class='tablazat-container'><table id='felso-t'>";
            echo "<tr><th class='cim' colspan='2'>Szállítási adatok</th></tr>";
            echo "<tr><th colspan='2'><hr></th></tr>";
            echo "<tr><td class='cimke'>Név</td><td>$adatok_megadott[teljes_nev]</td></tr>";
            echo "<tr><td class='cimke'>Telefonszám</td><td>$adatok_megadott[telefonszam]</td></tr>";
            echo "<tr><td class='cimke'>Település</td><td>$adatok_megadott[telepules]</td></tr>";
            echo "<tr><td class='cimke'>Cím</td><td>$adatok_megadott[cim]</td></tr>";
            echo "</table></div>";
        
            $vegosszeg=0;
            echo "<div class='tablazat-container'><table id='also-t'>";
            echo "<tr><th class='cim' colspan='3'>Rendelés tételei</th></tr>";
            echo "<tr><th colspan='3'><hr></th></tr>";
            echo "<tr><th class='th-megn'> Megnevezés </th> <th class='th-egys'>Egységár</th> <th class='th-menny'> Mennyiség </th></tr>";
            echo "<tr>";
            foreach ($kosar as $tetel) {
                $id = $tetel["id"];
                $lekerdezes = $db->query("SELECT * FROM termek WHERE id = $id");
                $eredmeny = $lekerdezes->fetchAll(PDO::FETCH_ASSOC);
                foreach ($eredmeny as $termek){
                    $megnevezes = $termek["megnevezes"];
                    $leiras = $termek["leiras"];
                    $afakulcs_id = $termek["afa_kulcs_id"];

                    $lekerdezes_afa = $db->query("SELECT * FROM afa_kulcsok WHERE id = $afakulcs_id");
                    $eredmeny_afa = $lekerdezes_afa->fetchAll(PDO::FETCH_ASSOC);
                    foreach ($eredmeny_afa as $afa_kulcs) {
                       $afa_kulcs_megn = $afa_kulcs["kulcs"];
                    }

                    $netto_egyseg_ar = $termek["netto_egyseg_ar"];
                    $brutto_egyseg_ar = ceil(($netto_egyseg_ar+$netto_egyseg_ar*($afa_kulcs_megn/100))/10)*10;
                    $mennyiseg = $tetel["menny"];
                    $termek_ossz_ar = $brutto_egyseg_ar*$mennyiseg;
                    $vegosszeg+=$termek_ossz_ar;
                }
                if ($mennyiseg !=0) {
                    echo "<td class='th-megn'> $megnevezes</td>";
            
                echo "<td class='th-egys'> $brutto_egyseg_ar Ft </td>";
                echo "<td class='th-menny'> $mennyiseg db</td>";
                echo "</tr>";
                //print_r($tetel);
                echo"<br>";
                }    
            }
            
            echo "</table></div>";
            echo "<p><b>Fizetesi Mód:</b> $adatok_megadott[fizetesi_modok]</p>";
            echo "<p><b>Végösszeg:</b><span id='vegosszeg'> $vegosszeg Ft</span></p>";

            
            if (isset($_POST["submitRendeles"])) 
            {
                if (isset($_SESSION["belepettE"]))
                {
                    if ($_SESSION["belepettE"]==true)
                    {
                        $email =  $_SESSION["email"];
                        
                        $lekerdezes_felhasznaloi_adatok = $db->query("SELECT * FROM felhasznalo_adatok WHERE email = '$email'");
                        $eredmeny_felhasznaloi_adatok = $lekerdezes_felhasznaloi_adatok->fetchAll(PDO::FETCH_ASSOC);
                        foreach ($eredmeny_felhasznaloi_adatok as $sor ) {
                            $fh_id = $sor["id"];
                        }
                        $teljes_nev = $adatok_megadott["teljes_nev"];
                        $cim = $adatok_megadott["cim"];
                        $fizetesi_modok = $adatok_megadott["fizetesi_modok"];
                        $megjegyzes = $adatok_megadott["megjegyzes"];  

                        $lekerdezes_fizetesi_modok = $db->query("SELECT * FROM fizetesi_modok WHERE megnevezes = '$fizetesi_modok'");
                        $eredmeny_fizetesi_modok = $lekerdezes_fizetesi_modok->fetchAll(PDO::FETCH_ASSOC);
                        foreach ($eredmeny_fizetesi_modok as $fizmod)
                        {
                            $fizetesi_modok_id = $fizmod["id"];
                        }

                        $lekerdezes_rendeles_statusz = $db->query("SELECT * FROM rendeles_statusza WHERE id = '1'" );
                        $eredmeny_rendeles_statusz = $lekerdezes_rendeles_statusz->fetchAll(PDO::FETCH_ASSOC);
                        foreach ($eredmeny_rendeles_statusz as $statusz)
                        {
                            $rendeles_statusza_id = $statusz["id"];
                        }

                        $rendeles_datumido =  date("Y-m-d H:i:s");
                        $szallitas_datum =  date("Y-m-d");

                        $vegosszeg_brutto = $vegosszeg;
                        $vegosszeg_netto =  ceil(($vegosszeg*100/115)/10)*10;
                        echo $vegosszeg_brutto. "<br>";
                        echo $vegosszeg_netto. "<br>";
            
                        $brutto_egyseg_ar = ceil(($netto_egyseg_ar+$netto_egyseg_ar*($afa_kulcs_megn/100))/10)*10;
        
                        $feltoltes_rendeles = $db->query("INSERT INTO `rendeles` (`id`, `felhasznalo_adatok_id`,`teljes_nev`, `cim`,`fizetesi_modok_id`, `rendeles_statusza_id`, 
                                                        `rendeles_datumido`,`szallitas_datum`,`szallitas_megj`, `brutto_vegosszeg` ,`netto_vegosszeg`) 
                                                        VALUES ('NULL','$fh_id','$teljes_nev','$cim ','$fizetesi_modok_id','$rendeles_statusza_id','$rendeles_datumido','$szallitas_datum',
                                                        '$megjegyzes','$vegosszeg_brutto','$vegosszeg_netto');");                                
                        $eredmeny_feltoltes_rendeles = $feltoltes_rendeles->fetchAll(PDO::FETCH_ASSOC);
                        
                        $lekerdezes_rendeles = $db->query("SELECT * FROM rendeles WHERE felhasznalo_adatok_id = $fh_id");
                        $eredmeny_lekerdezes_rendeles = $lekerdezes_rendeles->fetchAll(PDO::FETCH_ASSOC);

                        foreach ($eredmeny_lekerdezes_rendeles as $rendeles)
                        {
                            $rendeles_id = $rendeles["id"];
                        }
                        foreach ($kosar as $termek_tetel) {
                            $termek_id = $termek_tetel["id"];
                            $lekerdezes = $db->query("SELECT * FROM termek WHERE id = $termek_id");
                            $eredmeny = $lekerdezes->fetchAll(PDO::FETCH_ASSOC);
                            foreach ($eredmeny as $termek){
                                $megnevezes = $termek["megnevezes"];
                                $leiras = $termek["leiras"];
                                $afakulcs_id = $termek["afa_kulcs_id"];
            
                                $lekerdezes_afa = $db->query("SELECT * FROM afa_kulcsok WHERE id = $afakulcs_id");
                                $eredmeny_afa = $lekerdezes_afa->fetchAll(PDO::FETCH_ASSOC);
                                foreach ($eredmeny_afa as $afa_kulcs) {
                                $afa_kulcs_megn = $afa_kulcs["kulcs"];
                                }        
                                $netto_egyseg_ar = $termek["netto_egyseg_ar"];
                            
                                $termek_mennyiseg = $termek_tetel["menny"];
                                $feltoltes_rendeles = $db->query("INSERT INTO `rendeles_tetelei` (`id`, `rendeles_id`,`termek_id`, `megnevezes`,`mennyiseg`, `netto_egyseg_ar`, `afakulcs`) VALUES ('NULL','$rendeles_id','$termek_id','$megnevezes','$termek_mennyiseg','$netto_egyseg_ar','$afa_kulcs_megn');");
                                $eredmeny_feltoltes_rendeles = $feltoltes_rendeles->fetchAll(PDO::FETCH_ASSOC);
                            }
                        }
                        echo '<script>alert("Rendelés felvéve")</script>';
                    }
                    else{
        
                        $fh_id = 1;
                        $teljes_nev = $adatok_megadott["teljes_nev"];
                        $cim = $adatok_megadott["cim"];
                        $fizetesi_modok = $adatok_megadott["fizetesi_modok"];
                        $megjegyzes = $adatok_megadott["megjegyzes"];  

                        $lekerdezes_fizetesi_modok = $db->query("SELECT * FROM fizetesi_modok WHERE megnevezes = '$fizetesi_modok'");
                        $eredmeny_fizetesi_modok = $lekerdezes_fizetesi_modok->fetchAll(PDO::FETCH_ASSOC);
                        foreach ($eredmeny_fizetesi_modok as $fizmod)
                        {
                            $fizetesi_modok_id = $fizmod["id"];
                        }

                        $lekerdezes_rendeles_statusz = $db->query("SELECT * FROM rendeles_statusza WHERE id = '1'" );
                        $eredmeny_rendeles_statusz = $lekerdezes_rendeles_statusz->fetchAll(PDO::FETCH_ASSOC);
                        foreach ($eredmeny_rendeles_statusz as $statusz)
                        {
                            $rendeles_statusza_id = $statusz["id"];
                        }

                        $rendeles_datumido =  date("Y-m-d H:i:s");
                        $szallitas_datum =  date("Y-m-d");

                        $vegosszeg_brutto = $vegosszeg;
                        $vegosszeg_netto =  ceil(($vegosszeg*100/115)/10)*10;
                        echo $vegosszeg_brutto. "<br>";
                        echo $vegosszeg_netto;
                        $brutto_egyseg_ar = ceil(($netto_egyseg_ar+$netto_egyseg_ar*($afa_kulcs_megn/100))/10)*10;

                        $feltoltes_rendeles = $db->query("INSERT INTO `rendeles` (`id`, `felhasznalo_adatok_id`,`teljes_nev`, `cim`,`fizetesi_modok_id`, `rendeles_statusza_id`, `rendeles_datumido`,`szallitas_datum`,`szallitas_megj`, `brutto_vegosszeg` ,`netto_vegosszeg`) VALUES ('NULL','$fh_id','$teljes_nev','$cim ','$fizetesi_modok_id','$rendeles_statusza_id','$rendeles_datumido','$szallitas_datum','$megjegyzes','$vegosszeg_brutto','$vegosszeg_netto');");
                    
                        $eredmeny_feltoltes_rendeles = $feltoltes_rendeles->fetchAll(PDO::FETCH_ASSOC);

                        $lekerdezes_rendeles = $db->query("SELECT * FROM rendeles WHERE felhasznalo_adatok_id = $fh_id");
                        $eredmeny_lekerdezes_rendeles = $lekerdezes_rendeles->fetchAll(PDO::FETCH_ASSOC);
                        
                        foreach ($eredmeny_lekerdezes_rendeles as $rendeles)
                        {
                            $rendeles_id = $rendeles["id"];
                        }

                        foreach ($kosar as $termek_tetel) {
                            $termek_id = $termek_tetel["id"];
                            $lekerdezes = $db->query("SELECT * FROM termek WHERE id = $termek_id");
                            $eredmeny = $lekerdezes->fetchAll(PDO::FETCH_ASSOC);
                            foreach ($eredmeny as $termek){
                                $megnevezes = $termek["megnevezes"];
                                $leiras = $termek["leiras"];
                                $afakulcs_id = $termek["afa_kulcs_id"];
            
                                $lekerdezes_afa = $db->query("SELECT * FROM afa_kulcsok WHERE id = $afakulcs_id");
                                $eredmeny_afa = $lekerdezes_afa->fetchAll(PDO::FETCH_ASSOC);
                                foreach ($eredmeny_afa as $afa_kulcs) {
                                $afa_kulcs_megn = $afa_kulcs["kulcs"];
                                }
                                $netto_egyseg_ar = $termek["netto_egyseg_ar"];
                                $termek_mennyiseg = $termek_tetel["menny"];
                                $feltoltes_rendeles = $db->query("INSERT INTO `rendeles_tetelei` (`id`, `rendeles_id`,`termek_id`, `megnevezes`,`mennyiseg`, `netto_egyseg_ar`, `afakulcs`) VALUES ('NULL','$rendeles_id','$termek_id','$megnevezes','$termek_mennyiseg','$netto_egyseg_ar','$afa_kulcs_megn');");
                                $eredmeny_feltoltes_rendeles = $feltoltes_rendeles->fetchAll(PDO::FETCH_ASSOC);
                            }
                        }
                        echo '<script>alert("Rendelés felvéve")</script>';
                    }
                }
            }
            ?>
            <div class="alsoSorBlokk">  
                <form action="" method="post" id="rendeles-vege-form">
                    <a class="submit" id="rendeles-vege-gomb-1" id="vissza" href="adatok_megadasa.php">Vissza</a>
                    <button class="submit" id="rendeles-vege-gomb-2" name = "submitRendeles">Rendelés</button> 
                </form>
            </div>
        </div>
</body>
</html>