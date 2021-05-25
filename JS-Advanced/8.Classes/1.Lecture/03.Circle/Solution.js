const Circle = require('./Circle');

// Create instance
let c = new Circle(2);

// Call the radius from the constructor
console.log(`Radius: ${c.radius}`);

// Call the getter of diameter
console.log(`Diameter: ${c.diameter}`);

// Call the getter of area
console.log(`Area: ${c.area}`);


// Call the setter of diameter and set new value;
c.diameter = 1.6;

// Now the radius will be changed because the setter of c.diameter = 1.6;
// has return this.radius = value / 2;
console.log(`Radius: ${c.radius}`);

// Call the getter of diameter with the new value 1.6
console.log(`Diameter: ${c.diameter}`);

// Call the getter of area with new value because radius is already changed
console.log(`Area: ${c.area}`);
