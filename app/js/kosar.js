let kosarClick = 0;
let profilClick = 0;
let kosarE = false;
let profilE = false;

const kosar = document.getElementById('kosarDiv');
const profil = document.getElementById('profil-beallitasDiv');
//kosar
function kosarMegjelenit() {
    if (profilE) {
        profilMegjelenit()
    }
    if (kosarClick %2 == 0) {
        kosar.classList.add("kosar-tartalom-visible");
        kosarE = true; 
    }
    else {
        kosar.classList.remove("kosar-tartalom-visible"); 
        kosarE = false
    }
    kosarClick += 1;
}
//profil
function profilMegjelenit() {
    if (kosarE) {
        kosarMegjelenit()
    }
    if (profilClick %2 == 0) {
        profil.classList.add("profil-beallitasok-visible");
        profilE = true;
    }
    else {
        profil.classList.remove("profil-beallitasok-visible"); 
        profilE = false;
    }
    profilClick += 1;
}


$( document ).ready(function() {
    Kosar_Frissit();
});

function Kosar_Frissit()
{
    $.post
    (
      "kosar_adatok.php",
      $("#frm_kosar_adatok").serialize(),
    )
    .done(function(data,status){
        if(status == 'success')
        {
            var ret = JSON.parse(data);
            if(ret['hiba_kod'] == 0)
            {
                if(ret['adatok'] === false)
                {
                    var s = 'A kosár üres';
                }
                else
                {
                  
                  
                  if (document.getElementById('oldal').innerHTML=="rendeles") {
                    var header = '<a class="tovabb" href="index.php">Vissza</a>';
                    document.getElementById('torol').innerHTML = '<button onclick="KosarTorol()" class="torol_gomb">Kosár ürítése';
                    document.getElementById('kosarFooter').innerHTML = '<p class="footer_bal">Termék: <span class="kosar-kiemelt">' + ret['adatok']['db'] + ' db</span><br>'+
                    'Végösszeg: <span class="kosar-kiemelt">' + ret['adatok']['ertek'] + ' Ft</span></p>'+
                    '<p class="footer_jobb"><a class="tovabb" href="adatok_megadasa.php" >Tovább</a><p>';
                  }
                  else{
                    var header = '<p>Termék: <span class="kosar-kiemelt">' + ret['adatok']['db'] + ' db</span><br>'+
                    'Végösszeg: <span class="kosar-kiemelt">' + ret['adatok']['ertek'] + ' Ft</span></p>';
                    document.getElementById('torol').innerHTML = '<button onclick="KosarTorol()" class="torol_gomb">Kosár ürítése</button>';
                    document.getElementById('kosarFooter').innerHTML = '<button class="atlatszo-gomb"><a href="rendeles.php" class="tovabb_rendeleshez">Tovább a rendeléshez</a></button>';
                  }
                  
                }
                $('#kosarHeader').html(header);
                kosar_adatait_mutat(ret['adatok']);
            }
        }
    })
    .fail(function(data,status)
    {
        alert('hiba...');
    });
}

function HozzaAd(id,mennyiseg)
{
console.log(id+ ' <=> ' + mennyiseg);
  document.getElementById('termek').value = id;
  document.getElementById('darab').value = mennyiseg;
  $.post
  (
    "kosarba_tesz.php",
    $("#frm_kosar").serialize(),
  )
  .done(function(data,status){
      if(status == 'success')
      {
          var ret = JSON.parse(data);
          if(ret['hiba_kod'] == 0)
          {
              Kosar_Frissit();
              // ha a rendeles oldalon vagyunk akkor nem kell
              if (document.getElementById('oldal').innerHTML!="rendeles"){
                // ha nincs nyitva a kosár megnyijta, ha a profil nyitva van bezárja
              if (!kosarE) {
                if (!profilE) {
                    profilMegjelenit();
                  }
                kosarMegjelenit();
              }
              }
              
          }
      }
  })
  .fail(function(data,status)
  {
      alert('hiba...');
  });
}

function kosar_adatait_mutat(adatok)
{
    var parent = document.getElementById('kosarBody');
    parent.innerHTML = "";
    

    var sorok = adatok['sorok'];
    var n = sorok.length;
    
        for(let i = 0; i < n; i++)
        {
            //kosar elem
            var kosar_elem = document.createElement('div');
            kosar_elem.setAttribute('class','kosar-elem');
            parent.appendChild(kosar_elem);
            //kosar -bal
            var kosar_bal = document.createElement('div');
            kosar_bal.setAttribute('class','kosar-bal');
            kosar_elem.appendChild(kosar_bal);
            //kosar -jobb
            var kosar_jobb = document.createElement('div');
            kosar_jobb.setAttribute('class','kosar-jobb');
            kosar_elem.appendChild(kosar_jobb);
            //termek kep
            var t_kep = document.createElement('div');
            t_kep.setAttribute('class','t_kep');
            kosar_bal.appendChild(t_kep);
            // img
            var img = document.createElement("img");
            img.setAttribute('class','img-fluid t-img');
            img.setAttribute('src','img/'+sorok[i]["kep"]);
            t_kep.appendChild(img);
            //termek neve
            var t_nev = document.createElement('div');
            t_nev.setAttribute('class','t_nev');
            kosar_jobb.appendChild(t_nev);
            t_nev.innerHTML = sorok[i]['megn'];
            //termek ara
            var t_brutto = document.createElement('div');
            t_brutto.setAttribute('class','t_brutto');
            kosar_jobb.appendChild(t_brutto);
            t_brutto.innerHTML = sorok[i]['ar'] + ' Ft';
            //termek mennyisege
            var t_mennyiseg = document.createElement('div');
            t_mennyiseg.setAttribute('class','t_mennyiseg');
            kosar_jobb.appendChild(t_mennyiseg);
            t_mennyiseg.innerHTML = sorok[i]['menny'] + ' ' + sorok[i]['me'];
            //termek leirasa
            if (document.getElementById('oldal').innerHTML=="rendeles"){
                var t_leiras = document.createElement('div');
                t_leiras.setAttribute('class','t_leiras');
                kosar_elem.appendChild(t_leiras);
                t_leiras.innerHTML = sorok[i]['leiras'];
            }
            
            var kod = sorok[i]['id'];
            var s = '<button onclick="HozzaAd('+kod+',1)" class="kosar_gomb"><i class="fa-solid fa-plus"></i></button>'+
                    '<button onclick="HozzaAd('+kod+',-1)" class="kosar_gomb"><i class="fa-solid fa-minus"></i></button>';
                    
            t_mennyiseg.innerHTML += s;
        }
    
    
}

function KosarTorol()
{
    location.href = "kosar_torol.php";
}


                            
