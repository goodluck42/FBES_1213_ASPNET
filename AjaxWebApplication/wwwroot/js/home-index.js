$(function () {
	let $cars = $("#car-list > *[data-id]");

	$cars.on("click", function (e) {

		let $that = $(this);

		$.ajax({
			url: "/Home/Remove",
			contentType: "application/json",
			data: JSON.stringify({
				id: $that.data("id")
			}),
			type: "POST",
			success: function () {
				$that.remove();
			}
		});
	});
});