using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    public int vidas = 3; 
    

    void Awake()
    {
        
     
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
