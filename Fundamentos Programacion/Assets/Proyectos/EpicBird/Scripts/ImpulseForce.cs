using System;
using Unity.VisualScripting;
using UnityEngine;

public class ImpulseForce : MonoBehaviour
{
    public float Force = 10f;

    private Rigidbody2D rigidBody;

    public static int HP = 3;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        CheckGravity();
    }

    private void Update()

    {
        CheckGravity();
        CheckInput();
    }

    void CheckInput()
    {
        if (FlappyManager.isGameStarted == false) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

    }

    private void CheckGravity()
    {
        if (FlappyManager.isGameStarted)
        {
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rigidBody.bodyType = RigidbodyType2D.Kinematic;
        }
    }

        void Jump()
    {
        FlappyManager.JumpCount++;
        rigidBody.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
    }

    void Damage()
    {
        HP--;
        print("CRASH");
        print("Life left: " + HP);

        if (HP == 0)
            print("Game Over");
    }


    void Points()
    {
        FlappyManager.Score++;
        print("My Score: " + FlappyManager.Score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PointMaker"))
        {
            Points();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.transform.CompareTag("Obstacle"))
        {
            Damage();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(207f,86f,72f,1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameBorder"))
        {
            Damage();
            print("Collided with game border");
        }
    }
}
