using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatterHandler : MonoBehaviour
{
    public GameObject bloodSplatterPrefab;

    public float minParticleSize;
    public float maxParticleSize;

    private void OnParticleCollision(GameObject other)
    {
        print("OnParticleCollision");
        GameObject bloodSplatter = Instantiate(bloodSplatterPrefab, other.transform.position, other.transform.rotation, this.transform);

        float rand = Random.Range(minParticleSize, maxParticleSize);

        bloodSplatter.transform.localScale = new Vector3(rand, rand, rand);
        bloodSplatter.transform.eulerAngles = Vector3.zero;
    }
}
