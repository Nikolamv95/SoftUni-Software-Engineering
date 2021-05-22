function getFibonator(){

    let num1 = 0;
    let num2 = 1;
    
    return function fib(){
        // num1, num2 & result will keep their state after
        // every call of the function
        // Call 1 => num1 = 0, num2 = 1;
        // Call 2 => num1 = 1, num2 = 1;
        // Call 3 => num1 = 1, num2 = 2;
        // Call 4 => num1 = 2, num2 = 3;
        // Call 4 => num1 = 3, num2 = 5;
        let result = num1 + num2;
        num1 = num2;
        num2 = result;

        return num1;
    };
}


let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
