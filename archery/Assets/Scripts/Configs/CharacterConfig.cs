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
        [field: SerializeField] public float MinSlideVelocity { get; set; }
        [field: SerializeField] public AnimationCurve SlideBoostCoefCurve { get; set; }
        [field: SerializeField] public float MaxSlideBoostTime { get; set; }
        
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
    }
}