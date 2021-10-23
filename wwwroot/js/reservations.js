const currentHotelPathArr = location.pathname.split('/');
const reservationHeading = document.getElementById('reservation-heading');
const reservationModal = document.querySelector('.reservation-modal-bg');
const reservationBtn = document.getElementById('book-btn');
const paymentBtn = document.getElementById('payment-btn');
const nameInput = document.getElementById('name-input');
const surnnameInput = document.getElementById('surname-input');
const emailInput = document.getElementById('email-input');
const phoneInput = document.getElementById('phone-input');
const dateOfBirthInput = document.getElementById('date-of-birth-input');


const toggleShowReservationModal = () => {
    reservationBtn.addEventListener('click', () => {
        reservationModal.classList.add('show');
        reservationHeading.innerHTML = `Reservation <strong style='color:#6C63FF'>${hotelName}</strong>`;
    });
    document.getElementById('cancel-btn').addEventListener('click', () => {
        reservationModal.classList.remove('show');
    })
}


const initCreateReservation = () => {
    const currentHotelId = currentHotelPathArr[currentHotelPathElements.length - 1];

    paymentBtn.addEventListener('click', () => {

        const createForm = {
            Name: nameInput.value,
            Surname: surnnameInput.value,
            Email: emailInput.value,
            Phone: phoneInput.value,
            DateOfBirth: dateOfBirthInput.value,
            HotelId: currentHotelId,
            UserToken: userToken,

        };
        if (checkReservationValidation()) {
            fetch('/api/reservations', {
                method: 'post',
                headers: {
                    "Content-Type": 'application/json'
                },
                body: JSON.stringify(createForm)
            }).then(res => console.log(res))
        }
        
    })
};


const checkReservationValidation = () => {
    let isValid = true;
    document.getElementById('date-of-birth-error').innerHTML = '';
    if (nameInput.value === '') {
        document.getElementById('name-error').innerHTML = "The Name field is required.";
        isValid = false;
    }
    if (surnnameInput.value === '') {
        document.getElementById('surname-error').innerHTML = "The Surname field is required.";
        isValid= false;
    }
    if (emailInput.value === '') {
        document.getElementById('email-error').innerHTML = "The Email field is required.";
        isValid = false;
    }
    if (phoneInput.value === '') {
        document.getElementById('phone-error').innerHTML = "The Phone field is required.";
        isValid = false;
    }
    if (dateOfBirthInput.value === '') {
        document.getElementById('date-of-birth-error').innerHTML = "The Date of Birth field is required.";
        isValid = false;
    }
    if (moment(dateOfBirthInput.value, 'YYYY-MM-DD') < moment().subtract(100, 'years')) {
        document.getElementById('date-of-birth-error').innerHTML = "You are probably dead.";
        isValid = false;
    }
    if (moment(dateOfBirthInput.value, 'YYYY-MM-DD') > moment()) {
        document.getElementById('date-of-birth-error').innerHTML = "Date of Birth cannot be greater than today.";
        isValid = false;
    }
    if (moment(dateOfBirthInput.value, 'YYYY-MM-DD') > moment().subtract(18, 'years')){
        document.getElementById('date-of-birth-error').innerHTML = "You are not old enough.";
        isValid = false;
    }
    return isValid;
}


toggleShowReservationModal();
initCreateReservation();