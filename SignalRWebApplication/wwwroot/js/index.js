$(function () {
	let hubBuilder = new signalR.HubConnectionBuilder();
	let hubConnection = hubBuilder.withUrl("/hubs/chat").build();
	let $chatMessage = $("#chat-message");
	let $chat = $("#chat");

	$("#chat-message-send").on("click", function () {
		hubConnection.invoke("SendMessage", $chatMessage.val()).then(() => {
			console.log("Message send");
			$chatMessage.val("");
		}).catch((error) => {
			console.error(error);
		});
	});

	hubConnection.on("ReceiveMessage", function (message) {
		$chat.append(`<div class="message">${message}</div>`);
	});

	hubConnection.on("ReceiveHistory", function (messages) {
		for (let message of messages) {
			$chat.append(`<div class="message">${message}</div>`);
		}
	});

	hubConnection.start().then(() => {
		console.log("Connected to hub");

		hubConnection.invoke("GetHistory").then(() => {
			console.log("History received");
		}).catch((error) => {
			console.log(error);
		});

	}).catch((error) => {
		console.error(error);
	});


});