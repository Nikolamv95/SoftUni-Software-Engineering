function solve() {
   const output = document.querySelector('textarea');
   const cart = [];

   document.querySelector('.shopping-cart').addEventListener('click', (place) => {
      if (place.target.tagName === 'BUTTON' && place.target.className == 'add-product') {
         const productElement = place.target.parentNode.parentNode;
         const title = productElement.querySelector('.product-title').textContent;
         const price = Number(productElement.querySelector('.product-line-price').textContent);
         output.value += `Added ${title} for ${price} to the cart.\n`;
         cart.push({ title, price });
      };
   });

   document.querySelector('.checkout').addEventListener('click', () => {
      const result = cart.reduce((acc, c) => {
         acc.item.push(c.title);
         acc.total += c.price;
         return acc;
      }, {item: [], total: 0})
      
      output.value = `You bought ${result.item.join(' ')} for ${result.total.toFixed(2)}.`
   })
};