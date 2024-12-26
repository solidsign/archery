using MyLibs.Movement;

namespace Game.Libraries.App.Character
{
    public class PlayerComponentsHolder : IPlayerComponentsHolder
    {
        public IVelocityHolder Velocity { get; }
        public IInputController Input { get; }
        public IMovementController MovementController { get; }
        public IPlayerCharacterAnimationController Animation { get; }
        public ICollisionsProvider Collisions { get; }
    }
}