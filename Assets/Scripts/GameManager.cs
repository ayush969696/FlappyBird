using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject restartBtn;
    public GameObject gameover;
    private int score = 0;
    public GameObject pipesSpawner;

    private void Awake()
    {
        Application.targetFrameRate = 60;   // it will run on the starting at 60 framerate seconds
        player.enabled = true;
        restartBtn.SetActive(false);
        gameover.SetActive(false);
        pipesSpawner.SetActive(true);

    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0;  // it will stop the game time.
        Destroy(player);
        pipesSpawner.SetActive(false);
    }
    public void GameOver()
    {
        gameover.SetActive(true);
        restartBtn.SetActive(true);
        Pause();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score:" + score;
    }
  
}
