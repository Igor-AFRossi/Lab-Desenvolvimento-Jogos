using UnityEngine;
using System.Collections;

public class MotherShip : MonoBehaviour
{
    public float speed = 5f; // Velocidade da nave
    public float minSpawnTime = 30f; // Tempo mínimo para spawn
    public float maxSpawnTime = 50f; // Tempo máximo para spawn
    public float moveStep = 5f; // Incremento na posição X por movimento
    public GameObject explosionEffect; // Efeito de explosão ao ser destruída

    private float rightBound; // Limite direito da tela

    void Start()
    {
        rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 2f; // Calcula o limite direito da tela
        StartCoroutine(SpawnMotherShip());
    }

    void Update()
    {
        transform.position += Vector3.right * moveStep * Time.deltaTime * speed;

        // Se passar do limite da tela, destruir o objeto
        if (transform.position.x >= rightBound)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnMotherShip()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnDelay);

            // Criar nova nave mãe no canto esquerdo
            Instantiate(gameObject, new Vector3(-rightBound, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - 1, 0), Quaternion.identity);
        }
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Missile"))
    //     {
    //         Destroy(collision.gameObject); // Destroi o míssil
    //         Explode(); // Executa explosão
    //     }
    // }

    // void Explode()
    // {
    //     if (explosionEffect != null)
    //     {
    //         Instantiate(explosionEffect, transform.position, Quaternion.identity);
    //     }
    //     Destroy(gameObject); // Remove a nave mãe
    // }
}
