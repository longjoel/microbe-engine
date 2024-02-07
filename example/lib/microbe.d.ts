declare interface Sprite {
    x:number;
    y:number;
    tileIndex:number;
    visible:boolean;
    xFlipped:boolean;
    yFlipped:boolean;
    background:boolean;
}

declare interface RGB {
    r:number;
    g:number;
    b:number;
}

declare interface TilePalette {
    c1:RGB;
    c2:RGB;
    c3:RGB;
}

declare interface GamepadState{
    up:boolean;
    down:boolean;
    left:boolean;
    right:boolean;
    a:boolean;
    b:boolean;
    start:boolean;
    select:boolean;
}

declare interface SampleSegment{
    sn:string;
    sv:number;

    tn:string;
    tv:number;

    sqn:string;
    sqv:number;

    nv:number;
}

declare type cbMain = (dt:number)=>void;

declare function setTile(index:number, data:number[]);
declare function setVram(x:number, y:number, index:number);
declare function setScroll(x:number,y:number);
declare function setSprite(index:number,sprite:Sprite);
declare function getSprite(index:number):Sprite;
declare function getPalette(index:number):TilePalette;
declare function setPalette(index:number, palette:TilePalette);
declare function setString(x:number, y:number, text:string);
declare function setChar(x:number, y:number, c:string);
declare function setTextColor(color:RGB);

declare function setMain(cbMain);

declare function getGamepadState():GamepadState;

declare function setSample(index:number, intervalMS:number ,sample:SampleSegment[]);
declare function playMusic(index:number);
declare function playEffect(index:number);
declare function stopMusic();
