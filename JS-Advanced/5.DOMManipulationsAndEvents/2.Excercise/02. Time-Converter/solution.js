function attachEventsListeners() {
    let convertedTime = {};

    document.querySelector('main').addEventListener('click', (event) => {
        if (event.target.tagName === 'INPUT' && event.target.value == 'Convert') {

            const divInput = event.target.parentElement.children[1];
            const inputType = divInput.id;
            const inputNumber = divInput.value;
            convertedTime = convertTime(inputType, inputNumber);

            document.getElementById('days').value = convertedTime.days;
            document.getElementById('hours').value = convertedTime.hours;
            document.getElementById('minutes').value = convertedTime.minutes;
            document.getElementById('seconds').value = convertedTime.seconds;
        }
    });

    function convertTime(inputType, inputNumber) {
        let days = 0;
        let hours = 0;
        let minutes = 0;
        let seconds = 0;

        switch (inputType) {
            case 'days':
                days = Number(inputNumber);
                break;
            case 'hours':
                hours = Number(inputNumber);
                days = hours / 24;
                break;
            case 'minutes':
                minutes = Number(inputNumber);
                days = minutes / 1440;
                break;
            case 'seconds':
                seconds = Number(inputNumber);
                days = seconds / 86400;
                break;
        }

        minutes = days * 1440;
        hours = days * 24;
        seconds = days * 86400;

        return {
            days,
            hours,
            minutes,
            seconds,
        }
    }
}