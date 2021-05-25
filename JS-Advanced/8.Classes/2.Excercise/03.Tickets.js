class Ticket {
    constructor(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}

function createTicket(array, sortType) {
    const ticketStorage = [];
    array.forEach(array => {
        const dataArgs = array.split('|');
        const ticket = new Ticket(dataArgs[0], Number(dataArgs[1]), dataArgs[2]);
        ticketStorage.push(ticket);
    });
    
    const result = ticketStorage.sort(function (a, b) {
        if (a[sortType] < b[sortType]) {
            return -1;
        }
        else if (a[sortType] > b[sortType]) {
            return 1;
        }
    });

    return result;
}

console.log(createTicket(
    ['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'], 'destination'));