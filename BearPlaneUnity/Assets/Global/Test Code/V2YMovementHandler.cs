using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2YMovementHandler : MonoBehaviour
{
    private float _previousYTouchPosition;
    private float _currentYTouchPosition;

    [SerializeField] private float acceleration;
    [SerializeField] private float maxForce;
    [SerializeField] private float deadZone;

    private Rigidbody2D rb; // The object's Rigidbody2D component

    private void Start()
    {
        // Get the object's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0) // Check if there is any touch input
        {
            Touch touch = Input.GetTouch(0); // Get the first touch input

            if (touch.phase == TouchPhase.Ended)
            {
                _previousYTouchPosition = 0;
                _currentYTouchPosition = 0;
            }
            else
            {
                _previousYTouchPosition = _currentYTouchPosition;
                _currentYTouchPosition = touch.position.y;

                float newYForce = _currentYTouchPosition - _previousYTouchPosition;

                if (Mathf.Abs(newYForce) < deadZone)
                {
                    newYForce = 0;
                }
                else if (newYForce > maxForce)
                {
                    newYForce = maxForce;
                }
                else if (newYForce < -maxForce)
                {
                    newYForce = -maxForce;
                }

                rb.AddForce(new Vector2(0, newYForce * acceleration));
            }
        }
    }
}