function deleteByEmail() {
    const rows = [...document.querySelectorAll('tbody>tr')];
    const inputEmail = document.querySelector('input[name="email"]').value;
    const resultElement = document.getElementById('result');

    const matches = rows.filter(r => r.children[1].textContent == inputEmail);

    if (matches.length > 0) {
        matches.forEach(r=> r.remove());
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    };
}