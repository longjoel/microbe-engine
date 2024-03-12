var arr = new Array(64);
for(var i = 0; i < 64; i++) {
    arr[i]= (i %3)+1;
}
setTile(0, arr);

var ogSprite = getSprite(0);
ogSprite.visible = true;
ogSprite.x = 10;
ogSprite.y = 10;
setSprite(0, ogSprite);

setSample(0,100,[{
    sn:100,
    sv:0,
    sqn:100,
    sqv:0,
    nv:100,
    tn:100,
    tv:0
}
]);