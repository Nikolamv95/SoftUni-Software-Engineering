function carFactory(input) { 
    
    const {
        model,
        power,
        carriage,
        color,
        wheelsize
    } = input;

    function getEngine(power) {
 
        const engines = [
            { power: 90, volume: 1800 },
            { power: 120, volume: 2400 },
            { power: 200, volume: 3500 }
        ].sort((a, b) => a.power - b.power);
    
        return engines.find(el => el.power >= power);
    }
    
    function getWheels(wheelSize) {
    
        let size = wheelSize;
    
        if (wheelSize % 2 == 0) {
            size = wheelSize - 1;
        }
    
        return Array(4).fill(size);
    }
    
    return {
        model: model,
        engine: getEngine(power),
        carriage: { type: carriage, color: color },
        wheels: getWheels(wheelsize),
    };
};



console.log(carFactory({
    model: 'Ferrari',
    power: 200,
    color: 'red',
    carriage: 'coupe',
    wheelsize: 21
}));
