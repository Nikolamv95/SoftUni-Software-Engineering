function pow(num, power) {
    return num ** power;
}

function sqr(num) {
    return pow(num, 2);
}

// console.log(pow(3,2))
// console.log(pow(4,2))
// console.log(pow(5,2))
// console.log(pow(6,2))
// console.log(pow(7,2))


// console.log(sqr(3))
// console.log(sqr(4))
// console.log(sqr(5))
// console.log(sqr(6))
// console.log(sqr(7))

// Decoration

// we bind the pow function with static value for power 2
// and variable which currently is null but we can set it later 
const newSqr = pow.bind(null, 2);

// so now we will give only 1 argumet (num), because power (2) is
// alredy given to the function;
console.log(newSqr(2));
console.log(newSqr(3));
console.log(newSqr(4));
console.log(newSqr(5));