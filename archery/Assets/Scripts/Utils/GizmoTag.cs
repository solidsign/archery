using UnityEditor;
using UnityEngine;

namespace Archery.Utils
{
    public class GizmoTag : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private bool _drawAlways = true;
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private Vector3 _textOffset;
        [SerializeField] private Vector3 _sphereOffset;
        [SerializeField] private Color _sphereColor = Color.red;
        
        private void OnDrawGizmos()
        {
            if (_drawAlways)
            {
                Draw();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Draw();
        }

        private void Draw()
        {
            Gizmos.color = _sphereColor;
            Gizmos.DrawWireSphere(transform.position + _sphereOffset, _radius);
            Handles.Label(transform.position + _textOffset, _tag);
        }
    }
}