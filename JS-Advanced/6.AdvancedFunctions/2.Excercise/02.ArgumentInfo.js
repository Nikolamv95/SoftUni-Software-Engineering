function argumentInfo(...arguments) {
    const typeCounts = {};
    const otputs = [];
    const values = [];

    arguments.forEach(element => {
        const typeOfElement = typeof (element);

        if (!typeCounts[typeOfElement]) {
            typeCounts[typeOfElement] = 1;
        } else {
            typeCounts[typeOfElement] + 1;
        }

        otputs.push(`${typeOfElement}: ${element}`);
    });

    Object.keys(typeCounts)
        .sort((a, b) => typeCounts[b] - typeCounts[a])
        .forEach(k => {
            values.push(`${k} = ${typeCounts[k]}`);
        });

    return otputs.concat(values).join('\n');
}

// Testing
console.log(argumentInfo('cat', 42, function () { console.log('Hello world!') }, 45));
