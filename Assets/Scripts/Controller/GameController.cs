using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static GameController instance;

    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(1);
    }
}
