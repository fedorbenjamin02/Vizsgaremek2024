<?php
function kapcs()
{
    $host = "localhost";
    $user = "root";
    $pwd = "";
    $dbname = "frissfutar";

    $s = "mysql:host=$host;dbname=$dbname;charset=utf8;port:3306";
    $db = new PDO($s, $user, $pwd);
    return $db;
}
?>