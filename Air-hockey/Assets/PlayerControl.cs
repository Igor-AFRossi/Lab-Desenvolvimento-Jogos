using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;
        if (pos.y > 0){
            pos.y = 0;
        }
        else if (pos.y < -4.35f){
            pos.y = -4.35f;
        }
        if (pos.x > 3){
            pos.x = 3;
        }
        else if (pos.x < -3){
            pos.x = -3;
        }
        transform.position = pos;
    }
}
