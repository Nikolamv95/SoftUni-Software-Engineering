'use strict';

const myObj = {};
Object.defineProperty(myObj, 'name',{
    value: 'George',
    writable: false // Means readonly
})

console.log(myObj.name) // George

// myObj.name = 'Vasil';
console.log(myObj.name) // George

////////////////////////////////
const newObj = {};
// in which object (newObj) to create property with name => (name);
// Because of the closure we can set value of the name and give it
// to the object
let name = 'George'
Object.defineProperty(newObj, 'name',{
    get(){
        return name;
    },
    set(value){
        name = value;
    },
});

console.log ('Before: ' + newObj.name) // George
// keep in minde that if we change the value of newObj.name
// the value of let name will be changed also -> refferen data type
newObj.name = 'Vasil'
console.log ('After: ' + newObj.name) // Vasil
console.log ('After: ' + name) // Vasil