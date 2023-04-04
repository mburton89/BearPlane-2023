using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private bool isShaking = false;
    private float shakeDuration = 0.1f;
    private float shakeMagnitude = 0.1f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        if (isShaking)
        {
            Vector3 shakePosition = Random.insideUnitSphere * shakeMagnitude;
            transform.position += shakePosition;
        }
    }

    public void ShakeScreen(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        isShaking = true;
        Invoke("StopShaking", duration);
    }

    private void StopShaking()
    {
        isShaking = false;
    }
}