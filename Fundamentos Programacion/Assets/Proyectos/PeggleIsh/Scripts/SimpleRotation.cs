using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] private float xSpeed = 0.0f;
    [SerializeField] private float ySpeed = 0.0f;
    [SerializeField] private float zSpeed = 0.0f;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }
}
