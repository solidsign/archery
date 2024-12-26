using MyLibs.Movement;
using UnityEngine;

namespace Game.Libraries.App.Character
{
    public class PlayerComponentsHolder : IPlayerComponentsHolder
    {
        public IPhysicalObjectProperties Properties { get; }
        public IInputController Input { get; }
        public IMovementController Movement { get; }
        public IPlayerCharacterAnimationController Animation { get; }
        public ICollisionsProvider Collisions { get; }
        public CharacterConfig Config { get; }
    }
}