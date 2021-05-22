function sortArr(array, type) {
    return array.sort((a, b) => type == 'asc' ? a - b : b - a);
}

console.log(sortArr([14, 7, 17, 6, 8], 'asc'));
console.log(sortArr([14, 7, 17, 6, 8], 'desc'));