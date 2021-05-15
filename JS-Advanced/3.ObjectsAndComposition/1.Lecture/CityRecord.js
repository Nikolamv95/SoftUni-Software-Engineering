function cityRecord(name, population, treasury) {
    const city = {
        name: name,
        population: population,
        treasury: treasury,
    };

    delete city.name;
    return city;
}

console.log(cityRecord('Tortuga', 7000, 15000));

