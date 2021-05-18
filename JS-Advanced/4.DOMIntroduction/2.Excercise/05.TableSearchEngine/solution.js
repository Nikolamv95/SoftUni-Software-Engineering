function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   const rows = document.querySelectorAll('tbody tr');
   const input = document.querySelector('#searchField');

   function onClick() {
      const inputValue = input.value;

      for (const row of rows) {
         if (row.textContent.includes(inputValue)) {
            row.setAttribute('class', 'select');
         }
         else{
            row.removeAttribute('class');
         }
      }
   }
}
