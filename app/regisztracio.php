<?php

//REGISZTRACIO
if (isset($_POST["submitRegisztral"])) {
    //header("Location: bejelentkezett.php");
	$email = $_POST["email"];
	$jelszo = $_POST["jelszo"];
	$jelszoujra = $_POST["jelszoujra"];
    $veznev = $_POST["vezetek"];
	$kernev = $_POST["kereszt"];
    $nev = $_POST["vezetek"]." ".$_POST["kereszt"];
    $telszam = $_POST["telefon"];
    $telszamHossz = strlen($telszam);
	$iszam = $_POST["iszam"];
    $telepules = $_POST["telepules"];
    $u_hazsz = $_POST["utcaHazszam"];

    //JELSZÓ ELLENŐRZÉS
    $nagyBetu = preg_match('@[A-Z]@', $jelszo);
    $kisBetu = preg_match('@[a-z]@', $jelszo);
    $szam    = preg_match('@[0-9]@', $jelszo);
    $specialisKarakter = preg_match('@[^\w]@', $jelszo);
    $lekerdezes = $db->query("SELECT email FROM felhasznalo_adatok WHERE email = '$email'");
    $eredmeny = $lekerdezes->fetchAll(PDO::FETCH_ASSOC);
    if ($eredmeny != null){
        $alert = <<< JS
        $(function() {
            var alert = document.getElementById('alert');
            alert.innerHTML ='Az email foglalt';          
        });
        JS;
    }
    else{
        if ($jelszo===$jelszoujra ) 
        {
            if(!$nagyBetu || !$kisBetu || !$szam || !$specialisKarakter || strlen($jelszo) < 8) {
                $alert = <<< JS
                $(function() {
                    var alert = document.getElementById('alert');
                    alert.innerHTML ='A jelszó nem elég erős';          
                });
                JS;
            }
            else{
                if ($telszamHossz<13 && $telszamHossz>8 && is_numeric(substr($telszam,1)))
                {
                    if (strlen($iszam)==4) 
                    {
                        $lekerdezesI_szam = $db->query("SELECT id FROM telepulesek WHERE i_szam = '$iszam'");
                        $eredmenyI_szam = $lekerdezesI_szam->fetchAll(PDO::FETCH_ASSOC);
                        if ($eredmenyI_szam == null){
                            $alert = <<< JS
                            $(function() {
                                var alert = document.getElementById('alert');
                                alert.innerHTML ='Ilyen irányítószám nem létezik';   
                            });
                            JS;
                        }
                        else{
                            // SIKERES REGISZTRÁCIÓ
                            $alert = <<< JS
                            $(function() {
                                var alert = document.getElementById('alert');
                                alert.innerHTML ='<p id="siker">Sikeres regisztáció</p>'; 
                            });
                            JS; 
                            // felhasználoi adatok feltöltés
                            $feltoltFelh = $db->query("INSERT INTO `felhasznalo_adatok` (`id`, `teljes_nev`, `telefonszam`, `email`, `jelszo`) VALUES (NULL, '$nev', '$telszam', '$email', md5('$jelszo'));");
                            $eredmenyFeltoltesF = $feltoltFelh->fetchAll(PDO::FETCH_ASSOC);
                            $lekerdezesFelha = $db->query("SELECT id FROM felhasznalo_adatok WHERE email = '$email'");
                            $eredmenyFelha = $lekerdezesFelha->fetchAll(PDO::FETCH_ASSOC);
                            //SZÁLLÍTÁS FELTÖLTÉS
                            foreach ($eredmenyFelha as $sor1) 
                            {
                                foreach ($eredmenyI_szam as  $sor2) 
                                {
                                    //print_r($sor1["id"]." ");
                                    $szamsor1 = intval($sor1["id"]);
                                    $szamsor2 = intval($sor2["id"]);
                                    $feltoltSzallitasi_cim = $db->query("INSERT INTO `szallitasi_cim` (`id`, `felhasznalo_adatok_id`, `telepules_id`, `utca_hazszam`) VALUES (NULL, $szamsor1, $szamsor2, '$u_hazsz');");
                                    $eredmenySzallitasi_cim = $feltoltSzallitasi_cim->fetchAll(PDO::FETCH_ASSOC);
                                }
                            }  
                        }
                    }
                    else {
                        $alert = <<< JS
                        $(function() {
                            var alert = document.getElementById('alert');
                            alert.innerHTML ='Az irányítószám nem megfelelő'; 
                        });
                        JS; 
                    }
                }
                else{
                    $alert = <<< JS
                    $(function() {
                        var alert = document.getElementById('alert');
                        alert.innerHTML ='A telefonszám nem megfelelő'; 
                    });
                    JS; 
                    }
                }
        }
        else{
            $alert = <<< JS
            $(function() {
                var alert = document.getElementById('alert');
                alert.innerHTML ='A jelszó nem egyezik';   
            });
            JS;
        }
        /* $alert = <<< JS
        $(function() {
            var alert = document.getElementById('alert');
            alert.innerHTML ='Működik a gomb'; 
           
        });
        JS;*/
    }
}?>