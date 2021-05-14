function isMagicNumber(jaggedArray) {

    const arrResult = [];
    let rowSum = 0;
    let colSum = 0;

    for (let i = 0; i < jaggedArray.length; i++) {

        rowSum = jaggedArray[i].reduce((a, b) => a + b, 0);
        arrResult.push(rowSum);

        for (let z = 0; z < jaggedArray.length; z++) {
            colSum += jaggedArray[z][i];
        }

        arrResult.push(colSum);
        colSum = 0;
    }

    return arrResult.every(v=> v === arrResult[0]);
}

console.log(isMagicNumber([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));

console.log(isMagicNumber([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));

console.log(isMagicNumber([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));