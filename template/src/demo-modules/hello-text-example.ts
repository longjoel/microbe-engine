import { clearText } from "../utils";

export class HelloTestExample implements DemoModule {
    public onLoad(){

        var arr = Array(64);
            for(let j = 0; j < 64; j++){arr[j]=0}

        for(let i = 0; i < 256;i++){

            setTile(i,arr);

        }

    }
    public onTick(dt: number) {
        clearText();
        setString(6,10,'Hello World');
    };

    public onStop(){
       
    };
}