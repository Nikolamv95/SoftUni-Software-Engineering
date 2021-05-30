/*
class Person{
    constructor(firstName, lastName){
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get fullName(){
        return `${this.firstName} ${this.lastName}`;
    }
    set fullName(value){
        const args = value.split(' ');
        this.firstName = args[0];
        this.lastName = args[1];
    }
}
*/

// This is constructor function
function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    // Assigne property to the constructor function
    Object.defineProperty(this, 'fullName', {
        enumerable: true,
        get: function () {
            return `${this.firstName} ${this.lastName}`;
        },
        set: function (value) {
            const args = value.split(' ');
            this.firstName = args[0];
            this.lastName = args[1];
        }
    })
}

let person = new Person("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson
person.fullName = "Mary Smith";
console.log(person.fullName);

