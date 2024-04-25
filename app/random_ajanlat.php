<?php
//include_once "adatok.php";
// random heti ajanlat
$levesek = array();
$tesztak = array();
$pizzak = array();
$gyrosok = array();
$burgerek = array();
$frissensultek = array();

foreach ($adatok as $t) {
    switch ($t['csoport']) {
        case 'Levesek': array_push($levesek,$t['id']); break;
        case 'Pizzák': array_push($pizzak,$t['id']); break;
        case 'Tészták': array_push($tesztak,$t['id']); break;
        case 'Gyrosok': array_push($gyrosok,$t['id']); break;
        case 'Hamburgerek': array_push($burgerek,$t['id']); break;
        case 'Frissensültek': array_push($frissensultek,$t['id']); break;
        default: break;
    }
}

function random_termekeket_megjelenit($csoport,$adatok){
    $random = rand(0,count($csoport)-1);
    foreach ($adatok as $t) {
        if ($t['id'] == $csoport[$random]) {
            $kep = $t['kep'];
            $megnevezes = $t['megn'];
            $leiras = $t['leiras'];
            $brutto_ar = $t['ar'];
            echo"<div class='kartyak'>
                    <div class='kartya_tartalom-hidden'>
                        <div class='kartya-header'><img class='img-fluid kartya-img' src='img/$kep'
                                alt=''>$megnevezes</div>
                        <div class='kartya-body'>$leiras</div>
                        <div class='kartya-footer'>$brutto_ar Ft";
                    echo' <button  class="kosarhoz" onclick="HozzaAd('.$t['id'].',1)">Rendelés<i class="fa-solid fa-plus"></i></button>';
                echo"   </div>
                </div></div>";
        }
    }
}

random_termekeket_megjelenit($levesek,$adatok);
random_termekeket_megjelenit($burgerek,$adatok);
random_termekeket_megjelenit($frissensultek,$adatok);
random_termekeket_megjelenit($tesztak,$adatok);
random_termekeket_megjelenit($gyrosok,$adatok);
random_termekeket_megjelenit($pizzak,$adatok);

?>