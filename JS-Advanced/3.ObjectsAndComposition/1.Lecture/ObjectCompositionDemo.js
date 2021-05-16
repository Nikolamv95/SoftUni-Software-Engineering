/////////////// Step 1 - Declarin object town
let name = "Sofia";
let population = 1325744;
let country = "Bulgaria";

let town = { name, population, country };
console.log(town);
// Object {name: "Sofia", population: 1325744,country: "Bulgaria"}

/////////////// Step 2 - add object inside the object
// create new property location = new object which will be recorded in prop location
town.location = { lat: 42.698, lng: 23.322 };
console.log(town);
// Object {…, location: Object}

/////////// Step 3 - Nested Destructuring

//{property: {chiledProperty}} = object which has this property
//in c# object location with property last => location.last(value);
const { location: { lat } } = town;

// the data will be writen in the {chiledProperty} and we can read it
// console.log(chiledProperty)
console.log(lat);

//////// Step 4 - Array with multiple objects inside
const employees = [
    { name: 'John', position: 'worker' },  // first element
    { name: 'Jane', position: 'secretary' }
];

//destruct the array and take the firs element of it with property name
let employeeName = employees[0].name; // name of first element is 'John'
let empPos = employees[0].position; //position of first element is 'worker'

//////////// Step 5 - Object with property array inside (INHERITANS)
const company = {
    employees: ['John', 'Jane', 'Sam', 'Suzanne'],
    name: ['Quick Build', 'Marcos DB']
};

const firstName = company.employees[0];
const { employees: [empName] } = company; // empName is 'John'


