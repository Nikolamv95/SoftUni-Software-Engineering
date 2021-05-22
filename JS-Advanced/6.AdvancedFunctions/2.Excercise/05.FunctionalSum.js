// This is decorative function in which we save the state of the value
// which we want to work with outside the nested function


// Example if I have array, on every call of the function I dont want to go trough it
// and start from 0 [] = new [], so I keep the values in the [] in the main function
// and return another function in which I will work with the []
// The example bellow is the best example;


// 1 - First we call function add and give number X
function add(a){

    // then we create variable in which we will save the value
    // if we have chained values (1)(6)(etc..)
    let sum = 0;
    // we do operation sum += a to cover scenario if we dont have
    // chained values
    sum += a;


    // 3 - on every (X)(X)(etc) chained value the function which will be
    // called is calc. This function receive value and sum it with our
    // variable SUM. CLOSURE(variable which is declared outside of the
    // calc function)
    function calc(b){
        sum += b;

        // then we return again calc in order to keep the logic
        // on every chained value call calc;
        return calc;
    }

    // 4 - if we want to print the result outside the function add
    // change the behaviour of calc toString and return sum;
    calc.toString = () => sum;

    // 2 - After the function add is done we return our nested function  calc
    // which can take parameter number X
    return calc;
}

// with toString we print SUM
console.log(add(1).toString());
console.log(add(1)(6)(-3).toString());