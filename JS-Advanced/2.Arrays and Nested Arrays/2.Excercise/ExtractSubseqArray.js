function extractArr(array) {

    const result = [];
    for (let i = 0; i < array.length; i++) {

        let currNum = array[i]

        if (currNum >= result[result.length - 1] || result.length === 0) {
            result.push(currNum);
        }
    }

    return result;
}

// or with reduce

function solve(arr) {
    return arr.reduce(function (result, currentValue, index, initiialArray) {

        if (currentValue >= result[result.length - 1] || result.length === 0) {
            result.push(currentValue);
        }
        
        return result;
    }, [])
}

console.log(extractArr([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(extractArr([1, 2, 3, 4]));
console.log(extractArr([20, 3, 2, 15, 6, 1]));