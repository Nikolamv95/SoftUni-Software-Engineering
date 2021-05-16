function solve() {
    let variable = 'aaa';

    // switch
    // switch (property) {
    //     case 'aaa':
    //         console.log(property);
    //         break;
    //     case 'bbb':
    //         console.log('something else');
    //         break;
    //     default:
    //         break;
    // }

    // or function which are stored in a object
    let obj = {
        'aaa': function(){
            console.log(variable)
        },
        'bbb': function(){
            console.log(variable)
        }
    }

    // return and execute the function
    return obj[variable]();
    // return obj[variable]; (only return the function)
}

solve();
