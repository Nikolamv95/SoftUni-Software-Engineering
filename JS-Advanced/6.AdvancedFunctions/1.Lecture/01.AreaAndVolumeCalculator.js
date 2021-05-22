function area() {
    return this.x * this.y;
}

function vol() {
    return this.x * this.y * this.z;
}

function solve(area, vol, dataAsJSON){
    const figures = JSON.parse(dataAsJSON);
    
    const result = input.map(figure=> ({
        area:  area.call(figure),
        volume: vol.call(figure),
    }));
   
   return figures;
}

const input = `[
    {"x":"10","y":"-22","z":"10"},
    {"x":"47","y":"7","z":"-5"},
    {"x":"55","y":"8","z":"0"},
    {"x":"100","y":"100","z":"100"},
    {"x":"55","y":"80","z":"250"}
]`;
    

solve(area, vol, input)
