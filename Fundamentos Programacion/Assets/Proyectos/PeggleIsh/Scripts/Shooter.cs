
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Pewpew;
    public float Force = 10.0f;
    public Rigidbody2D rb;
    public Transform firePoint;

    private Vector2 mouseDir;

    

    public void Update()
    {
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localRotation = Quaternion.LookRotation(Vector3.forward, mouseDir - (Vector2)transform.position);
        Shoot();
    }
    public void FixedUpdate()
    {
        rb.velocity = transform.up * Force;
    }
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameObject ballInstance = Instantiate(Ball, firePoint.position, firePoint.rotation );
            Rigidbody2D rb = ballInstance.GetComponent<Rigidbody2D>();
            
            rb.AddForce(Vector2.down * Force, ForceMode2D.Impulse); //aqui es el pobema peeeero no se como arreglarlo xd
           
        }
    }
}
