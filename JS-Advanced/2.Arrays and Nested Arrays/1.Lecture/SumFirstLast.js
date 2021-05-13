function sumFirst(array) {
    let first = Number([...array].pop());
    let last = Number([...array].shift());
    return first + last;
}

console.log(sumFirst(['20', '30', '40']))
console.log(sumFirst(['13']))