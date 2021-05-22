const myObj = {
    name: 'Peter',
    myMethod(){
        console.log('My name is ' + this.name);
    },
};

// function myFunc(a, b) {
//     console.log(this);
//     console.log(a,b);
// };

// // In this case the function will be executed in the global scope
// myFunc(5,3);

// // In this case we say execute the code of myFunc in the scope of myObject
// // ant "this" will be applyed in the context of myObj

// myFunc.apply(myObj, [6, 11]);// takes the arguments only as array
// myFunc.call(myObj, 6, 11); // is prefferd
// myFunc.call(myObj, ...[6, 11]); // is prefferd

// // Bind creates new function which context is the myObj and we 
// // have to handle the new function with new context
// const funcMyObjContext = myFunc.bind(myObj);
// // now funcMyObjContext() is a function with the context of myObj
// funcMyObjContext(10, 12);

//////// Example

// in this case we take a refference to the myMethod but now the context
// // of the function is different (Global Scope)
// const funcRefGlobal = myObj.myMethod;

// now funcRefMyObjContext has the same context as myMethod and can be 
// executed from everywhere and it will keep the same context of myObj
// const funcRefMyObjContext = myObj.myMethod.bind(myObj);

// // funcRefGlobal();
// funcRefMyObjContext();


// // in this case the method will be executed in the global scope because
// // the button dont have such a property like this.name;
// document.querySelector('button').addEventListener('click', myObj.myMethod);

// // in this case we say your context of execution will always be in the context of myObj
// // and if we look we can see that myObj has this as a property and we can take
// // the name from there;
// document.querySelector('button').addEventListener('click', myObj.myMethod.bind(myObj));

// We take a function from the global scope but say that the this will be taken from the myObj

function myFunc(a, b) {
    console.log(this.name);
    console.log(a,b);
};

// const funcRefMyObjContext = myFunc.bind(myObj);
// funcRefMyObjContext(10, 12);


// Both executions bellow are similar

// Execution - 1
// We call myFunc function with context of myObj and 5, 3 values
myFunc.call(myObj, 5, 3);

// Execution - 2 
// We attach to myObj new function (by refference) composedFunction 
// and now composedFunction will have the same logic as myFunc and 
// the context will be from myObj. But this is not a good practice add
// or change propertis of an object which we receive from outside
myObj.composedFunction = myFunc;
myObj.composedFunction(6,2);