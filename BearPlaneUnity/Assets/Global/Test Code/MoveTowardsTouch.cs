using UnityEngine;

public class MoveTowardsTouch : MonoBehaviour
{
    public float speed = 5f; // The speed at which the object moves

    private Rigidbody2D rb; // The object's Rigidbody2D component
    private Vector2 targetPosition; // The position of the touch input

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
                // Convert the touch position to world coordinates
                Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                targetPosition = new Vector2(transform.position.x, targetWorldPosition.y); // Set the target position on the Y-axis
            }
        }

        // Move towards the target position over time using the Rigidbody2D component
        Vector2 currentPosition = rb.position;
        rb.MovePosition(Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime));
    }
}