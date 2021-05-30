const myCollection = {};
// the method size will not be counted when 
// we iterate trough the collection -> It`s hidden;
Object.defineProperty(myCollection, 'size', {
    enumerable: false,
    get: function () {
        return Object.keys(this).length;
    }
});

myCollection['Jhon'] = '+11111';
myCollection['Peter'] = '+21111';
myCollection['May'] = '+31111';

console.log(myCollection.size);

for (let key in myCollection) {
    console.log(key, myCollection[key])
}

// Freeze the collection and set writable to false
Object.freeze(myObj);
myCollection['Jhon'] = '+22222111';

// Unlock the collection and set writable to true
Object.seal(myObj);
myCollection['Jhon'] = '+22222111';