////// Task 1 - Declare empty object
const myObject = {};

////// Task 2 - Declare object with properties
const myObject2 = {
    name: 'Peter',
    age: 23,
    hairColor: 'Brown',
};

////// Task 3 - Access property
console.log(myObject2.name); // with property - best
//or
console.log(myObject2['name']) // with string - sometimes
//or
const propName = 'name';
console.log(myObject2[propName]); // with variable - good

///// Task 4 - Change object
myObject2.name = 'NewPeter';
console.log(myObject2.name);

///// Task 5 - Adding new property
myObject2.newProperty = 'newProperty';
console.log(myObject2.newProperty);
//or
// create new property and add value to it
myObject2['heigth'] = 170
console.log(myObject2['heigth']) // with string - sometimes
// or with empty space. If we have such a property we can only
//access it with ['porp name']
myObject2['Middle name'] = 'Ivanov';
console.log(myObject2['Middle name']);

///// Task 6 - Delete
delete myObject2.heigth;
console.log(myObject2);
// or if the property name will come as variable we have to delete
// it with delete obejectName[variable name];
let newProperty = 'newProperty';
delete myObject2[newProperty];
console.log(myObject2)

//// Task 7 - Destructor let {prop1, prop2} = myObject2 (the program will check if
// myObject2 contains these props and will assign their values. After that the values
// are accessible)
let {age, name} = myObject2;
console.log(age);
console.log(name);