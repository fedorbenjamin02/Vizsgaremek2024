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
					<h2 class="form-cim">Jelszó Módosítás</h2>
					<p class="inp-p">Új jelszó</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-unlock fa-lg fi"></i></div>
						<input class="inp" type="password" placeholder="Új " name="uj_jelszo">
                        
					</div>
					<p class="inp-p">Új jelszó megerősítése</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-unlock fa-lg fi"></i></div>
                        <input class="inp" type="password" placeholder="" name="uj_jelszo_mege">
						
					</div>
                    
                    

					<button type="submit" class="btn login" name="uj_jelszo_mentes">Módosítás</button>
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


if (isset($_POST["uj_jelszo_mentes"])) {

    $uj_jelszo = $_POST["uj_jelszo"];
    $uj_jelszo_mege = $_POST["uj_jelszo_mege"];
    $email = $_SESSION["email"] ;

    $nagyBetu = preg_match('@[A-Z]@', $uj_jelszo);
    $kisBetu = preg_match('@[a-z]@', $uj_jelszo);
    $szam    = preg_match('@[0-9]@', $uj_jelszo);
    $specialisKarakter = preg_match('@[^\w]@', $uj_jelszo);
    echo $email;
    if ($uj_jelszo==$uj_jelszo_mege) {
        if(!$nagyBetu || !$kisBetu || !$szam || !$specialisKarakter || strlen($uj_jelszo) < 8) {
            $alert = <<< JS
            $(function() {
                var alert = document.getElementById('alert');
                alert.innerHTML ='A jelszó nem elég erős';          
            });
            JS;
            echo "A jelszó nem elég erős";
        }
        else{
            $jelszo_modositott_feltolt = $db->query("UPDATE `felhasznalo_adatok` SET `jelszo` = MD5('$uj_jelszo') WHERE `email` = '$email';");  
            $eredmeny_modositott_jelszo = $jelszo_modositott_feltolt->fetchAll(PDO::FETCH_ASSOC);
            //UPDATE `felhasznalo_adatok` SET `jelszo` = MD5('Teszt123*') WHERE `email` = "teszt.elek@gmail.com";





        echo $uj_jelszo." ".$uj_jelszo_mege ." jooooooooooooooo jelszo";
        }
    }
    else {
        echo "A jelszó nem egyezik";
    }


}


?>