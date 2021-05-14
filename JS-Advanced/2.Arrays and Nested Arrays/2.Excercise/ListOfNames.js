function sortArr(array) {
    const sortArr = array.sort((a, b) => a.localeCompare(b));
    const result = [];
    for (let i = 0; i < sortArr.length; i++) {
        result.push(`${i + 1}.${sortArr[i]}`);
    }
    return result.join('\n');
}


console.log(sortArr(["John", "Bob", "Christina", "Ema"]));

// .foreach((i, x) => `${i}.${x}\n`)