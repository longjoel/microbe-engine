import { clearText } from "../utils";

/**
 * This demonstrates a simple scrolling pattern.
 */
export class ScrollingBackgroundDemo implements DemoModule {

    radius:number = 128;
    angle:number = 0;

    public onLoad() {

        var arr = Array(64);
        for (let j = 0; j < 64; j++) { arr[j] = 1 }

        for (let i = 0; i < 64; i++) {
            let px = getPalette(i);
            px.c1 = { r: i*4, g: i*4, b: i*4 };
            setPalette(i, px);


            setTile(i, arr)
        }

        for (let y = 0; y < 32; y++) {
            for (let x = 0; x < 32; x++) {
                setVram(x, y, (Math.floor(Math.random()*256)));
            }
        }

    }
    public onTick(dt: number) {
        clearText();
        this.angle = this.angle+=1;

        let x = Math.cos(this.angle * Math.PI / 180)*this.radius;
        let y = Math.sin(this.angle * Math.PI / 90)*this.radius;

        setScroll(Math.floor(x),Math.floor(y));

    };

    public onStop() {

    };
}