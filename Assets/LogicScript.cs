using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps track of high level information - such as the player's score
/// </summary>
public class LogicScript : MonoBehaviour
{
    public int playerScore;

    public Text scoreText;

    public GameObject gameOverScreen;

    public GameObject beginScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;

        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void beginGame()
    {
        beginScreen.SetActive(false);



    }


}
