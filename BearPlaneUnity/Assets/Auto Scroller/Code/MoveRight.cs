using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed; // The speed at which the object moves to the right

    private Rigidbody2D rb; // The object's Rigidbody2D component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}