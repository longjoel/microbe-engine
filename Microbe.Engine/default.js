

setTile(0, [
    1, 2, 3, 2, 1, 2, 3, 2,
    2, 0, 0, 3, 3, 0, 0, 3,
    3, 0, 0, 3, 3, 0, 0, 3,
    2, 0, 0, 3, 3, 0, 0, 3,
    1, 0, 0, 3, 3, 0, 0, 3,
    2, 0, 0, 3, 3, 0, 0, 3,
    3, 0, 0, 3, 3, 0, 0, 3,
    2, 3, 3, 3, 3, 3, 3, 3
]);

setTile(1, [
    0, 0, 0, 2, 2, 0, 0, 0,
    0, 0, 0, 2, 2, 0, 0, 0,
    0, 0, 2, 2, 2, 2, 0, 0,
    0, 0, 0, 2, 2, 0, 0, 0,
    0, 2, 2, 2, 2, 2, 2, 0,
    0, 0, 0, 2, 2, 0, 0, 0,
    0, 0, 2, 0, 0, 2, 0, 0,
    0, 0, 2, 0, 0, 2, 0, 0
]);

var p1 = getPalette(1);

setString(0, 0, "microbe-engine");

setPalette(1, {...p1,
    c2: {
        r: 255, g: 0, b: 128
    }
});

let a = 0;

let spr0 = getSprite(0);
spr0.visible = true;
spr0.x = 18;
spr0.y = 18;
spr0.tileIndex = 1;
setSprite(0, spr0);

setMain((t) => {

   

    var gpState = getGamepadState();
    spr0 = getSprite(0);

    if (gpState.up) {
        setTextColor({ r: 0, g: 128, b: 0 });
        spr0.y--;

    }
    if (gpState.down) {
        spr0.y++;
    }

    if (gpState.left) {
        spr0.x--;

    }
    if (gpState.right) {
        spr0.x++;
    }

    spr0.background = gpState.a;
    

    setSprite(0, spr0);
   


});