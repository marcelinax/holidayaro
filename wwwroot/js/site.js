const navItems = document.querySelectorAll('.nav-item');



if (location.pathname === '/') {
    navItems[0].classList.add('active');
}

