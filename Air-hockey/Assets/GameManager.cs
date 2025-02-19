using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theDisc;                 // Referência ao objeto disco
    GameObject computer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theDisc = GameObject.FindGameObjectWithTag("Disc"); // Busca a referência do disco
        computer = GameObject.FindGameObjectWithTag("Computer");
    }

    // incrementa a potuação
    public static void Score (string goalID) {
        if (goalID == "Red_goal")
        {
            PlayerScore1++;
        } else
        {
            PlayerScore2++;
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Blue\n  " + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "Red\n " + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 4 - 90, 110, 90, 30), "RESTART\n GAME"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theDisc.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (GUI.Button(new Rect(Screen.width / 4 - 90, 140, 90, 30), "RESTART\n DISC"))
        {
            theDisc.SendMessage("ResetDisc", null, SendMessageOptions.RequireReceiver); 
            computer.SendMessage("ResetPosition", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 7)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theDisc.SendMessage("ResetDisc", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 7)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theDisc.SendMessage("ResetDisc", null, SendMessageOptions.RequireReceiver);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
