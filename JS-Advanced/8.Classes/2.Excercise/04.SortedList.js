class List {
    constructor() {
        this.values = [];
        this.size = 0;
    }

    add(elemenent) {
        this.values.push(elemenent);
        this.size = this.values.length;
    }
    remove(index) {
       this.values.splice(index, 1);
       this.size = this.values.length;
    }
    get(index) {
        return this.values[index];
    }
    _size() {
        return this.size = this.values.length;
    }
}

// Instantiate and test functionality
var myList = new List();
myList.add(5);
myList.add(3);
myList.remove(0);

console.log(myList);
