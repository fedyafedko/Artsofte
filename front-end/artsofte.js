fetch('http://localhost:5129/')
    .then(response => response.json())
    .then(data => {
        const table = document.getElementById('data-table');
        const tbody = table.querySelector('tbody');

        data.forEach(item => {
            const row = document.createElement('tr');
            row.innerHTML = `
        <td>${item.name}</td>
        <td>${item.surname}</td>
        <td>${item.age}</td>
        <td>${item.departmentFloor}</td>
        <td>${item.languageName}</td>
        <td>
        <a class="link-update" href="../UpdatePage/update_page.html">Change</a><br>
        <a class="link-update" href="#" onclick="deleteData('${item.id}')">Delete</a>
        </td>
      `;
            tbody.appendChild(row);
        });
    })
    .catch(error => {
        console.error('Error:', error);
    });
function deleteData(id){
    fetch(`http://localhost:5129/delete?id=${id}`, {
        method: 'DELETE'
    })
        .then(function(response) {
            if (response.ok) {
                console.log('Request done');
                alert("You have deleted an employee")
            }
            location.reload();
        })
        .catch(function(error) {
            console.log('Error:', error);
        });
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


function postData(event) {
    event.preventDefault();

    const name = document.getElementById('name').value;
    const surname = document.getElementById('surname').value;
    const age = document.getElementById('age').value;
    const department = document.getElementById('department').value;
    const language = document.getElementById('language').value;

    const data = {
        name: name,
        surname: surname,
        age: age,
        departmentFloor: department,
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
        .then(function(response) {
            if (response.ok) {
                console.log('Request done');
                alert("You have added an employee")
            }
            location.reload();
        })
        .catch(function(error) {
            console.log('Error:', error);
        });
}



