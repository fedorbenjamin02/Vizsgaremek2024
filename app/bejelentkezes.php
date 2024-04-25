<?php
//BEJELENTKEZÉS

session_start();
if (isset($_POST["submitBelep"])) {
	$email = $_POST["emailBelep"];
    //
    $_SESSION['email'] = $email;
    //
	$jelszo = md5($_POST["jelszoBelep"]);
	$lekerdezes = $db->query("SELECT * FROM felhasznalo_adatok WHERE email = '$email'");
	$eredmeny = $lekerdezes->fetchAll(PDO::FETCH_ASSOC);
    if ($eredmeny== null){
        $alert = <<< JS
        $(function() {
            var alert = document.getElementById('alert');
            alert.innerHTML ='Helytelen felhasználónév vagy jelszó!'; 
        });
        JS;
    }
	foreach ($eredmeny as $sor) {
		if ($jelszo==$sor['jelszo'/*az adatbazis mezo neve*/]) {
			$_SESSION['belepettE'] = true;
			header("Location: index.php");
		}
		else {
			$alert = <<< JS
			$(function() {
				var alert = document.getElementById('alert');
				alert.innerHTML ='Helytelen felhasználónév vagy jelszó!'; 
			});
			JS;
		} 
	}
}
?>