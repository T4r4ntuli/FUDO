namespace Fudo.Enums
{
    public enum Event { Test }

    public enum ComponentType
    {
        Position,
        Scale,
        Direction,
        Rotation,
        MaxSpeed,
        IsVisible,
        Controllable,
        Movement,
        PreviousFrameMovement,
        BufferedInputs,
        InputToMovement,
        Count
    }

    public enum Key { Up, Down, Left, Right}

    public enum KeyState { Down, Up, Hold }
}