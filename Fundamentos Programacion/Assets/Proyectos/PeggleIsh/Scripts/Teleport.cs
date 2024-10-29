using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport twinLinkedPortal;
    [SerializeField] private float angleVector;
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
        Rigidbody2D ballRigidBody = ball.GetComponent<Rigidbody2D>(); //Obtenemos el rigidbody de la bola
        Vector2 ballSpeed = ballRigidBody.velocity; //Obtenemos la velocidad de la bola
        float speedMagnitude = ballSpeed.magnitude; //Obtenemos la magnitud de la velocidad de la bola
        ballRigidBody.velocity = Vector2.zero; //Establecemos la velocidad de la bola a 0

        ball.transform.position = twinLinkedPortal.transform.position; //Establecemos la posición de la bola en la posición del portal al que se va a teletransportar

        Vector2 exitDirection = Quaternion.Euler(0, 0, angleVector) * twinLinkedPortal.transform.up; //Calculamos la dirección de salida de la bola

        ballRigidBody.velocity = exitDirection * speedMagnitude; //Establecemos la velocidad de la bola en la dirección de salida y con la magnitud de la velocidad de la bola
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
        Vector3 teleportPosition = twinLinkedPortal.transform.position;
        Vector3 direction = Quaternion.Euler(0, 0, angleVector) * Vector3.up;
        Gizmos.DrawLine(teleportPosition, teleportPosition + direction);
    }
}
