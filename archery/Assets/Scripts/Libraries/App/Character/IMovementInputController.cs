using UnityEngine;

namespace Game.Libraries.App.Character
{
    public interface IMovementInputController
    {
        Vector2 NormalizedMovement { get; }
        KeyState Jump { get; }
        KeyState Slide { get; }
    }
}