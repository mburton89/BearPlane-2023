using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BloodSplatter : MonoBehaviour
{
    public float minParticleSize;
    public float maxParticleSize;

    public float minMovementSpeed;
    public float maxMovementSpeed;

    public float minSecondsToLive;
    public float maxSecondsToLive;

    void Start()
    {
        float randSize = Random.Range(minParticleSize, maxParticleSize);
        float randSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
        float randSecondsToLive = Random.Range(minSecondsToLive, maxSecondsToLive);

        transform.localScale = new Vector3(randSize, randSize, randSize);
        //transform.DOLocalMoveY(transform.position.y - randSpeed, randSecondsToLive * 2, false);
        GetComponent<SpriteRenderer>().DOFade(0, randSecondsToLive);

        Destroy(gameObject, randSecondsToLive + 0.2f);
    }
}
