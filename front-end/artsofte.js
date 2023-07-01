function openUpdateForm(event, id) {
    event.preventDefault();

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

$(function() {
    fetch('http://localhost:5129/Languages')
        .then(response => response.json())
        .then(data => {
            const select = document.getElementById('language');

            const fetchedTags = data.map(item => item.name);

            let availableTags = [
                "ActionScript",
                "AppleScript",
                "Asp",
                "BASIC",
                "C",
                "C++",
                "Clojure",
                "COBOL",
                "ColdFusion",
                "Erlang",
                "Fortran",
                "Groovy",
                "Haskell",
                "Java",
                "JavaScript",
                "Lisp",
                "Perl",
                "PHP",
                "Python",
                "Ruby",
                "Scala",
                "Scheme",
                ...fetchedTags
            ];

            let uniqueTags = [...new Set(availableTags)];

            $("#language").autocomplete({
                source: uniqueTags
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
});





