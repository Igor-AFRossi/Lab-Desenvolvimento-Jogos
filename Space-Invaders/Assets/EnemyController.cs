using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 4.0f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("O jogador foi atingido!");
            GameManager.Instance.DecreaseLife(); 
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject); 
        }
    }
}
