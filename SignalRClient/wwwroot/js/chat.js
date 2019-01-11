"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:6001/chatHub").build();
//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(function (err) {
    return console.log(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//El código anterior:
//Crea e inicia una conexión.
//Agrega al botón de envío un controlador que envía mensajes al concentrador.
//Agrega al objeto de conexión un controlador que recibe mensajes desde el concentrador y los agrega a la lista.