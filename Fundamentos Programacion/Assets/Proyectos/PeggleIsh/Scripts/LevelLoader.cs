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
        if(_levelData.levelNumber > _levelPrefabs.Count || _levelData.levelNumber <= 0)
        {
            _levelData.ResetLevel();
        }

        _levelPrefabs[_levelData.levelNumber - 1].SetActive(true);
        GameManager.Instance.TimeLeft = _levelData.levelTime[_levelData.levelNumber - 1];
        GameManager.Instance.BallsLeft = _levelData.levelBalls[_levelData.levelNumber - 1];
    }
}
