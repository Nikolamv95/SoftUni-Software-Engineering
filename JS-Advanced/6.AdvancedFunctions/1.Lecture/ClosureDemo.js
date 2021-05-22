// function solve() {
//     const output = document.querySelector('textarea');
//     const cart = [];

//     // those functions can see the variables and the other functions which are in the scope
//     // where the current function is declared;
//     document.querySelector('.shopping-cart').addEventListener('click', (place) => {
//        cart = push(1); // this lambda function see cart which is outside of its scope
//     });

//  };


// Example
//  function A(){
//     let myVarA =  5;
//    console.log('Inside A', myVarA)
//    B();
//  }

//  function B(){
//    let myVarB =  3;
//    console.log('Inside B',myVarB )
//    C();
// }

// function C(){
//    let myVarC =  'Peter';
//    console.log('Inside C', myVarC)
// }

// A();


// // Example 2

// function A() {
//    let myVarA = 5;
//    console.log('Inside A', myVarA)
//    B();

//    function B() {
//       let myVarB = 3;
//       console.log('Inside B', myVarB, myVarA);
//    }
// }

// A();


// Example 3

// function A() {
//    let myVarA = 5;
//    console.log('Inside A', myVarA)
//    return B;

//    function B() {
//       let myVarB = 3;
//       console.log('Inside B', myVarB, myVarA);
//    }
// }

// const funcB = A();
// funcB();

// Example 4

function createRect(width, height) {

   return {
      getWidth,
      getHight,
      getArea,
   }

   function getWidth() {
      return width;
   }

   function getHight() {
      return height;
   }

   function getArea(){
      return width * height;
   }
}

const myRect = createRect(5, 3);

// IN THIS CASE WE CREATE NEW PROPERTY WIDTH
// AND THIS PROPERTY HAS NOTHING ABOUT IT WITH 
// WIDTH WHICH IS USED IN THE FUNCTIONS
myRect.width = 8;

// EXAMPLE
console.log(myRect.width); // 8 -> the value of the new PUBLIC property 
console.log(myRect.getHight()); // 5 -> in this function width came from function createRect(width, height)
console.log(myRect.getWidth()); // 3 -> in this function width came from function createRect(width, height)
console.log(myRect.getArea()); // 15 -> in this function width came from function createRect(width, height)



