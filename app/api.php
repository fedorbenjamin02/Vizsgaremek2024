<?php
require "adatok.php";
if (isset($_GET["kategoriak"])) {
    echo json_encode($termek_kategoria_adatok);
}
if (isset($_GET["adatok"])) {
    echo json_encode($adatok);
}
if (isset($_GET["csoportok"])) {
    echo json_encode($termek_csoport_adatok);
}
