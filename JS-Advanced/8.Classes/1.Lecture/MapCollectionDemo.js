// Create map
const myMap = new Map();
console.log(myMap);

// Set values
myMap.set('peter', '111');
myMap.set('vasko', '222');

// Get values
console.log(myMap);
console.log(myMap.get('peter'));

// Set values to existing record
myMap.set('peter', '1112');
console.log(myMap);

// Itterate trough the map
for (const entry of myMap) {
    console.log(entry);
}

console.log('-----------')
// Itterate trough the map.keys
for (const entry of myMap.keys()) {
    console.log(entry);
}

// Deconstructoring
for (const [key, value] of myMap.keys()) {
    console.log("->>>>>>" + key + '->>>' + value);
}

// Convert to array
let arr = Array.from(myMap);
console.log(arr);

console.log(myMap.size);
console.log(myMap.has('peter'));
console.log(myMap.keys());
console.log(myMap.values());
console.log(myMap.delete(1));
console.log(myMap.clear());
console.log(myMap);

// Map cannot be sorted so we have to convert it to Array and the result will be
// saved in the variable sorted. This operation will not reflect over the initial
// sort collection myMap
let sorted = Array.from(myMap.entries()).sort((a,b) => a[1] = b[1]);
console.log(sorted);
