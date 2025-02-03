using UnityEngine;

namespace Archery.Utils
{
    public class MaxFps : MonoBehaviour
    {
        [SerializeField] private int _targetFps;

        private void Update()
        {
            Application.targetFrameRate = _targetFps;
        }
    }
}