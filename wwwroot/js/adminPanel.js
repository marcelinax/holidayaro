const sidebarLinks = document.querySelectorAll('.sidebar-link-item');

if (location.pathname == '/Hotels') {
    sidebarLinks[1].classList.add('active');
}
if (location.pathname === '/ReservationsAdmin') {
    sidebarLinks[2].classList.add('active');
}
if (location.pathname === '/PaymentsAdmin') {
    sidebarLinks[3].classList.add('active');
}


