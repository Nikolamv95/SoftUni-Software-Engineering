class Person {
    constructor(name) {
        this.name = name;
    }
    sayHi() {
        console.log(`${this.name} say hello!`)
    }
}

class Employee extends Person {
    constructor(name, salary) {
        super(name); // call the constructor from Person like base in C#
        this.salary = salary;
    }
    collectSalary() {
        console.log(`${this.name} collected ${this.salary} lv.`);
        // call method from Person in method inside Employee
        this.sayHi();
    }
    // override
    // sayHi(){
    //     ///do something
    // }

}

const myEmployee = new Employee('Petar', 1200);
console.log(myEmployee);
myEmployee.collectSalary();
myEmployee.sayHi();