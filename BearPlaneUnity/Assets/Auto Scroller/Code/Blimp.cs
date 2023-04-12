using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blimp : MonoBehaviour
{
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
    }

    public void Explode()
    {
        //LaunchPilot();
        GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        //ScreenShaker.Instance.ShakeScreen();
        //SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Explosion);
        Destroy(gameObject);
    }
}
