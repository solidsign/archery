using Archery.Character.Movement.StateMachine;

namespace Archery.Character
{
    public class InertialRunPlayerMovementState : PlayerMovementState
    {
        private SurfaceCollision _surface;

        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.InertialRun);
            _surface = Components.Collisions.GetCurrentMainStickyCollision().Value;
        }
        
        public override void Update()
        {
            base.Update();
            
            var surface = Components.Collisions.GetCurrentMainStickyCollision();
            if (surface.HasValue) _surface = surface.Value;
            var moveDirection = Components.GetNormalizedInputMoveDirection(_surface.SurfaceNormal);
            var velocity = moveDirection * Components.Config.CrouchSpeed;
            var moveDelta = velocity * Components.Services.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}