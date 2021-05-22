function createCounter(){
    let count = 0;

    return function(){
        count ++;
        console.log(count);
    };
;}

const myCounter1 = createCounter();

console.log(myCounter1);
myCounter1();
myCounter1();
myCounter1();
myCounter1();
myCounter1();
myCounter1();
myCounter1();
myCounter1();