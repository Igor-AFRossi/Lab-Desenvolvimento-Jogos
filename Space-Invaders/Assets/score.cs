using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    public Text scoreText; 

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); 
        scoreText.text = $"{finalScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
