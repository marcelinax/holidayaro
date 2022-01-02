const currentHotelPathArr = location.pathname.split('/');
const reservationHeading = document.getElementById('reservation-heading');
const reservationModal = document.querySelector('.reservation-modal-bg');
const paymentModal = document.querySelector('.payment-modal-bg');
const reservationBtn = document.getElementById('book-btn');
const paymentBtn = document.getElementById('payment-btn');
const nameInput = document.getElementById('name-input');
const surnnameInput = document.getElementById('surname-input');
const emailInput = document.getElementById('email-input');
const phoneInput = document.getElementById('phone-input');
const dateOfBirthInput = document.getElementById('date-of-birth-input');
const creditCardNumberInput = document.getElementById('card-number-input');
const creditCardHolderNameInput = document.getElementById('card-holder-name-input');
const paypalEmailInput = document.getElementById('paypal-email-input');
const cardPayment = document.getElementById('card-payment');
const paypalPayment = document.getElementById('paypal-payment');
const cvvInput = document.getElementById('ccv-input');
const monthSelect = document.getElementById('month-select');
const yearSelect = document.getElementById('year-select');
const makePaymentBtn = document.getElementById('make-payment-btn');
let reservationToPayId = null;
let paymentMethod = 'card';


const renderMonthSelectOptions = () => {

    for (let i = 1; i <= 12; i++) {
        const selectOption = document.createElement('option');
        selectOption.innerHTML = i < 10 ? `0${i}` : i;
        selectOption.value = i < 10 ? `0${i}` : i;
        monthSelect.appendChild(selectOption);
    }

}

const renderYearSelectOptions = () => {

    for (let i = 2021; i <= 2025; i++) {
        const selectOption = document.createElement('option');
        selectOption.innerHTML = i;
        selectOption.value = i;
        yearSelect.appendChild(selectOption);
    }
}

const toggleShowReservationModal = () => {
    reservationBtn.addEventListener('click', () => {
        reservationModal.classList.add('show');
        reservationHeading.innerHTML = `Reservation <strong style='color:#6C63FF'>${hotelName}</strong>`;
    });
    document.getElementById('cancel-btn').addEventListener('click', () => {
        reservationModal.classList.remove('show');
    })
}

const clearReservationForm = () => {
    nameInput.value = '';
    surnnameInput.value = '';
    emailInput.value = '';
    phoneInput.value = '';
    dateOfBirthInput.value = '';
}

const togglePaymentModal = () => {

    paymentModal.classList.toggle('show');

}

const initCreatePayment = () => {
    makePaymentBtn.addEventListener('click', () => {

        const paymentForm = {
            PaypalEmail: paypalEmailInput.value,
            CreditCardNumber: creditCardNumberInput.value,
            CreditCardHolderName: creditCardHolderNameInput.value,
            CreditCardExpirationMonth: paymentMethod === 'card' ? monthSelect.value : '',
            CreditCardExpirationYear: paymentMethod === 'card' ? yearSelect.value : '',
            CreditCardCvv: cvvInput.value,
            ReservationId: reservationToPayId,
            PaymentAmount: hotelPrice
        }

        if (paymentValidation()) {
            fetch('/api/payments', {
                method: 'post',
                headers: {
                    "Content-Type": 'application/json'
                },
                body: JSON.stringify(paymentForm)
            }).then(res => res.json()).then(data => {

               
                alert('Payment has been confirmed!');
                reservationToPayId = null;
                togglePaymentModal();
            });
        }
    })
}

const clearPaymentValidation = () => {
    
        document.getElementById('card-number-error').innerHTML = '';
        document.getElementById('card-holder-name-error').innerHTML = '';
        document.getElementById('expiration-date-error').innerHTML = '';
        document.getElementById('cvv-error').innerHTML = '';
    document.getElementById('paypal-email-error').innerHTML = '';
   
}

