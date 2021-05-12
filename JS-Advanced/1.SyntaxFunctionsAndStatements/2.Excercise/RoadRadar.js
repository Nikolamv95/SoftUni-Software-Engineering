function roadRadar(speed, area) {

    let result = '';
    
    switch (area) {
        case 'city':
            const restrictionCity = 50;
            result = checkSpeed(speed, restrictionCity);
            return result;
        case 'residential':
            const restrictionResidential = 20;
            result = checkSpeed(speed, restrictionResidential);
            return result;
        case 'interstate':
            const restrictionInterstate = 90;
            result = checkSpeed(speed, restrictionInterstate);
            return result;
        case 'motorway':
            const restrictionMotorway = 130;
            result = checkSpeed(speed, restrictionMotorway);
            return result;
    }

    function checkSpeed(speed, restriction) {
        if (speed <= restriction) {
            return `Driving ${speed} km/h in a ${restriction} zone`;
        }
        else {
            const difference = speed - restriction;
            let status = checkKmOverLimit(difference);

            return `The speed is ${difference} km/h faster than the allowed speed of ${restriction} - ${status}`;
        }
    }

    function checkKmOverLimit(difference) {
        if (difference <= 20) {
            return 'speeding';
        }
        else if (difference > 20 && difference <= 40) {
            return 'excessive speeding';
        }
        else {
            return 'reckless driving';
        }
    }
}

console.log(roadRadar(40, 'city'));
console.log(roadRadar(21, 'residential'));
console.log(roadRadar(120, 'interstate'));
console.log(roadRadar(200, 'motorway'));