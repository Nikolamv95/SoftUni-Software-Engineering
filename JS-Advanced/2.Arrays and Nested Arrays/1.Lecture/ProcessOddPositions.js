function procPoss(array) {
    const result = [];
    for (let i = 1; i < array.length; i += 2) {
        result.push(array[i] * 2);
    }
    return result.reverse();
}

console.log(procPoss([10, 15, 20, 25]));
console.log(procPoss([3, 0, 10, 4, 7, 3]));
