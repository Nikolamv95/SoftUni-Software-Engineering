function negPosNumbers(array){
    const arrayResult = [];
    for (const num of array) {
        if (num < 0) {
            arrayResult.unshift(num);
        }
        else{
            arrayResult.push(num);
        }
    }

    return arrayResult.join('\n');

}

console.log(negPosNumbers([3, -2, 0, -1]));