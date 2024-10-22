using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portalss : MonoBehaviour
{
    public GameObject twinPortal;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject instance = Instantiate(collision.gameObject, twinPortal.transform.position, Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Destroy(collision.gameObject);
        }
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
       // if (collision.gameObject.CompareTag("Ball"))
    //    {
     //       twinPortal = collision.gameObject;

    //    }
    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
      //  if (collision.gameObject.CompareTag("Ball"))
      //  {
     //       twinPortal = null;
      //  }
   // }

}
