$(function () {
	let $container = $("#pages-container");
	let $pageData = $("#page-data");
	let pages = parseInt($container.data("page-count"));
	const c_ProductCountInOnePage = 5;

	for (let i = 0; i < pages; ++i) {
		$container.append(`<input data-page="${i + 1}" type="button" class="page-button" value=${i + 1}>`);
	}

	$container.on("click", function (e) {
		let $that = $(e.originalEvent.target);

		if ($that.hasClass("page-button")) {
			let currentPage = parseInt($that.data("page"));
			
			let from = (c_ProductCountInOnePage * (currentPage - 1)) + 1;
			let to = currentPage * c_ProductCountInOnePage;

			$.ajax({
				url: `https://localhost:7162/api/v1/product/range?from=${from}&to=${to}`,
				method: "GET",
				success: function (data) {
					$pageData.empty();
					for (let product of data) {
						$pageData.append(`<div>[<span>${product.id}</span>]: <span>${product.name}</span> (<span>${product.quantity}</span>)</div>`)
					}
				}
			});
		}
	});
});