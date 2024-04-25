<?php
require "connect.php";
$db = kapcs();
include_once ("bejelentkezes.php");
//$_SESSION["adatok_megadasa"];
$teljes_nev = "";
$telefonszam = "";
$cim = "";
$telepules = "";
$fizetesi_mod = "";
$megjegyzes = "";

if (isset($_SESSION["belepettE"]))
{
    if ($_SESSION["belepettE"] == true ) {
        $email = $_SESSION["email"];
        $lekerdezes_felhasznaloi_adatok = $db->query("SELECT * FROM felhasznalo_adatok WHERE email = '$email'");
	    $eredmeny_felhasznaloi_adatok = $lekerdezes_felhasznaloi_adatok->fetchAll(PDO::FETCH_ASSOC);
        foreach ($eredmeny_felhasznaloi_adatok as $sor ) {
            $fh_id = $sor["id"];
            $teljes_nev = $sor["teljes_nev"];
            $telefonszam = $sor["telefonszam"];
        }
        $lekerdezes_szallitasi_cim = $db->query("SELECT * FROM szallitasi_cim WHERE felhasznalo_adatok_id = '$fh_id'");
	    $eredmeny_szallitasi_cim = $lekerdezes_szallitasi_cim->fetchAll(PDO::FETCH_ASSOC);
        foreach ($eredmeny_szallitasi_cim as $sor ) {
            $telepules_id = $sor["telepules_id"];
            $cim = $sor["utca_hazszam"];
        }
        $lekerdezes_telepulesek = $db->query("SELECT * FROM telepulesek WHERE id = '$telepules_id'");
	    $eredmeny_telepulesek = $lekerdezes_telepulesek->fetchAll(PDO::FETCH_ASSOC);
        foreach ($eredmeny_telepulesek as $sor ) {
            $telepules = $sor["telepules"];
        }
        
        

         if (isset($_POST["nev"])) {
        $teljes_nev = $_POST["nev"];
        $telefonszam = $_POST["telszam"];
        $cim = $_POST["cim"];
        $telepules = $_POST["telepules"];
        }
        if (isset($_SESSION["adatok_megadasa"]))
        {
            $adatok_megadott = $_SESSION["adatok_megadasa"];
            unset($_SESSION["adatok_megadasa"]);     
            
            
            $teljes_nev = $adatok_megadott["teljes_nev"];
            $telefonszam = $adatok_megadott["telefonszam"];
            $cim = $adatok_megadott["cim"];
            $telepules = $adatok_megadott["telepules"];
            $fizetesi_mod = $adatok_megadott["fizetesi_modok"];
            $megjegyzes = $adatok_megadott["megjegyzes"];
        }
    }
    else{
        if (isset($_POST["nev"])) {
            $teljes_nev = $_POST["nev"];
            $telefonszam = $_POST["telszam"];
            $cim = $_POST["cim"];
            $telepules = $_POST["telepules"];
        }
        if (isset($_SESSION["adatok_megadasa"]))
        {
            $adatok_megadott = $_SESSION["adatok_megadasa"];
            unset($_SESSION["adatok_megadasa"]);     
            
            
            $teljes_nev = $adatok_megadott["teljes_nev"];
            $telefonszam = $adatok_megadott["telefonszam"];
            $cim = $adatok_megadott["cim"];
            $telepules = $adatok_megadott["telepules"];
            $fizetesi_mod = $adatok_megadott["fizetesi_modok"];
            $megjegyzes = $adatok_megadott["megjegyzes"];
        }
    }
    if(isset($_POST["fizetesi_modok"])){
    $fizetesi_mod = $_POST["fizetesi_modok"];}
    if(isset($_POST["megjegyzes"])){
    $megjegyzes = $_POST["megjegyzes"];}
}

