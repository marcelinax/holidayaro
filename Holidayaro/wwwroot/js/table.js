const itemsSelect = document.getElementById('show-items-select');
const itemsAmountHeading = document.getElementById('items-amount-heading');

const previousPageBtn = document.getElementById('previous-page-btn');
const nextPageBtn = document.getElementById('next-page-btn');

let currentPage = 0;
let pageSize = 0;

const res = parseInt(location.search.split('startIndex=')[1]);

const getCurrentPage = () => {
    if (location.search) {
       
        pageSize = parseInt(location.search.split('pageSize=')[1]);
        currentPage = res / pageSize + 1;
    }
}
getCurrentPage();

nextPageBtn.addEventListener('click', () => {
    if (currentPage === 0) return;
    if ((currentPage) * itemsSelect.value >= totalItems) return;
    location.search = `?startIndex=${(currentPage) * itemsSelect.value}&pageSize=${itemsSelect.value}`;
})

previousPageBtn.addEventListener('click', () => {
    if (currentPage === 0) return;
    if ((currentPage) <= 1) return;
    location.search = `?startIndex=${(currentPage - 2) * itemsSelect.value}&pageSize=${itemsSelect.value}`;
})

if (pageSize === 0) {
    itemsSelect.value = totalItems;
}
else {
    itemsSelect.value = pageSize;
}

itemsSelect.addEventListener('change', () => {
    location.search = `?startIndex=0&pageSize=${itemsSelect.value}`;
})

let to = (currentPage) * itemsSelect.value < totalItems ? (currentPage) * itemsSelect.value : totalItems;
if (!currentPage) to = totalItems;
const from = !res ? 1 : parseInt(res) + 1;
itemsAmountHeading.innerHTML = `Showing ${from}-${to} of ${totalItems}`
