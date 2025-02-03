using UnityEngine;

namespace Archery.Utils
{
    public class MouseHider : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}