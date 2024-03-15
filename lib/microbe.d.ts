/**
 * Represents a sprite in the game.
 */
declare interface Sprite {
    x: number;
    y: number;
    tileIndex: number;
    visible: boolean;
    xFlipped: boolean;
    yFlipped: boolean;
    background: boolean;
}

/**
 * Represents an RGB color.
 */
declare interface RGB {
    r: number;
    g: number;
    b: number;
}

/**
 * Represents a tile palette.
 */
declare interface TilePalette {
    c1: RGB;
    c2: RGB;
    c3: RGB;
}

/**
 * Represents the state of a gamepad.
 */
declare interface GamepadState {
    up: boolean;
    down: boolean;
    left: boolean;
    right: boolean;
    a: boolean;
    b: boolean;
    start: boolean;
    select: boolean;
}

/**
 * Represents a segment of a sample.
 */
declare interface SampleSegment {
    sn: string;
    sv: number;
    tn: string;
    tv: number;
    sqn: string;
    sqv: number;
    nv: number;
}

/**
 * The main callback function.
 * @param dt - The time difference since the last frame.
 */
declare type cbMain = (dt: number) => void;

/**
 * Sets the tile data at the specified index.
 * @param index - The index of the tile.
 * @param data - The tile data.
 */
declare function setTile(index: number, data: number[]): void;

/**
 * Sets the VRAM data at the specified position.
 * @param x - The x-coordinate of the position.
 * @param y - The y-coordinate of the position.
 * @param index - The index of the VRAM data.
 */
declare function setVram(x: number, y: number, index: number): void;

/**
 * Sets the scroll position.
 * @param x - The x-coordinate of the scroll position.
 * @param y - The y-coordinate of the scroll position.
 */
declare function setScroll(x: number, y: number): void;

/**
 * Sets the sprite at the specified index.
 * @param index - The index of the sprite.
 * @param sprite - The sprite data.
 */
declare function setSprite(index: number, sprite: Sprite): void;

/**
 * Gets the sprite at the specified index.
 * @param index - The index of the sprite.
 * @returns The sprite data.
 */
declare function getSprite(index: number): Sprite;

/**
 * Gets the palette at the specified index.
 * @param index - The index of the palette.
 * @returns The palette data.
 */
declare function getPalette(index: number): TilePalette;

/**
 * Sets the palette at the specified index.
 * @param index - The index of the palette.
 * @param palette - The palette data.
 */
declare function setPalette(index: number, palette: TilePalette): void;

/**
 * Sets the string at the specified position.
 * @param x - The x-coordinate of the position.
 * @param y - The y-coordinate of the position.
 * @param text - The string to set.
 */
declare function setString(x: number, y: number, text: string): void;

/**
 * Sets the character at the specified position.
 * @param x - The x-coordinate of the position.
 * @param y - The y-coordinate of the position.
 * @param c - The character to set.
 */
declare function setChar(x: number, y: number, c: string): void;

/**
 * Sets the text color.
 * @param color - The color to set.
 */
declare function setTextColor(color: RGB): void;

/**
 * Sets the tile palette for a specific tile.
 * @param tileIndex - The index of the tile.
 * @param paletteIndex - The index of the palette.
 */
declare function setTilePalette(tileIndex: number, paletteIndex: number): void;

/**
 * Sets the main callback function.
 * @param cbMain - The main callback function.
 */
declare function setMain(cbMain: cbMain): void;

/**
 * Gets the state of the gamepad.
 * @returns The gamepad state.
 */
declare function getGamepadState(): GamepadState;

/**
 * Sets the sample data at the specified index.
 * @param index - The index of the sample.
 * @param intervalMS - The interval in milliseconds.
 * @param sample - The sample data.
 */
declare function setSample(index: number, intervalMS: number, sample: SampleSegment[]): void;

/**
 * Plays the music at the specified index.
 * @param index - The index of the music.
 */
declare function playMusic(index: number): void;

/**
 * Plays the effect at the specified index.
 * @param index - The index of the effect.
 */
declare function playEffect(index: number): void;

/**
 * Stops the currently playing music.
 */
declare function stopMusic(): void;

/**
 * set raw data for the sample.
 */
declare function setSampleRaw(index: number, data: Uint8Array): void;

/**
 * load graphics from a file.
 */
declare function loadGfx(fileName: string): void;

/** 
 * load samples from a file.
 * */
declare function loadSamples(fileName: string): void;