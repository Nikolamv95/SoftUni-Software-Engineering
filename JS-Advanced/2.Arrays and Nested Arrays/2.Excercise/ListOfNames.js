function sortArr(array) {
    const sortArr = array.slice(0).sort((a, b) => a.localeCompare(b)).map((name, index) => {
        return `${index + 1}.${name}`
    })
        return sortArr.join('\n');
}


console.log(sortArr(["John", "Bob", "Christina", "Ema"]));