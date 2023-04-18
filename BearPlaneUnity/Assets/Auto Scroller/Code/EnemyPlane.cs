using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject pilotPrefab;
    public Transform pilotSpawnPoint;
    public float pilotMinLaunchSpeed;
    public float pilotMaxLaunchSpeed;
    public float pilotMinLaunchTorque;
    public float pilotMaxLaunchTorque;

    bool hasLaunchedPilot;
    public float crashSpeed;

    SpriteRenderer spriteRenderer;
    public Sprite noPilotSprite;

    public float horizontalVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.velocity = new Vector2(horizontalVelocity, 0);
    }

    private void Update()
    {
        if (hasLaunchedPilot)
        {
            rb.gravityScale += 0.01f;
            rb.drag += 0.01f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyPlane>())
        {
            Vector2 dir = transform.position - collision.transform.position;
            Vector2 dirMultiplied = dir.normalized * 10;
            print(dirMultiplied);
            Vector2 newLaunchVelocity = rb.velocity + dirMultiplied;

            LaunchPilot(newLaunchVelocity);
            collision.gameObject.GetComponent<EnemyPlane>().Explode();
        }

        if (collision.gameObject.GetComponent<Bear>())
        {
            Bear bear = collision.gameObject.GetComponent<Bear>();
            Vector2 launchVelocity = new Vector2(bear.gameObject.GetComponent<MoveRight>().speed + 4, bear.rb.velocity.y * 1.4f);
            LaunchPilot(launchVelocity);
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pilot>() && collision.gameObject.GetComponent<Pilot>().ownedPlane != gameObject)
        {
            Explode();

            collision.gameObject.GetComponent<Pilot>().Explode();

            Vector2 dir = transform.position - collision.transform.position;
            Vector2 dirMultiplied = dir.normalized * 10;

            print(dirMultiplied);

            Vector2 newLaunchVelocity = rb.velocity + dirMultiplied;

            LaunchPilot(newLaunchVelocity);

        }
    }

    public void Explode()
    {
        GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        ScreenShaker.Instance.ShakeScreen();
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Explosion);

        Bear.Instance.IncreaseSpeed();

        Destroy(gameObject);
    }

    public void EjectPilot()
    {
        if (hasLaunchedPilot) return;

        GameObject launchedPilot = Instantiate(pilotPrefab, pilotSpawnPoint.position, transform.rotation, null);

        launchedPilot.GetComponent<Rigidbody2D>().velocity = rb.velocity;

        float randLaunchSpeed = Random.Range(pilotMinLaunchSpeed, pilotMaxLaunchSpeed);
        launchedPilot.GetComponent<Rigidbody2D>().AddForce(Vector2.up * randLaunchSpeed);

        float randLaunchTorque = Random.Range(pilotMinLaunchTorque, pilotMaxLaunchTorque);
        launchedPilot.GetComponent<Rigidbody2D>().AddTorque(randLaunchTorque);

        launchedPilot.GetComponent<Pilot>().ownedPlane = gameObject;

        hasLaunchedPilot = true;

        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Eject);

        spriteRenderer.sprite = noPilotSprite;
    }

    public void LaunchPilot(Vector2 velocity)
    {
        if (hasLaunchedPilot) return;

        GameObject launchedPilot = Instantiate(pilotPrefab, pilotSpawnPoint.position, transform.rotation, null);

        launchedPilot.GetComponent<Rigidbody2D>().velocity = velocity;

        float randLaunchTorque = Random.Range(pilotMinLaunchTorque, pilotMaxLaunchTorque);
        launchedPilot.GetComponent<Rigidbody2D>().AddTorque(randLaunchTorque);

        launchedPilot.GetComponent<Pilot>().ownedPlane = gameObject;

        hasLaunchedPilot = true;
    }
}
