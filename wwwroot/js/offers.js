let hotels = [];
let countries = [];
const offersBox = document.getElementById('offers');
const priceFilter = document.getElementById('price-filter-input');
const minDaysFilter = document.getElementById('min-days-select');
const maxDaysFilter = document.getElementById('max-days-select');
const starsFilterBox = document.querySelector('.stars-filter-box');
const countriesFilterBox = document.querySelector('.countries-filter-box');
let filteredStarRating = -1;
let filteredCountries = [];


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
    const hotelElement = document.createElement('div');
    hotelElement.classList.add('offer-box', 'col-4');
    const content = `
        <a href='/hotels/details/${hotel.hotelId}'>
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
        </a>
     `;
    hotelElement.innerHTML = content;
    offersBox.appendChild(hotelElement);
}


const renderSelectOptions = () => {
    for (let i = 1; i <= 28; i++) {
        const optionElement = document.createElement('option');
        optionElement.value = i;
        if (i === 1) {
            optionElement.innerHTML = `${i} day`;
   
        }
        else {
            optionElement.innerHTML = `${i} days`
         
            optionElement.addEventListener('click', () => {
                minDaysFilter.value = i;
            })
           
        };
        minDaysFilter.appendChild(optionElement.cloneNode(true));
        maxDaysFilter.appendChild(optionElement.cloneNode(true));
        maxDaysFilter.value = 28;
        minDaysFilter.value = 7;
    }
}

const renderStarsFilterBoxButtons = () => {
    for (let i = 0; i < 5; i++) {
        const starFilterButton = document.createElement('button');
        starFilterButton.classList.add('star-btn');
        const content = `
           <p>${i + 1}</p>
           <i class='bx bxs-star'></i>
        `;
        starFilterButton.addEventListener('click', () => {
            filteredStarRating = +i + 1;
            drawHotels();
        });
        starFilterButton.innerHTML = content;
        starsFilterBox.appendChild(starFilterButton)
    }
}

const renderCountriesFilters = () => {
    console.log(countries)
    countries.forEach(country => {
        const countryFilterBox = document.createElement('div');
        countryFilterBox.classList.add('country-filter-box');
        const content = `
            <div class='checkbox'></div>
            <p>${country}</p>
        `;
        
        countryFilterBox.innerHTML = content;
        countryFilterBox.addEventListener('click', () => {
            filteredCountries.push(country);
            drawHotels();
        });
        countriesFilterBox.appendChild(countryFilterBox);
    })
}


const filteredHotels = () => {
    let filtered = hotels;

    const priceMax = priceFilter.value;
    document.getElementById('price-filter-input-value').innerHTML = priceFilter.value;
    if (priceMax) {
        filtered = filtered.filter(h => h.price <= priceMax);
    }
    if (filteredStarRating !== -1) {
        filtered = filtered.filter(h => Math.ceil(h.rating /2) === filteredStarRating);
        console.log(filtered)
    }
    if (filteredCountries.length > 0) {
        filtered = filtered.filter(h => filteredCountries.includes(h.country));
    }
    if (minDaysFilter.value) {
        filtered = filtered.filter(h => h.days >= minDaysFilter.value );
    }
    if (maxDaysFilter.value) {
        filtered = filtered.filter(h => h.days <= minDaysFilter.value );
    }

    return filtered;
}

const drawHotels = () => {
    offersBox.innerHTML = '';
    return filteredHotels().forEach(hotel => {
        drawHotel(hotel);
    })

}




const getAllHotels = () => {
    fetch('/api/hotelsapi').then(res => res.json()).then(data => {
        hotels = data.$values;
        countries = data.$values.map(value => value.country);
        renderCountriesFilters();
        drawHotels()
    })
}

getAllHotels();
renderSelectOptions();
renderStarsFilterBoxButtons();
priceFilter.addEventListener('change', () => drawHotels());
minDaysFilter.addEventListener('change', () => drawHotels());

