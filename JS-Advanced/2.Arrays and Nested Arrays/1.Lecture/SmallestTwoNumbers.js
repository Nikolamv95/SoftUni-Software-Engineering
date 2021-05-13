function smallestTwoNumbers(array){
    const result = [];
    array.sort((a, b) => a - b);
    result[result.length] = array[0]; 
    result[result.length] = array[1]; 
    return result.join(' ');
}

console.log(smallestTwoNumbers([30, 15, 50, 5]));