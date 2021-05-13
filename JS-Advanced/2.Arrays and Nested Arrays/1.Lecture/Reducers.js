let myArrReduce = [10, 20, 30, 40]
let myArrReduce2 = [10, 20, 30, 40]

let sumArray = myArrReduce.reduce((acc, c) => acc + c, 0);
let averageArray = myArrReduce.reduce((a, b) => (a + b), 0) / myArrReduce.length;
let maxNumber = myArrReduce.reduce((a, b) => Math.max(a, b));
let minNumber = myArrReduce.reduce((a, b) => Math.min(a, b));