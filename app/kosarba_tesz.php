<?php
  session_start();
  include "kosar_fv.php";

  $vissza = [];
  $vissza['hiba_kod'] = 0;
  $vissza['info'] = "";
  $vissza['adatok'] = [];
  if(isset($_POST['termek'], $_POST['darab']))
  {
      $id = $_POST['termek'];
      $db = $_POST['darab'];
      if(!isset($_SESSION['kosar']))
        $_SESSION['kosar'] = [];
      $hol = KosarbanKeres($_SESSION['kosar'],$id);
      if($hol == -1)
      {
        $_SESSION['kosar'][] = array("id" => $id, "menny" => $db);
      }
      else
      {
        if($_SESSION['kosar'][$hol]['menny'] + $db > 0)
          $_SESSION['kosar'][$hol]['menny'] += $db;
        else
        $_SESSION['kosar'][$hol]['menny'] = 0;
      }
      $vissza['adatok'] = KosarAdatok($_SESSION['kosar']);
  }
  else
  {
    $vissza['hiba_kod'] = 1;
    $vissza['info'] = "Nincs kiválasztott termék!";
  }
  echo json_encode($vissza);
?>