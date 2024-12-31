using System;
using UnityEngine;

namespace Archery.Character
{
    [Serializable]
    public class PlayerReferences
    {
        [field: SerializeField] public Transform LookCameraTransform { get; private set; }
    }
}