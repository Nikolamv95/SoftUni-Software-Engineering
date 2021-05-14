function extractArr(array) {

    const result = [];
    let prevNum = 0;
    let currNum = 0;
    for (let i = 0; i < array.length; i++) {

        currNum = array[i]

        if (currNum > prevNum) {
            result.push(currNum);
        }

        prevNum = array[i];
    }

    return result;
}

console.log(extractArr([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(extractArr([1, 2, 3, 4]));
console.log(extractArr([20, 3, 2, 15, 6, 1]));