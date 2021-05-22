function calculator() {
    let firstElement;
    let secondElement;
    let resultElement;

    return {
        init: (selector1, selector2, resultSelector) => {
            firstElement = document.querySelector(selector1);
            secondElement = document.querySelector(selector2);
            resultElement = document.querySelector(resultSelector);
        },
        add: () => {
            resultElement.value = Number(firstElement.value) + Number(secondElement.value);
        },
        subtract: () => {
            resultElement.value = Number(firstElement.value) - Number(secondElement.value);
        },
    };
};

let calculate = calculator();

// on this way "#num1" we take the element from the DOM tree with id "#num1" and give it 
// as a parameter to init function; This is optional instead GetElementById
calculate.init("#num1","#num2","#result")




