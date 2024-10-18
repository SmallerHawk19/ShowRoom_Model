using UnityEngine;

public class Popper : MonoBehaviour
{
    [SerializeField] private GameObject _popParticles;

    public void DestroyPopper()
    {
        Instantiate(_popParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
