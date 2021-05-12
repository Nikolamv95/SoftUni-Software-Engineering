const number = 10.54;
console.log(number.toFixed(0));

// .toFixed(X) rounds to X number after the floating dot. if X = 0 the number will be 
//rounded to the cloasest integer number, if x is 2 the number will be 10.54;

const number2 = 0.54;
console.log(number2.toFixed(0).padStart(1, '0'));

// .padStart(x, 'symbol') will add aditional sumbol at the start of the variable;
// 0.54 will be rounded to 1 and infront it will concate 0 => 01. 
// If x is 1 so the result will be only 1 because padStart count the current lenght 
// of the symbols and if x is bigger number than it will add at the beginig the amount of symbols
// variable.length(2) - x(1) = 1 so wil ladd only 1 symbol. Add symbols up to X length
