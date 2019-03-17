var redis = require('redis');
var client = redis.createClient();

client.on('connect', function () {
    console.log('Redis client connected');
});

client.on('error', function (err) {
    console.log('Something went wrong ' + err);
});

client.get('foo', redis.print);
client.get('lorem', redis.print);

client.get('obj', (err, result) => {
    if (result){
        var obj = JSON.parse(result);
        console.log(obj);
    }
})