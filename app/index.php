<?php
	session_start();
    include_once "adatok.php";
    
    if (!isset($_SESSION['belepettE'])) {
        $_SESSION['belepettE'] = false;
    }
    
    if ($_SESSION['belepettE']) {
        $emailcim = $_SESSION['email'];
        $sql_teljes_nev = $db->query("SELECT teljes_nev FROM felhasznalo_adatok WHERE email = '$emailcim'");
        $eredmeny_nev = $sql_teljes_nev->fetchAll(PDO::FETCH_DEFAULT);
        foreach ($eredmeny_nev as $sor) {
        $teljes_nev = $sor['teljes_nev'];
    }
    }
?>
<!DOCTYPE html>
<html lang="hu">

<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Friss Futár</title>
    <!--fontawesome a betűtípushoz és az ikonokhoz-->
    <script src="https://kit.fontawesome.com/ae360af17e.js" crossorigin="anonymous"></script>
    <!---->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <link rel="stylesheet" href="css/indexDark.css">
    <script defer src="js/index.js"></script>
    <script defer src="js/popup.js"></script>
    <script src="jquery-3.6.3.min.js"></script>
    <script defer src="js/kosar.js"></script>
</head>

<body id="body">
    <div id="oldal">index</div>
    <!--wrapper-->
    <div class="wrapper">
        <!-- Sidebar -->
        <aside id="sidebar">
            <div class="h-100">
                <div class="logo">
                    <div id="logokep"></div>
                </div>
                <!-- gomb a sidebar behúzására -->
                <button class="sidebar_toggle" type="button">
                    <i class="fa-solid fa-arrow-right-arrow-left fa-lg"></i>
                </button>
                <!-- oldal tetejére ugrás -->
                <div class="fel">
                    <button class="fel_gomb" type="button" data-bs-theme="dark">
                        <a href="#fent">
                            <i class="fa-solid fa-arrow-up-long fa-xl"></i>
                        </a>
                    </button>
                </div>
                <!-- Sidebar Navigáció -->
                <ul class="sidebar-nav">
                    <li class="sidebar-item">
                        <!--Fiók-->
                        <?php
                            if (!$_SESSION['belepettE']) {
                                echo '
                                <a href="#" class="sidebar-link collapsed" data-bs-toggle="collapse" data-bs-target="#fiok"
                                    aria-expanded="false" aria-controls="fiok">
                                    <i class="fa-regular fa-user fa-lg pe-2"></i>
                                    Fiók
                                </a>
                                <ul id="fiok" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                                    <li class="sidebar-item">
                                        <a href="belep_regisztral.php" onclick="openLogin()" class="sidebar-link"><span
                                                class="fiok_al">Bejelentkezés</a>
                                    </li>
                                    <li class="sidebar-item">
                                        <a href="belep_regisztral.php" onclick="openRegister()" class="sidebar-link"><span
                                                class="fiok_al">Regisztráció</a>
                                    </li>
                                </ul></li>
                                ';
                            }
                            else{
                                echo'
                                <a href="#Kuponok" class="sidebar-link">
                                    <i class="fa-solid fa-tags pe-2"></i>
                                    Kuponok
                                </a></li>';
                            }
                        ?>
                        <!--Fiók vége-->
                        <!--Étlap-->
                    <li class="sidebar-item">
                        <a href="#" class="sidebar-link collapsed" data-bs-toggle="collapse" data-bs-target="#etlap"
                            aria-expanded="false" aria-controls="etlap">
                            <i class="fa-solid fa-utensils  fa-lg pe-2"></i>
                            Étlap
                        </a>
                        <ul id="etlap" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                            <li class="sidebar-item">
                                <div class="etlap">
                                    <a href="#etelek" class="sidebar-link collapsed" data-bs-toggle="collapse"
                                        data-bs-target="#etel" aria-expanded="false" aria-controls="etel">
                                        <i class="fa-solid fa-drumstick-bite pe-2"></i>
                                        <span class="etlap_almenu">Ételek</span>
                                    </a>
                                    <ul id="etel" class="sidebar-dropdown list-unstyled collapse">
                                        <!--étlap almenu 2-->
                                        <div class="etel_almenu">
                                            <?php
                                            $n = count($termek_csoport_adatok);
                                            for ($i=0; $i < $n; $i++) { 
                                                // ételek
                                                if ($termek_csoport_adatok[$i]['kategoria']=="Étel") {
                                                    $cs_nev = $termek_csoport_adatok[$i]['megn'];
                                                    echo
                                                    "<li class='sidebar-item'>
                                                        <a href='#$cs_nev' class='sidebar-link'><span>$cs_nev</span></a>
                                                    </li>";
                                                }
                                            }
                                            ?>
                                        </div>
                                    </ul>
                                    <a href="#italok" class="sidebar-link collapsed" data-bs-toggle="collapse"
                                        data-bs-target="#ital" aria-expanded="false" aria-controls="ital">
                                        <i class="fa-solid fa-whiskey-glass pe-2"></i>
                                        <span class="etlap_almenu">Italok</span>
                                    </a>
                                    <ul id="ital" class="sidebar-dropdown list-unstyled collapse">
                                        <!--étlap almenu 1-->
                                        <div class="ital_almenu">
                                            <?php
                                            $n = count($termek_csoport_adatok);
                                            for ($i=0; $i < $n; $i++) { 
                                                // italok
                                                if ($termek_csoport_adatok[$i]['kategoria']=="Ital") {
                                                    $cs_nev = $termek_csoport_adatok[$i]['megn'];
                                                    echo
                                                    "<li class='sidebar-item'>
                                                        <a href='#$cs_nev' class='sidebar-link'><span>$cs_nev</span></a>
                                                    </li>";
                                                }
                                            }
                                            ?>
                                        </div>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </li>
                    <!--Étlap vége-->
                    <!--Kapcsolat-->
                    <li class="sidebar-item">
                        <a href="#kapcsolat" class="sidebar-link">
                            <i class="fa-solid fa-link pe-2"></i>
                            Kapcsolat
                        </a>
                    </li>
                    <!--Kapcsolat vége-->
                    </li>
                    <li class="sidebar-item">
                        <div class="switch">
                            <div class="form-check">
                                <input class="input_check" type="checkbox" role="switch" id="theme" name="theme"
                                    onclick="toggleTheme()">
                                <label class="form-check-label" for="theme" id="tema_valtas">sötét mód</label>
                            </div>
                        </div>
                    </li>
                </ul>
                <!--Sidebar Navigation vége-->
            </div>
        </aside>
        <!-- Fő tartalom -->
        <div class="main" id="fent">
            <header>
                <div class="navtop">
                    <nav class="navbar navbar-expand px-3">
                        <div class="nav-kosar">           
                            <button class="atlatszo-gomb" onclick="kosarMegjelenit()"><i class="fa-solid fa-cart-shopping fa-xl" ></i></button>
                        </div>
                        <div class="nav-logo"></div>
                        <!-- Keresés-->
                        <input class="kereses" type="text" placeholder="Keresés..">
                        <?php
                            if ($_SESSION['belepettE']) {
                                echo "<div id='profil'>
                                <div class='felhasznalo'>$teljes_nev</div>
                                <div class='profil-ikon'><button class='atlatszo-gomb' onclick='profilMegjelenit()'>
                                <i class='fa-regular fa-user fa-xl'></i></button></div>
                                </div>
                                ";
                            }
                        ?>
                        <div class="profil-beallitasok-hidden" id="profil-beallitasDiv">
                            <a class="kijelentkezes" href="kijelentkezes.php">Kijelentkezés <i class="fa-solid fa-arrow-right-from-bracket"></i></a>
                            <hr class="profil-hr">
                            <a class="beallitasok" href="fiok_beallitasok.php">Beállítások <i class="fa-solid fa-gear"></i></a>
                        </div>
                    </nav>
                </div>
            </header>
            <!--content-->
            <div class="content" id="cont">
                <!--heti ajanlat-->
                <h2>Kiemelt ajánlataink</h2>
                <div class="grid" id="heti_ajanlat_grid">
                    <?php
                        include_once "random_ajanlat.php";
                    ?>
                </div>
                <!--kuponok-->
                <?php
                    if ($_SESSION['belepettE']) {
                        echo '<h2 class="h2_nagy_margin" id="Kuponok">Kuponok</h2>
                        <div class="grid" id="kupon_grid">';
                        foreach ($adatok as $t) {
                            if ($t['csoport'] == 'Kupon') {
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
                        echo '</div>';
                    }
                ?> 
                <!--Menu kezdete-->
                <div class="menu">
                    <!-- Ételek + Italok-->
                    <?php
                        include_once "termekek_megjelenit.php";
                        // Ételek
                        echo "<h2>Ételek</h2>";
                        termekeketMegjelenit("Étel",$termek_csoport_adatok,$adatok);
                        // Italok
                        echo "<h2>Italok</h2>";
                        termekeketMegjelenit("Ital",$termek_csoport_adatok,$adatok);
                    ?>
                </div>
                <script type="text/javascript">
                    var csop_adatok = <?php echo json_encode($termek_csoport_adatok); ?>;
                </script>
                <!-- kosár form -->
                <?php include_once "kosar_form.php";?>
                <!-- kosar tartalma -->
                <div class="kosar-tartalom-hidden" id="kosarDiv">
                    <div class="kosarTorles" id="torol"></div>
                    <div id="kosarHeader"></div>
                    <div id="kosarBody"></div>
                    <div id="kosarFooter"></div>
                </div>

                <div id = "kapcsolat" >
                    <p >Email cím: </p>
                    <p >Telefonszám: </p>
                    <p >Fax: </p>
                    <p >Frissfutár Vác </p>
                    <p >Frontendre vár</p>
                </div>


                <footer>
                    <div class="foot">
                        <div class="footer-logo"></div>
                        <div class="footer-content">Köszönjük, ha minket választasz!</div>
                    </div>
                </footer>
            </div>
            <!-- Fő tartalom vége -->
        </div>
        <!--content vége-->
</body>
<!--scripts-->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe"
    crossorigin="anonymous"></script>


</html>