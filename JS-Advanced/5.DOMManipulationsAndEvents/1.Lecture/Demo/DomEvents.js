const button = document.querySelector('button');
button.addEventListener('click', onClick)

// We dont use this in object functions
// const myObj = {
//     counter: 0,
//     increment() {
//         console.log(this);

//         this.counter++;

//         button.textContent = this.counter;
//     },
// };

function onClick(event){
    //this and event.target are equals
    console.log(this == event.target);
    //event target keep reference to the element from which the action came
    const btn = event.target;
    const value = Number(btn.textContent);
    btn.textContent = value + 1;
}


