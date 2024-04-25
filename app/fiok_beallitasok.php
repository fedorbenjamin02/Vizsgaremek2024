<?php 
require "connect.php";
$db = kapcs();
include_once ("bejelentkezes.php");

$email = $_SESSION["email"];
$lekerdezes_felhasznaloi_adatok = $db->query("SELECT * FROM felhasznalo_adatok WHERE email = '$email'");
$eredmeny_felhasznaloi_adatok = $lekerdezes_felhasznaloi_adatok->fetchAll(PDO::FETCH_ASSOC);
foreach ($eredmeny_felhasznaloi_adatok as $sor )
{ 
    $id = $sor["id"];
    $telefonszam = $sor["telefonszam"];
    
}
$lekerdezes_szallitasicim = $db->query("SELECT * FROM szallitasi_cim WHERE felhasznalo_adatok_id = '$id'");
$eredmeny_szallitasicim = $lekerdezes_szallitasicim->fetchAll(PDO::FETCH_ASSOC);
foreach ($eredmeny_szallitasicim as $sor )
{ 
    $telepules_id = $sor["telepules_id"];
    $utca_hazszam = $sor["utca_hazszam"];
}

$lekerdezes_telepules = $db->query("SELECT * FROM telepulesek WHERE id = '$telepules_id'");
$eredmeny_telepules = $lekerdezes_telepules->fetchAll(PDO::FETCH_ASSOC);
foreach ($eredmeny_telepules as $sor )
{ 
    $telepules = $sor["telepules"];
}





if (isset($_POST["telefonszam_modosit"])) {
    header("Location: telefonszam_modosit.php");
}


if (isset($_POST["jelszo_modosit"])) {
    header("Location: jelszo_modosit.php");
}

if (isset($_POST["szallitasicim_modosit"])) {
    header("Location: szallitasicim_modosit.php");
}






?>

<!DOCTYPE html>
<html lang="hu">

<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Friss Futár - Beállítások</title>
    <!--fontawesome a betűtípushoz és az ikonokhoz-->
    <script src="https://kit.fontawesome.com/ae360af17e.js" crossorigin="anonymous"></script>
    <!---->
    <link rel="stylesheet" href="css/indexDark.css">
    <script defer src="js/fiok.js"></script>
</head>
<body id="body">
    <div class="form-popup formAlap">
				<form action="" method="post" class="form">
					<h2 class="form-cim">Fiók beállítások</h2>
					
                    <div class="ikonok">
                        <div class="formIcon"><i class="fa-solid fa-phone fa-lg fi"></i></div>
                        <div class="formIcon"><i class="fa-solid fa-unlock fa-lg fi"></i></div>
                        <div class="formIcon"><i class="fa-solid fa-location-dot"></i></div>
                    </div>
                    <div class="gombok">
                        <button class="gomb" id="telefonszam_modosit" name = "telefonszam_modosit"  >Telefonszám módosítás</button> 
                        <button class="gomb" id="jelszo_modosit" name = "jelszo_modosit" >Jelszó módosítás</button>
                        <button class="gomb" id="szallitasicim_modosit" name = "szallitasicim_modosit">Szállitási cím módosítás</button>
                    </div>
                            
                    <a href="index.php"><button class="btn-cancel"><i class="fa-solid fa-arrow-left-long fa-lg fi"></i></button></a>
				</form>
			</div>
</body>
</html>

<!--<script>
    function Telefonszam_modosit() {
        document.getElementById("telefonszam_modosit").name = "telefonszam_modosit";
        //alert(document.getElementById("telefonszam_modosit").name);
 
    }

    function Jelszo_modosit() {
        document.getElementById("jelszo_modosit").name = "jelszo_modosit";
        //alert(document.getElementById("jelszo_modosit").name);
 
    }



</script>-->

