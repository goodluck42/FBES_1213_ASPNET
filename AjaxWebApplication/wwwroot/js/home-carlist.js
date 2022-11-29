$(function () {
	let $getCarsButton = $("#get-cars");
	let $carContainer = $("#cars-container");

	$getCarsButton.on("click", async function () {

		let data = await $.ajax({
			url: "/Home/GetCars",
			type: "GET",
		});

		$carContainer.empty();

		// @item.Id @item.Model @item.Price @item.Speed
		for (let item of data) {
			console.log(item);
			$carContainer.append(`<div>${item.id} ${item.model} ${item.price} ${item.speed}</div>`);
		}
		
	});
});