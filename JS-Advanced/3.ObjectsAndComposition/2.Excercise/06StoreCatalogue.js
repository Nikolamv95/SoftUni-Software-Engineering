function storeCatalogue(args) {
    let dictionary = {};

    for (const productInfo of args) {
        let [name, price] = productInfo.split(" : ");
        let firstLetter = name.charAt(0);

        if (!dictionary[firstLetter]) {
            dictionary[firstLetter] = [];
        }

        dictionary[firstLetter].push({ name, price: Number(price) });
        // sort by product name 
        dictionary[firstLetter].sort((a, b) => (a.name).localeCompare(b.name));
    }

    // let result = [];
    // for (let letter in dict) {
    //     let values = dict[letter].map(x => `  ${x.name}:  ${x.price}`);
    //     let string = `${letter}\n${values.join('\n')}`
    //     result.push(string);
    // }

    let result = [];
    let dict = Object.entries(dictionary).sort((a, b) => a[0].localeCompare(b[0])).forEach(entry => {
        let values = entry[1]
                .sort((a, b) => a.name
                .localeCompare(b.name))
                .map(x => `  ${x.name}:  ${x.price}`)
                .join('\n');

        let string = `${entry[0]}\n${values}`
        result.push(string);
    });

    return result.join('\n');
}

console.log(storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']));