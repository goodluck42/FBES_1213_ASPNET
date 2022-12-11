$(function () {
	let $userNameInput = $("#user-name");
	let $userCreationDateInput = $("#creation-date");
	let $userCreateButton = $("#user-add");

	$userCreateButton.on("click", function (e) {

		let json = JSON.stringify({
			id: 0,
			firstName: $userNameInput.val(),
			creationDate: $userCreationDateInput.val()
		});

		console.log(json);

		$.ajax({
			url: "https://localhost:7287/api/v1/user/add",
			method: "POST",

			data: json,
			success: function (e) {
				console.log(e);
			}
		});
	});

});