var x = 50;

setMain(function(){

    var inputState = getGamepadState(0);
        var restart = true;
        if(inputState.left){
            x = x-1;
            restart = true;
        }
        if(inputState.right){
            x = x+1;
            restart = true;
        }
    
        if(restart){
        stopMusic();
            setSample(0,100,[{
                sn:100,
                sv:0,
                sqn:100,
                sqv:0,
                nv:x,
                tn:100,
                tv:0
            }
            ]);
        playMusic(0);
        restart = false;
        }
});

// setMain(()=>{

//     var inputState = getGamepadState(0);
//     var restart = true;
//     if(inputState.left){
//         x = x-1;
//         restart = true;
//     }
//     if(inputState.right){
//         x = x+1;
//         restart = true;
//     }

//     if(restart){
//     stopMusic();
//         setSample(0,100,[{
//             sn:100,
//             sv:0,
//             sqn:100,
//             sqv:0,
//             nv:x,
//             tn:100,
//             tv:0
//         }
//         ]);
//     playMusic(0);
//     restart = false;
//     }


// });

