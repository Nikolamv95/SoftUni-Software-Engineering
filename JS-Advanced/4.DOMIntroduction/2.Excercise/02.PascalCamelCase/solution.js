function solve() {
  const text = document.getElementById('text').value.toLowerCase().split(' ');
  const convention = document.getElementById('naming-convention').value;
  console.log(text);
  let result = '';
  if (convention == 'Camel Case') {

    const [firstWord, ...values] = text;
    result = firstWord + values.map(letter => letter[0].toUpperCase() + letter.slice(1)).join('');
    
  } else if (convention == 'Pascal Case') {
    result = text.map(letter => letter[0].toUpperCase() + letter.slice(1)).join('');
  } else {
    result = 'Error!';
  }

  document.getElementById('result').innerHTML = result;
}