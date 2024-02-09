import data from './data.json';

setTile(0,data.grass.tile);
setPalette(0,data.grass.palette);

setTile(1,data.tree.tile);
setPalette(1,data.tree.palette);

for(let y = 0; y < data.area.height;y++){
    for(let x = 0; x < data.area.width;x++){
        setVram(x,y,data.area.data[y*8+x]);
    }
}

setMain((dt:number) => {
    setString(5,5,"Hello World");
});