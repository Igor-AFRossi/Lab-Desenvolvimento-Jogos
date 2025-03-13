using UnityEngine;
using UnityEngine.UI;
public class Gamescore : MonoBehaviour
{
    public Text scoreText; 
    public int score;
    void Start()
    { 
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

