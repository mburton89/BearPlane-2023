using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPilotOnImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyPlane>())
        {
            collision.GetComponent<EnemyPlane>().LaunchPilot(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyPlane>())
        {
            collision.gameObject.GetComponent<EnemyPlane>().LaunchPilot();
        }
    }
}
