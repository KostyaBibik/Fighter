using UnityEngine;

namespace Core
{
    public class SmoothCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;         
        [SerializeField] private Vector3 offset = new(0, 1, -10);
        [SerializeField] private float smoothSpeed = 5f;    

        private void LateUpdate()
        {
            if (target == null) 
                return;

            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
        }
    }
}