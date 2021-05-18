// function sumTable() {
//     const rows = document.querySelectorAll('table tr');
//     let sum = 0;

//     for (let i = 1; i < rows.length; i++) {
//         const cols = rows[i].children;
//         sum += Number(cols[cols.length - 1].textContent);
//     }

//     document.getElementById('sum').innerHTML = sum;
// }

function sumTable() {
    const rows = [...document.querySelectorAll('table tr')].slice(1, -1);

    document.getElementById('sum').textContent = rows.reduce((sum, row) => {
        return sum + Number(row.lastElementChild.textContent);
    }, 0)
}