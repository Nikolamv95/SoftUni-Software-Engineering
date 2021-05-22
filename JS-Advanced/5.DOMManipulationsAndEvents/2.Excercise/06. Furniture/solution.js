// function solve() {
//   const textAreas = document.querySelectorAll('textarea');
//   const buttons = document.querySelectorAll('button');
//   const body = document.querySelector('tbody');

//   function createCell(type, textContent, attribute) {
//     const cell = document.createElement('td');
//     const content = document.createElement(type);

//     if (attribute) {
//       content.setAttribute(attribute[0], attribute[1]);
//     }

//     content.textContent = textContent;
//     cell.appendChild(content);

//     return cell;
//   };

//   buttons[0].addEventListener('click', event => {

//     const arr = JSON.parse(textAreas[0].value);

//     for (const element of arr) {
//       const rowTr = document.createElement('tr');

//       const cellImage = createCell('img', '', ['src', element.img]);
//       const cellName = createCell('p', element.name);
//       const cellPrice = createCell('p', element.price);
//       const celldecFactor = createCell('p', element.decFactor);
//       const cellCheckbox = createCell('input', '', ['type', 'checkbox']);

//       // Append to TR
//       rowTr.appendChild(cellImage);
//       rowTr.appendChild(cellName);
//       rowTr.appendChild(cellPrice);
//       rowTr.appendChild(celldecFactor);
//       rowTr.appendChild(cellCheckbox);

//       // append to tbody
//       body.appendChild(rowTr);
//     }
//   });

//   buttons[1].addEventListener('click', event => {

//     const furniture = Array.from(body.querySelectorAll('input[type=checkbox]:checked'))
//       .map(input => input.parentNode.parentNode);

//     const result = furniture.reduce((result, row) => {
//       const cells = row.children;

//       const name = cells[1].children[0].textContent;
//       result.bought.push(name);

//       const price = Number(cells[2].children[0].textContent)
//       result.totalPrice += price;

//       const decFactor = Number(cells[3].children[0].textContent)
//       result.decFactorSum += decFactor;

//       return result;
//     },
//       {
//         bought: [],
//         totalPrice: 0,
//         decFactorSum: 0,
//       });

//     textAreas[1].value = `Bought furniture: ${result.bought.join(', ')}\nTotal price: ${result.totalPrice.toFixed(2)}\nAverage decoration factor ${result.decFactorSum / furniture.length}`;
//   });
// }


function solve() {
  // Get the text area and spread to input textarea and output textarea
  const [input, output] = [...document.querySelectorAll('textarea')];

  // Get the tbody element in the table element
  const table = document.querySelector('table.table tbody')

  // Get the buttons and spread to generate button and buy button
  const [generateBtn, buyBtn] = [...document.querySelectorAll('button')];

  // Create array in which will save the refferences to the newlly created elements
  // for the DOM Tree
  const furninture = [];

  // work with GENERATE BUTTON
  // Attach event listener to generate button
  generateBtn.addEventListener('click', () => {
    // parse the input to JSON objects and trim the end of the JSON to avoid mistakes
    const funtitureArray = JSON.parse(input.value.trim())

    // remove the currnet dom elements in the table
    table.innerHTML = '';

    // iterate trough every JSON object
    funtitureArray.forEach(element => {
      // create the element
      const item = createRow(element);
      // push the newlly created element to the array in order to have 
      //refference and access it later (closure)
      furninture.push(item)
      // append the newlly created to the table element in the DOM
      table.appendChild(item.element);
    });
  });

  // WORK WITH BUY BUTTON
  // Attach event listener to buy button
  buyBtn.addEventListener('click', () => {
    // iterate trough the elements and check if an element is checked
    // if true append the string to the output textarea
    furninture.forEach(item => {
      output.value += item.isChecked() ? `${item.getValues().name}\n` : '';
    });

    // we can do what ever we want here if the buy button is clicked;
  });

  // those functions bind the original createElement function but the difference
  // is that the type will be with already setted value;
  const createTd = createElement.bind(null, 'td');
  const createP = createElement.bind(null, 'p')


  // Create Row function
  function createRow(data) {

    // create the image
    const img = createElement('img')
    // save the src and take the image url from the data
    img.src = data.img;

    // create the check buttom
    const check = createElement('input')
    // create type checkbox
    check.type = 'checkbox';

    // create the element which should be appended to the table
    const element = createElement('tr',
      createTd(img),
      createTd(createP(data.name)),
      createTd(createP(data.price)),
      createTd(createP(data.decFactor)),
      createTd(check),
    );

    // return only the elements which can be accessed from other functions (closure)
    // these are the only visible methods from this function
    return {
      element,
      isChecked,
      getValues,
    };

    // returns value if the check button is checked
    function isChecked() {
      return check.checked;
    };

    // returns the data of the current element 
    function getValues() {
      return data
    }
  };


  // create Element function
  function createElement(type, ...content) {
    // create element (the element which should be created)
    const result = document.createElement(type);

    // iterates trough the array of content
    content.forEach(element => {
      if (typeof element === 'string') {
        // createTextNode is similar to textContent, 
        //here we create the text which we have to show in the browser
        const node = document.createTextNode(element);

        // and after that append this text to the newlly created element
        result.appendChild(node);
      } else {
        // if its not string we append the element to the result
        result.appendChild(element);
      }
    });

    // we return the result
    return result;
  };
}