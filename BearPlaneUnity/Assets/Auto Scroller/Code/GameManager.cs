using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Bear bear;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60f;
    }

    // Update is called once per frame
    public void Restart()
    {
        StartCoroutine(RestartGame());
    }


    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}
