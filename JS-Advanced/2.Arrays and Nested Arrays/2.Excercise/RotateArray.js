function reverseN(array, n) {
    
    for (let i = 0; i < n; i++) {
        array.unshift(array.pop());
    };

    return array.join(' ');
}

console.log(reverseN(['1', '2', '3', '4'], 2));
console.log(reverseN(['Banana', 'Orange', 'Coconut', 'Apple'], 15));