<?php
session_start();
unset($_SESSION['belepettE']);
unset($_SESSION['kosar']);
header("location:index.php");
?>