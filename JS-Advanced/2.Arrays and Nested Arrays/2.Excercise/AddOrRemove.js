function printArray(array) {
    const result = [];

    for (let i = 0; i < array.length; i++) {
        if (array[i] === 'add') {
            result.push(i+1);
        }
        else {
            result.pop(i);
        }   
    }

    return result.length == 0 ? 'Empty' : result.join('\n');
}

console.log(printArray(['add', 'add', 'add', 'add']));
console.log(printArray(['add', 'add', 'remove', 'add', 'add']));
console.log(printArray(['remove', 'remove', 'remove']));