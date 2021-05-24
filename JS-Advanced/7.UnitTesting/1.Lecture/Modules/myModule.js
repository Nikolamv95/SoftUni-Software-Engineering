function sum(a, b) {
    return Number(a) + Number(b);
}

function multiply(a, b) {
    return a * b;
}


function divide(a, b) {
    return a / b;
}

// function sum and miltiply become public while divide is private
module.exports = {
    sum,
    multiply,
};