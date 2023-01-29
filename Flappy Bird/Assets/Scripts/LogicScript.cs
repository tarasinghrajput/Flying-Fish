using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    public BirdScript birdScript;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public BirdScript bird;

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        Time.timeScale = 1;
        GameOverScreen.SetActive(false);
        pausePanel.SetActive(false);
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        birdScript.soundScore();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        bird.audioSource.Stop();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void quit()
    {
        Application.Quit();
    }
}
