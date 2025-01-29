using UnityEngine;

namespace Archery.Utils
{
    public class TimeScale : MonoBehaviour
    {
        [SerializeField] private float _timeScale;

        private void Update()
        {
            Time.timeScale = _timeScale;
        }
    }
}