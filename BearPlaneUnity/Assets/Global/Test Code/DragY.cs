using UnityEngine;

public class DragY : MonoBehaviour
{
    private Rigidbody2D rb; // The object's Rigidbody2D component
    private Vector2 touchOffset; // The offset between the touch position and the object's position

    void Start()
    {
        // Get the object's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0) // Check if there is any touch input
        {
            Touch touch = Input.GetTouch(0); // Get the first touch input

            if (touch.phase == TouchPhase.Began) // Check if the touch input just started
            {
                // Calculate the offset between the touch position and the object's position
                Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                touchOffset = new Vector2(0f, touchWorldPosition.y - rb.position.y);
            }
            else if (touch.phase == TouchPhase.Moved) // Check if the touch input is being moved
            {
                // Move the object along the Y-axis based on the touch position and the offset
                Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                Vector2 targetPosition = new Vector2(rb.position.x, touchWorldPosition.y - touchOffset.y);
                rb.MovePosition(targetPosition);
            }
        }
    }
}