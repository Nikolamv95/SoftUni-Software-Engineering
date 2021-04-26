// WebSocket = undefined;
// EventSource = undefined;
//, signalR.HttpTransportType.LongPolling

let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/coffeehub")
        .build();

    // This is the name of the methods ReceiveOrderUpdate. Find this method is CoffeeHub
    // When the server calls the JS method the code bellow will be 
    // executed(update) => { document.getElementById("status").innerHTML = update; });
    connection.on("ReceiveOrderUpdate", (update) => {
        document.getElementById("status").innerHTML = update;
    });

    // This is the name of the methods NewOrder. Find this method is CoffeeController
    connection.on("NewOrder", function (order) {
        document.getElementById("status").innerHTML = "Someone ordered a " + order.product;
    });

    // This is the name of the methods Finished. Find this method is CoffeeHub
    connection.on("Finished", function () {
        // connection.stop();
    });

    connection.start()
        .catch(err => console.error(err.toString()));
};

setupConnection();

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();
    const product = document.getElementById("product").value;
    const size = document.getElementById("size").value;

    fetch("/Coffee",
        {
            method: "POST",
            body: JSON.stringify({ product, size }),
            headers: {
                'content-type': 'application/json'
            }
        })
        .then(response => response.text())
        .then(id => connection.invoke("GetUpdateForOrder", parseInt(id)));
});