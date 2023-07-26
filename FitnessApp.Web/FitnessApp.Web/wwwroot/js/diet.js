// Create a connection to the SignalR hub
var connection = new signalR.HubConnectionBuilder().withUrl("/DietHub").build();

// Define the ReceiveMessage event to handle the incoming message from the hub
connection.on("ReceiveMessage", function (diet) {
    // Update the view with the new diet details
    var li = document.createElement("li");
    li.textContent = "New diet added: " + diet.name; // Customize this message according to your needs
    document.getElementById("messagesList").appendChild(li);
    console.log("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTesTestTestadd");
});

// Define the RemoveDiet event to handle the removed diet
connection.on("RemoveDiet", function (dietId) {
    // Update the view to remove the deleted diet
    var dietElement = document.getElementById(`diet_${dietId}`);
    if (dietElement) {
        dietElement.remove();
    }
});

// Start the SignalR connection
connection.start().then(function () {
    // Connection started successfully
    console.log("SignalR connection started.");
}).catch(function (err) {
    // Connection failed
    console.error(err.toString());
});
