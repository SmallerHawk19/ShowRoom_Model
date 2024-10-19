
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Pewpew;
    public float Force = 10.0f;
    public Rigidbody2D rb;
 

    public void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameObject ballInstance = Instantiate(Ball, transform.position, Quaternion.identity);
            Rigidbody2D rb = ballInstance.GetComponent<Rigidbody2D>();
            
            rb.AddForce(Vector2.down * Force, ForceMode2D.Impulse);
           
        }
    }
}
