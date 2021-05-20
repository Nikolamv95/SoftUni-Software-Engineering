function create(words) {
   const content = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      const div = document.createElement('div');

      const paragraph = document.createElement('p');
      paragraph.textContent = words[i];
      paragraph.style.display = 'none';

      div.appendChild(paragraph);
      content.appendChild(div);
   }

   content.addEventListener('click', (event) => {
      const paragraph = event.target.children[0];
      const paragraphStyle = paragraph.style;

      if (paragraphStyle.display === 'none') {
         paragraphStyle.display = 'block';
      } else {
         paragraphStyle.display = 'none';
      }
   })

}