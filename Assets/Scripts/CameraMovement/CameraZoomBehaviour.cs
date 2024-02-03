using System;
using UnityEngine;

namespace CameraMovement
{
    public class CameraZoomBehaviour : MonoBehaviour
    {
        [SerializeField] private int scrollSensitivity = 50;
        [SerializeField] private int minZoom = 1, maxZoom = 10;
        
        private void Update()
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                Camera.main.orthographicSize += scrollSensitivity * Time.deltaTime;
            }
            if (Input.mouseScrollDelta.y > 0)
            {
                Camera.main.orthographicSize -= scrollSensitivity * Time.deltaTime;
            }

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
        }
    }
}