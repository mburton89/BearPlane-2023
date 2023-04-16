using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    public float preParachuteDragMultiplier;
    public float postParachuteDrag;

    public float secondsToWaitForParachute;
    Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    public Sprite parachuteSprite;

    bool hasDeployedParachute;
    bool canExplode;
    public float secondsBeforeCanExplode = 0.2f;
    [HideInInspector] public bool shouldDeployParachute = true;
    [HideInInspector] public GameObject ownedPlane;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
        StartCoroutine(CanExplodeBuffer());
        StartCoroutine(DeployParachute());
    }

    void Update()
    {
        if (!hasDeployedParachute)
        {
            rb.drag += preParachuteDragMultiplier;
        }
    }

    private IEnumerator DeployParachute()
    {
        int rand = Random.Range(0, 5);

        yield return new WaitForSeconds(secondsToWaitForParachute);

        if (shouldDeployParachute) //dud parachute
        {
            hasDeployedParachute = true;
            spriteRenderer.sprite = parachuteSprite;
            rb.AddTorque(-rb.rotation);
            rb.gravityScale = rb.gravityScale * 0.3f;
            rb.drag = postParachuteDrag;
            SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Parachute);
        }
        else
        {
            rb.gravityScale *= 4f;
        }
    }

    public void Explode()
    {
        if (!canExplode) return;

        GameObject prefab = Resources.Load<GameObject>("Blood"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        ScreenShaker.Instance.ShakeScreen();
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Guts);
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Bear);
        Destroy(gameObject);
    }

    private IEnumerator CanExplodeBuffer()
    {
        yield return new WaitForSeconds(secondsBeforeCanExplode);
        canExplode = true;
    }
}
