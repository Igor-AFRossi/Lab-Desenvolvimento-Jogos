using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;
    public Animator anim;
    public Text scoreTxt;
    public Text lifeTxt;

    public int score = 0;
    public int life = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if(moveInput == 0){
            anim.SetBool("Running", false);
        }
        else{
            anim.SetBool("Running", true);
        }

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Carrot"){
            Destroy(collision.gameObject);
            score += 100;
            Debug.Log(score);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Door" && SceneManager.GetActiveScene().name == "Tutorial"){
            if (score >= 200){
                score = 0;
                SceneManager.LoadScene("Game");
            }
        }
        if (collision.gameObject.tag == "Door" && SceneManager.GetActiveScene().name == "Game"){
            if (score >= 1000){
                Victory();
            }
        }
        if (collision.gameObject.tag == "Enemy"){
            if(isGrounded == false){
                Destroy(collision.gameObject);
                score += 100;
                Debug.Log(score);
            }
            else{
                if (collision.gameObject.transform.position.x > transform.position.x){
                    rb.linearVelocity = new Vector2(-10f, rb.linearVelocity.y);
                    anim.SetBool("Hurt", true);
                    life -= 1;
                    if (life <= 0){
                        GameOver();
                    }
                    Debug.Log(life);
                    anim.SetBool("Hurt", false);
                }
                else{
                    rb.linearVelocity = new Vector2(+10f, rb.linearVelocity.y);
                    anim.SetBool("Hurt", true);
                    life -= 1;
                    if (life <= 0){
                        GameOver();
                    }
                    Debug.Log(life);
                    anim.SetBool("Hurt", false);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void Victory(){
        Debug.Log("Victory!!");
        Debug.Log(score);
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Victory");
    }

    private void GameOver(){
        Debug.Log("GameOver!!");
        Debug.Log(score);
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameOver");
    }
}
