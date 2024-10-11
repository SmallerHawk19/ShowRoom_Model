using UnityEngine;

public class ImpulseForce : MonoBehaviour
{
    public float Force = 10f;

    private Rigidbody2D rigidbody;

    public static int HP = 5;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()

    {
        CheckInput();

        
        void CheckInput()

        {
            if (Input.GetKeyDown(KeyCode.Space) && FlappyManager.isGameStarted)

            {
                Jump();
                rigidbody.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
            }

        }
    }


    void Jump()
    {
        FlappyManager.JumpCount++;
        rigidbody.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
    }


    void CheckInput()

    {
        if (Input.GetKeyDown(KeyCode.Space) && FlappyManager.isGameStarted)

        {
            Jump();
        }

    }
    void Damage()
    {
        HP--;
        print("CRASH" + HP);

        if (HP == 0)
            print("Game Over");

    }


    void Points()
    {
        FlappyManager.Score++;
        print(FlappyManager.Score + "My Score");

    }

    void OnCollisionEnter(Collision objeto)
    {
        if (objeto.transform.CompareTag("Obstacle"))
        {
            Damage();

        }

    }

    void OnTriggerEnter(Collider objeto)
    {
        //print("Trigger");
        if (objeto.transform.CompareTag("PointMaker"))
        {
            Points();
        }

    }


}
