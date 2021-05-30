const myObj = {
    name: 'Peter',
    age: 21,
};

console.log(Object.getOwnPropertyDescriptor(myObj, 'name'));

Object.defineProperty(myObj, 'lastName', {
    value: 'Jackson', 
    writable: true, 
    enumerable: true, // if its false will not have the option to itterate trough it
    configurable: true
});

console.log(myObj);
console.log(myObj.lastName);

for (let key in myObj) {
    console.log(key + ` ->> ` + myObj[key]);
}