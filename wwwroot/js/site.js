const navItems = document.querySelectorAll('.nav-item');

let reservationToPay = 0;
let hotelPrice = 0;

const payNowBtns = document.querySelectorAll('#pay-now-btn');
const paymentModal = document.querySelector('.payment-modal-bg');
const creditCardNumberInput = document.getElementById('card-number-input');
const creditCardHolderNameInput = document.getElementById('card-holder-name-input');
const paypalEmailInput = document.getElementById('paypal-email-input');
const cardPayment = document.getElementById('card-payment');
const paypalPayment = document.getElementById('paypal-payment');
const cvvInput = document.getElementById('ccv-input');
const monthSelect = document.getElementById('month-select');
const yearSelect = document.getElementById('year-select');
const makePaymentBtn = document.getElementById('make-payment-btn');
let paymentMethod = 'card';




if (location.pathname === '/') {
    navItems[0].classList.add('active');
}
if (location.pathname === '/MyReservations') {
    navItems[1].classList.add('active');
    if (!location.search)
        location.search = `?token=${userToken}`;
}




const showPaymentModal = (reservationId, price) => {
    paymentModal.classList.add('show');
    hotelPrice = price;
    reservationToPay = reservationId;
}




const initCreatePayment = () => {
    makePaymentBtn.addEventListener('click', () => {

        const paymentForm = {
            PaypalEmail: paypalEmailInput.value,
            CreditCardNumber: creditCardNumberInput.value,
            CreditCardHolderName: creditCardHolderNameInput.value,
            CreditCardExpirationMonth: monthSelect.value,
            CreditCardExpirationYear: yearSelect.value,
            CreditCardCvv: cvvInput.value,
            ReservationId: reservationToPay,
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
                paymentModal.classList.remove('show');
                location.reload();
            });
        }
    })
}

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
        if (!emailRegex.test(paypalEmailInput.value.toLowerCase())) {
            document.getElementById('paypal-email-error').innerHTML = 'Invalid Email.';
            isValid = false;
        }

    }
    return isValid;
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

renderMonthSelectOptions();
renderYearSelectOptions();
setPaymentMethod();
changePaymentForm();
initCreatePayment();