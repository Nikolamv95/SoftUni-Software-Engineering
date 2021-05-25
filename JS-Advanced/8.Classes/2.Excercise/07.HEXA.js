class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() { return this.value; }
    // hex will be given from outside and it will be from type Hex
    // we give the object and when we try to sum this.value from the current instance
    // + the object hex, hex automatically will take its (this.value) and will convert
    // it to number
    plus(hex) { return new Hex(this.value + hex); }
    minus(hex) { return new Hex(this.value - hex); }
    toString() { return '0x' + this.value.toString(16).toUpperCase(); }
    parse(string) { return parseInt(string, 16); }
}

// Create Hex FF object with value 255
let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;

// Create new Hex object a with value 10
let a = new Hex(10);

// Create new Hex object a with value 5
let b = new Hex(5);

// 
console.log(a.plus(b.value).toString());
console.log(a.plus(b.value).toString() === '0xF');

let c = new Hex(10);
console.log(c);
