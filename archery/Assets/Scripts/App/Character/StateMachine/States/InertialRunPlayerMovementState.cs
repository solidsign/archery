using Game.Libraries.App.Character.Movement.StateMachine;

namespace Game.Libraries.App.Character
{
    public class InertialRunPlayerMovementState : PlayerMovementState
    {
        private SurfaceCollision _surface;

        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.InertialRun);
            _surface = Components.Collisions.GetCurrentMainCollision().Value;
        }
        
        public override void Update()
        {
            base.Update();
            
            var surface = Components.Collisions.GetCurrentMainCollision();
            if (surface.HasValue) _surface = surface.Value;
            var moveDirection = Components.GetNormalizedInputMoveDirection(_surface.SurfaceNormal);
            var velocity = moveDirection * Components.Config.CrouchSpeed;
            var moveDelta = velocity * Components.App.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}