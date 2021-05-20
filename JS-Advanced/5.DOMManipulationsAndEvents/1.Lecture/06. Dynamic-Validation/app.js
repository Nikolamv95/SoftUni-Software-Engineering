function validate() {
    // change event is when you write something in the input and then
    // click on different place on the page. Then this event will be fired

    // if the input is not blank you have to change somethin inside and the
    // click on different place on the window
    document.getElementById('email').addEventListener('change', onChange);
    function onChange(event) {

        // Take the value from the event (this is the email)
        const inputEmail = event.target.value;

        // check with regex
        if (/^[a-z]+@[a-z]+\.[a-z]+$/.test(inputEmail)) {
            // if after the change event is fired, the class name is valid
            // remove all classes
            event.target.className = '';
        } else {
            // if not append error class
            event.target.className = 'error';
        }

    }
}