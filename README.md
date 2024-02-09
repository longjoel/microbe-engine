# microbe-engine

## About

`microbe-engine` is a minimalistic approach to building gameboy and gameboy color style games using Javascript / typescript. This is a code first engine, meaning graphics, actions, sounds, sound effects can be expressed as code.

This engine uses WinForms for graphics and event handling, JInt as the Javascript engine, and XInputium for connecting with gamepads.

## Constraints

`microbe-engine` supports 256 tiles, with a vram area that supports 32 x 32 tiles. The framebuffer is 160x144 pixels, or 20x18 tiles.

Each tile has it's own palette of 3 colors, plus 0 being the transparent color.

This is easy enough to modify in `MicrobeGrahics.cs` If your particular situation requires more fidelity.

On the audio side of things, `microbe-engine` supports 256 audio samples. A sample can be generated using an interval (how long each line of the sample should be played), and a list of sample segments. Each sample segment looks like this.

```
{
    // sine wave instrument
    sn:"C4",    // note
    sv:.5       // volume
    
    // triangle wave instrument
    tn:"C4",    // note
    tv:.25,     // volume
    
    // square wave instrument
    sqn:"C4",   // note
    sqv:.55,    // volume

    // noise instrument
    nv:0        // volume  
}
```

The virtual gamepad supports Up, Down, Left, Right, A, B, Start, and Select.

This can either be done with a real xinput compatable gamepad or with a keyboard where the arrow keys represent up, down, left, and right, z and x are mapped to A and B, Escape is select, and Enter is Right.

At some point, it will be possible to read and save data as JSON objects.