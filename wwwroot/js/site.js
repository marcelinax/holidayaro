const hotelDescriptions = [];
const hotelAttractions = [];
const hotelDescriptionsElement = document.querySelector("#hotel-descriptions .items");
const hotelDescriptionInputElement = document.querySelector("#hotel-descriptions input");
const hotelAttractionsElement = document.querySelector("#hotel-attractions .items");
const hotelAttractionsInputElement = document.querySelector("#hotel-attractions input");

const drawHotelDescriptions = () => {
    hotelDescriptionsElement.innerHTML = '';
    hotelDescriptions.forEach(hotelDescription => {
        const hotelDescriptionElement = document.createElement('span');
        hotelDescriptionElement.innerHTML = hotelDescription;
        hotelDescriptionsElement.appendChild(hotelDescriptionElement);
    })
}

hotelDescriptionInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        hotelDescriptions.push(e.target.value);
        drawHotelDescriptions();
        e.target.value = '';
    }
})


const drawHotelAttractions = () => {
    hotelAttractionsElement.innerHTML = '';
    hotelAttractions.forEach(hotelAttraction => {
        const hotelAttractionElement = document.createElement('span');
        hotelAttractionElement.innerHTML = hotelAttraction;
        hotelAttractionsElement.appendChild(hotelAttractionElement);
    })
}

hotelAttractionsInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        hotelAttractions.push(e.target.value);
        drawHotelAttractions();
        e.target.value = '';
    }
})