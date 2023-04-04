using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovementHandler : MonoBehaviour
{
    private float _previousYTouchPosition;
    private float _currentYTouchPosition;

    [SerializeField] float acceleration;
    [SerializeField] float maxForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleTouchInput();
        HandleKeyboardInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0) // Check if there is any touch input
        {
            Touch touch = Input.GetTouch(0); // Get the first touch input

            _previousYTouchPosition = _currentYTouchPosition;
            _currentYTouchPosition = touch.position.y;

            float newYForce = _currentYTouchPosition - _previousYTouchPosition;

            rb.AddForce(new Vector2(0, newYForce * acceleration));

            if (_previousYTouchPosition != 0)
            {
                rb.AddForce(new Vector2(0, newYForce * acceleration));
            }
        }
        else
        {
            _previousYTouchPosition = 0;
            _currentYTouchPosition = 0;
        }
    }

    void HandleKeyboardInput()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput != 0)
        {
            float velocity = verticalInput * acceleration;
            rb.AddForce(Vector2.up * velocity);
        }
    }
}
