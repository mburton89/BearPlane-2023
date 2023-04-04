using UnityEngine;

public class ObjectLauncher : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float forwardlaunchSpeed = 10f;
    [SerializeField] private float upwardlaunchSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(objectPrefab, transform.position, Quaternion.identity, transform);
            Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
            objRb.velocity = GetComponentInParent<Rigidbody2D>().velocity;
            objRb.AddForce(transform.up * upwardlaunchSpeed, ForceMode2D.Impulse);
        }
    }
}
