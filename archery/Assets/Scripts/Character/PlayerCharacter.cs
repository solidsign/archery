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
            
            // clean up after update
            Components.Collisions.Clear();
            
            // apply movement
            Components.Movement.Apply();
            
            // check up properties updates
            Components.Properties.Update();
        }

        public void DrawAdmGui()
        {
            GUI.skin.label.fontSize = 18;
            
            GUILayout.BeginArea(new Rect(Vector2.zero, Vector2.one * 800f), GUI.skin.box);

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
            GUILayout.Space(25f);
            GUILayout.Label($"Collisions");
            GUILayout.Label($"Collisions count: {Components.Collisions.GetCollisions().Count}");
            GUILayout.Label("Current Main Sticky: " + Components.Collisions.GetCurrentMainStickyCollision());

            GUILayout.EndVertical();
            
            GUILayout.EndArea();
        }
    }
}