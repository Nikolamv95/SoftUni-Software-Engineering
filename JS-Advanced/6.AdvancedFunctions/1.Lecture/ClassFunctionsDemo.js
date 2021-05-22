// In this case we return the result of the function sayHello

function getGreetingFunc() {
    return sayHello();

    function sayHello() {
        console.log('Hi!');
    }
}

getGreetingFunc();

// vs

// in this case we return the exact function sayHello
function getGreetingFunc() {
    return sayHello;

    function sayHello() {
        console.log('Hi!');
    }
}

// which can be captured and executed bellow
const returnedFunction = getGreetingFunc(); 
returnedFunction();


// Predicate function

// iterate trough the array / enter in to isFound function
let found = array1.find(isFound);

// and compare every element from the array is bigger than 10
function isFound(element) {
    return element > 10; //True or false
}

console.log(found); // 12
