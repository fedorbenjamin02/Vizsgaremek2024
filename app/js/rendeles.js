// ---------------------------- oldal megnyitása, téma beállítása-------------------------------------
const theme = document.getElementsByTagName("link")[0];
window.addEventListener("load", () => {
  //tema
  const theme_prefered = localStorage.getItem('theme_pref_rendeles');
  if (theme_prefered != null) {
      theme.setAttribute('href', theme_prefered);
} 
});
// --------