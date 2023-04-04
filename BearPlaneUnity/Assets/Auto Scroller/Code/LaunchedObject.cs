using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchedObject : MonoBehaviour
{
    Rigidbody2D rb;
    public float dragMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        rb.drag += dragMultiplier;
    }
}
