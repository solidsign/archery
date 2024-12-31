using System;
using Archery.Core;
using UnityEngine;

namespace Archery.Character
{
    [Serializable]
    public class PlayerReferences
    {
        [field: SerializeField] public Transform LookCameraTransform { get; private set; }
    }

    public class PlayerCharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerReferences _references;

        private PlayerCharacter _playerCharacter;

        private void Awake()
        {
            enabled = false;
        }

        public void Initialize(Services services)
        {
            _playerCharacter = new PlayerCharacterBuilder(_references, services).Build();
            enabled = true;
        }

        private void Update()
        {
            _playerCharacter.Update();
        }
    }
}