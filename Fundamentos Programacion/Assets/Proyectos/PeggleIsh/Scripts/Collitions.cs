using UnityEngine;

public class Collitions : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            collision.gameObject.GetComponent<Popper>().DestroyPopper();
        }
    }
}