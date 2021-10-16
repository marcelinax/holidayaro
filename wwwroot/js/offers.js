const getAllHotels = () => {
    fetch('/api/hotelsapi').then(res => console.log(res))
}

getAllHotels();