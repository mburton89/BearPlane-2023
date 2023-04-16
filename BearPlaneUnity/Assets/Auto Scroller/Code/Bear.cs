using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public GameObject roarWavePrefab;
    public Transform roarWaveSpawnPoint;
    public float roarLaunchSpeed;

    [HideInInspector] public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public List<Sprite> sprites;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Roar();
        }
    }

    public void Roar()
    {
        GameObject roarWave = Instantiate(roarWavePrefab, roarWaveSpawnPoint.position, transform.rotation, null);
        roarWave.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, 0);
        roarWave.GetComponent<Rigidbody2D>().AddForce(Vector2.right * roarLaunchSpeed);

        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Bear);

        StartCoroutine(ShowRoarSprite());
    }

    private IEnumerator ShowRoarSprite()
    {
        spriteRenderer.sprite = sprites[1];
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = sprites[0];
    }

    public void Explode()
    {
        //LaunchPilot();
        GameObject prefab = Resources.Load<GameObject>("Explosion"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        ScreenShaker.Instance.ShakeScreen();
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Explosion);
        GameManager.Instance.Restart();
        Destroy(gameObject);
    }
}
