function encodeAndDecodeMessages() {
    const textArea = document.querySelectorAll('textarea');
    const buttons = document.querySelectorAll('button');

    const map = {
        encode: {
            text: textArea[0],
            btn: buttons[0],
            func: (char) => String.fromCharCode(char.charCodeAt(0) + 1),
        },
        decode: {
            text: textArea[1],
            btn: buttons[1],
            func: (char) => String.fromCharCode(char.charCodeAt(0) - 1)
        }
    }


    document.getElementById('main').addEventListener('click', event => {

        if (event.target.tagName !== 'BUTTON') {
            return;
        }

        const type = event.target.textContent.toLowerCase().trim().includes('encode') ? 'encode' : 'decode';
        const message = map[type].text.value.split('').map(map[type].func).join('');

        map.encode.text.value = '';
        map.decode.text.value = message;

    })
}