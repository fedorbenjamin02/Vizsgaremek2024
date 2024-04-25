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
    <link rel="stylesheet" href="">
    <script defer src="js/fiok.js"></script>
</head>

<body id="body">
    
    <div class="form-popup">
				<form action="" method="post" class="form">
					<h2 class="form-cim">Telefonszám Módosítás</h2>
					<p class="inp-p">Új Telefonszám</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-phone fa-lg fi"></i></div>
						<input class="inp" type="tel" placeholder="Új " name="uj_telefon">
                        
					
                    
                    

					<button type="submit" class="btn login" name="uj_telefon_mentes">Módosítás</button>
				</form>
				<a href="fiok_beallitasok.php"><button type="button" class="btn-cancel"><i
						class="fa-regular fa-circle-xmark fa-xl close"></i></button></a>
			</div>
           
         

    
</body>
</html>



<?php 
require "connect.php";
$db = kapcs();
include ("bejelentkezes.php");


if (isset($_POST["uj_telefon_mentes"])) {

    $uj_telefonszam = $_POST["uj_telefon"];
    $uj_telszam_hossz = strlen($uj_telefonszam);
  
    $email = $_SESSION["email"] ;
    echo $email;
    echo $uj_telefonszam. "  fff ";

   

    if ($uj_telszam_hossz<13 && $uj_telszam_hossz>8 ) {
        $jelszo_modositott_feltolt = $db->query("UPDATE `felhasznalo_adatok` SET `telefonszam` = '$uj_telefonszam' WHERE `email` = '$email';");  
        $eredmeny_modositott_jelszo = $jelszo_modositott_feltolt->fetchAll(PDO::FETCH_ASSOC);
        //UPDATE `felhasznalo_adatok` SET `jelszo` = MD5('Teszt123*') WHERE `email` = "teszt.elek@gmail.com";
        echo $uj_telefonszam." jooooooooooooooo telszam";
        }
        else {
            echo " nem megfelelő hosszú a telefonszám";
        }
    }
    





?>