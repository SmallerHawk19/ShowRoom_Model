using UnityEngine;

public class Portals : MonoBehaviour
{
    public GameObject Twin;
    public GameObject Ball;
    public int ForceX;
    public int ForceY;
    public int ForceZ;

    public Transform Destino;
   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject instance = Instantiate(Ball, Twin.transform.position, Quaternion.identity);
            instance.transform.localPosition = new Vector3(ForceZ, ForceX, ForceY);

        }
    }
}
