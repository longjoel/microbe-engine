

setTile(0, [
    1, 1, 1, 1, 1, 1, 1, 1,
    1, 2, 1, 1, 1, 2, 1, 1,
    1, 1, 1, 1, 1, 2, 1, 1,
    1, 1, 2, 1, 1, 1, 2, 1,
    1, 1, 1, 1, 1, 1, 1, 1,
    1, 1, 1, 1, 1, 1, 1, 1,
    1, 1, 1, 1, 3, 1, 1, 1,
    1, 1, 1, 1, 1, 1, 1, 1
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

var p0 = getPalette(0);
var p1 = getPalette(1);

setString(0, 0, "microbe-engine");

setPalette(0, {
    ...p1,
    c1: {
        r: 100, g: 250, b: 75
    },
    c2: {
        r: 75, g: 100, b: 25
    },
    c3: {
        r: 10, g: 100, b: 25
    }
});

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