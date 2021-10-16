const hotelDescriptions = [];
const hotelAttractions = [];
const hotelDescriptionsElement = document.querySelector("#hotel-descriptions .items");

const hotelDescriptionInputElement = document.querySelector("#hotel-descriptions input");
const hotelAttractionsElement = document.querySelector("#hotel-attractions .items");
const hotelAttractionsInputElement = document.querySelector("#hotel-attractions input");

const drawHotelDescriptions = () => {
    hotelDescriptionsElement.innerHTML = '';
    hotelDescriptions.forEach((hotelDescription,index) => {
        const hotelDescriptionElement = document.createElement('span');
        hotelDescriptionElement.innerHTML = `${hotelDescription} <small class='delete'>x</small>`;
        hotelDescriptionElement.querySelector('.delete').addEventListener('click', () => deleteDecsription(index))
        hotelDescriptionsElement.appendChild(hotelDescriptionElement);
    })
}

hotelDescriptionInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        if (e.target.value !== '') {
            hotelDescriptions.push(e.target.value);
            drawHotelDescriptions();
            e.target.value = '';
        }
      
      
    }
})


const drawHotelAttractions = () => {
    hotelAttractionsElement.innerHTML = '';
    hotelAttractions.forEach((hotelAttraction,index) => {
        const hotelAttractionElement = document.createElement('span');
        
        hotelAttractionElement.innerHTML = `${hotelAttraction} <small class='delete'>x</small>`;
        hotelAttractionElement.querySelector('.delete').addEventListener('click', () => deleteAttraction(index))
        hotelAttractionsElement.appendChild(hotelAttractionElement);
    })
}


const deleteAttraction = (index) => {
    hotelAttractions.splice(index, 1);
    drawHotelAttractions()
}
const deleteDecsription = (index) => {
    hotelDescriptions.splice(index, 1);
    drawHotelDescriptions()
}

hotelAttractionsInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        if (e.target.value !== '') {
            hotelAttractions.push(e.target.value);
            drawHotelAttractions();
            e.target.value = '';
        }
        
       
    }
})

document.getElementById("create-hotel-form").addEventListener("submit", (e) => {
    let isValid = true;

    if (hotelAttractions.length < 1) {
        isValid = false;
        document.getElementById('attractions-error').innerHTML = 'The Attractions field is required.';
    }
    else document.getElementById('attractions-error').innerHTML = '';

    if (hotelDescriptions.length < 1) {
        isValid = false;
        document.getElementById('descriptions-error').innerHTML = 'The Descriptions field is required.';
    }
    else document.getElementById('descriptions-error').innerHTML = '';
    if (!isValid) e.preventDefault()

    

})