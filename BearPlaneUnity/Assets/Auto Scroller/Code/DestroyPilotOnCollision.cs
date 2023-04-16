using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPilotOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Pilot>())
        {
            collision.gameObject.GetComponent<Pilot>().Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pilot>())
        {
            collision.gameObject.GetComponent<Pilot>().Explode();
        }
    }
}
