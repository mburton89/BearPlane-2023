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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
        StartCoroutine(EstablishDrag());
    }

    void Update()
    {
        if (!hasDeployedParachute)
        {
            rb.drag += preParachuteDragMultiplier;
        }
    }

    private IEnumerator EstablishDrag()
    {
        int rand = Random.Range(0, 5);

        if (rand == 3) //dud parachute
        {
            yield return new WaitForSeconds(secondsToWaitForParachute);
            //spriteRenderer.sprite = parachuteDudSprite;
            //SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Parachute);
            rb.gravityScale *= 4f;
        }
        else
        {
            yield return new WaitForSeconds(secondsToWaitForParachute);
            hasDeployedParachute = true;
            spriteRenderer.sprite = parachuteSprite;
            rb.AddTorque(-rb.rotation);
            rb.gravityScale = rb.gravityScale * 0.3f;
            rb.drag = postParachuteDrag;
            SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Parachute);
        }
    }

    public void Explode()
    {
        GameObject prefab = Resources.Load<GameObject>("Blood"); // Load the prefab from the Resources folder
        Instantiate(prefab, transform.position, transform.rotation); // Instantiate the prefab
        ScreenShaker.Instance.ShakeScreen();
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.Guts);
        Destroy(gameObject);
    }
}
