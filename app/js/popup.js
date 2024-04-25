
const theme = document.getElementsByTagName("link")[1];
const container = document.querySelector(".form-container");
const elsoRegOldal = document.getElementById("elso-oldal");
const masodikRegOldal = document.getElementById("masodik-oldal");
const tovabbGomb = document.querySelector(".tovabb");
const regisztracioGomb = document.querySelector(".register");
const visszaGomb = document.querySelector(".btn-back");

function openLogin() {
  localStorage.setItem('mode','');
}
function openRegister() {
  localStorage.setItem('mode','r');
}
function closeForm()
{
  close();
}
function login() {
  //login code
}
function register() {
  //register code
}
function tovabb(){
  elsoRegOldal.classList.add("hidden");
  masodikRegOldal.classList.remove("hidden");
  regisztracioGomb.removeAttribute("hidden");
  tovabbGomb.setAttribute("hidden","true");
  visszaGomb.classList.remove("hidden");
}
function vissza(){
  elsoRegOldal.classList.remove("hidden");
  masodikRegOldal.classList.add("hidden");
  tovabbGomb.removeAttribute("hidden");
  regisztracioGomb.setAttribute("hidden","true");
  visszaGomb.classList.add("hidden");
}
const signInBtn = document.getElementById("belep");
const signUpBtn = document.getElementById("regisztral");
signInBtn.addEventListener("click", () => {
  container.classList.remove("regisztracio");
});

signUpBtn.addEventListener("click", () => {
  container.classList.add("regisztracio");
});

// ---------------------------- oldal megnyitása, téma beállítása-------------------------------------
window.addEventListener("load", () => {
    const current = localStorage.getItem('mode');
    if (current == 'r') {
      container.classList.add("regisztracio");
    }
  //ha sötéttel kezdünk, ne legyen világosról sötétre váltásnak animációja
  //téma beállítás
  const theme_prefered = localStorage.getItem('theme_pref_popup');
  if (theme_prefered != null) {
      theme.setAttribute('href', theme_prefered);
} 
});
// --------


