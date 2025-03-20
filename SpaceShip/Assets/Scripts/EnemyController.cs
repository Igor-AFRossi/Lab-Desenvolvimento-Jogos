using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{



    public Rigidbody2D rb;
    public float speed = 2f;

    public float points = 100f;
    public GameController controller;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //movimenta��o do inimigo 
        rb.linearVelocity = Vector3.left * speed;

        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            controller.points += this.points;
        }
        
    }
}
