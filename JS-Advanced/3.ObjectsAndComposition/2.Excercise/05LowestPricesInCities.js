'use strict'

function solve(input) {
    let log = {};

    while (input.length) {
        let sale = input.shift();
        let [town, product, price] = sale.split(' | ');

        if (!log[product]) {
            // create object NOT ARRAY never do that if you have only one object [{key: value}] only {key: value}
            log[product] = { town, price: Number(price) };
        } else {
            // check the price and do the ternary operator
            log[product] = log[product].price <= Number(price) ? log[product] : { town, price: Number(price) };
        }
    }

    let result = [];
    for (const product in log) {
        result.push(`${product} -> ${log[product].price} (${log[product].town})`);
    }

    return result.join('\n')
}

console.log(solve(
    ['Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10']
))