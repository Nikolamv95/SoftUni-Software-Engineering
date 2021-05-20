function focused() {
    document.querySelectorAll('input').forEach(i => {
        // focus and blur are DOM API events
        i.addEventListener('focus', onFocus);
        i.addEventListener('blur', onBlur);
    });


    function onFocus(event) {
        event.target.parentNode.className = 'focus';
    }

    function onBlur(event) {
        event.target.parentNode.className = '';
    }
}