///////////ADATOK ELLENŐRZÉSE///////////////
if (isset($_POST["submitRendeles"]))
{
    $megfelelo_telszam;
    $megfelelo_telepules;
    //TELEFONSZÁM
    $telszam_hoszz = strlen($_POST["telszam"]);
    if ($telszam_hoszz>13 || $telszam_hoszz<8 || !is_numeric(substr($_POST["telszam"],1)))
    {
        echo "<div class='alert'>Helytelen telefonszám</div>";
        $megfelelo_telszam = false;
    }
    else{
        $megfelelo_telszam = true;
    }
    //TELEPÜLÉS
    $telepules_megadott = $_POST["telepules"];
    $lekerdezes_telepules_letezik_e = $db->query("SELECT * FROM telepulesek WHERE telepules = '$telepules_megadott'");
	$eredmeny_telepules_letezik_e = $lekerdezes_telepules_letezik_e->fetchAll(PDO::FETCH_ASSOC);
    if ($eredmeny_telepules_letezik_e==null) {
        echo "<div class='alert2'>Helytelen település</div>";
        $megfelelo_telepules = false;
    }
    else{
        $megfelelo_telepules = true;
    }
    if ($megfelelo_telszam==true && $megfelelo_telepules==true) {
        header("Location: blokk.php");
        $_SESSION["adatok_megadasa"]= array("teljes_nev" => $teljes_nev, "telefonszam" => $telefonszam,  "cim" => $cim, "telepules" => $telepules, "fizetesi_modok"=> $fizetesi_mod, "megjegyzes" => $megjegyzes);
    }
}
?>
<!DOCTYPE html>
<html lang="hu">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Friss Futár - Adatok Megadása</title>
    <script src="https://kit.fontawesome.com/ae360af17e.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="css/rendelesDark.css">
    <script defer src="js/rendeles.js"></script>
</head>
<body id="body">
    <div class="formTarolo">
        <form action="" method="post" id="formAdatokMegadasa">
                <h2>Adatok megadása</h2>
            <p class="input-p">Teljes név</p>
            <div class="input">
                <div class="formIcon"><i class="fa-solid fa-user fa-lg"></i></div>
                <input class="inp" type="text" value="<?php echo $teljes_nev ?>" name="nev" id="nev"  required>
            </div>
            <p class="input-p">Telefonszám</p>
            <div class="input">
                <div class="formIcon"><i class="fa-solid fa-phone fa-lg"></i></div>
                <input class="inp" type="tel" value="<?php echo $telefonszam ?>" name="telszam"  maxlength="13"  required>
                
            </div>
            <p class="input-p">Település</p>
            <div class="input">
                <div class="formIcon"><i class="fa-solid fa-map-location-dot fa-lg"></i></div>
                <input class="inp" type="text" value="<?php echo $telepules ?>" name="telepules"  required>
            </div>
            <p class="input-p">Cím</p>
            <div class="input">
                <div class="formIcon"><i class="fa-solid fa-location-dot fa-lg"></i></div>
                <input class="inp" type="text" value="<?php echo $cim ?>" name="cim"  required>
            </div>
            <p class="input-p">Fizetési mód</p>
            <div class="input">
                <div class="formIcon"><i class="fa-solid fa-credit-card fa-lg"></i></div>
                <select class="inp" name="fizetesi_modok" id="">
                <?php
                    $lekerdezes_fizetesi_modok = $db->query("SELECT * FROM fizetesi_modok");
                    $eredmeny_fizetesi_modok= $lekerdezes_fizetesi_modok->fetchAll(PDO::FETCH_ASSOC);
                    foreach ($eredmeny_fizetesi_modok as $sor ) {
                    $id = $sor["id"]; 
                        $fizetesi_mod_megn = $sor["megnevezes"];
                        if ($fizetesi_mod_megn == $fizetesi_mod) {
                            echo "<option class='opt' value='$fizetesi_mod_megn' selected >$fizetesi_mod_megn</option>";
                        }
                        else{
                        echo "<option class='opt' value='$fizetesi_mod_megn'>$fizetesi_mod_megn</option>";
                    }
                    }
                ?>
                </select>
            </div>
            <div>
                <p class="input-p" id="megj">Megjegyzés</p>     
                <textarea name="megjegyzes" cols="40" rows="3"   placeholder="Ide írja a megjegyzését a rendeléshez..."><?php echo $megjegyzes ?></textarea>
            </div>
            <div class="alsoSor">
                <a class="submit" id="vissza" href="rendeles.php"><i class="fa-solid fa-arrow-left-long fa-xl"></i></a>
                <button class="submit" type="submit" name="submitRendeles"><i class="fa-solid fa-arrow-right-long fa-xl"></i></button>   
            </div>    
        </form>
    </div>
</body>
</html>