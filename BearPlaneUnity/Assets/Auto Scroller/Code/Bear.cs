using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public GameObject roarWavePrefab;
    public Transform roarWaveSpawnPoint;
    public float roarLaunchSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
