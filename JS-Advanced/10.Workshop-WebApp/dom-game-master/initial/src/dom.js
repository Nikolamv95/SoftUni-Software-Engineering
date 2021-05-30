function createElement(type, attributes = {}, ...content) {
    // create element of type T
    const result = document.createElement(type);

    // Attach all attributes only as a class
    for (const attr in attributes) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLowerCase(), attributes[attr]);
        }else{
            result[attr] = attributes[attr];
        }
    }

    // Append all elements to it;
    content.forEach(element => {
        if (typeof element == 'string' || typeof element == 'number') {
            const node = document.createTextNode(element);
            result.appendChild(node);
        } else {
            result.appendChild(element);
        }
    });

    return result;
};