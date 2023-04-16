using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private Camera mainCamera;
    private bool isVisible;

    private void Start()
    {
        mainCamera = Camera.main;
        isVisible = false;

        InvokeRepeating("CheckOffScreen", 0f, 2f);
    }

    void CheckOffScreen()
    {
        if (!isVisible)
        {
            Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
            if (screenPos.x >= 0f && screenPos.x <= 1f && screenPos.y >= 0f && screenPos.y <= 1f)
            {
                isVisible = true;
            }
        }
        else
        {
            Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
            if (screenPos.x < 0f || screenPos.x > 1f || screenPos.y < 0f || screenPos.y > 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}