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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            collision.gameObject.GetComponent<EnemyPlane>().Explode();
        }
    }

    public void Explode()
    {
        //LaunchPilot();
        GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        ScreenShaker.Instance.ShakeScreen();
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Explosion);
        Destroy(gameObject);
    }

    public void LaunchPilot()
    {
        GameObject launchedPilot = Instantiate(pilotPrefab, pilotSpawnPoint.position, transform.rotation, null);

        launchedPilot.GetComponent<Rigidbody2D>().velocity = rb.velocity;

        float randLaunchSpeed = Random.Range(pilotMinLaunchSpeed, pilotMaxLaunchSpeed);
        launchedPilot.GetComponent<Rigidbody2D>().AddForce(Vector2.up * randLaunchSpeed);

        float randLaunchTorque = Random.Range(pilotMinLaunchTorque, pilotMaxLaunchTorque);
        launchedPilot.GetComponent<Rigidbody2D>().AddTorque(randLaunchTorque);

        launchedPilot.GetComponent<DestroyPlaneOnImpact>().ownedPlane = gameObject;

        hasLaunchedPilot = true;

        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Eject);

        spriteRenderer.sprite = noPilotSprite;
    }
}
