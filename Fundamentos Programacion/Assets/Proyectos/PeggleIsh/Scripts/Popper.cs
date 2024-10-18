using UnityEngine;

public class Popper : MonoBehaviour
{
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            gameObject.SetActive(false);
        }
    }

}
