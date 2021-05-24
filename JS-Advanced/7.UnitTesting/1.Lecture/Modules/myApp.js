// this is how we access functions from another file with destructuring
const {sum, multiply} = require('./myModule');

console.log(sum(6, 4));
console.log(multiply(6, 4));