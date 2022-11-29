$(function () {
	let $model = $("#car-model");
	let $price = $("#car-price");
	let $speed = $("#car-speed");
	let $addButton = $("#car-add");

	$addButton.on("click", function () {
		let model = $model.val();
		let price = $price.val();
		let speed = $speed.val();

		$.ajax({
			url: "/Home/Add",
			contentType: "application/json",
			type: "POST",
			data: JSON.stringify({
				Model: model,
				Speed: speed,
				Price: price
			}),
			success: function () {
				alert("Done");
			}
		});
	});
});