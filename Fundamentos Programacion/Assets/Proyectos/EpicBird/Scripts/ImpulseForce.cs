using UnityEngine;

public class ImpulseForce : MonoBehaviour
{
    public float Force = 10f;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
        }
    }
}
