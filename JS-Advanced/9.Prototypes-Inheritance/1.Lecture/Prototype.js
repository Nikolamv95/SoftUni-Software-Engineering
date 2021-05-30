// Person Class function
function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
}

// Its a base class which stores functions which other class functions can use
Person.prototype.write = function(message){
    console.log(`Person wrote ${message}`);
}

Person.prototype.doWrite = function(message){
    console.log(`Person wanted to wrote ${message}`);
}

// Create instance of Person
const myPerson = new Person('Ivan', 'Petjov');
console.log(myPerson);

// Use the delegated function write from the prototype
// The prototype basicly is a template which stores
// different type of functions with implementation inside;
myPerson.write('Hello world');
myPerson.doWrite('Hello world');