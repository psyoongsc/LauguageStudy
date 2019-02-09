var express = require('express')
var app = express()
var BlockChain = require('./blockchain')
var bitcoin = new BlockChain();

var bodyParser = require('body-parser')

var uuid = require('uuid/v1');
var nodeAddress = uuid().split('-').join('');

var port = process.argv[2];

var rp = require('request-promise');

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

//새로운 노드를 등록하고 전체 네트워크에 알림
app.post('/register-and-broadcast-node', function (req, res) {
    //새로 진입한 노드 주소
    const newNodeUrl = req.body.newNodeUrl;
    //비트코인 네트워크에 새로 진입한 노드의 주소가 없을 경우 추가
    if(bitcoin.networkNodes.indexOf(newNodeUrl) == -1) {
        bitcoin.networkNodes.push(newNodeUrl);
    }
    const regNodesPromises = [];
    //비트코인 네트워크에 등록된 네트워크에 새로운 노드 정보를 등록
    bitcoin.networkNodes.forEach(networkNodesUrl => {
        const requestOption = {
            uri: networkNodesUrl + '/register-node',
            method: 'POST',
            body: {newNodeUrl: newNodeUrl},
            json: true
        };
        //순차적으로 비동기를 실행하기 위해서 배열에 넣음
        regNodesPromises.push(rp(requestOption))
    });  //for 문 끝

    //순차적으로 비동기 작업 처리
    Promise.all(regNodesPromises)
    .then(data => {
        //새로운 노드안에 전체 네트워크에 대한 정보 한번에 입력해주기
        const bulkRegisterOption = {
            uri: newNodeUrl + '/register-nodes-bulk',
            method: 'POST',
            body: {allNetworkNodes: [...bitcoin.networkNodes, bitcoin.currentNodeUrl]},
            json: true
        };

        return rp(bulkRegisterOption);
    }).then(data => {
        res.json({note: "새로운 노드가 전체 네트워크에 성공적으로 등록이 되었습니다."});
    })
})

app.post('/register-node', function (req, res) {
    const newNodeUrl = req.body.newNodeUrl;
    const nodeNotAlreadyPresent = bitcoin.networkNodes.indexOf(newNodeUrl) == -1;
    const notCurrentNode = bitcoin.currentNodeUrl !== newNodeUrl;

    if(nodeNotAlreadyPresent&&notCurrentNode) {
        bitcoin.networkNodes.push(newNodeUrl);
        res.json({note: "새로운 노드가 등록되었습니다."})
    }
})

app.post('/register-nodes-bulk', function (req, res) {

})

app.listen(port, function() {
    console.log(`listening on port ${port}...`)
})