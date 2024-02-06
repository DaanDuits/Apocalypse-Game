using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Input = UnityEngine.Input;

namespace CameraMovement
{
    public class CameraMovement : MonoBehaviour
    {
        private bool _isDragging;
        
        private Vector3 _dragOrigin;
        private Vector3 _difference;

        private Vector3 MouseWorldPos => Camera.main.ScreenToWorldPoint(Input.mousePosition);
        private Vector3 _mouseOrigin;
        private Vector3 _mouseDifference;

        private void Update()
        {
            if (Input.GetMouseButton(2))
            {
                _difference =  MouseWorldPos - transform.position;
                
                if (!_isDragging)
                {
                    _isDragging = true;
                    _dragOrigin = MouseWorldPos;
                    _mouseOrigin = Input.mousePosition;
                }
                
                _mouseDifference = Input.mousePosition - _mouseOrigin;
            }
            else if (Input.GetMouseButtonUp(2))
            {
                _isDragging = false;
            }

            if (_isDragging && _mouseDifference != Vector3.zero)
            {
                transform.position = _dragOrigin - _difference;
            }
        }
    }
}