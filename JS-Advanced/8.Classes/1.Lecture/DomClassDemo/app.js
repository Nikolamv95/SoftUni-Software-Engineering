class Modal {
    constructor(message, parent) {
        this.message = message;
        this.element = this._initialize();
        this.render(parent)
    }

    _initialize() {
        // we have to bind this function if we want the context of the function to reffer scope of the class -> this.onClose.bind(this)
        const container = createElement('div', createElement('p', this.message), button('OK', this.onClose.bind(this)));
        container.classList.add('modal');
        return container;
    }

    onClose() {
        this.element.remove();
    }

    render(parent) {
        parent.appendChild(this.element);
    }
}

document.getElementById('createBtn').addEventListener('click', () => {
    const main = document.querySelector('main');
    new Modal('It works', main);
});

function button(label, callback) {
    const element = createElement('button', label);
    element.addEventListener('click', callback);
    return element;
}

function createElement(type, ...content) {
    const result = document.createElement(type);

    content.forEach(element => {
        if (typeof element === 'string') {
            const node = document.createTextNode(element);
            result.appendChild(node);
        } else {
            result.appendChild(element);
        }
    });

    return result;
};