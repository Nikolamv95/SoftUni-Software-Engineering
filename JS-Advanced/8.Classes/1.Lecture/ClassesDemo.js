'use strict';

class Person {
    // The logi here is similar with C#
    constructor(age, city){
        // the purpose of this._city (_) is if someone use this method
        // to know that this property/method cannot be touched. Its visible
        // but DONT TOUCH IT!
        //this._city = city;
        this.city = city;

        //this._age = age;
        this.age = age;
        
        this.name = 'Nikola';
    }

    get City(){

        return this._city;
    }

    // value refferse to the variable city which is given in the constructor
    set City(value){

        // value logic validation
        if(typeof value != 'string'){
            throw new TypeError('Parameter should be in string format')
        }

        // the this._city value will receive it`s new value from the variable value;
        return this._city = value;
    }

    // if we want to call the getter => const age = (instance)person.age;
    get Age(){
        return this._age;
    }

    // if we want to set the value of age => (instance)person.age = 10
    set Age(value){

        // the value will go trough the validation
        if(!isNaN(value)){
            throw new TypeError('Parameter should be in number format')
        }

        // if true the value will set the new value of this._age
        return this._age = value;
    }

    sayHi(){
        // the variables in the method will call the getters of this._age, this._city and the value from the constructor this.name
        console.log(` Hi I\`m ${this.name} and I\` ${this._age} years old an I leave in ${this._city}`)
    }

    static sayHelloPerson(){
        console.log('This method can be accessed trough the class Person directly.');
    }
}

// Create instance
const person = new Person('10', 10);
// // Show the class
console.log(person);

// // Show property of the class
// console.log(person.age)

// // Use method from the class
// person.sayHi();

// // We can bind the function inside the class to a const variable
// // write in sayHiBind the method from person class sayHi with the parameters of class person
// const sayHiBind = person.sayHi.bind(person);
// sayHiBind();

// // check if a object is instance of a class
// console.log(person instanceof Person); // true or false

// // Access static method directly from the class not its instances
// Person.sayHelloPerson();

// // Static method cant be called trough the instance of the class it will return error
// //person.sayHelloPerson();

// // Assign new static property to the class
// Person.newName = 'Joro';

// console.log(Person.newName);

// //I