function addItem() {
    const inputText = document.getElementById('newItemText');
    const inputValue = document.getElementById('newItemValue');
    const dropDown = document.getElementById('menu');
    const optionSelect = document.createElement('option');


    let textInput = inputText.value;
    let valueInput = inputValue.value;

    const inputObject = objectFacotry(textInput, valueInput);

    function objectFacotry(textInput, valueInput) {
        return {
            name: textInput,
            value: valueInput
        };
    }

    optionSelect.value = inputObject.name;
    optionSelect.textContent = inputObject.name;
    dropDown.appendChild(optionSelect);

    inputText.value = '';
    inputValue.value = '';
}