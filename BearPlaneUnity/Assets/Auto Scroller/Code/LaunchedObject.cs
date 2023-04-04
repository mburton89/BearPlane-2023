using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchedObject : MonoBehaviour
{
    public float drag;
    public float secondsToWaitForDrag;
    Rigidbody2D rb;
    public float dragMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
        //StartCoroutine(EstablishDrag());
    }

    private IEnumerator EstablishDrag()
    {
        yield return new WaitForSeconds(secondsToWaitForDrag);
        rb.drag = drag;
        rb.angularDrag = drag;
    }

    private void Update()
    {
        rb.drag += dragMultiplier;
    }
}
