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
        <td>${item.gender}</td>
        <td>${item.departmentFloor}</td>
        <td>${item.languageName}</td>
        <td>
        <a class="link-update" href="#" onclick="openUpdateForm(event, '${item.id}')">Change</a><br>
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