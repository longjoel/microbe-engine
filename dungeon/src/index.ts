const mkFramebuffer = (width: number, height: number, start: number) => {
    return {
        width: width,
        height: height,
        start: start,
        pixels: new Array(width*8 * height*8).fill(0)
    };
};

const drawLine = (x0: number, y0: number, x1: number, y1: number, colorIndex: number, fb: any) => {

    const dx = Math.abs(x1 - x0);
    const dy = Math.abs(y1 - y0);
    const sx = x0 < x1 ? 1 : -1;
    const sy = y0 < y1 ? 1 : -1;
    let err = dx - dy;

    while (true) {
        
        fb.pixels[(x0 * fb.width * 8) + x0] = colorIndex
        if (x0 === x1 && y0 === y1) break;
        const e2 = 2 * err;
        if (e2 > -dy) {
            err -= dy;
            x0 += sx;
        }
        if (e2 < dx) {
            err += dx;
            y0 += sy;
        }


    }
}

const drawFramebufferToTiles = (fb: any) => {
    log(fb.pixels);
    let index = fb.start;
    for (let gridY = 0; gridY < fb.height; gridY++) {
        for (let gridX = 0; gridX < fb.width; gridX++) {
            let miniGrid = new Array(8*8).fill(0);
            for (let sy = 0; sy < 8; sy++) {
                for (let sx = 0; sx < 8; sx++) {
                    let originX = gridX * 8 + sx;
                    let originY = gridY * 8 + sy;
                    let src = fb.pixels[(originY * fb.width * 8) + originX];

                    miniGrid[sy * 8 + sx] =src;
                }

            }
            setTile(index, miniGrid);
            index++;
        }
    }
}


const drawFramebufferToVram = (x: number, y: number, fb: any) => {
    for (let dy = 0; dy < fb.height; dy++) {
        for (let dx = 0; dx < fb.width; dx++) {
            setVram(x + dx, y + dy, fb.start + ((dy * fb.width) + dx));
        }
    }
};

let fb1 = mkFramebuffer(8, 8, 1);

drawLine(0, 0, 64, 64, 2, fb1);
drawFramebufferToTiles(fb1);
drawFramebufferToVram(1, 1, fb1);