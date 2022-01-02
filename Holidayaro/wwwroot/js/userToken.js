var userToken;


const generateUserToken = () => {
    const uniqueId = Date.now().toString(36) + Math.random().toString(36).substring(2);
    return uniqueId;
}

if (localStorage.getItem('reservationUserToken')) {
    userToken = localStorage.getItem('reservationUserToken');
}
else {
    userToken = generateUserToken();
    localStorage.setItem('reservationUserToken', userToken );
}