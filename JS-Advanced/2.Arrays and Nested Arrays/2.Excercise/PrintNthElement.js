function printNthElement(array, n) {
    const result = [];
    for (let i = 0; i < array.length; i += n) {
        result.push(array[i]);
    };

    return result;
}

// or
// first varialbe is the element of the array, the second one is the index, the third one is optional 
// the inital array.

const solve = (arr, step) => arr.filter((element, index, initiialArray) => index % step === 0 );

console.log(printNthElement(['5', '20', '31', '4', '20'], 2));