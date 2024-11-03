
using JetBrains.Annotations;
using UnityEngine;

public class Boosters : MonoBehaviour
{
    
    [SerializeField] private float speedBoost = 10.0f;
    [SerializeField] private float lifeTime = 5;
    [SerializeField] private int BallAdded = 1;
    [SerializeField] private GameObject Ball;
    bool isCollided = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collition");
        if (other.gameObject.CompareTag("Ball") && !isCollided)
        {
            isCollided = true;
            for (int i = 0; i < BallAdded; i++)
            {
                GameObject ballInstance = Instantiate(Ball, transform.position, Quaternion.identity);
                Rigidbody2D rb = ballInstance.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Random.Range(-speedBoost, speedBoost), Random.Range(-speedBoost, speedBoost));
                Destroy(gameObject, lifeTime);
            }
            //Destroy(gameObject);
        }

       
    }

    
}
