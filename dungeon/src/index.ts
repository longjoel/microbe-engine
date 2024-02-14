class playerBuilder {

    playerPalette= {
        c1:{r:128,g:128,b:128} as RGB,
        c2:{r:128,g:200,b:128} as RGB,
        c3:{r:0,g:0,b:0} as RGB

    } as TilePalette;

    tiles={stand:[
        0,0,1,1,1,1,0,0,
        0,1,3,2,3,2,1,0,
        0,1,3,2,3,2,1,0,
        0,0,1,1,1,1,0,0,
        1,1,1,1,1,1,1,1,
        0,0,0,1,1,0,0,0,
        0,0,1,0,0,1,0,0,
        0,1,1,0,0,1,1,0,
    ]};

    build(tileStart:number, paletteStart:number){

        setPalette(paletteStart, this.playerPalette);
        setTile(tileStart, this.tiles['stand']);
        setTilePalette(tileStart,paletteStart);

    }

}

new playerBuilder().build(1,1);

setMain(()=>{
setSprite(0, {tileIndex:1, background:false, visible:true, x:32,y:32, xFlipped:false, yFlipped:false});
});