using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatterHandler : MonoBehaviour
{
    public GameObject bloodSplatterPrefab;

    private void OnParticleCollision(GameObject other)
    {
        print("OnParticleCollision");
        GameObject bloodSplatter = Instantiate(bloodSplatterPrefab, other.transform.position, other.transform.rotation, this.transform);
        bloodSplatter.transform.eulerAngles = Vector3.zero;
    }
}
