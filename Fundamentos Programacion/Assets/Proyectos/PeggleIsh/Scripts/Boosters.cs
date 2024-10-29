
using UnityEngine;

public class Boosters : MonoBehaviour
{
    [SerializeField] private GameObject Booster;
    [SerializeField] private float speedBoost = 10.0f;
    [SerializeField] private int lifeTime = 5;
    [SerializeField] private int BallQuantity = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MultiplyBooster"))
        {
            for (int i = 0; i < BallQuantity; i++)
            {
                //GameObject ballInstance = Instantiate(Ball, transform.position, Quaternion.identity);
               // Rigidbody2D rb = ballInstance.GetComponent<Rigidbody2D>();
               // rb.velocity = new Vector2(Random.Range(-speedBoost, speedBoost), Random.Range(-speedBoost, speedBoost));
            }
        }
    }
}
