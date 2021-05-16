//Task 1 - Associative Arrays declare -> DICTIONARY IN C#
// a = key, 1 = value, both are accessible
const obj = {a: 1, b:2, c:3};
for (const key in obj) {
    console.log(`${key} -> ${obj[key]}`)    
}

// Task 2 - Take all keys
const keys = Object.keys(obj);
console.log(keys)

// Task 3 - Take all values
const values = Object.values(obj);
console.log(values)

// Task 4 - Take all the data in Typle structure
const entries = Object.entries(obj);

// entry is KeyValuePair
for (let [key, value] of entries) {
    console.log('key', key);
    console.log('values', value);
}