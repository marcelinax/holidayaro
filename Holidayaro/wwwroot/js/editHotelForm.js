
let hotelDescriptions = [];
let hotelDescriptionsIds = [];
let hotelAttractions = [];
let hotelAttractionsIds = [];
let hotelPhotos = [];
let hotelPhotosIds = [];
const hotelDescriptionsElement = document.querySelector("#hotel-descriptions .items");
const argument = location.pathname.split('/');
const currentHotelId = +argument[argument.length - 1];

const hotelDescriptionInputElement = document.querySelector("#hotel-descriptions input");
const hotelAttractionsElement = document.querySelector("#hotel-attractions .items");
const hotelAttractionsInputElement = document.querySelector("#hotel-attractions input");

const hotelPhotosElement = document.querySelector("#hotel-photos .items");
const hotelPhotosInputElement = document.querySelector("#hotel-photos input");

const drawHotelDescriptions = () => {
    hotelDescriptionsElement.innerHTML = '';
    hotelDescriptions.forEach((hotelDescription, index) => {
        const hotelDescriptionElement = document.createElement('span');
        hotelDescriptionElement.innerHTML = `${hotelDescription} <small class='delete'>x</small>`;
        hotelDescriptionElement.querySelector('.delete').addEventListener('click', () => deleteDecsription(hotelDescriptionsIds[index]))
        hotelDescriptionsElement.appendChild(hotelDescriptionElement);
    })
}

hotelDescriptionInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        if (e.target.value !== '') {
            fetch('/api/hoteldescriptions', {
                method: "POST",
                body: JSON.stringify({
                    hotelId: currentHotelId,
                    name: e.target.value
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                getHotelDescriptions()
                e.target.value = '';
            })

        }
    }
})

const deleteDecsription = (descriptionId) => {
    fetch(`/api/hoteldescriptions/${descriptionId}`, { method: 'DELETE' }).then(() => {
        getHotelDescriptions()
    })

}

const getHotelDescriptions = () => {
    fetch('/api/hoteldescriptions').then(res => res.json()).then(data => {

        hotelDescriptions = data.$values.filter(item => item.hotelId === currentHotelId).map(item => item.name);
        hotelDescriptionsIds = data.$values.filter(item => item.hotelId === currentHotelId).map(item => item.hotelDescriptionId);
        drawHotelDescriptions();
    })
}


const drawHotelAttractions = () => {
    hotelAttractionsElement.innerHTML = '';
    hotelAttractions.forEach((hotelAttraction, index) => {
        const hotelAttractionElement = document.createElement('span');
        hotelAttractionElement.innerHTML = `${hotelAttraction} <small class='delete'>x</small>`;
        hotelAttractionElement.querySelector('.delete').addEventListener('click', () => deleteAttraction(hotelAttractionsIds[index]))
        hotelAttractionsElement.appendChild(hotelAttractionElement)
    })
}


const deleteAttraction = (attractionId) => {
    fetch(`/api/hotelattractions/${attractionId}`, { method: 'DELETE' }).then(() => {
        getHotelAttractions()
    })
}

const getHotelAttractions = () => {
    fetch('/api/hotelattractions').then(res => res.json()).then(data => {
        console.log(data.$values);
        hotelAttractions = data.$values.filter(item => item.hotelId === currentHotelId).map(item => item.name);
        hotelAttractionsIds = data.$values.filter(item => item.hotelId === currentHotelId).map(item => item.hotelAttractionId);
        drawHotelAttractions();
    })

}

const drawHotelPhotos = () => {
    hotelPhotosElement.innerHTML = '';
    hotelPhotos.forEach((hotelPhoto, index) => {
        const hotelPhotoElement = document.createElement('span');
        hotelPhotoElement.innerHTML = `${hotelPhoto} <small class='delete'>x</small>`;
        hotelPhotoElement.querySelector('.delete').addEventListener('click', () => deletePhoto(hotelPhotosIds[index]))
        hotelPhotosElement.appendChild(hotelPhotoElement)
    })
}


const deletePhoto = (photoId) => {
    fetch(`/api/photosurls/${photoId}`, { method: 'DELETE' }).then(() => {
        getPhotosUrls()
    })
}

const getPhotosUrls = () => {
    fetch('/api/photosurls').then(res => res.json()).then(data => {
        hotelPhotos = data.$values.filter(item => item.hotelId === currentHotelId).map(item => item.photoUrl);
        hotelPhotosIds = data.$values.filter(item => item.hotelId === currentHotelId).map(item => item.photosUrlId);
        drawHotelPhotos();
    })
}


hotelAttractionsInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        if (e.target.value !== '') {
            fetch('/api/hotelattractions', {
                method: "POST",
                body: JSON.stringify({
                    hotelId: currentHotelId,
                    name: e.target.value
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                getHotelAttractions()
                e.target.value = '';
            })
        }
    }
})

hotelPhotosInputElement.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        e.stopPropagation();
        if (e.target.value !== '') {
            fetch('/api/photosurls', {
                method: "POST",
                body: JSON.stringify({
                    hotelId: currentHotelId,
                    photoUrl: e.target.value
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                getPhotosUrls()
                e.target.value = '';
            })
        }
    }
})

document.getElementById("edit-hotel-form").addEventListener("submit", (e) => {
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

    if (hotelPhotos.length < 1) {
        isValid = false;
        document.getElementById('photos-error').innerHTML = 'The Photos urls field is required.';
    }
    else document.getElementById('photos-error').innerHTML = '';
    if(!isValid)e.preventDefault();
})



getHotelDescriptions();
getHotelAttractions();
getPhotosUrls();