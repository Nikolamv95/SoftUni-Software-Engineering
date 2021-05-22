const recipes = {
    apple: {
        carbohydrates: 1,
        flavour: 2,
    },
    lemonade: {
        carbohydrates: 10,
        flavour: 20,
    },
    burger: {
        carbohydrates: 5,
        flavour: 3,
        fat: 7,
    },
    eggs: {
        carbohydrates: 5,
        flavour: 1,
        fat: 1,
    },
    turkey: {
        protein: 10,
        carbohydrates: 10,
        flavour: 10,
        fat: 10,
    }
};

function solution() {
    state = {
        protein: 0,
        carbohydrates: 0,
        flavour: 0,
        fat: 0,
    }

    return function manager(input) {
        const [operation, ingredient, amount] = input.split(' ');

        if (operation === 'restock') {
            result[valueArgs[ingredient]] += Number(amount);
            return 'Success';
        } else if (operation === 'prepare') {
            let isPrepared = prepareRecipe(ingredient, amount);
        } else { };
    }

    function prepareRecipe(ingredient, amount) {
        currRecipe = recipes[ingredient];
        let isEnough = true;

        if (haveCarboFlavour()) {
            switch (ingredient) {
                case 'burger' || 'eggs':
                    isEnough = state.fat >= currRecipe.fat ? true : false;
                    if (isEnough) {
                        state.fat -= currRecipe.fat;
                    }
                    break;
                case 'eggs':

                    break;
            }
        }

        return isEnough;

    }

    function haveCarboFlavour() {
        
        return state.carbohydrates >= currRecipe.carbohydrates && state.flavour >= currRecipe.flavour
    }
}


let manager = solution();
console.log(manager("prepare apple 10"));





