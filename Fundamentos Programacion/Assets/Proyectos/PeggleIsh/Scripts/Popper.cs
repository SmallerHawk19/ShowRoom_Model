using System.Collections;
using UnityEngine;

public class Popper : MonoBehaviour
{
    [SerializeField] private GameObject _scoreCanvas;
    [SerializeField] private GameObject _popParticles;
    [SerializeField] private GameObject _activatedParticles;
    public int _scoreValue = 100;

    private bool _isActivated = false;
    [SerializeField] private bool _isFrenzyPopper = false;

    private void Start()
    {
        if(_isFrenzyPopper)
        {
            FrenzyPopperManager.Instance.AddPopperCount(this.gameObject);
        } else
        {
             GameManager.Instance.AddPopperCount();  
        }
    }

    private void OnDestroy()
    {
       if(!_isFrenzyPopper) GameManager.Instance.RemovePopperCount();
    }

    private void OnEnable()
    {
        if (_isFrenzyPopper && FrenzyPopperManager.Instance != null) FrenzyPopperManager.Instance.AddPopperCount(this.gameObject);
    }

    private void OnDisable()
    {
        if(_isFrenzyPopper) FrenzyPopperManager.Instance.RemovePopperCount();
    }

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
        if (_isFrenzyPopper)
        {
            Instantiate(_popParticles, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        } else
        {
            Instantiate(_popParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void ResetPopper()
    {
        _isActivated = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        _scoreCanvas.SetActive(false);
    }

    private IEnumerator DeactivateCanvas()
    {
        yield return new WaitForSeconds(1.5f);
        _scoreCanvas.SetActive(false);
    }
}
