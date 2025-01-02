using Archery.Character.StateMachine;

namespace Archery.Character
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
            // read player input and world around
            Components.Input.Update();
            
            // plan movement
            MovementStateMachine.Update();
            Components.Movement.Jobs.Update();
            
            // apply movement
            Components.Movement.Apply();
            
            // check up properties updates
            Components.Properties.Update();
            
            // clean up after update
            Components.Collisions.Clear();
        }
    }
}