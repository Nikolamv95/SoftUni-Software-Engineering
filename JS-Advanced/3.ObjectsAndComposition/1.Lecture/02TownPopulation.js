function townPop(townsArray) {
    let towns = {};

    for (let townStr of townsArray) {
        // .filter(x=> x.length > 0) similar to remove empty entries
        let [town, population] = townStr.split(' <-> ').filter(x => x.length > 0);
        population = Number(population);

        if (towns[town] != undefined) {
            // add the population to the current town
            towns[town] += population;
            continue;
        }

        // here you add the key and its value
        towns[town] = population;
    }

    for (let [town, name] of Object.entries(towns)) {
        console.log(`${town}: ${name}`);
    }
}

townPop([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000',
    'Sofia <-> 1200000']
);