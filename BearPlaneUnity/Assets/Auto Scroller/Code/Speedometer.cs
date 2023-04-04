using UnityEngine;

public class Speedometer : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float speedInMps = rb.velocity.magnitude;
        float speedInMph = speedInMps * 2.23694f;
        Debug.Log($"Speed in mph: {speedInMph}");
    }
}