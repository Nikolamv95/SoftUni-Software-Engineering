function solve() {
    const TASKS = {
        JUNIOR: [
            " is working on a simple task.",
        ],
        SENIOR: [
            " is taking time off work.",
            " is supervising junior workers.",
            " is working on a complicated task."],
        MANAGER: [
            " scheduled a meeting.",
            " is preparing a quarterly report."],
    };

    class Employee {
        constructor(name, age, tasks) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = tasks;
            this._index = 0;
        }

        work() {
            if (this._index === this.tasks.length) {
                this._index = 0;
            }

            console.log(this.name + this.tasks[this._index]);
            this._index++;
        };

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        };
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age, TASKS.JUNIOR);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age, TASKS.SENIOR);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age, TASKS.MANAGER);
            this.dividend = 0;
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        };
    }

    return {
        Junior,
        Senior,
        Manager,
    }
}

const company = solve();
const junior = new company.Junior('Vasil', 2000);
const senior = new company.Senior('Martin', 2000);
const manager = new company.Manager('Marko', 3000);
console.log(junior);
console.log(senior);
console.log(manager);

senior.work();
senior.work();
senior.work();
senior.work();
manager.collectSalary();
senior.collectSalary();