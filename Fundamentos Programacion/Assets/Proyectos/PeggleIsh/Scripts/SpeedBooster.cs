using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private float speedBoost = 10.0f;
    [SerializeField] private float lifeTime = 5;
    [SerializeField] private Rigidbody2D rb;

    bool isCollided = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collition");
        if (other.gameObject.CompareTag("Ball") && !isCollided)
        {
            isCollided = true;
            rb.AddForce(Vector2.up * speedBoost, ForceMode2D.Impulse);
            Destroy(gameObject, lifeTime);
            
        }


    }
}
