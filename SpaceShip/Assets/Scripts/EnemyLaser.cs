using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 6f;

    private Vector2 direcao;
    public GameController controller;


    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calcula a dire��o para o jogador no momento da cria��o do tiro
            direcao = (player.transform.position - transform.position).normalized;
        }
        else
        {
            Debug.LogWarning("Player nao encontrado");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Move o tiro constantemente na dire��o calculada inicialmente
        transform.Translate(direcao * speed * Time.deltaTime);

        if (controller.slow)
        {
            speed = 2f;
        }
        else
        {
            speed = 4f;
        }
    }

}
