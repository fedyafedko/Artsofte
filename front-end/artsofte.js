function openUpdateForm(event, id) {
    event.preventDefault();

    // Відкриття вікна або перенаправлення на сторінку оновлення з передачею ідентифікатора
    window.location.href = `../UpdatePage/update_page.html?id=${id}`;
}
fetch('http://localhost:5129/Department')
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById('department');

        data.forEach(item => {
            const option = document.createElement('option');
            option.value = item.floor;
            option.textContent = item.floor;
            select.appendChild(option);
        });
    })
    .catch(error => {
        console.error('Error:', error);
    });

fetch('http://localhost:5129/Languages')
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById('language');

        data.forEach(item => {
            const option = document.createElement('option');
            option.value = item.name;
            option.textContent = item.name;
            select.appendChild(option);
        });
    })
    .catch(error => {
        console.error('Error:', error);
    });





