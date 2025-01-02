using UnityEngine;

namespace Archery.Character
{
    public interface IMovementInputController
    {
        Vector3 NormalizedLookDirection { get; }
        float NormalizedForwardMovement { get; }
        float NormalizedRightMovement { get; }
        KeyState Jump { get; }
        KeyState Slide { get; }
    }
}