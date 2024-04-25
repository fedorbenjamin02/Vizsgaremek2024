<?php
require_once "connect.php";
function fizetesi_modok_feltolt()
{
    $fa_tomb = array("készpénz", "bankkártya", "SZÉP-kártya");

    for ($i = 0; $i < count($fa_tomb); $i++) {
        $id = $i + 1;
        $megnevezes = $fa_tomb[$i];
        $sql = "INSERT INTO `fizetesi_modok` (`id`, `megnevezes`) VALUES ('$id', '$megnevezes');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }
}

function termek_kategoria_feltolt()
{
    $tk_tomb = array("Étel", "Ital");

    for ($i = 0; $i < count($tk_tomb); $i++) {
        $id = $i + 1;
        $megnevezes = $tk_tomb[$i];
        $sql = "INSERT INTO `termek_kategoria` (`id`, `megnevezes`) VALUES ('$id', '$megnevezes');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }
}

function termek_csoport_feltolt()
{
    $etel_tomb = array("Hamburgerek", "Frissensültek", "Tészták", "Levesek", "Gyrosok", "Pizzák", "Mártások", "Saláták", "Köretek", "Desszertek");
    $ital_tomb = array("Szénsavas üdítők", "Gyümölcslevek", "Energiaitalok", "Szeszes italok", "Teák", "Ásványvizek");

    for ($i = 0; $i < count($etel_tomb); $i++) {
        $id = $i + 1;
        $t_k_id = 1;
        $megnevezes = $etel_tomb[$i];
        $sql = "INSERT INTO `termek_csoport` (`id`, `termek_kategoria_id`, `megnevezes`) VALUES ('$id', '$t_k_id', '$megnevezes');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }
    for ($i = 0; $i < count($ital_tomb); $i++) {
        $id = NULL;
        $t_k_id = 2;
        $megnevezes = $ital_tomb[$i];
        $sql = "INSERT INTO `termek_csoport` (`id`, `termek_kategoria_id`, `megnevezes`) VALUES ('$id', '$t_k_id', '$megnevezes');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

}
function rendeles_statusza_feltolt()
{
    $rs_tomb = array("rendelés felvéve", "rendelés készen áll szálításra", "kiszállítva");

    for ($i = 0; $i < count($rs_tomb); $i++) {
        $id = $i + 1;
        $rendeles_allapot = $rs_tomb[$i];
        $sql = "INSERT INTO `rendeles_statusza` (`id`, `rendeles_allapot`) VALUES ('$id', '$rendeles_allapot');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }
}
function afa_kulcsok_feltolt()
{
    $ak_tomb_meg = array("27%", "15%", "0%","AAM","TAM");
    $ak_tomb_kulcs = array(27,15,0,0,0);

    for ($i=0; $i <count($ak_tomb_meg); $i++) { 
        $id = NULL;
        $megnevezes = $ak_tomb_meg[$i];
        $kulcs = $ak_tomb_kulcs[$i];
        $sql = "INSERT INTO `afa_kulcsok` (`id`, `megnevezes`,`kulcs`) VALUES ('$id', '$megnevezes','$kulcs');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }




}

function mennyisegi_egysegek_feltolt()
{
    $me_tomb = array("cm", "l", "db","adag","g");
    

    for ($i=0; $i <count($me_tomb); $i++) { 
        $id = NULL;
        $megnevezes = $me_tomb[$i];
       
        $sql = "INSERT INTO `mennyisegi_egysegek` (`id`, `megnevezes`) VALUES ('$id', '$megnevezes');";
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }




}

function termek_feltoltes()
{
    $t_tomb_lev = array("Fokhagyma krémleves", "Gyümölcsleves", "Halászlé","Brokkoli krémleves","Paradicsomleves","Bableves","Gulyásleves","Húsleves");
    $t_tomb_bur = array("Marha hamburger", "Csirke hamburger", "Sertés hamburger","Magyaros hamburger", "Retro hamburger");
    $t_tomb_friss = array("Rántott hús", "Rántott sajt", "Cigány pecsenye","Rostonsült Csirekmell", "Cordon Bleu");
    $t_tomb_tesztak = array("Milánói makaróni", "Spenótos tészta", "Csirkés penne","Carbonara spagetti", "Szecsuáni csípős tészta");

    $t_tomb_gyros = array("Gyros tál", "Gyros pitában", "Gyros tortillában");

    $t_tomb_pizza = array("Margaréta pizza", "Hawaii pizza", "SonGoKu pizza","Magyaros pizza","Húsimádó pizza","Gyros pizza","Szalámis pizzas","Sonkás Kukoricás pizza", "Ketész pizza");

    $t_tomb_martas = array("Tartár mártás", "BBQ szósz", "Bazsalikomos ketchup","Kapor mártás", "Sajt mártás" ,"Mézes mustáros mártás");

    $t_tomb_salatak = array("Görög saláta", "Cézár saláta", "Gyümölcs saláta","Krumli saláta");

    $t_tomb_koretek = array("Steak burgonya", "Burgonypüré", "Rizs","Sült krumli", "Rizibizi");

    $t_tomb_desszertek = array("Francia krémes", "Sajt torta", "Linzer","Tiramisu", "Palacsinta");


    $t_tomb_szensavasu = array("Coca-cola", "Pepsi", "Fanta narancs","Szentkirályi szénsavas","Mizse szénsavas","Nestlé szénsavas");

    $t_tomb_gyumolcsL = array("Almalé", "Narancslé", "Baracklé");

    $t_tomb_energiai = array("Redbull energiaital", "Monster energiaital", "Hell energiaital");

    $t_tomb_szeszes = array("Borsodi", "Aranyászok", "Heineken","Thummerer Egri Tréfli Cuvée vörös édes");

    $t_tomb_teak = array("Fuze tea citromos", "Fuze tea barackos", "Rauch citromos","Rauch barackos");

    $t_tomb_asvanyvizek = array("Szentkirályi szénsavmentes", "Mizse szénsavmentes", "Nestlé szénsavmentes");

    /*for ($i=0; $i <count($t_tomb_lev); $i++) { 
        $id = NULL;
        $termek_csoport_id = 4;
        $megnevezes = $t_tomb_lev[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 500;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }*/


    for ($i=0; $i <count($t_tomb_bur); $i++) { 
        $id = NULL;
        $termek_csoport_id = 1;
        $megnevezes = $t_tomb_bur[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 510;
        $menyiseg = 3;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_friss); $i++) { 
        $id = NULL;
        $termek_csoport_id = 2;
        $megnevezes = $t_tomb_friss[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 600;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_tesztak); $i++) { 
        $id = NULL;
        $termek_csoport_id = 3;
        $megnevezes = $t_tomb_tesztak[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 400;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_gyros); $i++) { 
        $id = NULL;
        $termek_csoport_id = 5;
        $megnevezes = $t_tomb_gyros[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 300;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_pizza); $i++) { 
        $id = NULL;
        $termek_csoport_id = 6;
        $megnevezes = $t_tomb_pizza[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1300;
        $menyiseg = 1;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_martas); $i++) { 
        $id = NULL;
        $termek_csoport_id = 7;
        $megnevezes = $t_tomb_martas[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1300;
        $menyiseg = 5;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_salatak); $i++) { 
        $id = NULL;
        $termek_csoport_id = 8;
        $megnevezes = $t_tomb_salatak[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1400;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_koretek); $i++) { 
        $id = NULL;
        $termek_csoport_id = 9;
        $megnevezes = $t_tomb_koretek[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_desszertek); $i++) { 
        $id = NULL;
        $termek_csoport_id = 10;
        $megnevezes = $t_tomb_desszertek[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 4;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_szensavasu); $i++) { 
        $id = NULL;
        $termek_csoport_id = 11;
        $megnevezes = $t_tomb_szensavasu[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 2;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_gyumolcsL); $i++) { 
        $id = NULL;
        $termek_csoport_id = 12;
        $megnevezes = $t_tomb_gyumolcsL[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 2;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_energiai); $i++) { 
        $id = NULL;
        $termek_csoport_id = 13;
        $megnevezes = $t_tomb_energiai[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 2;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }

    for ($i=0; $i <count($t_tomb_szeszes); $i++) { 
        $id = NULL;
        $termek_csoport_id = 14;
        $megnevezes = $t_tomb_szeszes[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 2;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_teak); $i++) { 
        $id = NULL;
        $termek_csoport_id = 15;
        $megnevezes = $t_tomb_teak[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 2;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }


    for ($i=0; $i <count($t_tomb_asvanyvizek); $i++) { 
        $id = NULL;
        $termek_csoport_id = 16;
        $megnevezes = $t_tomb_asvanyvizek[$i];
        $leiras = "leirasIde";
        $kep = "kepIde";
        $netto_ar = 1500;
        $menyiseg = 2;
        $afa_kulcs = 2;
        
       
        $sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES ('$id', '$termek_csoport_id', '$megnevezes', '$leiras', '$kep',  '$netto_ar', '$menyiseg', '$afa_kulcs');";
        
        $db = kapcs();
        $stm = $db->prepare($sql);
        $stm->execute();
        $db = null;
    }



    
}



//INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`, `leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES (NULL, '4', 'Sajtleves', 'sajtos', 'asd', '400', '4', '2');


?>