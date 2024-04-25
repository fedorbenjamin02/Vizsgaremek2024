<?php
    require "connect.php";
    $db = kapcs();

    // termékek ------------------------------------------------------------------------------------------------
    $adatok = array();
    $sql =  "SELECT t.id AS 'id', t.megnevezes AS 'megn', t.leiras AS 'leiras', t.kep AS 'kep',     
            t.netto_egyseg_ar AS 'netto_ar', tcs.megnevezes AS 'csoport', a.kulcs AS 'afa_kulcs', 
            m.megnevezes AS 'm_egyseg', tk.megnevezes AS 'kategoria'
            FROM termek AS t INNER JOIN afa_kulcsok AS a ON t.afa_kulcs_id = a.id  
            INNER JOIN termek_csoport AS tcs ON t.termek_csoport_id = tcs.id
            INNER JOIN mennyisegi_egysegek AS m ON t.mennyisegi_egysegek_id = m.id
            INNER JOIN termek_kategoria AS tk ON tcs.termek_kategoria_id = tk.id";
    $sql_termekek= $db->query($sql);
    $termekek = $sql_termekek->fetchAll(PDO::FETCH_ASSOC);
    foreach ($termekek as $t) {
        $id = $t['id'];
        $csoport = $t['csoport'];
        $megnevezes = $t['megn'];  
        $leiras = $t['leiras'];
        $kep = $t['kep'];
        $m_egyseg = $t['m_egyseg'];
        $netto_ar = $t['netto_ar'];
        $kategoria = $t['kategoria'];
        $afa_kulcs = $t['afa_kulcs'];
        $brutto_ar = ceil(($netto_ar+$netto_ar*($afa_kulcs/100))/10)*10; //10re kerekítés felfelé
        array_push($adatok,array("id"=>$id, "csoport"=>$csoport, "kep"=>$kep, "megn"=>$megnevezes, "afa"=>$afa_kulcs,
                     "me"=>$m_egyseg, "netto"=>$netto_ar,"ar"=>$brutto_ar, "leiras"=>$leiras, "kategoria"=>$kategoria));
    }
    //--------------------------------------------------------------------------------------------------------

    //termék csoportok --------------------------------------------------------------------------------------
    $termek_csoport_adatok = array();
    $sql =  "SELECT tcs.id AS 'id', tcs.megnevezes AS 'megn', tk.megnevezes AS 'kategoria'     
            FROM termek_csoport AS tcs 
            INNER JOIN termek_kategoria AS tk ON tcs.termek_kategoria_id = tk.id";
    $sql_csoportok = $db->query($sql);
    $csoportok = $sql_csoportok->fetchAll(PDO::FETCH_ASSOC);
    foreach ($csoportok as $cs) {
        $id = $cs['id'];
        $megnevezes = $cs['megn'];  
        $kategoria = $cs['kategoria'];
        array_push($termek_csoport_adatok,array("id"=>$id, "megn"=>$megnevezes, "kategoria"=>$kategoria));
    }
    //--------------------------------------------------------------------------------------------------------

    //termek kategoriak -------------------------------------------------------------------------------------
    $termek_kategoria_adatok = array();
    $sql =  "SELECT tk.id AS 'id', tk.megnevezes AS 'megn' FROM termek_kategoria AS tk";
    $sql_kategoriak = $db->query($sql);
    $kategoriak = $sql_kategoriak->fetchAll(PDO::FETCH_ASSOC);
    foreach ($kategoriak as $k) {
        $id = $k['id'];
        $megnevezes = $k['megn'];  
        array_push($termek_kategoria_adatok,array("id"=>$id, "megn"=>$megnevezes));
    }
    // --------------------------------------------------------------------------------------------------------

    //print_r($termek_adatok);
    //print_r($termek_csoport_adatok);
    //print_r($termek_kategoria_adatok);
?>