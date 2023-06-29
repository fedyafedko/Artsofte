fetch('http://localhost:5129/')
    .then(response => response.json())
    .then(data => {
        const table = document.getElementById('data-table');
        const tbody = table.querySelector('tbody');

        data.forEach(item => {;
            const row = document.createElement('tr');
            row.innerHTML = `
        <td>${item.name}</td>
        <td>${item.surname}</td>
        <td>${item.age}</td>
        <td>${item.departmentFloor}</td>
        <td>${item.languageName}</td>
        <td>
        <a class="link-update" href="../UpdatePage/update_page.html">Change</a><br>
        <a class="link-update" href="../UpdatePage/update_page.html">Delete</a>
        </td>
      `;
            tbody.appendChild(row);
        });
    })
    .catch(error => {
        console.error('Error:', error);
    });

fetch('http://localhost:5129/Department')
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById('department');

        // Додавання елементів option до випадаючого списку
        data.forEach(item => {
            const option = document.createElement('option');
            option.value = item.floor;  // значення з API
            option.textContent = item.floor;  // мітка з API
            select.appendChild(option);
        });
    })
    .catch(error => {
        console.error('Помилка отримання даних з API:', error);
    });

fetch('http://localhost:5129/Languages')
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById('language');

        // Додавання елементів option до випадаючого списку
        data.forEach(item => {
            const option = document.createElement('option');
            option.value = item.name;  // значення з API
            option.textContent = item.name;  // мітка з API
            select.appendChild(option);
        });
    })
    .catch(error => {
        console.error('Помилка отримання даних з API:', error);
    });


function postData(event) {
    event.preventDefault(); // Зупиняємо перезавантаження сторінки при надсиланні форми

    const form = document.getElementById('add_form');
    const name = document.getElementById('name').value;
    const surname = document.getElementById('surname').value;
    const age = document.getElementById('age').value;
    const department = document.getElementById('department').value;
    const language = document.getElementById('language').value;

    const data = {
        name: name,
        surname: surname,
        age: age,
        department: department,
        languageName: language
    };

    // Відправка запиту POST
    fetch('http://localhost:5129/add', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(result => {
            // Обробка результату відповіді сервера
            console.log('Результат:', result);
            // Додайте свій код для обробки результату відповіді
        })
        .catch(error => {
            console.error('Помилка:', error);
        });
}



