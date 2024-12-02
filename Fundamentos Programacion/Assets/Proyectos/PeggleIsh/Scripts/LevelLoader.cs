using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelDataSO _levelData;
    [SerializeField] private List<GameObject> _levelPrefabs;

    private void OnEnable()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
       _levelPrefabs[_levelData.levelNumber - 1].SetActive(true);
    }
}
