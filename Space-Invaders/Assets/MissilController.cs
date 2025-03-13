using UnityEngine;

public class MissilController : MonoBehaviour
{
    public float speed = 8.0f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien1"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            GameManager.Instance.Score(20, 1); 
        }
        else if (collision.CompareTag("Alien2"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            GameManager.Instance.Score(20, 1); 
        }
        else if (collision.CompareTag("MotherShip"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            GameManager.Instance.Score(50, 0); 
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject); 
        }
    }
}
