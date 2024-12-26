using UnityEngine;

namespace Game.Libraries.App.Character
{
    [CreateAssetMenu(fileName = "characterConfig", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public float RunSpeed { get; private set; }
    }
}