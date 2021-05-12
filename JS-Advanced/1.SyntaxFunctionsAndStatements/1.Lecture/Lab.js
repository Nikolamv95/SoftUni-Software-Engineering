// Excercise 1 - Print input
function echo(input) {
    console.log(input.length);
    console.log(input);
}

echo('Hello, JavaScript')

// Excercise 2 - Sum of string length
function stringLength(a, b, c) {

    let total = a.length + b.length + c.length;
    let average = Math.floor(total / 3)

    console.log(total);
    console.log(average)
    console.log('---')
}


stringLength('chocolate', 'ice cream', 'cake')
stringLength('pasta', '5', '22.3')

// or
function stringLength(...params) {

    let total = params.reduce((a, b) => a + b.length, 0)

    console.log(total);
    console.log(Math.floor(total / 3))
    console.log('---')
};


stringLength('chocolate', 'ice cream', 'cake')
stringLength('pasta', '5', '22.3')


// Excercise 3 - Max Value
function maxNumber(a, b, c) {
    var maxNum = Math.max(a, b, c);
    console.log(maxNum);
}

maxNumber(1, 2, 3);


// Excercise 4 - Area of a circle
function areaCircle(a) {
    if (!Number(a)) {
        return console.log(`It's a string`);
    }
    let area = Math.PI * Math.pow(a, 2);
    console.log(area.toFixed(2));
}

areaCircle(5);
areaCircle(NaN);
areaCircle(undefined);
areaCircle('5number');


// Excercise 5 - Math Operations
function solve(num1, num2, operator) {
    let result = 0;
    switch (operator) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/': result = num1 / num2; break;
        case '%': result = num1 % num2; break;
        case '**': result = num1 ** num2; break;
    }

    console.log(result);
}

solve(1, 2, '+');
solve(1, 2, '-');
solve(1, 2, '*');
solve(1, 2, '/');
solve(1, 2, '%');
solve(1, 2, '**');

// Excercise 6 - Sum of Numbers N…M
function sumNtoM(startNum, endNum) {
    let sum = 0;
    for (let i = startNum; i <= endNum; i++) {

        sum += i;
    }

    console.log(sum);
}

sumNtoM(1, 5);
sumNtoM(-8, 20);

// Excercise 7 - Day of Week
function solve(day) {
    let result = 0;
    switch (day) {
        case 'Monday': result = 1; break;
        case 'Tuesday': result = 2; break;
        case 'Wednesday': result = 3; break;
        case 'Thursday': result = 4; break;
        case 'Friday': result = 5; break;
        case 'Saturday': result = 6; break;
        case 'Sunday': result = 7; break;
        default: return console.log('error');
    }

    console.log(result);
}

solve('Monday');
solve('Tuesday');
solve('Wednesday');
solve('Thursday');
solve('Friday');
solve('Saturday');
solve('Sunday');
solve('Different');


// Excercise 8 - Square of Stars     
function squareOfStars(n) {

    let row = 0;

    if (n == undefined) {
        row = 5;
    }
    else {
        row = n;
    }

    let stars = '';

    for (let i = 0; i < row; i++) {
        stars += '* ';
    }

    console.log(stars);

    for (let z = 0; z < row - 1; z++) {
        console.log(stars);
    }
}

squareOfStars();

// Excercise 9 - Aggregate Elements
function arrayManipulations(...array) {
    let sum = 0;
    let concat = '';
    
    for (let i = 0; i < array[0].length; i++) {
        sum += array[0][i];
        concat += `${array[0][i]}`;
    }

    console.log(sum);
    console.log(concat);
}

arrayManipulations([1, 2, 3])