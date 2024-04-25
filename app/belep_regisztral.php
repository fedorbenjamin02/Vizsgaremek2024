<?php
	require "connect.php";
	$db = kapcs();
    include "regisztracio.php";
    include "bejelentkezes.php";
?>

<!DOCTYPE html>
<html lang="hu">
<head>
	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Bejelentkezés - Regisztráció</title>
	<script src="https://kit.fontawesome.com/ae360af17e.js" crossorigin="anonymous"></script>
    <!---->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script defer src="js/popup.js"></script>
    <link rel="stylesheet" href="css/belepesDark.css">
</head>
<body id="body">

	<div class="seged">
    
        <div class="form-container">
        
            <!-- regisztráció form -->
            <div class="form-popup" id="form-regisztracio">
                <form action="" method="post" class="form" id="formRegisztracio">
                <h2 class="form-cim">Regisztráció</h2>
                    <div id="tabNumber"></div>
                    <div class="form-group Step">
                        <h2 class="form-alcim">Fiók Adatok</h2>
                        <p class="inp-p-reg">E-mail cím</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-envelope fa-lg fi"></i></div>
                            <input class="inp" type="email" placeholder="E-mail..." name="email" required>
                        </div>
                        <p class="inp-p-reg">Jelszó</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-unlock fa-lg fi"></i></div>
                            <input class="inp" id="jelszo" type="password" placeholder="Adja meg jelszavát..." name="jelszo" required>
                        </div>
                        <p class="inp-p-reg">Jelszó megerősítése</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-lock fa-lg fi"></i></div>
                            <input class="inp" type="password" placeholder="Jelszó ismét..." name="jelszoujra" id="jelszoujra" required>
                        </div>
                    </div>
                    <div class="form-group Step">
                        <h2 class="form-alcim">Személyes Adatok</h2>
                        <p class="inp-p-reg">Vezetéknév</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-user fa-lg fi"></i></div>
                            <input class="inp" type="text" placeholder="vezetéknév..." name="vezetek" required>
                        </div>
                        <p class="inp-p-reg">Keresztnév</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-user fa-lg fi"></i></div>
                            <input class="inp" type="text" placeholder="keresztnév..." name="kereszt" required>
                        </div>
                        <p class="inp-p-reg">Telefonszám</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-phone fa-lg fi"></i></div>
                            <input class="inp" type="tel" id="tel" placeholder="+36 30 ..." name="telefon" required>
                        </div>
                    </div>
                    <div class="form-group Step">
                        <h2 class="form-alcim">Szállítási Cím</h2>
                        <p class="inp-p-reg">Irányítószám</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-location-dot fa-lg fi"></i></div>
                            <input class="inp" type="number" placeholder="Irányítószám..." name="iszam" required>
                        </div>
                        <p class="inp-p-reg">Település</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-location-dot fa-lg fi"></i></div>
                            <input class="inp" type="text" placeholder="Település..." name="telepules" required>
                        </div>
                        <p class="inp-p-reg">utca, házszám</p>
                        <div class="input">
                            <div class="formIcon"><i class="fa-solid fa-location-dot fa-lg fi"></i></div>
                            <input class="inp" type="text" placeholder="Utca, házszám..." name="utcaHazszam" required>
                        </div>
                    </div>
                    
                    <input type="button" id="btnPrevious" value="Vissza" class="btn"
                        onclick="ButtonClick(-1)" name="Previous" />
                    <input readonly type="button" id="btnNext" value="Tovább" class="btn" onclick="ButtonClick(1)" 
                        name="Next" />
                    <script src="https://code.jquery.com/jquery-3.7.0.slim.min.js"></script>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.5/jquery.validate.min.js"></script>
                    <script>
                        let CurrentForm = 0;

                        ShowForm(CurrentForm);
                        
                        function ShowForm(n) {
                            let x = document.getElementsByClassName("Step");

                            x[n].style.display = "block";

                            document.getElementById("btnPrevious").style.display =
                                n == 0 ? "none" : "flex";

                            document.getElementById("btnNext").value =
                                x.length - 1 == n ? "Regisztráció" : "Tovább";
							document.getElementById("btnNext").name =
                                x.length - 1 == n ? "submitRegisztral" : "Next";
                            document.getElementById("btnNext").type =
                                x.length - 1 == n ? "submit" : "Tovább";

                            document.getElementById("tabNumber").innerHTML = n + 1 + "/" + x.length;
                        }

                        

                        function ButtonClick(n) {
                            if (n==-1) {
                                
                                $("#formRegisztracio").validate();
                                let x = document.getElementsByClassName("Step");
                                if (n == 1 && !$("#formRegisztracio").valid()) return false;
                                x[CurrentForm].style.display = "none";
                                document.getElementById("btnNext").style.transform = "translateX(0)";
                                CurrentForm = CurrentForm + n;
                                if (x.length == CurrentForm) {                                    
                                    return false;
                                }
                                ShowForm(CurrentForm);
                                
                            }
                            else if (CurrentForm==0) {
                                var jelszo = document.getElementById("jelszo").value;
                                var jelszoujra = document.getElementById("jelszoujra").value;
                                if (jelszoEllenorzes(jelszo,jelszoujra)) {
                                    $("#formRegisztracio").validate();
                                    let x = document.getElementsByClassName("Step");
                                    if (n == 1 && !$("#formRegisztracio").valid()) return false;
                                    x[CurrentForm].style.display = "none";
                                    document.getElementById("btnNext").style.transform = "translateX(0)";
                                    CurrentForm = CurrentForm + n;
                                    if (x.length == CurrentForm) {                                    
                                        return false;
                                    }
                                    ShowForm(CurrentForm);
                                }
                                else{ 
                                    
                                    if (jelszo != jelszoujra) {
                                        alert("A két jelszó nem egyezik")
                                    }
                                    else
                                    {
                                        alert("A jelszó nem elég erős (Tartalmazzon legalább 1 kis -és nagy betűt, számot,  specialiskaraktert és minimum 8 karakter hosszú legyen)")
                                    }
                                }
                            }
                            else if (CurrentForm==1) {
                                var telszam = document.getElementById("tel").value;
                                if (telefonEllenorzes(telszam)) {
                                    $("#formRegisztracio").validate();
                                    let x = document.getElementsByClassName("Step");
                                    if (n == 1 && !$("#formRegisztracio").valid()) return false;
                                    x[CurrentForm].style.display = "none";
                                    document.getElementById("btnNext").style.transform = "translateX(0)";
                                    CurrentForm = CurrentForm + n;
                                    if (x.length == CurrentForm) {                                    
                                        return false;
                                    }
                                    ShowForm(CurrentForm);
                                }
                                else{ 
                                    alert("Telefonszám nem megfelelő")
                                }
                            }
                        }
                        function telefonEllenorzes(telszam) {
                            var telszam1tol = String(telszam).substring(1);
                            var sv=parseInt(telszam1tol);
                            if (telszam.length<13 && telszam.length>8 && Number.isInteger(sv))    
                            {
                                return true;
                            }
                            return false;
                        }

                        function jelszoEllenorzes(jelszo,jelszoujra) {
                            var nagyBetu = jelszo.match(/[A-Z]/);
                            var kisBetu= jelszo.match(/[a-z]/);
                            var szam = jelszo.match(/[0-9]/);
                            var specialisKarakter = jelszo.match(/[^\w]/);
                            if (jelszo==jelszoujra) 
                            {
                                if(!nagyBetu || !kisBetu || !szam || !specialisKarakter || jelszo.length < 8) {
                                   return false;    
                                }
                                else{
                                    return true;
                                }
                            }
                            else {return false;}
                        }

                    </script>
                    
                    <a href="index.php"><button type="button" class="btn-cancel"><i
								class="fa-regular fa-circle-xmark fa-xl close"></i></button></a>
                </form>
            </div>
			<!-- bejelentkezés form -->
			<div class="form-popup" id="form-bejelentkezes">
				<form action="" method="post" class="form" id="formBejelentkezes">
					<h2 class="form-cim">Bejelentkezés</h2>
					<p class="inp-p">E-mail-cím</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-user fa-lg fi"></i></div>
						<input class="inp" type="email" placeholder="E-mail..." name="emailBelep"  required>
					</div>
					<p class="inp-p">Jelszó</p>
					<div class="input">
						<div class="formIcon"><i class="fa-solid fa-unlock fa-lg fi"></i></div>
						<input class="inp" type="password" placeholder="Adja meg jelszavát..." name="jelszoBelep"  required>
					</div>
					
					<button type="submit" class="btn login" name="submitBelep">Bejelentkezés </button>
				</form>
				<a href="index.php"><button type="button" class="btn-cancel"><i
						class="fa-regular fa-circle-xmark fa-xl close"></i></button></a>
			</div>
			<!-- Overlay -->
			<div class="overlay-container">
					<div class="overlay">
						<div class="overlay-panel" id="overlay-left">
							<button class="btn" id="belep">Bejelentkezés</button>
						</div>
						<div class="overlay-panel" id="overlay-right">
							<button class="btn" id="regisztral">Regisztráció</button>
						</div>
					</div>
			</div> 
            
        </div>
        
    </div>
    <div id="alert"><script><?= $alert?></script></div> 
</body>
</html>