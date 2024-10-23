using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport twinLinkedPortal;
    [SerializeField] private Vector2 portalSpeedVector;
    [SerializeField] private float teleportCooldown = 0.5f;

    [HideInInspector] public bool OnCooldown = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if(OnCooldown) return;
            ActivateCooldown();
            TeleportBall(collision.gameObject);
            Invoke("DeactivateCooldown", teleportCooldown);
        }
    }

    private void TeleportBall(GameObject ball)
    {
        Rigidbody2D ballRigidBody = ball.GetComponent<Rigidbody2D>();
        Vector2 ballSpeed = ballRigidBody.velocity;
        ballRigidBody.velocity = Vector2.zero;
        ball.transform.position = twinLinkedPortal.gameObject.transform.position;
        ballRigidBody.velocity = new Vector2(ballSpeed.x * portalSpeedVector.x, ballSpeed.y * portalSpeedVector.y);
    }

    private void ActivateCooldown()
    {
        OnCooldown = true;
        twinLinkedPortal.OnCooldown = true;
    }

    private void DeactivateCooldown()
    {
        OnCooldown = false;
        twinLinkedPortal.OnCooldown = false;
    }

    //Ayudado por fernando Hola que ase Saco :v
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(twinLinkedPortal.gameObject.transform.position, transform.position * portalSpeedVector);
    }
}
