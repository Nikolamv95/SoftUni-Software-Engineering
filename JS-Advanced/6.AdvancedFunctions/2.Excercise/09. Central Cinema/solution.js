function solve() {
    const formElements = document.querySelector('#container').children;
    const inputs = Array.from(formElements).slice(0, formElements.length - 1);
    const onScreenBtn = Array.from(formElements)[formElements.length - 1];
    onScreenBtn.addEventListener('click', createMovie);

    const moviesUl = document.querySelector('#movies>ul');
    const archieveUl = document.getElementById('archive').querySelector('ul');

    document.querySelector('#archive>button').addEventListener('click', event => {
        event.target.parentNode.textContent = '';
    })


    function archive(element) {
        const li = element.target.parentNode.parentNode;
        const ticketsSold = +element.target.parentNode.children[1].value;
        const movieName = li.children[0].textContent;
        const pricepetTicket = li.children[2].children[0].textContent;
        const totalPrice = ticketsSold * pricepetTicket;
        createArchive(movieName, totalPrice);
        li.remove();
    }

    function deleteArchive(element) {
        const li = element.target.parentNode;
        li.remove();
    }

    function createArchive(movieName, ticketsTotal) {
        let li = createCustomElement('li');
        const name = createCustomElement('span', movieName);
        const tickets = createCustomElement('strong', `Total amount: ${ticketsTotal.toFixed(2)}`);
        const button = createCustomElement('button', 'Delete');
        button.addEventListener('click', deleteArchive);

        elementAppender(archieveUl, li);
        elementAppender(li, name);
        elementAppender(li, tickets);
        elementAppender(li, button);
    }

    function createMovie(event) {
        event.preventDefault();

        const name = inputs[0].value;
        const hall = inputs[1].value;
        const price = Number(inputs[2].value);

        if (!name || !hall || !Number(price)) {
            alert('All fields should be filled')
            return;
        }

        cleanInputs();
        createMovieElements(name, hall, price)
    }

    function createMovieElements(name, hall, price) {

        let li = createCustomElement('li');
        const movieEl = createCustomElement('span', name);
        const hallEl = createCustomElement('strong', `Hall: ${hall}`);

        const divEl = createCustomElement('div');
        const priceEl = createCustomElement('strong', price.toFixed(2));
        const inputEl = createCustomElement('input', undefined, ['placeholder', 'Ticket sold'])
        const archiveBtnEl = createCustomElement('button', 'Archive')
        archiveBtnEl.addEventListener('click', archive);

        elementAppender(moviesUl, li);
        elementAppender(li, movieEl);
        elementAppender(li, hallEl);
        elementAppender(li, divEl);
        elementAppender(divEl, priceEl);
        elementAppender(divEl, inputEl);
        elementAppender(divEl, archiveBtnEl);
    }

    function elementAppender(main, toAppend) {
        main.appendChild(toAppend);
    }

    function createCustomElement(type, text, attributes) {
        const result = document.createElement(type);
        if (text !== undefined) {
            const node = document.createTextNode(text);
            result.appendChild(node);
        }

        if (attributes) {
            result.setAttribute(attributes[0], attributes[1])
        }

        return result;
    }

    function cleanInputs() {
        inputs[0].value = '';
        inputs[1].value = '';
        inputs[2].value = '';
    }
}