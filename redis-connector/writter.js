var host = "127.0.0.1";
var port = 6379;
var redis = require('redis');

// var client = redis.createClient(); //creates a new client at host 127.0.0.1:6379
var client = redis.createClient(port, host);

client.on('connect', function () {
    console.log('Redis client connected');
});

client.on('error', function (err) {
    console.log('Something went wrong ' + err);
});

client.set('foo', 1, redis.print);
client.set('lorem', 'ipus', redis.print);

var obj = {
    "name": "duongpth",
    "prop": {
        "phone": "0374484419",
        "adr": "TCH10, q12"
    }
}

client.set('obj', JSON.stringify(obj), redis.print)