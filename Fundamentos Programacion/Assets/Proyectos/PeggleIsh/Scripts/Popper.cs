using System.Collections;
using UnityEngine;

public class Popper : MonoBehaviour
{
    [SerializeField] private GameObject _scoreCanvas;
    [SerializeField] private GameObject _popParticles;
    [SerializeField] private GameObject _activatedParticles;
    public int _scoreValue = 100;

    private bool _isActivated = false;

    public void ActivatePopper()
    {
        if(_isActivated) return;
        _isActivated = true;
        GameManager.Instance.AddPopper(gameObject);
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        _scoreCanvas.SetActive(true);
        _scoreCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _scoreValue.ToString();
        //_activatedParticles.SetActive(true);
        StartCoroutine(DeactivateCanvas());
    }

    public void DestroyPopper()
    {
        if(!_isActivated) return;
        Instantiate(_popParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator DeactivateCanvas()
    {
        yield return new WaitForSeconds(1.5f);
        _scoreCanvas.SetActive(false);
    }
}
