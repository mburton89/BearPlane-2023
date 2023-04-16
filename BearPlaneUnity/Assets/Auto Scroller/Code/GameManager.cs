using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MoveRight moveRight;

    public int currentSpeed;

    public TextMeshProUGUI currentSpeedText;
    public TextMeshProUGUI bestSpeedText;

    public float speedTextMultiplier;


    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        bestSpeedText.SetText(PlayerPrefs.GetInt("BestSpeed").ToString());
    }

    public void Restart()
    {
        StartCoroutine(RestartGame());
    }

    private void Update()
    {
        UpdateUI();
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateUI()
    {
        float currentSpeedFloat = moveRight.speed * speedTextMultiplier;
        currentSpeed = (int)currentSpeedFloat;

        currentSpeedText.SetText(currentSpeed.ToString());

        if (currentSpeed > PlayerPrefs.GetInt("BestSpeed"))
        {
            PlayerPrefs.SetInt("BestSpeed", currentSpeed);
            bestSpeedText.SetText(currentSpeedText.text);
        }
    }
}
