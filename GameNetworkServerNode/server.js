// server.js

const WebSocket = require('ws');

const wss  = new WebSocket.Server({port: 8000});

wss.on('connection', (ws)=>{
    console.log(" 클라이언트 접속됨");
})