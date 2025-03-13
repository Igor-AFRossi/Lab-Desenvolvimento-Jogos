using UnityEngine;
using UnityEngine.SceneManagement; // Importa a biblioteca para gerenciar cenas

public class SceneController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Start")
        {
            LoadScene("Game"); 
        }
        else if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "GameOver")
        {
            LoadScene("Start"); 
        }
        else if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Victory")
        {
            LoadScene("Start"); 
        }
    }

    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}