function getNeighboursCount(nestArr) {
    let sum = 0;
    let currArray = [];
    let nextArray = [];

    for (let i = 0; i < nestArr.length - 1; i++) {
        currArray = [...nestArr[i]];
        nextArray = [...nestArr[i + 1]];

        for (let z = 0; z < currArray.length; z++) {
            if (currArray[z] == nextArray[z]) {
                sum++;
            }
        }
    }

    return sum;
}

console.log(getNeighboursCount([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']
]));

console.log(getNeighboursCount([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']
]));