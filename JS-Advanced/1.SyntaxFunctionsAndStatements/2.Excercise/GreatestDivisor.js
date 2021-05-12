"use strict"

function greatestComDivisor(num1, num2) {
    let bestDivisor = 0;

    if (num1 > num2) {
        for (let i = 1; i <= num2; i++) {
            if (num1 % i == 0 && num2 % i == 0) {
                bestDivisor = i;
            }
        }
    } else {
        for (let i = 1; i < num1; i++) {
            if (num1 % i == 0 && num2 % i == 0) {
                bestDivisor = i;
            }
        }
    }

    return bestDivisor;
}

console.log(greatestComDivisor(15, 5));
console.log(greatestComDivisor(2154, 458));