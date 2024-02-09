import data from './data.json';

setTile(0, data.grass.tile);
setPalette(0, data.grass.palette);

setTile(1, data.tree.tile);
setPalette(1, data.tree.palette);

for (let i = 0; i < 10; i++) {

    let spr = getSprite(i);
    spr.x = Math.floor(Math.random() * 160)
    spr.y = Math.floor(Math.random() * 144)
    spr.visible = true;
    spr.tileIndex = 1;
    setSprite(i,spr);

}


let accum = 0;
setMain((dt: number) => {

    if (accum % 3) {
        setString(5, 5, "Hello World");
    }
    else{
        setString(5, 5, "");
    }
    accum++;
    if(accum > 25){
        accum = 0;

      
    }

    for (let i = 0; i < 10; i++) {

        let dx = Math.floor((Math.random() * 7)-5);
        let spr = getSprite(i);
        spr.x = spr.x+dx;
        spr.y = spr.y+1;
        if(spr.y > 144){spr.y = 0;}
        if(Math.abs(dx)> 3){spr.y = spr.y-1}
        spr.visible = true;
        spr.tileIndex = 1;
        setSprite(i,spr);

    }

});