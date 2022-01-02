const starsBox = document.querySelector('.current-offer-stars-box');
const proposedOffersBox = document.querySelector('.current-offer-bottom-offers-box-inside');
const hotelMenuLink = document.getElementById('hotel-btn');
const roomMenuLink = document.getElementById('room-btn');
const boardMenuLink = document.getElementById('board-btn');
const currentOfferImg = document.querySelector('.current-offer-bg');
const galleryImages = document.querySelectorAll('.current-offer-top-box-gallery-item');
const imageModalImg = document.querySelector('.image-modal-img');
const imageModalBox = document.querySelector('.image-modal');
const closeImageModalBtn = document.getElementById('close-image-modal');
const currentHotelPathElements = location.pathname.split('/');


let currentMenuLink = 'hotel';
let hotels = [];


const setCurrentOfferImg = (img) => {
    galleryImages.forEach(galleryImg => {
        galleryImg.classList.remove('current');
        if (galleryImg.firstElementChild.style.backgroundImage.substring(5, galleryImg.firstElementChild.style.backgroundImage.length - 2) == img) {
            galleryImg.classList.add('current');
        }
    });


    currentOfferImg.style.backgroundImage = `url(${img})`;
}

const showImgModal = (img) => {
    imageModalImg.style.backgroundImage = `url(${img})`;
    imageModalBox.classList.add('show');
}


const renderStars = (rating) => {
    let stars = ``;
    const starsCount = Math.ceil(rating / 2);
    for (let i = 1; i <= starsCount; i++) {
        stars += `<i class='bx bxs-star' ></i>`;

    };
    for (let i = starsCount; i < 5; i++) {
        stars += `<i class='bx bx-star' ></i>`;
    };
    return stars;
}


const renderProposedOffers = () => {
    const currentHotelId = currentHotelPathElements[currentHotelPathElements.length - 1];
    
    let randomHotels = [];
    for (let i = 0; i < 3; i++) {
        let randomHotel;

        do {
            randomHotel = Math.floor(Math.random() * hotels.length)
        }
        while (randomHotels.includes(hotels[randomHotel]) || hotels[randomHotel].hotelId === +currentHotelId );
       
        console.log(hotels)
        randomHotels.push(hotels[randomHotel]);
    }
    randomHotels.forEach(hotel => {
        const proposedOfferBox = document.createElement('div');
        proposedOfferBox.classList.add('current-offer-bottom-offers-box-item');
        const content = `
        <div class='col-6 current-offer-bottom-offers-box-item-img px-2' style="background-image: url(${hotel.photosUrls.$values[0].photoUrl})"></div>
        <div class='col-6 current-offer-bottom-offers-box-item-info px-2'>
         <p class='name'>${hotel.name}</p>
        <p class='country'>${hotel.country}</p>
        <p class='price'>$${hotel.price}</p>
        <div class='stars-box'></div>
        </div>
    `;
        proposedOfferBox.innerHTML = content;
        proposedOfferBox.addEventListener('click', () => {
            location.pathname = `hotels/details/${hotel.hotelId}`;
        })
        const proposedOfferStarBox = proposedOfferBox.querySelector('.stars-box');
        proposedOfferStarBox.innerHTML = renderStars(hotel.rating);
        proposedOffersBox.appendChild(proposedOfferBox);
    })


}

const getAllHotels = () => {
    fetch('/api/hotelsapi').then(res => res.json()).then(data => {
        hotels = data.$values;
        renderProposedOffers();
    })
}

const renderInformationAboutHotel = () => {
    const hotelInformationBox = document.querySelector('.current-offer-bottom-hotel-information-box-main-hotel');
    const roomInformationBox = document.querySelector('.current-offer-bottom-hotel-information-box-main-room');
    const boardInformationBox = document.querySelector('.current-offer-bottom-hotel-information-box-main-board');

    if (currentMenuLink === 'hotel') {
        hotelInformationBox.classList.remove('d-none');
        roomInformationBox.classList.add('d-none');
        boardInformationBox.classList.add('d-none');
        hotelMenuLink.classList.add('active');
        roomMenuLink.classList.remove('active');
        boardMenuLink.classList.remove('active');

    }
    if (currentMenuLink === 'room') {
        roomInformationBox.classList.remove('d-none');
        boardInformationBox.classList.add('d-none');
        hotelInformationBox.classList.add('d-none');
        roomMenuLink.classList.add('active');
        boardMenuLink.classList.remove('active');
        hotelMenuLink.classList.remove('active');
    }
    if (currentMenuLink === 'board') {
        boardInformationBox.classList.remove('d-none');
        roomInformationBox.classList.add('d-none');
        hotelInformationBox.classList.add('d-none');
        boardMenuLink.classList.add('active');
        hotelMenuLink.classList.remove('active');
        roomMenuLink.classList.remove('active');
    }
}

starsBox.innerHTML = renderStars(hotelRating);
hotelMenuLink.addEventListener('click', () => {
    currentMenuLink = 'hotel'

    renderInformationAboutHotel();

});
roomMenuLink.addEventListener('click', () => {
    currentMenuLink = 'room';

    renderInformationAboutHotel();
});
boardMenuLink.addEventListener('click', () => {
    currentMenuLink = 'board';

    renderInformationAboutHotel();
});

renderInformationAboutHotel();
getAllHotels();
galleryImages[0].classList.add('current');
currentOfferImg.addEventListener('click', () => showImgModal(currentOfferImg.style.backgroundImage.substring(5, currentOfferImg.style.backgroundImage.length - 2)));
closeImageModalBtn.addEventListener('click', () => imageModalBox.classList.remove('show'))