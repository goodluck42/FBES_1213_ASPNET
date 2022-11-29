$(function () {
	let $model = $("#car-model");
	let $price = $("#car-price");
	let $speed = $("#car-speed");
	let $id = $("#car-id");
	let $updateButton = $("#car-update");

	$updateButton.on("click", function () {
		let model = $model.val();
		let price = $price.val();
		let speed = $speed.val();
		let id = $id.val();

		$.ajax({
			url: "/Home/Update",
			contentType: "application/json",
			data: JSON.stringify({
				Model: model,
				Speed: speed,
				Price: price,
				Id: id
			}),
			type: "POST",
			success: function () {
				alert("Updated");
			}
		});
	});

});