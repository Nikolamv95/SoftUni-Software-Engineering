// function search() {
//    const liValues = [...document.getElementById('towns').children];
//    const searchText = document.getElementById('searchText').value;
//    const sum = [...liValues.filter(text => text.textContent.includes(searchText))].length;
//    document.getElementById('result').innerHTML = `${sum} matches found`;
// }

// or

function search() {
   let listItems = document.querySelectorAll('#towns>li')
   let input = document.querySelector('input').value;
   let result = document.getElementById('result');

   let sum = 0;
   for (const li of listItems) {
      if ((li.textContent).toLocaleLowerCase().includes(input.toLocaleLowerCase()) && input !=='') {
         li.style.fontWeight = 'bold';
         li.style.textDecoration = 'underline'
         sum++;
      } else {
         li.style.fontWeight = '';
         li.style.textDecoration = ''
      }
   }

   result.textContent = `${sum} matches found`;

}