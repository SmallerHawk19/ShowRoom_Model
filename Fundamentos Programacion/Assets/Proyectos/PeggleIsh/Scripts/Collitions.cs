using UnityEngine;

public class Collitions : MonoBehaviour
{
    public float lifeTime = 60;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            GameManager.Instance.AddPopper(collision.gameObject);
        } else if (collision.gameObject.CompareTag("BlackHole"))
        {
            GameManager.Instance.EndTurn();
            Destroy(gameObject);
        }
    }
}