const paymentValidation = () => {
    let isValid = true;
    const emailRegex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    const cardNumberRegex = /[0-9]{12}(?:[0-9]{3})?$/;
    clearPaymentValidation();
    if (paymentMethod === 'card') {
        if (creditCardNumberInput.value === '') {
            console.log(2)
            document.getElementById('card-number-error').innerHTML = 'The Card Number field is required';
            isValid = false;
        }
        if (!cardNumberRegex.test(creditCardNumberInput.value)) {
            console.log(1)
            document.getElementById('card-number-error').innerHTML = 'Invalid Credit Number.';
            isValid = false;
        }
        if (creditCardHolderNameInput.value === '') {
            document.getElementById('card-holder-name-error').innerHTML = 'The Card Holder Name field is required';
            isValid = false;
        }
       
        if (cvvInput.value === '') {
            document.getElementById('cvv-error').innerHTML = 'CVV is required';
            isValid = false;
        }
       
        if (moment(`${monthSelect.value}.${yearSelect.value}`, 'MM.YYYY') < moment()) {
            document.getElementById('expiration-date-error').innerHTML = 'Your Card is expired.';
            isValid = false;
        }
       

    }
    if (paymentMethod === 'paypal') {
        if (paypalEmailInput.value === '') {
            document.getElementById('paypal-email-error').innerHTML = 'The Email field is required';
            isValid = false;
        }
        if (!emailRegex.test(paypalEmailInput.value.toLowerCase())){
            document.getElementById('paypal-email-error').innerHTML = 'Invalid Email.';
            isValid = false;
        }

    }
    return isValid;
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
            PaymentAmount: hotelPrice,
            Date: moment(new Date())

        };
        if (checkReservationValidation()) {
            fetch('/api/reservations', {
                method: 'post',
                headers: {
                    "Content-Type": 'application/json'
                },
                body: JSON.stringify(createForm)
            }).then(res => res.json()).then(data => {
                reservationModal.classList.remove('show');
                clearReservationForm();
                togglePaymentModal();
                reservationToPayId = data.reservationId;
            })
        }

    })
};


const checkReservationValidation = () => {
    let isValid = true;
    clearValidation();

    const phoneRegex = /^\d{9}$/;
    const emailRegex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;

    if (nameInput.value === '') {
        document.getElementById('name-error').innerHTML = "The Name field is required.";
        isValid = false;
    }
    if (surnnameInput.value === '') {
        document.getElementById('surname-error').innerHTML = "The Surname field is required.";
        isValid = false;
    }
    if (emailInput.value === '') {
        document.getElementById('email-error').innerHTML = "The Email field is required.";
        isValid = false;
    }
    if (!emailRegex.test(emailInput.value)) {
        document.getElementById('email-error').innerHTML = "Invalid Email.";
        isValid = false;
    }
    if (phoneInput.value === '') {
        document.getElementById('phone-error').innerHTML = "The Phone field is required.";
        isValid = false;
    }
    if (!phoneRegex.test(phoneInput.value)) {
        document.getElementById('phone-error').innerHTML = "Invalid Phone.";
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
    if (moment(dateOfBirthInput.value, 'YYYY-MM-DD') > moment().subtract(18, 'years')) {
        document.getElementById('date-of-birth-error').innerHTML = "You are not old enough.";
        isValid = false;
    }
    return isValid;
}

const clearValidation = () => {
    document.getElementById('date-of-birth-error').innerHTML = '';
    document.getElementById('name-error').innerHTML = '';
    document.getElementById('surname-error').innerHTML = '';
    document.getElementById('phone-error').innerHTML = '';
    document.getElementById('email-error').innerHTML = '';
}


const setPaymentMethod = () => {
    cardPayment.addEventListener('click', () => {
        paymentMethod = 'card';
        changePaymentForm();
        renderMonthSelectOptions();
        renderYearSelectOptions();
        clearPaymentValidation();
    });
    paypalPayment.addEventListener('click', () => {
        paymentMethod = 'paypal';
        changePaymentForm();
        clearPaymentValidation();
    });
}


const changePaymentForm = () => {
    if (paymentMethod === 'card') {
        paypalEmailInput.disabled = true;
        paypalPayment.classList.add('disactive');
        cardPayment.classList.remove('disactive');
        creditCardHolderNameInput.disabled = false;
        creditCardNumberInput.disabled = false;
        monthSelect.disabled = false;
        yearSelect.disabled = false;
        cvvInput.disabled = false;

    }
    if (paymentMethod === 'paypal') {
        paypalEmailInput.disabled = false;
        paypalPayment.classList.remove('disactive');
        cardPayment.classList.add('disactive');
        creditCardHolderNameInput.disabled = true;
        creditCardNumberInput.disabled = true;
        monthSelect.disabled = true;
        yearSelect.disabled = true;
        cvvInput.disabled = true;
    }
}




toggleShowReservationModal();
initCreateReservation();
initCreatePayment();
renderMonthSelectOptions();
renderYearSelectOptions();
setPaymentMethod();
changePaymentForm();
