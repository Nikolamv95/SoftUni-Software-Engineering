function subtract() {
    const firstNum = document.getElementById('firstNumber').value;
    const secondNum = document.getElementById('secondNumber').value;

    document.getElementById('result').innerHTML = Number(firstNum) - Number(secondNum);
}