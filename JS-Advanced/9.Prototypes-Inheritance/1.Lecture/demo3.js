const myObj = {};
Object.defineProperty(myObj, 'name', {
    value: 'Jhon',
    writable: true, // if false we cannot change the value of 'name' => John -> Peter (forbiden)
    enumerable: true, // if false we cannot itterate trough the current property 'name' its hidden
    configurable: false, // if false we cannot change writable and enumerable
});


console.log(myObj);
// cannot be deleted because configurable is false
delete myObj.name;
console.log(myObj);
