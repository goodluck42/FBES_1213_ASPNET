$(function ()
{
	$.get(`/Home/GetProduct?number=${2}`, data => {
		console.log(data);
	});
});