
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Ball;
    public float Force = 10.0f;
    public Transform firePoint;

    private Vector2 mouseDir;

    public void Update()
    {
        LookAtMouse();
        Shoot();
    }

    public void Shoot()
    {
        if(GameManager.Instance.IsBallInPlay || GameManager.Instance.BallsLeft == 0) return;
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.StartTurn();
            GameObject ballInstance = Instantiate(Ball, firePoint.position, firePoint.rotation );
            Rigidbody2D rb = ballInstance.GetComponent<Rigidbody2D>();
            
            rb.AddForce(firePoint.up * Force, ForceMode2D.Impulse);      
        }
    }

    private void LookAtMouse()
    {
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localRotation = Quaternion.LookRotation(Vector3.forward, mouseDir - (Vector2)transform.position);
    }
}
