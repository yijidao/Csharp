var net = require('net');
var host = '127.0.0.1';
var port = '8080';

net.createServer(function(sock){
    console.log("CONNECT: " + sock.remoteAddress + ":" + sock.remotePort);
    sock.on('data', function (data){
        sock.write('you said --' + data);
        console.log('you said --' + data);
    });
}).listen(port, host);