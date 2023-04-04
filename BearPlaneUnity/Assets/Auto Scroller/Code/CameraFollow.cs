using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _initialZ;

    public float xOffset;

    private void Awake()
    {
        _initialZ = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(_target.transform.position.x + xOffset, 0, _initialZ);
        //if (_target.transform.position.x >= transform.position.x)
        //{
        //}
    }
}
