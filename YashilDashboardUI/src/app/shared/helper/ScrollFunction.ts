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
  if (currentMenu) {
    const currentMenuItemEl = document.getElementById('m_' + currentMenu);
    if (currentMenuItemEl) {
      currentMenuItemEl.click();
    }
  }
}

