function factory(library, orders) {

    const result = [];

    // Iterate trough the orders
    for (const order of orders) {

        // Create new ORDER object. Object.assign copy property of a object
        // and assign it to new object
        const newOrder = Object.assign({}, order.template);

        // Iterates trough order.parts
        for (const method of order.parts) {
            // newOrder[part] (create new property with name [method])
            // library[part] access the implementation of the method which is in library
            // newOrder[method] = library[method] assign a method with name [method] 
            //from library to newOrder with property[method]
            newOrder[method] = library[method];
        }

        // in C#
        // class Product
        // public Template Name => this.name = order.template.name
        // public Parts[] Parts => this.Parts = new []{"value1", "value2" }
        result.push(newOrder);
    }

    return result;
}


const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};

const orders = [
    {
        template: { name: 'ACME Printer' },
        parts: ['print']
    },
    {
        template: { name: 'Initech Scanner' },
        parts: ['scan']
    },
    {
        template: { name: 'ComTron Copier' },
        parts: ['scan', 'print']
    },
    {
        template: { name: 'BoomBox Stereo' },
        parts: ['play']
    },
];

const products = factory(library, orders);
console.log(products);

// Acces the values in products
const player = products[3];
console.log(player.name);
player.play('JS Bomb', 'You are alone');