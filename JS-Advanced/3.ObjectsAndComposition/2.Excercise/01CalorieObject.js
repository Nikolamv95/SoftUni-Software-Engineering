function createCalorieObject(input) {
    let calorieObj = {};
    
    for (let i = 0; i < input.length; i += 2) {
        
        let name = input[i];
        let calorie = input[i + 1];

        calorieObj[name] = Number(calorie);
    }

    return calorieObj;
}

let result = createCalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);