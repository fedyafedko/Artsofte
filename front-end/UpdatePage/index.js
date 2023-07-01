function openUpdateForm(event, id) {
    event.preventDefault();

    window.location.href = `../UpdatePage/update_page.html?id=${id}`;
}
const urlParams = new URLSearchParams(window.location.search);
const userId = urlParams.get('id');
fetch(`http://localhost:5129/${userId}`)
    .then(response => response.json())
    .then(data => {
        console.log(data);
        document.getElementById('name').value = data.name;
        document.getElementById('surname').value = data.surname;
        document.getElementById('age').value = data.age;
        document.getElementById('department').value = data.departmentFloor;
        document.getElementById('language').value = data.languageName;
    })
    .catch(error => {
        console.log('Error', error);
    });
function updateData(event, id) {
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

    fetch(`http://localhost:5129/edit?id=${userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(function (response) {
            if (response.ok) {
                console.log('Request done');
                alert("You have updated an employee")
            }
            else{
                alert("You have entered incorrect data")
            }
            location.reload();
        })
        .catch(function (error) {
            console.log('Error', error);
        });
}
