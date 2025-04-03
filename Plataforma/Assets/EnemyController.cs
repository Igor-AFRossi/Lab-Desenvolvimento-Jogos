using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int count = 0;
    private Rigidbody2D rb;
    private bool facingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (count < 40){
            rb.linearVelocity = new Vector2(-2, rb.linearVelocity.y);
            count += 1;
        }
        else if (count == 40){
            if (!facingRight)
                Flip();
            count += 1;
        }
        else if (count < 80){
            rb.linearVelocity = new Vector2(2, rb.linearVelocity.y);
            count += 1;
        }
        else{
            count = 0;
            if (facingRight)
                Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
