
// Person start
function Person(name){
    this.name = name;
}

Person.prototype.sayHi = function(){
    console.log(`${this.name} say hello!`)
}
// Person end

// Employee start
function Employee(name, salary){
    // use the constructor of Person with this for current context and name as parameter
    Person.call(this, name);
    // if array
    //Person.apply(this, [values]);
    this.salary  = salary;
}

// Use the Person.prototypes and apply them to employee
Employee.prototype = Object.create(Person.prototype);

// Extend employee prototype with more functions
Employee.prototype.collectSalary = function (){
    console.log(`${this.name} collected ${this.salary} lv.`);
}
// Employee end

const myEmployee = new Employee('Petar', 1200);
console.log(myEmployee);
myEmployee.collectSalary();
myEmployee.sayHi();