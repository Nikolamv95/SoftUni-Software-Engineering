function sortArr(array) {
    const sortArr = array.sort((a, b) => a.length - b.length || a.localeCompare(b));
    return sortArr.join('\n');
}


console.log(sortArr(['alpha', 'beta', 'gamma']));
console.log(sortArr(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
console.log(sortArr(['test', 'Deny', 'omen', 'Default']));