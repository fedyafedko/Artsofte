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
            else{
                alert("You have entered incorrect data")
            }
            location.reload();
        })
        .catch(function(error) {
            console.log('Error:', error);
        });
}