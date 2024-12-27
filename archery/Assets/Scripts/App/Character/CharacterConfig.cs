using UnityEngine;

namespace Game.Libraries.App.Character
{
    [CreateAssetMenu(fileName = "characterConfig", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Stand")]
        [field: SerializeField] public float MaxStandAngle { get; private set; }
        
        [Header("Run")]
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float CrouchSpeed { get; private set; }
        
        [Header("Jump")]
        [field: SerializeField] public AnimationCurve JumpCurve { get; private set; }
        [field: SerializeField] public float MaxJumpHeight { get; private set; }
        [field: SerializeField] public float MaxJumpTime { get; private set; }
        [field: SerializeField] public float MinJumpTime { get; private set; }
        
        [Header("InAir")]
        [field: SerializeField] public AnimationCurve FallingVelocityCurve { get; private set; }
        [field: SerializeField] public float MaxFallingTime { get; private set; }
        [field: SerializeField] public float MaxFallingVelocity { get; private set; }
        [field: SerializeField] public float InAirRunSpeed { get; private set; }
    }
}