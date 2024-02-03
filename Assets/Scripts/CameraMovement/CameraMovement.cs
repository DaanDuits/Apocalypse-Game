using UnityEngine;
using UnityEngine.Serialization;
using Input = UnityEngine.Input;

namespace CameraMovement
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] [Range(0.2f, 2f)] private float moveSpeed = 1;
        
        private Vector3 _dragOrigin;
        private bool _isDragging;
        private Vector3 _difference;

        private void Update()
        {
            if (Input.GetMouseButton(2))
            {
                _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

                if (!_isDragging)
                {
                    _isDragging = true;
                    _dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                _isDragging = false;
            }

            if (_isDragging)
            {
                transform.position = _dragOrigin - _difference * moveSpeed;
                
            }
            
        }
    }
}