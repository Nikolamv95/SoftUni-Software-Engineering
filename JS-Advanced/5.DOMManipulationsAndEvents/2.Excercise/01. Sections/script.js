
// // without CLOSURE
// function create(words) {
//    const content = document.getElementById('content');

//    for (let i = 0; i < words.length; i++) {
//       const div = document.createElement('div');

//       const paragraph = document.createElement('p');
//       paragraph.textContent = words[i];
//       paragraph.style.display = 'none';

//       div.appendChild(paragraph);
//       content.appendChild(div);
//    }

//    content.addEventListener('click', (event) => {
//       const paragraph = event.target.children[0];
//       const paragraphStyle = paragraph.style;

//       if (paragraphStyle.display === 'none') {
//          paragraphStyle.display = 'block';
//       } else {
//          paragraphStyle.display = 'none';
//       }
//    })
// }

// WITH CLOSURE
function create(words) {
   const output = document.getElementById('content');
   words.forEach(word => output.appendChild(createArticle(word)));

   function createArticle(text) {
      const pEl = createElement('p', text);
      const divEl = createElement('div', pEl)

      pEl.style.display = 'none';
      divEl.addEventListener('click', () =>{
         pEl.style.display = '';
      })
      return divEl;
   }

   function createElement(type, content) {
      const result = document.createElement(type);

      if (typeof content === 'string') {
         result.textContent = content;
      } else {
         result.appendChild(content);
      }

      return result;
   }
}