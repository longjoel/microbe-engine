import {HelloTestExample} from './demo-modules/hello-text-example';
import {ScrollingBackgroundDemo} from './demo-modules/scrolling-background-demo';

const states = [ new HelloTestExample(), new ScrollingBackgroundDemo()];

let currentState = 0;

let oldGpState = getGamepadState();

setMain((dt:number)=>{

    setString(0,0,'Microbe engine demo');

    let gpState = getGamepadState();

    if( !oldGpState.select && gpState.select){

        states[currentState].onStop();

        currentState++;

        if(currentState >= states.length){
            currentState = 0;
        }

        states[currentState].onLoad();
        
    }

    states[currentState].onTick(dt);
    oldGpState = gpState;

});