using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject missilePrefab; 
    public Transform firePoint;

    void Update()
    {
        
        float move = Input.GetAxis("Horizontal"); 
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
    }

    void FireMissile()
    {
        Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
    }

}
