using Archery.Character.StateMachine;
using Archery.Character.StateMachine.States;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character
{
    public class PlayerCharacter
    {
        private PlayerComponentsHolder Components { get; }
        private IMovementStateMachine MovementStateMachine { get; }

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
            GUILayout.Label($"State: {MovementStateMachine.CurrentState.GetType().Name.Replace("PlayerMovementState", "")}");
            GUILayout.Space(25f);
            GUILayout.Label("Inputs");
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label($"Forward: {Components.Input.NormalizedForwardMovement}");
            GUILayout.Label($"Right: {Components.Input.NormalizedRightMovement}");
            GUILayout.Label($"Norm Move Direction: {Components.GetNormalizedInputMoveDirectionWorld()}");
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label($"Jump: isPressed: {Components.Input.Jump.IsPressed.ToShort()}, isDown: {Components.Input.Jump.IsDown.ToShort()}, isUp: {Components.Input.Jump.IsUp.ToShort()}");
            GUILayout.Label($"Slide: isPressed: {Components.Input.Slide.IsPressed.ToShort()}, isDown: {Components.Input.Slide.IsDown.ToShort()}, isUp: {Components.Input.Slide.IsUp.ToShort()}");
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.Space(25f);
            GUILayout.Label($"Properties");
            GUILayout.Label($"Velocity: {Components.Properties.Velocity.Value}");
            GUILayout.Label($"VelocityH: {Components.Properties.Velocity.Value.ProjectOnWorldGround().magnitude}");
            GUILayout.Label($"VelocityV: {Components.Properties.Velocity.Value.ProjectOnWorldUp().magnitude}");
            GUILayout.Label($"Position: {Components.Properties.Position.Value}");
            GUILayout.Space(25f);
            GUILayout.Label($"Collisions");
            GUILayout.Label($"Collisions count: {Components.Collisions.GetCollisions().Count}");
            GUILayout.Label("Current Main Sticky: " + Components.Collisions.GetCurrentMainStickyCollision());
            if (Components.Collisions.GetCurrentMainStickyCollision().HasValue)
            {
                GUILayout.Label("Current Main Sticky Ground Angle: " + Components.Collisions.GetCurrentMainStickyCollision().Value.SurfaceNormal.GetAngleWithWorldGround());
            }
            GUILayout.Space(25f);
            GUILayout.Label($"Jobs");
            GUILayout.Label($"Jump job: {Components.Movement.Jobs.HasJob<JumpPlayerMovementState.Job>().ToShort()}");

            GUILayout.EndVertical();
            
            GUILayout.EndArea();
        }
    }
}