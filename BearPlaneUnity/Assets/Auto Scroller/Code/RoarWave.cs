using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarWave : MonoBehaviour
{
    public float velocityMultiplier;
    public float torqueMultiplier;
    Rigidbody2D rb;

    public List<GameObject> collidedGameObjects;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collidedGameObjects.Contains(collision.gameObject)) return;

        collidedGameObjects.Add(collision.gameObject);

        if (collision.GetComponent<EnemyPlane>())
        {
            collision.GetComponent<EnemyPlane>().EjectPilot();
            collision.GetComponent<Rigidbody2D>().drag = 0.5f;
        }

        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            if (collision.gameObject.GetComponent<TiltBasedOnVelocity>())
            {
                collision.gameObject.GetComponent<TiltBasedOnVelocity>().enabled = false;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity * velocityMultiplier);
            //Vector2 direction = (collision.transform.position - transform.position);

            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * velocityMultiplier);
            collision.gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-torqueMultiplier, torqueMultiplier));


            print("OnTriggerEnter2D");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collidedGameObjects.Contains(collision.gameObject)) return;

        collidedGameObjects.Add(collision.gameObject);

        if (collision.gameObject.GetComponent<EnemyPlane>())
        {
            collision.gameObject.GetComponent<EnemyPlane>().EjectPilot();
        }

        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity * velocityMultiplier);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * velocityMultiplier);
            collision.gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-torqueMultiplier, torqueMultiplier));
            print("OnCollisionEnter2D");
        }
    }
}
