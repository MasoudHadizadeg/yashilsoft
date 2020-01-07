export function ScrollTop() {
  window.scroll(0, 0);
}

export function ShowScrollButtonFunctionality() {
  window.onscroll = () => {
    if (pageYOffset > 400) {
      document.getElementById('scroll-up-btn').style.display = 'flex';
    } else {
      document.getElementById('scroll-up-btn').style.display = 'none';
    }
  };
}


export function ScrollAfterRouteChange(currentMenu: any) {
  const currentSection = document.getElementById(currentMenu.finalUrl.fragment);
  if (currentSection) {
    const currentMenuItemEl = document.getElementById('#' + currentMenu.finalUrl.fragment);
    currentMenuItemEl.click();
  }
}
