using UnityEngine;
using UnityEngine.UI;

public class ShoutBar : MonoBehaviour
{
    public static ShoutBar Instance;

    public Image imageToRefill;
    public float refillTime = 1f;
    [HideInInspector] public float currentFill = 0f;
    private float timeSinceRefillStart = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        imageToRefill.fillAmount = 1;
    }

    private void Update()
    {
        if (currentFill < 1f)
        {
            timeSinceRefillStart += Time.deltaTime;
            currentFill = Mathf.Lerp(0f, 1f, timeSinceRefillStart / refillTime);
            imageToRefill.fillAmount = currentFill;
        }
    }

    public void StartRefill()
    {
        currentFill = 0f;
        timeSinceRefillStart = 0f;
    }
}