import * as signalR from "@microsoft/signalr";
import "./css/main.css";

const divMessages: HTMLDivElement = document.querySelector("#divMessages");
const tbMessage: HTMLInputElement = document.querySelector("#tbMessage");
const btnSend: HTMLButtonElement = document.querySelector("#btnSend");
const username = new Date().getTime();

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

interface IReceivedMessage {
    message: string,
    time: number
}

connection.on("messageReceived", (username: string, payload: IReceivedMessage) => {
    const m = document.createElement("div");

    m.innerHTML = `<span class="message-author">${username}</span><span> at ${payload.time}</span><div>${payload.message}</div>`;

    divMessages.appendChild(m);
    divMessages.scrollTop = divMessages.scrollHeight;
});

connection.start().catch((err) => document.write(err));

tbMessage.addEventListener("keyup", (e: KeyboardEvent) => {
    if (e.key === "Enter") {
        send();
    }
});

btnSend.addEventListener("click", send);

function send() {
    try {
        connection.invoke("newMessage", username, tbMessage.value)
            .then(() => (tbMessage.value = ""));
    } catch (err) {
        console.error(err);
    }
}