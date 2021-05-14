////////// Task 1 - Declare and print array
let myArr = [];
let myArr2 = [1, 2, 3];

console.log(myArr); // Result -> (0) []
console.log(myArr2); // Result -> (3) [1, 2, 3]

// If we want to print array implicit JS will call the method toString and will print the values in the array on one row.
// It`s the opposite in 

///////// Task 2 - Access value in the array

let myArrNew = [10, 20, 30, 44];
console.log(myArrNew[2]); // Result -> 30

// If we want we ca wrote an expression which has number result, inside the [];
console.log(myArrNew[1 + 1]); // Result -> 30

console.log(myArrNew.length); // Result -> the length is 4
console.log(myArrNew.length - 1); // Print the last element -> 44


///////// Task 3 - Overwrite new values in the array
let myArrOver = [10, 20, 100, 40];
console.log(myArrOver[2]); // Result -> 100
myArrOver[2] = 333; // 100 becomes 333
console.log(myArrOver[2]); // Result -> 333

// There is no index out of range exception. If we access index 7 in length 5 the value will be undefined
// The same is if we access index -1 -> Undefined
console.log(myArrOver[-1]);
console.log(myArrOver[10]);

// If the array is with length 4 and we add value on index 6 there will be a gap between 
//3th and 6th index with undefined values which dont exists. Empty space.
// Example 4,5 are undefinde 6th index = 66;
myArrOver[6] = 66;
console.log(myArrOver.length);
console.log(myArrOver);
console.log(myArrOver[4]);
console.log(myArrOver[5]);
console.log(myArrOver[6]);


/////////// Task 4 - Read the array
// Variation 1 - regualr for loop
for (let index = 0; index < myArrOver.length; index++) {
    console.log(`[${index}] -> ${myArrOver[index]}`);
}

// Variation 2 - for loop similar to foreach in C#
for (let value of myArrOver) {
    console.log(value)
}

// //////// Task 5 - Take multiple values from array
let newArray = [10, 20, 30, 40];

// we take the first and the second value from the array and assign them to the new 
let [xNum, yNum] = newArray; // copie the first and the second value of the array
// let [xNum, ...params] = newArray; // copie the first value of the array + the rest of it
let [...rest] = newArray; // copies the whole array

console.log(xNum, yNum);

//////// Task 6 - spread operator ....name
// this operators takes all the values which he has to receive
function takeRest(...params) {
    console.log(...params);
}

takeRest(1);
takeRest(1, 2);
takeRest(1, 2, 3);
takeRest(1, 2, 3, 4);
takeRest(1, 2, 3, 4, 5);


//////// Task 7 - array function (POP, PUSH, Shift)

// POP Removes the last element and returns it as a value - Stack C#
let arrayFunc = [10, 20, 30, 40];
console.log(arrayFunc.length); // 4
console.log(arrayFunc.pop()); // 40
console.log(arrayFunc.length); // 3

// PUSH add element after the last element of the array and returns the new length of the array - Stack C#
let arrayFunc2 = [10, 20, 30, 40];
console.log(arrayFunc2.length); // 4
console.log(arrayFunc2.push(10)); // 5

// SHIFT removes the firs element and returns it as a value - Queue C#
let arrayFunc3 = [10, 20, 30, 40];
console.log(arrayFunc3.length); // 4
console.log(arrayFunc3.shift()); // 10
console.log(arrayFunc3.length); // 3

// UNSHIFT adds one or more elements at the beginning of the array and returns the new length
let arrayFunc4 = [10, 20, 30, 40];
console.log(arrayFunc4.length); // 4
console.log(arrayFunc4.unshift(1, 2)); // 6

//////// Task 8 - Sorting

//Numbers
numArray.sort((a, b) => a - b); // For ascending sort
numArray.sort((a, b) => b - a); // For descending sort

//String, to catch the small letters we use this function
let myArrSplice3 = ['marry', 'Marry', 'John', 'alice']
myArrSplice3.sort((a, b) => a.localeCompare(b));
console.log(myArrSplice3);

/////// Task 9 - Splice like Skip and Take in C#
// Go on X element and delet Y count elements. Returns the deleted elements
let myArrSplice = [10, 20, 30, 40]
let result = myArrSplice.splice(1, 1);
// .slice(-3) takes the last 3 elements
// .slice(1, 5) takes the elements from index 1 to index 5
console.log(myArrSplice);

// If we want to add value in the array -> Go on X Index delete Y count, and add Value on X index
let myArrSplice2 = [10, 20, 30, 40]
let result = myArrSplice2.splice(1, 0, 222);
console.log(myArrSplice2);

//////// Task 10 - Concat
let myArrCon = [10, 20, 30, 40]
let myArrCon2 = [10, 20, 30, 40]
console.log(myArrCon.concat(myArrCon2))


///// Task 11 - Inludes == Contains in c#
myArrCon2.includes(1); // is number 1 exist in the array
myArrCon2.includes(1, 3); // is number exist 1 after index 3

///// Task 12 - IndexOf = FirstOrDefault in C#
// returns the index of the element
myArrCon2.indexOf(1); // If there is no such element will return -1

///// Task 13 - Foreach is like Foreach from Linq in C#
result.forEach(x => `${console.log(x)}`) // prints the element X
result.forEach((i, x) => `${i} => ${console.log(x)} `) // print the index of the element i and the element x

//// Task 14 - some -> ANY in C#
console.log(myArrCon2.some(x=> x == 3)) // returns true or false if a value in the array met the condition

//// Task 15 - find -> Single in C#
console.log(myArrCon2.find(x=> x == 'value')) // returns the object

//// Task 16 - filter -> where in C#
console.log(myArrCon2.filter(x=> x == 'value')) // returns the array of objects which met the condition

//// Task 17 - map -> select in C#
console.log(myArrCon2.map(x=> Number(x))); // returns new array of objects with new values

// multi map. change all values to numbers and add 1 to every value. Interates trough every value
console.log(myArrCon2.map(x=> Number(x).map(x=> x + 1)));

