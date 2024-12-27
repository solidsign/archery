using MyLibs.Movement;

namespace Game.Libraries.App.Character
{
    public class PlayerCharacter
    {
        public PlayerComponentsHolder Components { get; }
        public IMovementStateMachine MovementStateMachine { get; }

        public PlayerCharacter(PlayerComponentsHolder components, IMovementStateMachine movementStateMachine)
        {
            Components = components;
            MovementStateMachine = movementStateMachine;
        }
        
        public void Update()
        {
            Components.Input.Update();
            Components.Collisions.Update();
            MovementStateMachine.Update();
            Components.Movement.Jobs.Update();
            Components.Properties.Update();
        }
    }
}