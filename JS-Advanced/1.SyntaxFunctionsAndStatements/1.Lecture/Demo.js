const name = "Maria";
console.log(name)

// Task 1

//declarin function + name + variable
function printStars(count) {
    //body of the function
    console.log('*'.repeat(count))
}

//variable
let count = 10;

//Invoke the method with the variable
printStars(count);

// Task 2

function printName(count) {
    //body of the function
    return 'Best '.repeat(count);
}

let result = printName(7);
console.log(result);

// Task 3

function parameterIgnore(a, b, c) {
    console.log(a);
    console.log(b);
    console.log(c); //c will be undefined
}

parameterIgnore(1, 2);

// Task 4
function parameterIgnore(a, b, c) {
    console.log(a);
    console.log(b);
    console.log(c);
}

// 4, 5 will be ignored
parameterIgnore(1, 2, 3, 4, 5);

// Task 5

function countNums(a, b, c) {
    return a + b + c;
}

var sum = countNums(1, 2, 3);
console.log(sum);

// Task 6
let myString = 'My string';
console.log(myString.toLowerCase())

// Task 7
function countNums(a, b, c = 5) {
    return a + b + c;
}

var sum = countNums(1, 2);
console.log(sum);

// Task 8 - Compare by type v Compare by value

console.log(5 === '5'); // type
console.log(5 !== '5'); // not type

console.log(5 == '5'); // value
console.log(5 != '5'); // not value

// Task 9 - Ternary operator

console.log(5 > 7 ? 4 : 10);

// Task 9 - If condition

let a = 5;

if (a > 5) {
    console.log(a);
} else {
    console.log(`It's false`);
}

// Task 9 - Parse numbers
console.log(number);

// Ignore evrything after .4ignor
let number2 = parseInt('4.4ignor');
console.log(number2);

// Ignore evrything after ignor
let number3 = parseFloat('4.4ignor');
console.log(number3);

// Check if is NaN
let isNumber = Number.isNaN(Number('4.4'));
console.log(isNumber);

// Check if is Truthiness
function logTrughiness(val) {
    if (val) {
        console.log('is truthy');
    } else {
        console.log(`it's falsy`);
    }
}

let val = '4.32';
logTrughiness(val);

///!Truthy values are false, null, undefined, NaN, 0, 0n (it's bigint), and "";!
// Returns the first value which is not falsy -> 5
let val1 = false || '' || 5;
console.log(val1);

// Returns the first value which is not falsy -> 4
let val1 = 4 || '' || 5;
console.log(val1);

// Returns the first value which is not truthy -> ''
let val1 = 4 && '' && 5;
console.log(val1);

// Returns the first value which is not truthy -> falsy
let val1 = false && '' && 5;
console.log(val1);

// Typeof variable give us the type of the variable
typeof val1;

// Global variable if is defined for first time in the function
function solve() {
    a = 5;
}

solve();

console.log(a);

// Task 10 - Function calls function
function running() {
    return 'Running';
}

// run is the function runningm so in the console.log 
// we calls running() + ' ' + type (which have value sprint)
function category(run, type) {
    console.log(run() + ' ' + type)
}

category(running, 'sprint');

// Task 11 - nested function
function hypotenuse(m, n) {

    function square(num) {
        return num * num;
    }

    // square function is visible in the scope of hypotenuse function
    // and will be called 2 times
    return Math.sqrt(square(m) + square(n));
}

let result = hypotenuse(5, 5);
console.log(result);

// Task 12 - Hoisting

function solve(){
    if(true){
        let b = 5; // it's an error because b is in the scope of if
        var a = 5; // while a becomes variable for the whole solve() function (out of scope)
    }

    console.log(a);
    console.log(b);
}

solve();