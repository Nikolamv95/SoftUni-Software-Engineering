function cookingNumber(...input) {

    let num = Number(input[0]);

    for (let i = 1; i < input.length; i++) {
        switch (input[i]) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num -= num * 0.20;
                break;
        }
    }

    return num;
}

console.log(cookingNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop'));
console.log(cookingNumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));