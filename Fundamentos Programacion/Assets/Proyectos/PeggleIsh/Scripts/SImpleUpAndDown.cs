using UnityEngine;

public class SImpleUpAndDown : MonoBehaviour
{
    public float amplitude = 2.0f;  
    public float frequency = 1.0f;   
    public float offset = 0.0f;     

    private Vector3 startPosition;   

    void Start()
    {
        startPosition = transform.position;  
    }

    void Update()
    {
        float yPosition = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency + offset);
        transform.position = new Vector3(startPosition.x, yPosition, startPosition.z);
    }
}
