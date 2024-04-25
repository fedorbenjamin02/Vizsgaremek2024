<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    
<?php
require_once "connect.php";
require_once "feltolt.php";

if (array_key_exists('OK', $_POST)) {
    //fizetesi_modok_feltolt();
    //termek_kategoria_feltolt();
    //termek_csoport_feltolt();
    //rendeles_statusza_feltolt();
    //afa_kulcsok_feltolt();
    //mennyisegi_egysegek_feltolt();
    //termek_feltoltes();

}







?>
<form action="teszt.php" method="post">
   <!-- id: <input type="text" name="id"><br>
    Megnevezés: <input type="text" name="megnevezes"><br>
    <button onclick="fizetesi_modok_feltolt()">OK</button>-->
    <input type="submit" value="OK feltölt" name="OK"  >
    
</form>



</body>
</html>

