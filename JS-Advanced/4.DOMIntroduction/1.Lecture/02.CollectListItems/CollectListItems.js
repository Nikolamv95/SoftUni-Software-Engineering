// function extractText() {
//     const items = document.getElementsByTagName('li');
//     const area = document.getElementById('result');

//     [...items].map(x => area.textContent += `${x.textContent}\n`);
// }

function extractText() {
    const liElements = [...document.getElementsByTagName('li')];
    const elementText = liElements.map(e=> e.textContent);

    document.getElementById('result').value = elementText.join('\n');
}
