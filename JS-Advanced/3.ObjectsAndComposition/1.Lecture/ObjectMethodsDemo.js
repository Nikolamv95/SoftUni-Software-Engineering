// Task 1 - Object with functions insde -> Similar to class with public methods in C#
let person = {
    firstName: "John",
    lastName: "Doe",
    age: function (myAge) {
        return `My age is ${myAge}!`
    },
    fullName: function () {
        return `My full name is ${this.firstName} ${this.lastName}`
    },
};

console.log(person.age(21)); // My age is 21!
console.log(person.fullName()); // My full name is John Doe


// Task 2 -> Object with stake of functions in a object
let sortNumbers = {

    sortAscending: function (array) {
         return array.sort((a, b) => a - b)
         },
    // or without : function 
    sortDescending (array) { 
        return array.sort((a, b) => b - a) 
    },
};


let array = [1, 2, 3, 4, 4, 3, 2, 1];
let result = sortNumbers.sortDescending(array);
console.log(result.join(' '));

// Task 3 -> 2 objects can swap and inherite their methods
// Step 1 - declare objects with properties and methods
let man = {
    firstName: "John",
    lastName: "Doe",
    age: function (myAge) {
        return `My age is ${myAge}!`
    },
    fullName: function () {
        return `My full name is ${this.firstName} ${this.lastName}`
    },
};

let girl = {
    firstName: "Marie",
    lastName: "Davis",
};

// Step 2 - those 2 variables take the methods of object man
// because the object is refference type let age takes the refference
// to the method in age. Now man.age and age has same refference
let age = man.age;
let fullName = man.fullName;

// Step 3 - object girl declare new methods (age, fullName) and
// they took the refference to these methods from the variables
// age, fullName and man.age, man.fullName
girl.age = age;
girl.fullName = fullName;

// Step 4 - use the new methods in girl object
console.log(girl.age(15))
console.log(girl.fullName())
