using UnityEngine;
using UnityEngine.SceneManagement; // Importa a biblioteca para gerenciar cenas

public class SceneController : MonoBehaviour
{
    void Update()
    {
        // Se a tecla Espaço for pressionada e estiver no Menu, inicia o jogo
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Menu")
        {
            LoadScene("Fase1"); // Inicia a primeira fase
        }
        else if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "GameOver")
        {
            LoadScene("Menu"); // Inicia a primeira fase
        }
        else if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Victory")
        {
            LoadScene("Menu"); // Inicia a primeira fase
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