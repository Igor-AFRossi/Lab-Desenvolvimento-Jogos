using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerLives = 3;
    public int score = 0;
    public int value = 0;
    public Text scoreText; 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Score(int points, int val){
        score += points;
        value += val;
        scoreText.text = "Score:" + score;
        if (value >= 36){
            Victory();
        }
    }

    public void DecreaseLife()
    {
        playerLives--;
        Debug.Log("Vidas restantes: " + playerLives);
        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        Debug.Log(score);
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        LoadScene("Victory"); 
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Debug.Log(score);
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        LoadScene("GameOver"); 
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
