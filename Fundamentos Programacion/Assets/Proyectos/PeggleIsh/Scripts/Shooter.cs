
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Pewpew;
    public float Force = 10.0f;

    public void Shoot()
    {
        Instantiate(Ball, transform.position, Quaternion.identity);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            this.(Vector2.down * Force, ForceMode2D.Impulse);
        }
    }
}
