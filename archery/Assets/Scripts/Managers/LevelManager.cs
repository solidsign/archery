using Archery.Character;
using Archery.Core;
using UnityEngine;

namespace Archery.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterBehaviour _player;
        
        private Services _services;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _services = new Services();
        }

        private void Start()
        {
            _player.Initialize(_services);
        }
    }
}