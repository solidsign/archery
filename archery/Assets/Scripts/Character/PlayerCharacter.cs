using Archery.Character.StateMachine;
using UnityEngine;

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

        public void DrawAdmGui()
        {
            GUI.skin.label.fontSize = 24;
            
            GUILayout.BeginArea(new Rect(Vector2.zero, Vector2.one * 500f), GUI.skin.box);

            GUILayout.BeginVertical();
            
            GUILayout.Label("Movement FSM");
            GUILayout.Label($"State: {MovementStateMachine.CurrentState.GetType().Name}");
            GUILayout.Space(25f);
            GUILayout.Label("Inputs");
            GUILayout.Label($"Forward: {Components.Input.NormalizedForwardMovement}");
            GUILayout.Label($"Right: {Components.Input.NormalizedRightMovement}");
            GUILayout.Label($"Norm Move Direction: {Components.GetNormalizedInputMoveDirection()}");
            GUILayout.Space(25f);
            GUILayout.Label($"Properties");
            GUILayout.Label($"Velocity: {Components.Properties.Velocity.Value}");
            GUILayout.Label($"Position: {Components.Properties.Position.Value}");
            
            GUILayout.EndVertical();
            
            GUILayout.EndArea();
        }
    }
}