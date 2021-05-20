function solve() {
  const textAreas = document.querySelectorAll('textarea');
  const buttons = document.querySelectorAll('button');
  const body = document.querySelector('tbody');

  function createCell(type, textContent, attribute) {
    const cell = document.createElement('td');
    const content = document.createElement(type);

    if (attribute) {
      content.setAttribute(attribute[0], attribute[1]);
    }
    
    content.textContent = textContent;
    cell.appendChild(content);

    return cell;
  };

  buttons[0].addEventListener('click', event => {

    const arr = JSON.parse(textAreas[0].value);

    for (const element of arr) {
      const rowTr = document.createElement('tr');

      const cellImage = createCell('img', '', ['src', element.img]);
      const cellName = createCell('p', element.name);
      const cellPrice = createCell('p', element.price);
      const celldecFactor = createCell('p', element.decFactor);
      const cellCheckbox = createCell('input', '', ['type', 'checkbox']);

      // Append to TR
      rowTr.appendChild(cellImage);
      rowTr.appendChild(cellName);
      rowTr.appendChild(cellPrice);
      rowTr.appendChild(celldecFactor);
      rowTr.appendChild(cellCheckbox);

      // append to tbody
      body.appendChild(rowTr);
    }
  });

  buttons[1].addEventListener('click', event => {

    const furniture = Array.from(body.querySelectorAll('input[type=checkbox]:checked'))
      .map(input => input.parentNode.parentNode);

    const result = furniture.reduce((result, row) => {
      const cells = row.children;

      const name = cells[1].children[0].textContent;
      result.bought.push(name);

      const price = Number(cells[2].children[0].textContent)
      result.totalPrice += price;

      const decFactor = Number(cells[3].children[0].textContent)
      result.decFactorSum += decFactor;

      return result;
    },
      {
        bought: [],
        totalPrice: 0,
        decFactorSum: 0,
      });

    textAreas[1].value = `Bought furniture: ${result.bought.join(', ')}\nTotal price: ${result.totalPrice.toFixed(2)}\nAverage decoration factor ${result.decFactorSum / furniture.length}`;
  });
}