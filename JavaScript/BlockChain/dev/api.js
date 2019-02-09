var express = require('express')
var app = express()
var BlockChain = require('./blockchain')
var bitcoin = new BlockChain();

var bodyParser = require('body-parser')

var uuid = require('uuid/v1');
var nodeAddress = uuid().split('-').join('');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended:false}))

app.get('/blockchain', function (req, res) {
    res.send(bitcoin)
})

app.post('/transaction', function (req, res) {
    
    const blockIndex = bitcoin.createNewTransaction(req.body.amount, req.body.sender, req.body.recipient)
    res.json({note: `트랜잭션은 ${blockIndex} 블록안으로 들어갈 예정입니다.`})

})

app.get('/mine', function (req, res) {
    
    const lastBlock = bitcoin.getLastBlock();

    const previousBlockHash = lastBlock['hash'];

    const currentBlockData = {
        transactions: bitcoin.pendingTransactions,
        index: lastBlock['index'] + 1
    };

    const nonce = bitcoin.proofOfWork(previousBlockHash, currentBlockData);
    const blockHash = bitcoin.hashBlock(previousBlockHash, currentBlockData, nonce);

    bitcoin.createNewTransaction(10, "bosang0000", nodeAddress)

    const newBlock = bitcoin.createNewBlock(nonce, previousBlockHash, blockHash)

    res.json({
        note: "새로운 블록이 성공적으로 만들어졌습니다.",
        newBlock: newBlock
    })
})

app.listen(3000, function() {
    console.log('listening on port 3000')
})