using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlanOnImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyPlane>())
        {
            GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
            Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyPlane>())
        {
            GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
            Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
            Destroy(collision.gameObject);
        }
    }
}
