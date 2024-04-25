//valtozok definialasa
const toggler = document.querySelector(".sidebar_toggle");
const content = document.getElementById("cont");
const sidebar = document.getElementById("sidebar");
const navbar = document.querySelector(".navtop");
const footer = document.querySelector(".foot");
const theme_switch = document.getElementById('tema_valtas');
const check = document.getElementById('theme');
const footer_content = document.querySelector('.footer-content');
let clickSzam = 0;
// az összes <link> tagből az 1-es indexű (2.)-at választja ki, amely a css fájl (első a bootstrap)
const theme = document.getElementsByTagName('link')[1]; 
// px et vw be konvertál
function convertPXToVW(px) {
    return px * (100 / document.documentElement.clientWidth);
}
// várakozás
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
//------------------------------------- RESIZE -------------------------------------------
window.addEventListener("resize", () => {
    if (document.documentElement.clientWidth <=700) {
      content.style.marginLeft = "0px";
      content.style.width = "100vw";
      sidebar.style.backgroundColor = "var(--sidebar_hatter)";
    }
    else {
        sidebar.style.backgroundColor = "var(--sidebar_hatter-transparent)";
        let currentVW = 100-convertPXToVW(320);
        let VW = parseFloat(currentVW);
        //sidebar ki és behúzása
        //content szélesítése 320px-el
        if (clickSzam % 2 == 1) {
            content.style.marginLeft = "0px";
            content.style.width = "100vw";
            footer_content.style.marginLeft = '0px';
        }
        //content zsugorítása 320px-el
        else {
            content.style.marginLeft = "320px";
            // az aktualis 100vw -320px érték megadása
            content.style.width = VW+"vw";
            footer_content.style.marginLeft = '320px';
        }
    }
  });
