using Unity.VisualScripting;
using UnityEngine;

public class Collitions : MonoBehaviour
{
    public float lifeTime = 60;

    [SerializeField] private bool isClone = false;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
           collision.gameObject.GetComponent<Popper>().ActivatePopper();
        } else if (collision.gameObject.CompareTag("BlackHole"))
        {
            if (!isClone)
            {
                GameManager.Instance.EndTurn();
            }
            Destroy(gameObject);
        }
    }
}