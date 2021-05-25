// We use getter and setters when of of the values of the object
// depends from another value and its needed calclation + if we want
// to create validation of the input which is received

class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    // We call the get method when we want to read the value
    // const diameter = circle.diameter
    get diameter() {
        return this.radius * 2;
    };

    // We call the setter when we want to change the value of the diameter
    // circle.diamter = 8
    // The value of this setter is that we can make validation on the input
    set diameter(value) {
        if (typeof value != 'number') {
            throw new TypeError('Not a number');
        }
        // the value of theradius will be changed
        return this.radius = value / 2;
    };

    // Also we can do only getter without setter, so we can set its value
    // Readonly property
    get area() {
        return Math.PI * (this.radius ** 2);
    }
}

module.exports = Circle;

// Version 2
class Circle {
    constructor(radius) {
        this.getRadius = () => {
            return radius
        }
        this.setRadius = (value) => {
            radius = value
        }
        this.setDiameter = (value) => {
            this.radius = value / 2;
        }
    }

    get area() {
        return Math.PI * (this.getRadius() ** 2);
    }
}