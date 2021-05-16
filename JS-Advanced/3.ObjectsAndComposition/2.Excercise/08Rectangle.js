function rectangle(width, height, color) {

    function capitalize (word){
        // let [x, ...rest] = word;
        // let upperColor = `${x.toUpperCase()}${rest.join('')}`;
        // or
        return word[0].toUpperCase() + word.slice(1);
    }
    
    let rectangle = {
        width: width,
        height: height,
        color: capitalize(color),
        calcArea: function () {
            return this.width * this.height;
        }
    }

    return rectangle;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
