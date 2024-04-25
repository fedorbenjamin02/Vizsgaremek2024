<?php
session_start();
include "kosar_fv.php";

$vissza = [];
$vissza['hiba_kod'] = 0;
$vissza['info'] = "";
$vissza['adatok'] = false;

if(isset($_SESSION['kosar']) && isset($_POST['kosaradatai']) && $_POST['kosaradatai'] == "ok")
{
    $vissza['adatok'] = KosarAdatok($_SESSION['kosar']);
}
echo json_encode($vissza);
?>