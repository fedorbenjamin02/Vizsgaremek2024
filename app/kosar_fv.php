<?php
include_once "adatok.php";
// ----------------------------------------
function KosarbanKeres($kosar, $id)
{
$n = count($kosar);
for($i = 0; $i < $n; $i++)
{
    if($kosar[$i]['id'] == $id)
    {
        return $i;
    }
}
return -1;
}  
// ----------------------------------------
function KosarAdatok($kosar)
{
    global $adatok;
    $n = count($adatok);
    $darab = count($kosar);
    $kosar_osszeg = 0;
    $kosar_tetel_db = 0;
    $kosar_tetelek = [];
    for($i = 0; $i < $darab; $i++)
    {
      if($kosar[$i]['menny'] > 0)
      {
        $id = $kosar[$i]['id'];
        $j = 0;
        while($j < $n && $adatok[$j]['id'] != $id)
        {
          $j++;
        }
        if($j < $n)
        {
          $kosar_tetelek[] = $adatok[$j];
          $kosar_tetelek[count($kosar_tetelek)-1]['menny'] = $kosar[$i]['menny'];
          $kosar_tetelek[count($kosar_tetelek)-1]['ar2'] = number_format($adatok[$j]['ar'], 2, ',', ' ');
          $kosar_tetelek[count($kosar_tetelek)-1]['ertek'] = number_format($adatok[$j]['ar'] * $kosar[$i]['menny'], 2, ',', ' ');
          $kosar_osszeg += $adatok[$j]['ar'] * $kosar[$i]['menny'];
          $kosar_tetel_db++;
        }
      }
    }
    if($kosar_tetel_db > 0)
    {
      for($i = 0; $i < $kosar_tetel_db - 1; $i++)
      {
        for($j = $i + 1; $j < $kosar_tetel_db; $j++)
        {
          if($kosar_tetelek[$i]['megn'] > $kosar_tetelek[$j]['megn'])
          {
            $sv = $kosar_tetelek[$i];
            $kosar_tetelek[$i] = $kosar_tetelek[$j];
            $kosar_tetelek[$j] = $sv;
          }
        }
      }
      return array("db" => $kosar_tetel_db,
                   "ertek" => $kosar_osszeg,
                   "sorok" => $kosar_tetelek);
    }
    else
      return array("db" => 0, "ertek"=> 0, "sorok"=>[]);
}
// ----------------------------------------
?>