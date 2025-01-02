using System;
using UnityEngine;

namespace Archery.Character.Behaviours
{
    [Serializable]
    public class PlayerReferences
    {
        [field: SerializeField] public Transform LookCameraTransform { get; private set; }
        [field: SerializeField] public Transform MainTransform { get; private set; }
        [field: SerializeField] public CharacterConfig Config { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
    }
}