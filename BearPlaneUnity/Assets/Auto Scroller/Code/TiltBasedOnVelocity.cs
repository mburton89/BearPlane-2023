using UnityEngine;

public class TiltBasedOnVelocity : MonoBehaviour
{
    Rigidbody2D rb; // The rigidbody we want to base the tilt on
    [SerializeField] private float tiltSpeed = 10f; // The speed at which the object should tilt
    [SerializeField] private float maxTiltAngle = 45f; // The maximum angle the object can tilt

    private float initialRotationZ; // The initial z rotation of the object

    private void Awake()
    {
        initialRotationZ = transform.rotation.eulerAngles.z;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float tiltAmount = rb.velocity.y * tiltSpeed * Time.deltaTime;
        float newRotationZ = Mathf.Clamp(initialRotationZ + tiltAmount, initialRotationZ - maxTiltAngle, initialRotationZ + maxTiltAngle);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotationZ);
    }
}