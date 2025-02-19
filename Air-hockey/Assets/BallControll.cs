using UnityEngine;

public class BallControll : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // inicializa o disco randomicamente para esquerda ou direita
    void GoDisc(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto disco
        Invoke("GoDisc", 0.5f);    // Chama a função GoDisc após 2 segundos
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetDisc(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke("GoDisc", 0.5f);
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetDisc();
        Invoke("GoDisc", 0.5f);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
