using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float speedBoost = 10.0f;
    bool isCollided = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collition");

        if (other.gameObject.CompareTag("Ball") && !isCollided)
        {
            isCollided = true;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 currentVelocity = rb.velocity.normalized;
            rb.AddForce(currentVelocity * speedBoost, ForceMode2D.Impulse);
        }
        Destroy(this.gameObject);            
    }
}
