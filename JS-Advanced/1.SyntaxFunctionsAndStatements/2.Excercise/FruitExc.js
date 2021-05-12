"use strict"

function fruits(fruit, grams, price) {

    const kilograms = grams / 1000;
    const pricePerKg = price * kilograms;

    return `I need $${parseFloat(pricePerKg).toFixed(2)} to buy ${parseFloat(kilograms).toFixed(2)} kilograms ${fruit}.`;
}

console.log(fruits('orange', 2500, 1.80));
console.log(fruits('apple', 1563, 2.35));