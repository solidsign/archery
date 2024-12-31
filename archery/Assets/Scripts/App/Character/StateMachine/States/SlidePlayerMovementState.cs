using App.Character.Movement.StateMachine;
using UnityEngine;

namespace App.Character
{
    public class SlidePlayerMovementState : PlayerMovementState
    {
        private SurfaceCollision _slideSurface;

        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Slide);
            _slideSurface = Components.Collisions.GetCurrentMainStickyCollision().Value;
        }

        public override void Update()
        {
            base.Update();
            
            var slideSurface = Components.Collisions.GetCurrentMainStickyCollision();
            if (slideSurface.HasValue) _slideSurface = slideSurface.Value;
            var slideVelocity = Vector3.ProjectOnPlane(Components.Properties.Velocity, _slideSurface.SurfaceNormal) * _slideSurface.SlideAccelerationCoef;
            
            Components.Movement.Move(slideVelocity * Components.App.Time.DeltaTime);
        }
    }
}