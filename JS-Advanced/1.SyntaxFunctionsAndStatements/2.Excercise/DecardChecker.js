"use strict"

function decardChecker(x1, y1, x2, y2) {

    function getResult(x1, y1, x2, y2) {
        const distX = x1 - x2;
        const distY = y1 - y2;
        const result = Math.sqrt(Math.pow(distX, 2) + Math.pow(distY, 2));
        return Number.isInteger(result) ? 'valid' : 'invalid';
    }

    return `{${x1}, ${y1}} to {0, 0} is ${getResult(x1, y1, 0, 0)}
    \n{${x2}, ${y2}} to {0, 0} is ${getResult(x2, y2, 0, 0)}
    \n{${x1}, ${y1}} to {${x2}, ${y2}} is ${getResult(x1, y1, x2, y2)}`
}

console.log(decardChecker(3, 0, 0, 4));
console.log(decardChecker(2, 1, 1, 1));