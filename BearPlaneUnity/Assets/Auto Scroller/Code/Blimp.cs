using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blimp : MonoBehaviour
{
    public float verticalVelocity;
    Rigidbody2D rb;

    [HideInInspector] public bool hasBeenRoared;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int rand = Random.Range(0, 4);

        if (rand == 1)
        {
            rb.AddForce(Vector2.up * verticalVelocity);
        }
        else if (rand == 2)
        {
            rb.AddForce(Vector2.down * verticalVelocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bear>())
        {
            collision.GetComponent<Bear>().Explode();
            Explode();
        }

        if (collision.gameObject.GetComponent<Pilot>())
        {
            collision.gameObject.GetComponent<Pilot>().Explode();
            Explode();
        }

        if (collision.gameObject.GetComponent<EnemyPlane>() && hasBeenRoared)
        {
            collision.gameObject.GetComponent<EnemyPlane>().Explode();
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bear>())
        {
            collision.gameObject.GetComponent<Bear>().Explode();
            Explode();
        }

        if (collision.gameObject.GetComponent<Pilot>())
        {
            collision.gameObject.GetComponent<Pilot>().Explode();
            Explode();
        }

        if (collision.gameObject.GetComponent<EnemyPlane>() && hasBeenRoared)
        {
            collision.gameObject.GetComponent<EnemyPlane>().Explode();
            Explode();
        }
    }

    public void Explode()
    {
        //LaunchPilot();
        GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        //ScreenShaker.Instance.ShakeScreen();
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Explosion);
        Destroy(gameObject);
    }
}
