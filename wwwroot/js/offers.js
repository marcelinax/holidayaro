let hotels = [];
const offersBox = document.getElementById('offers');


const drawRatingStars = (hotel) => {
    let stars = ``;
    const starsCount = Math.ceil(hotel.rating /2) ;
    for (let i = 0; i < starsCount; i++) {
        stars += `<i class='bx bxs-star' ></i>`;
    }
    for (let i = starsCount; i < 5; i++) {
        stars += `<i class='bx bx-star' ></i>`;
    }
    return stars;
}



const drawHotel = (hotel) => {
    console.log(hotel.country);
    const hotelElement = document.createElement('div');
    hotelElement.classList.add('offer-box', 'col-4');
    const content = `
        <div class='offer-box-bg' style="background-image: url(${hotel.photosUrls.$values.length > 0 ? hotel.photosUrls.$values[0].photoUrl: ""})">
        <div class='offer-box-bg-country'>
        <p>${hotel.country}</p>
        </div>
        <div class='offer-box-bg-price'>
        <p>${hotel.price} $</p>
        </div>
        </div>
        <div class='offer-box-info p-3'>
        <h6>${hotel.name}</h6>
        <div class='offer-box-info-item stars-box'>
        ${drawRatingStars(hotel)}
        </div>
        <div class='offer-box-info-item'>
        <i class='bx bx-time'></i>
        <p>${hotel.days} days</p></div>
        </div>
     `;
    hotelElement.innerHTML = content;
    offersBox.appendChild(hotelElement);
}


const drawHotels = () => {
    return hotels.forEach(hotel => {
        drawHotel(hotel);
    })

}

const getAllHotels = () => {
    fetch('/api/hotelsapi').then(res => res.json()).then(data => {
        hotels = data.$values;
        console.log(hotels)
        drawHotels()
    })
}






getAllHotels();

console.log(hotels)
