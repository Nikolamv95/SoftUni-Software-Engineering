// In this case the eventListener is attached to the parent and it will take
// every action which is done in the parent or its childs;
document.getElementById('items').addEventListener('click', (ev)=> {
    if (event.target.tagName ==='A') {
        event.target.parentNode.remove();
    }
})


function addItem() {
    // Take the input
    const input = document.getElementById('newItemText');

    // Create li element and write the input in the text content of the li
    const liElement = createElement('li', input.value);

    // Create button delete
    const deleteBtn = createElement('a', '[DELETE]');


    deleteBtn.href = '#';

    // in this case the listener is attached to the child (the button not the parent)
    //on the top
    
    // On click over the delete button remove its parent
    // deleteBtn.addEventListener('click', (event)=> {
    //     event.target.parentNode.remove(event);
    // })

    // Append the button to the li (btn will be child of the li)
    liElement.appendChild(deleteBtn);

    // Take the parentNode and append the li element to its parent
    document.getElementById('items').appendChild(liElement);

    // Change the value in th input to empty string
    input.value = '';


}



function createElement(type, input) {
    const element = document.createElement(type);
    element.textContent = input;
    return element;
}