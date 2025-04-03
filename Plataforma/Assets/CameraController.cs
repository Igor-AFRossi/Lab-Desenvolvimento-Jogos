using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        if (target != null)
        {
            Vector3 startPosition = target.position + offset;
            startPosition.x = Mathf.Clamp(startPosition.x, minPosition.x, maxPosition.x);
            startPosition.y = Mathf.Clamp(startPosition.y, minPosition.y, maxPosition.y);
            transform.position = startPosition;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            smoothedPosition.z = transform.position.z;

            transform.position = smoothedPosition;
        }
    }
}