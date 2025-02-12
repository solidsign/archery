using UnityEngine;

namespace Archery.Character
{
    [CreateAssetMenu(fileName = "characterConfig", menuName = "Configs/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [field: Header("Stand")]
        [field: SerializeField] public float MaxStandAngle { get; private set; }
        [field: SerializeField] public float StickToGroundSpeed { get; private set; }
        
        [field: Header("Slide")]
        [field: SerializeField] public float MinSlideAngle { get; private set; }
        [field: SerializeField] public float MaxSlideAngle { get; private set; }
        [field: SerializeField] public float MinSlideVelocity { get; private set; }
        [field: SerializeField] public AnimationCurve SlideBoostCoefCurve { get; private set; }
        [field: SerializeField] public float MaxSlideBoostTime { get; private set; }
        [field: SerializeField] public float MinSlideBoostVelocity { get; private set; }

        [field: Header("Run")]
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float CrouchSpeed { get; private set; }
        
        [field: Header("Jump")]
        [field: SerializeField] public AnimationCurve JumpCurve { get; private set; }
        [field: SerializeField] public float MaxJumpHeight { get; private set; }
        [field: SerializeField] public float MaxJumpTime { get; private set; }
        [field: SerializeField] public float MinJumpTime { get; private set; }
        [field: SerializeField] public float MaxJumpSurfaceAngle { get; private set; }
        [field: SerializeField] public float MaxStopJumpHitSurfaceAngle { get; private set; }
        [field: SerializeField] public float MinStopJumpHitSurfaceAngle { get; private set; }
        [field: SerializeField] public float CoyoteTime { get; private set; }
        
        [field: Header("InAir")]
        [field: SerializeField] public AnimationCurve FallingVelocityCurve { get; private set; }
        [field: SerializeField] public float MaxFallingTime { get; private set; }
        [field: SerializeField] public float MaxFallingVelocity { get; private set; }
        [field: SerializeField] public float InAirControlAcceleration { get; private set; }
        
        [field: Header("Dash")]
        [field: SerializeField] public AnimationCurve DashCurve { get; private set; }
        [field: SerializeField] public float MaxDashTime { get; private set; }
        [field: SerializeField] public float MaxDashLength { get; private set; }
        [field: SerializeField] public float DashCooldown { get; private set; }
        
        [field: Header("Horizontal wall run")]
        [field: SerializeField] public float MaxHorizontalWallRunSurfaceAngle { get; private set; }
        [field: SerializeField] public float MinHorizontalWallRunSurfaceAngle { get; private set; }
        [field: SerializeField] public float MinProjectionVelocityForHorizontalWallRun { get; private set; }
        [field: SerializeField] public float MinForwardMovementForWallRun { get; private set; } = 0.8f;
        [field: SerializeField] public float MinLookDirectionForHorizontalWallRun { get; private set; }
        [field: SerializeField] public float HorizontalWallRunSpeed { get; private set; }
        [field: SerializeField] public float HorizontalWallRunGripSpeed { get; private set; }
        [field: SerializeField] public AnimationCurve HorizontalWallFallingVelocityCurve { get; private set; }
        [field: SerializeField] public float MaxHorizontalWallFallingTime { get; private set; }
        [field: SerializeField] public float MaxHorizontalWallFallingVelocity { get; private set; }
        
        [field: Header("Wall jump")]
        [field: SerializeField] public float MaxWallJumpSurfaceAngle { get; private set; }
        [field: SerializeField] public float MinWallJumpSurfaceAngle { get; private set; }
        [field: SerializeField] public AnimationCurve HorizontalWallJumpCurve { get; private set; }
        [field: SerializeField] public float MaxHorizontalWallJumpHeight { get; private set; }
        [field: SerializeField] public float MaxHorizontalWallJumpTime { get; private set; }
        [field: SerializeField] public float MinHorizontalWallJumpTime { get; private set; }
        [field: SerializeField] public AnimationCurve VerticalWallJumpCurve { get; private set; }
        [field: SerializeField] public float MaxVerticalWallJumpHeight { get; private set; }
        [field: SerializeField] public float MaxVerticalWallJumpTime { get; private set; }
        [field: SerializeField] public float MinVerticalWallJumpTime { get; private set; }
    }
}