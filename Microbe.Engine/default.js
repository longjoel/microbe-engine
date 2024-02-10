setString(0, 0, "microbe-engine");

setMain((dt) => {

    if (getGamepadState().a) {
        setString(10, 10, 'a');
    } else {
        setString(10,10,'.')
    }
});