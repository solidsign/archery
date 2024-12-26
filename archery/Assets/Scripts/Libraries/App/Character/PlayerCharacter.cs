using System;
using MyLibs.Core;
using MyLibs.Movement;

namespace Game.Libraries.App.Character
{
    public class PlayerCharacter : IUpdatable
    {
        public App App { get; }
        public PlayerComponentsHolder Components { get; }
        public IMovementStateMachine MovementStateMachine { get; }

        public PlayerCharacter(App app, PlayerComponentsHolder components, IMovementStateMachine movementStateMachine)
        {
            App = app;
            Components = components;
            MovementStateMachine = movementStateMachine;
        }
        
        public void Update()
        {
            
        }
    }
}