namespace Archery.Character.Input
{
    public struct KeyState
    {
        public bool IsPressed { get; }
        public bool IsDown { get; }
        public bool IsUp { get; }

        public KeyState(bool isPressed, bool isDown, bool isUp)
        {
            IsPressed = isPressed;
            IsDown = isDown;
            IsUp = isUp;
        }
    }
}