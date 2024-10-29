using UnityEngine;

public class AutoDestroyParticles : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 5f;

    private void Start()
    {
        Invoke("DestoryParticles", timeToDestroy);
    }

    private void DestoryParticles()
    {
        Destroy(gameObject);
    }
}
