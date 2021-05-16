'use strict'

function heroicInventory(input) {
    
    let result = [];

    for (const row of input) {
        let args = row.split(' / ');
        let hero = heroFactory(args);
        result.push(hero);
    }

    console.log(JSON.stringify(result))
}

function heroFactory(args) {

    let hero = {};
    let itemsArr = [];

    hero.name = args[0];
    hero.level = Number(args[1]);
    itemsArr = args[2] ? args[2].split(', ') : [];
    hero.items = itemsArr;

    return hero;
}

heroicInventory(
    ['Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara']
);