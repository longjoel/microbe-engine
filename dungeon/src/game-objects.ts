export enum Direction {
    North,
    South,
    East,
    West
}

export interface Item{
name:string;
}

/**
 * Represents an instance of an item on the playfield.
 */
export interface ItemInstance{
    itemName:string;
    x:number;
    y:number;
    onCollect:()=>void;
}

/** Represents a player on the playfield. */
export interface Player {
    x:number;
    y:number;
    inventory:Item[];
}

/** Represents a room */
export interface Room {
    roomId:string;                      // room id, used to look up different rooms
    exits:Record<Direction,string>[];   // exit, if a room has an exit
    items:ItemInstance[];               // items placed into room
    render:(x:number,y:number)=>void;   // render the room to vram, starting from the upper left.
}

export interface GameState {
    rooms:Record<string,Room>[]
    currentRoom:Room;
    player:Player;
}