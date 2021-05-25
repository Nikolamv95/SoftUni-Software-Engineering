class Person {
    constructor(firstName, lastName, age, email) {
        this.firstName = firstName,
            this.lastName = lastName,
            this.age = age,
            this.email = email
    };
}

function getPersons(array) {

    const persons = [];
    for (let i = 0; i < array.length; i++) {
        let person = new Person(array[i][0], array[i][1], array[i][2], array[i][3]);
        persons.push(person);
    }
    return persons;
}

const result = getPersons([['Anna', 'Simpson', 22, 'anna@yahoo.com'], ['SoftUni'], ['Stephan', 'Johnson', '25'], ['Gabriel', 'Peterson', 24, 'g.p@gmail.com']])
console.log(result);