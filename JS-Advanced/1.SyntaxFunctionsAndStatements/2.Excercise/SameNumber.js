"use strict"

function sameNumber(number) {
    let sum = 0;
    let isEquals = true;
    const numAsString = number.toString();

    for (let i = 0; i < numAsString.length; i++) {
        let char = Number(numAsString[i]);

        for (let z = i; z < numAsString.length; z++) {
            let nextChar = Number(numAsString[z]);

            if (char != nextChar) {
                isEquals = false;
            }
        }

        sum += char;
    }

    return `${isEquals}\n${sum}`;
}

console.log(sameNumber(2222222));
console.log(sameNumber(1234));