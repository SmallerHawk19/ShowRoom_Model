using System.Collections.Generic;
using UnityEngine;

public class FrenzyPopperManager : MonoBehaviour
{
    public static FrenzyPopperManager Instance;

    private List<GameObject> _currentPoppers = new List<GameObject>();
    private int _popperCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (_popperCount <= 0 && _currentPoppers.Count != 0)
        {
            foreach (GameObject popper in _currentPoppers)
            {
                popper.SetActive(true);
                Popper popperScript = popper.GetComponent<Popper>();
                popperScript.ResetPopper();
            }
        }
    }

    public void AddPopperCount(GameObject popper)
    {
        _popperCount++;
        // Holi Saco :V
        if(!_currentPoppers.Contains(popper))
        {
            _currentPoppers.Add(popper);
        }
    }

    public void RemovePopperCount()
    {
        _popperCount--;
    }
}
