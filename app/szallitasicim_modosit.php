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
					<h2 class="form-cim">Szállítási cím  Módosítás</h2>
					<p class="inp-p">Új település</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-phone fa-lg fi"></i></div>
						<input class="inp" type="text" placeholder="Új " name="uj_telepules">

                        <p class="inp-p">Új utca házszám</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-phone fa-lg fi"></i></div>
						<input class="inp" type="text" placeholder="Új " name="uj_utca_hazszsam">
                        
                        
					
                    
                    

					<button type="submit" class="btn login" name="uj_szallitasicim_mentes">Módosítás</button>
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


if (isset($_POST["uj_szallitasicim_mentes"])) {

    $uj_utca_hazszam = $_POST["uj_utca_hazszsam"];
    $uj_telepules = $_POST["uj_telepules"];

    $email = $_SESSION["email"] ;

    $felhasznalo_adatok_id_feltotl = $db->query("SELECT `id` FROM `felhasznalo_adatok` WHERE `email` = '$email';" );
    $eredmeny_felhasznalo_adatok_id = $felhasznalo_adatok_id_feltotl->fetchAll(PDO::FETCH_ASSOC);
    foreach ($eredmeny_felhasznalo_adatok_id as $sor1)
    {
         $felhasznalo_adatok_id = $sor1["id"];   
    }


    $lekerdezes_teleules_id = $db->query("SELECT `id` FROM `telepulesek` WHERE `telepules` = '$uj_telepules';" );
    $eredmeny_teleules_id = $lekerdezes_teleules_id->fetchAll(PDO::FETCH_ASSOC);
    foreach ($eredmeny_teleules_id as $sor1)
    {
         $telepules_id = $sor1["id"];   
    }
    if ($eredmeny_teleules_id != null){
    $szallitasicim_modositott_feltolt = $db->query("UPDATE `szallitasi_cim` SET `utca_hazszam` = '$uj_utca_hazszam' , `telepules_id` = '$telepules_id' WHERE `felhasznalo_adatok_id` = '$felhasznalo_adatok_id';");  
    $eredmeny_modositott_szallitasicim = $szallitasicim_modositott_feltolt->fetchAll(PDO::FETCH_ASSOC);
    echo "modosítva";
    }
    else{
        echo "nem létező település";
    }
  


    }
    





?>