//-----------------------------------------SIDEBAR-----------------------------------
toggler.addEventListener("click",function()
{
    //témaváltás animációjának visszaállítása
    content.style.transition = "all 0.3s ease-in-out";
    sidebar.style.transition = "all 0.35s ease-in-out";
    //sidebar ki és behúzása
    sidebar.classList.toggle("collapsed");
    clickSzam += 1;
    
    //content szélesítése 320px-el
    if (document.documentElement.clientWidth <= 700) {
        content.style.marginLeft = "0px";
        content.style.width = "100vw";
    }
    else {
        // az aktuális (vw) képernyő szélesség ből kivon 320px értékű (vw) -t
        let currentVW = 100-convertPXToVW(320);
        let VW = parseFloat(currentVW);
        //content szélesítése 320px-el
        if (clickSzam % 2 == 1) {
            content.style.marginRight = "320px";
            content.style.marginLeft = "0px" ;
            content.style.width = VW+"vw" ;
            content.style.marginRight = "0px";
            sleep(50).then(() => { content.style.width = "100vw" });
            footer_content.style.marginLeft = '0px';
        }
        //content zsugorítása 320px-el
        else {
            content.style.marginLeft = "320px";
            // az aktualis 100vw -320px érték megadása
            content.style.width = VW+"vw";

            footer_content.style.marginLeft = '320px';
        }
    }
    setTimeout(function(){
      window.scrollTo(window.scrollX, window.scrollY - 1);
    window.scrollTo(window.scrollX, window.scrollY + 1);
    }, 300);
    
});
// ---------------------------- oldal megnyitása -------------------------------------
window.addEventListener("load", () => {
    //ha sötéttel kezdünk, ne legyen világosról sötétre váltásnak animációja
    content.style.transition = "0";
    sidebar.style.transition = "0";
    // content igazítás
    if (document.documentElement.clientWidth <= 700) {
        footer_content.style.marginLeft = '0px';
        content.style.marginLeft = "0px";
        content.style.width = "100vw";
        sidebar.style.backgroundColor = "var(--sidebar_hatter)";
        sidebar.classList.toggle("collapsed");
        clickSzam += 1;
    }
    else{
        let currentVW = 100-convertPXToVW(320);
        let VW = parseFloat(currentVW);
        content.style.width = VW+"vw";
        footer_content.style.marginLeft = '320px';
    }
    //téma beállítás
    const theme_prefered = localStorage.getItem('theme_pref');
    if (theme_prefered != null) {
        theme.setAttribute('href', theme_prefered);
    }
    else{
        theme.setAttribute('href','css/indexLight.css');   
    }    
    // checkbox beállítása
    if (theme_prefered == 'css/indexDark.css') {
        theme_switch.innerHTML = "világos mód"; 
        check.style.accentColor = "yellow";   
    }
    else{
        theme_switch.innerHTML = "sötét mód";
        check.style.accentColor = "orange"; 
    }
    handleScrollAnimation();
    handleScrollAnimation2();
});
// -------------------- sötét és világos téma közti váltás ----------------------------
function toggleTheme() { 
    //témaváltás animációjának visszaállítása
    content.style.transition = "all 0.3s ease-in-out";
    sidebar.style.transition = "all 0.3s ease-in-out";
    // a href értékének felülírása -> css fájl cseréje
    if (theme.getAttribute('href') == 'css/indexLight.css') { 
        //mentes
        localStorage.setItem('theme_pref','css/indexDark.css');
        //belepes oldal temajanak mentese
        localStorage.setItem('theme_pref_popup','css/belepesDark.css');
        //beallitasok oldal temajanak mentese
        localStorage.setItem('theme_pref_fiok','css/fiokDark.css');
        //rendeles oldal temajanak mentese
        localStorage.setItem('theme_pref_rendeles','css/rendelesDark.css');
        //beallitas
        theme.setAttribute('href', 'css/indexDark.css'); 
        localStorage.setItem('current','világos mód');
        check.style.accentColor = "yellow";
    } 
    else { 
        //mentes
        localStorage.setItem('theme_pref', 'css/indexLight.css');
        //belepes oldal temajanak mentese
        localStorage.setItem('theme_pref_popup', 'css/belepesLight.css');
        //beallitasok oldal temajanak mentese
        localStorage.setItem('theme_pref_fiok','css/fiokLight.css');
        //rendeles oldal temajanak mentese
        localStorage.setItem('theme_pref_rendeles','css/rendelesLight.css');
        //beallitas
        theme.setAttribute('href', 'css/indexLight.css'); 
        localStorage.setItem('current','sötét mód');
        check.style.accentColor = "orange"; 
    }
}
// ---------------------------- SCROLL --------------------------------------------
//1. scroll
const scrollElements = document.querySelectorAll(".kartya_tartalom-hidden");
const scrollElements2 = document.querySelectorAll(".oldal-kartya-hidden");
//vertikális
const elementInView = (el, dividend = 1) => {
  const elementTop = el.getBoundingClientRect().top;
  return (
    elementTop <=
    (window.innerHeight || document.documentElement.clientHeight) / dividend
  );
};
const elementOutofView = (el) => {
  const elementTop = el.getBoundingClientRect().top;
  return (
    elementTop > (window.innerHeight || document.documentElement.clientHeight)
  );
};
const displayScrollElement = (element) => {
  element.classList.add("kartya_tartalom-visible");
};
const displayScrollElement2 = (element) => {
  element.classList.add("oldal-kartya-visible");
};
const hideScrollElement = (element) => {
  element.classList.remove("kartya_tartalom-visible")
};
const hideScrollElement2 = (element) => {
  element.classList.remove("oldal-kartya-visible")
};
const handleScrollAnimation = () => {
  
  scrollElements.forEach((el) => {
    if (elementInView(el, 1.25)) {
      displayScrollElement(el);
    } else if (elementOutofView(el)) {
      hideScrollElement(el)
    }
  })
}
const handleScrollAnimation2 = () => {
  
  scrollElements2.forEach((el) => {
    if (elementInView(el, 1.25)) {
      displayScrollElement2(el);
    } else if (elementOutofView(el)) {
      hideScrollElement2(el)
    }
  })
}
window.addEventListener("scroll", () => { 
  handleScrollAnimation();
  handleScrollAnimation2();
});
//--------------------- sidebar ki / be ---------------------------

//------------------- LAPOZÓ GOMBOK ----------------------------------

function balra(csop) {
  var container = document.getElementById("id_"+csop);
  var tavolsag = container.offsetWidth;
  container.scrollTo({
    left:container.scrollLeft - tavolsag,
    top: 0,
    behavior: "smooth"
  });
}

function jobbra(csop) {
    var container = document.getElementById("id_"+csop);
    var tavolsag = container.offsetWidth;
    container.scrollTo({
      left:container.scrollLeft + tavolsag,
      top: 0,
      behavior: "smooth"
    });
}







