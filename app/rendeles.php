
<!DOCTYPE html>
<html lang="hu">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Friss Futár - Rendelés</title>
    <!--fontawesome a betűtípushoz és az ikonokhoz-->
    <script src="https://kit.fontawesome.com/ae360af17e.js" crossorigin="anonymous"></script>
    <!---->
    <link rel="stylesheet" href="css/rendelesDark.css">
    <script defer src="js/rendeles.js"></script>
    <script defer src="js/kosar.js"></script>
    <script src="jquery-3.6.3.min.js"></script>
</head>

<body id="body">
    <div id="oldal">rendeles</div>
    <div class="content">
        <!-- kosár form -->
        <?php include_once "kosar_form.php";?>
        <!-- kosar tartalma -->
        <div class="kosar" id="kosarDiv">
            <div class="kosar-felso">
                <div id="kosarHeader"></div>
                <div class="kosarTorles" id="torol"></div>
            </div>
            <div id="kosarBody"></div>
            <div id="kosarFooter"></div>
        </div>
    </div>
</body>
</html>