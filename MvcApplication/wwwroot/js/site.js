// // Variable declaration
// var a = 1; // legacy
// let b = "2";
// const c = true; // cannot change value after declaration
// b = 4; // no type check
// b = 4 + '4' // even it's possible, equals to '44’
// if (a != b) { // equal operator
//     alert('a not equals b')
// } else if (b === c) { //strict equal operator
//     alert('b equals c')
// } else {
//     // action
// }
//
// let arr = [1, 1.2, true, undefined, null, [1, 3, 5]]; // this is array
// arr = arr.concat(5, 6, 7); // concat array with numbers
// let index = arr.findIndex(e => e > 3) // returns 0, if it returns -1 -  element not found
// arr.push(5); // add element to array
// arr.pop(); // remove last element from array
// arr.shift(); // remove first element from array
// arr.unshift(5); // add element to the beginning of array
//
// const obj = {
//     a: '1',
//     b: 2,
//     [a]: 4,
//     c: {
//         a: [1, 2, 3]
//     }
// }
//
// function some() {
//     console.log('Hello, world')
//     return 42
// }
//
// some()
//
// const func1 = function (a, b, c) {
//     return a + b + c;
// }
//
// const func2 = (a, b, c) => a + b + c;
//
// func1(1, 2, 3); // 6
// func2(1, 2, 3); // 6
// const data = localStorage.getItem('someValue'); // get data from local storage
// if (data) {
//     alert(data);
// }
// localStorage.setItem('someValue', 'This is stored data>>>'); // save data to local storage
// var clickCount = 0;
// $(".btn-primary").click(b => {
//     $(".btn-primary").text(`Clicked ${++clickCount} times`)
// })
//
//
//
