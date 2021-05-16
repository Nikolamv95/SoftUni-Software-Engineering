// Task 1 - Work with objects
let obj = { a: 1, b: 2, c: 3 }
//variation 1
let a = obj.a;
//variation 2
const { a } = obj;
console.log(a);
// or multiple destructioring
const { a, b, c } = obj;
console.log(a);
console.log(b);
console.log(c);

// Task 2 - Work with array
const arr = [1,2,3,4,5];
const [a,b,c] = arr;
console.log(a);
console.log(b);
console.log(c);
//or variable + array
const [a, ...b] = arr;
console.log(a);
console.log(b.join(', '));

// Task 3 - Work with array with objects
const arrObj = [{a:1}, {b:2}];
const[{a}] = arrObj;
console.log(a);
//or take only the second element
const[,{b}] = arrObj
console.log(b);
// or
const[a, b] = arrObj; 
console.log(a.a);
console.log(b.b);