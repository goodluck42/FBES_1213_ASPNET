$(function () {
	let $inputFile = $("#upload-container input[type=file]");
	let $uploadFileInput = $("#upload-container input[type=button]");

	$uploadFileInput.on("click", function (e) {
		let formData = new FormData();
		let files = $inputFile.prop("files");

		for (let file of files) {
			formData.append("files", file);
		}

		$.ajax({
			url: "/Home/UploadFile",
			method: "POST",
			data: formData,
			contentType: false,
			processData: false,
			cache: false,
			success: function () {
				console.log("Uploaded");
			}
		});
	});
});


//$(function () {
//	let $fileName = $("#ajax-upload-container input[type=text]");
//	let $fileDownload = $("#ajax-upload-container input[type=button]");

//	$fileDownload.on("click", function (e) {
//		$.ajax({
//			url: `/Home/DownloadFile`,
//			method: "get",
//			xhrHeaders:
//			{
//				responseType: "blob"
//			},
//			data: {
//				fileName: $fileName.val()
//			},
//			success: function (data) {
//				console.log(data);
//				let a = document.createElement('a');
//				let url = window.URL.createObjectURL(data);

//				console.log(url);
//				console.log(url.toString());

//				a.href = url;
//				a.download = 'file';

//				document.body.append(a);

//				a.click();
//				a.remove();

//				window.URL.revokeObjectURL(url);
//			}
//		});

//	});
//});