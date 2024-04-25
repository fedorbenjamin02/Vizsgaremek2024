<?php
function termekeketMegjelenit($kategoria,$termek_csoport_adatok,$adatok)
{
    $n = count($termek_csoport_adatok);
    for ($i=0; $i < $n; $i++) { 
        if ($termek_csoport_adatok[$i]['kategoria']==$kategoria){
            $csoport = $termek_csoport_adatok[$i]['megn'];
            echo 
            "<h3 id='$csoport'>$csoport</h3>
            <div class='menu-item-container' >
                <div class='lapoz'><button class='atlatszo-gomb' id='$csoport-elozo' onclick='balra(`$csoport`)'><i class='fa-solid fa-chevron-left fa-xl'></i></button></div>";
            echo "<div class='oldal-kartya-hidden' id='id_$csoport'>";
            //az aktuális csoport termékei
            $n2 = count($adatok);
            for ($j=0; $j < $n2; $j++) { 
                if ($adatok[$j]['csoport']==$csoport) {
                    $id = $adatok[$j]['id'];
                    $kep = $adatok[$j]['kep'];
                    $megnevezes = $adatok[$j]['megn'];
                    $leiras = $adatok[$j]['leiras'];
                    $brutto_ar = $adatok[$j]['ar'];
                    echo"<div class='oldal-kartya_tartalom ok_$csoport'> 
                            <div class='oldal-kartya-header'>
                                <img class='img-fluid kartya-img' src='img/$kep'alt=''>$megnevezes</div>
                            <div class='oldal-kartya-body'>$leiras</div>
                            <div class='oldal-kartya-footer'>$brutto_ar Ft";
                        echo ' <button class="kosarhoz" onclick="HozzaAd('.$adatok[$j]['id'].',1)">Rendelés<i class="fa-solid fa-plus"></i></button>';
                        echo"</div>
                        </div>";
                }
            }
            echo "</div>";
            echo "<div class='lapoz'><button class='atlatszo-gomb' id='$csoport-kovetkezo' onclick='jobbra(`$csoport`)'><i class='fa-solid fa-chevron-right fa-xl'></i></button></div>";
            echo "</div>";
        }
    }
}
?>