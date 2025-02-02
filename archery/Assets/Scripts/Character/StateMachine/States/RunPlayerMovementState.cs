using Archery.Character.Animation;
using Archery.Character.Collisions;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class RunPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Run);
        }

        public override void Update()
        {
            base.Update();

            var collision = Components.Collisions.GetCurrentMainStickyCollision();

            if (collision.HasValue is false)
            {
                collision = new SurfaceCollision(MathConstants.WorldGroundNormal, default, default, default);
                Debug.LogError($"Main collision was null with active Run state");
            }

            var moveDirection = Components.GetNormalizedInputMoveDirectionOnCurrentGround(collision.Value);
            var velocity = moveDirection * Components.Config.RunSpeed;
            var moveDelta = velocity * Components.Services.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}