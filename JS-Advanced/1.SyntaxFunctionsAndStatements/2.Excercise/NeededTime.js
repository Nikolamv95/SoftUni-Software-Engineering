function neededTime(steps, footprintLen, speed) {
    
    const dist = steps * footprintLen;
    let time = Math.round(dist / speed * 3.6);
    time += Math.floor(dist / 500) * 60;

    const seconds = time % 60;
    time -= seconds;
    time /= 60;

    const minutes = time % 60;
    time -= minutes;
    time /= 60;

    const hours = time;

    return `${pad(hours)}:${pad(minutes)}:${pad(seconds)}`;

    function pad(num) {
        return num < 10 ? '0' + num : '' + num;
    }
}

console.log(neededTime(4000, 0.60, 5));
console.log(neededTime(2564, 0.70, 5.5));