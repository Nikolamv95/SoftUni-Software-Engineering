function solve(input) {

    // Take the name of the properties and the rest of the data
    let [columns, ...table] = input.map(splitLine);

    function isEmptyString(x){
        return x != '';
    }

    function convertIfNum(x){
        return isNaN(x) ? x : Number(Number(x)).toFixed(2);
    }

    function splitLine(input) {
        return input
        .split('|') // split by |
        .filter(isEmptyString) // filter all values which have empty space
        .map(x=> x.trim()) // removes all empty space ` name ` => `name`
        .map(convertIfNum) // iterate trough all valus and conver numbers to Number()
    };

    return JSON.stringify(table.map(entry => {
        // table.map => takes the first array in table and iterate trough its indexes 0: 'City', 1: 42.00
        // columns.reduce=> acc(is the result), curr(is the value in the columns Town, Lattitude ect..),
        // index(is the index in the array table(entry))
        return columns.reduce((acc, curr, index) => {
          // at the beginig acc is object withouth properties after every iterate 
          // in the acc will be writen new property with its value from the table(entry) array
          //   Town: "Sofia",
          //   Latitude: 42.696552,
          //   Longitude: 23.32601,
            acc[curr] = entry[index];
            return acc;
            // , {} the final result form the resulet is array of objects;
        }, {})
    }))
    
}


console.log(solve(
    ['| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |']
));