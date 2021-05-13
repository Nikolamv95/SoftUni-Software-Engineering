let jaggedMatrix = [
    [4, 6, 3, 0],
    [2, 1, -2],
    [-5, 17],
    [7, 3, 9, 12]
];

for (let row of jaggedMatrix) {
    console.log(row.join('\t'));
};


// Concat all rows from the jaggedMatrix to 1 row of all values
let result = jaggedMatrix.reduce(matrixReduce);
console.log(result);
/**
 * 
 * @param {[]} acc 
 * @param {[]} c 
 */
function matrixReduce(acc, c) {
    return acc.concat(c);
}