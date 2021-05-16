/// STEP 1 - IMPORTANT!!!!!
function print() {
    console.log(`${this.name} is printing a page`);
}

function scan() {
    console.log(`${this.name} is scanning a document`);
}

// The printer inherits print function
const printer = {
    name: 'ACME Printer',
    print,
};

// The scanner inherits scan function
const scanner = {
    name: 'Initech Scanner',
    scan,
};

// The copier (which can prin and scan) inherits both function print, scan
// print, scan means take the implemented function on top and record them in the object
// print(), scan() means create new method with new logic inside
// print() { logic here; return something;}
const copier = {
    name: 'ComTron Copier',
    print,
    scan,
};

printer.print();
scanner.scan();
copier.print();
copier.scan();

//FunctionFactory
// Every time when we call this function createRect new object is created;
// If we call it 2 times 2 objects will be created with different refferences
function createRect(width, height) {

    // create object with 2 properties (width, height) and 1 method (getArea)
    const rect = { width, height };

    // implement the logic of the method which
    // uses the reference of the object rect.property instead of this.property
    rect.getArea = () => {
        return rect.width * rect.height;
    };

    // return the object
    return rect;
}

// create object with values 100, 20
let areaOfReactangle = createRect(100, 20);

// print the assets of the object
console.log(areaOfReactangle.width);
console.log(areaOfReactangle.height);
console.log(areaOfReactangle.getArea()); // Result - 2000

// The variable getArea takes the refference of the method in areaOfReactangle.getArea
const getArea = areaOfReactangle.getArea; // 1
// Result - 2000; the result is similar to areaOfReactangle.getArea(), because they have
// same refference of same object
console.log(getArea()); // 1

// You can see that 2 objects are created from this factory and those objects have different
// refferences but with same structure;
let areaOfRectangleDublicate = createRect(50, 200);
const getAreaDublicate = areaOfRectangleDublicate.getArea; // 2
console.log(getAreaDublicate()); // 

////////// Step 2 - Decorator function
function canPrint(device) {
    // step 3- > assign new property to received device with the following logic
    device.print = () => {
        // print something
        console.log(`${device.name} is printing a page`);
    }
}

// step 1 -> create object with property printer
const printer = { name: 'ACME Printer' };

// step 2 -> call function canPrint and inject object printer inside
canPrint(printer);

// step 4 -> by refference printer received it`s new property print
// and now we can use it;
printer.print();

