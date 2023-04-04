using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float acceleration = 5.0f;
    public float deceleration = 10.0f;

    private Rigidbody rb;
    private float targetYVelocity;
    private float currentYVelocity;
    private float dragStartY;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            dragStartY = Input.mousePosition.y;
            targetYVelocity = 0.0f;
        }
        else if (Input.GetMouseButton(0))
        {
            float dragEndY = Input.mousePosition.y;
            float dragDistance = dragEndY - dragStartY;

            targetYVelocity = Mathf.Clamp(dragDistance * speed, -speed, speed);
        }
        else
        {
            targetYVelocity = 0.0f;
        }

        currentYVelocity = Mathf.MoveTowards(currentYVelocity, targetYVelocity, Time.deltaTime * (currentYVelocity > targetYVelocity ? deceleration : acceleration));
        Vector3 movement = transform.up * currentYVelocity * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        Quaternion turn = Quaternion.Euler(0.0f, horizontal * rotationSpeed * Time.deltaTime, 0.0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}