using UnityEngine;

public class DragToMove : MonoBehaviour
{
    public float speed = 10.0f;
    public float acceleration = 5.0f;
    public float deceleration = 10.0f;

    private Rigidbody2D rb;
    private float dragStartY;
    private float targetYVelocity;
    private float currentYVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                dragStartY = touch.position.y;
                targetYVelocity = 0.0f;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float dragEndY = touch.position.y;
                float dragDistance = dragEndY - dragStartY;

                targetYVelocity = Mathf.Clamp(dragDistance * speed, -speed, speed);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                targetYVelocity = 0.0f;
            }

            currentYVelocity = Mathf.MoveTowards(currentYVelocity, targetYVelocity, Time.deltaTime * (currentYVelocity > targetYVelocity ? deceleration : acceleration));
            rb.MovePosition(rb.position + Vector2.up * currentYVelocity * Time.deltaTime);
        }
    }
}