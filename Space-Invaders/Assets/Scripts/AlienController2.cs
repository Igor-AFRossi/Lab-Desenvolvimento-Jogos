using UnityEngine;

public class AlienController2 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private int state = 0;
    private float x;
    private float y;
    private float speed = -2.0f;
    public GameObject enemyMissilePrefab; // Prefab do míssil
    public Transform firePoint; // Ponto de disparo
    private float fireChance = 0.01f; // 1% de chance de atirar a cada frame
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();  
        x = transform.position.x;
        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f){
            if (Random.value < fireChance) 
            {
                FireMissile();
            }
        }
        if (timer >= waitTime){
            state ++;
            ChangeState();
            timer = 0.0f;
        }
    }

     void ChangeState(){
        var vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;
        if(state == 2){
            state = 0;
            MoveDown();
        }
    }

    void MoveDown()
    {
        transform.position = new Vector2(x, transform.position.y - 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            Debug.Log("Uma nave atingiu a parede inferior! Game Over!");
            GameManager.Instance.GameOver(); 
        }
    }
    void FireMissile(){
    Instantiate(enemyMissilePrefab, firePoint.position, Quaternion.identity);
    }
}
