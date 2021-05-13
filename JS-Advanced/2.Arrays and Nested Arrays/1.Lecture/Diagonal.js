function diagonalSum(matrix) {
    let diagonalMainSum = 0;
    let diagonalSubnSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        let num = matrix[i][matrix.length - [1 + i]]
        diagonalMainSum += matrix[i][i];
        diagonalSubnSum += matrix[i][matrix.length - [1 + i]]
    }

    const array = [diagonalMainSum, diagonalSubnSum];
    return array;
}




console.log(diagonalSum([
    [20, 40],
    [10, 60]
]));

console.log(diagonalSum([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]));