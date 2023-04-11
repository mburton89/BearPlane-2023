using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlaneOnImpact : MonoBehaviour
{
    [HideInInspector] public GameObject ownedPlane;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyPlane>() && collision.gameObject != ownedPlane)
        {
            collision.GetComponent<EnemyPlane>().Explode();
        }

        if (collision.GetComponent<Pilot>())
        {
            collision.GetComponent<Pilot>().Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyPlane>() && collision.gameObject != ownedPlane)
        {
            collision.gameObject.GetComponent<EnemyPlane>().Explode();
        }

        if (collision.gameObject.GetComponent<Pilot>())
        {
            collision.gameObject.GetComponent<Pilot>().Explode();
        }
    }
}
