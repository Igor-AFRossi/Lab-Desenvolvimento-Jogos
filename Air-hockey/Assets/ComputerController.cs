using UnityEngine;

public class ComputerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private GameObject theDisc;
    public float speed = 3.0f;

    void Start()
    {
        theDisc = GameObject.FindGameObjectWithTag("Disc");
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 3.45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x = theDisc.transform.position.x;
        pos.y = theDisc.transform.position.y;
        if (pos.y < 0){
            pos.y = 0;
        }
        else if (pos.y > 4.35f){
            pos.y = 4.35f;
        }
        if (pos.x > 3){
            pos.x = 3;
        }
        else if (pos.x < -3){
            pos.x = -3;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }
}
