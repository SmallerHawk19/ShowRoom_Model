using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData", menuName = "PeggleIsh/LevelData", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public int levelNumber = 1;
    public List<float> levelTime;
    public List<int> levelBalls;

    public void AddLevel()
    {
        levelNumber++;
        SaveData();
    }

    public void SetLevel(int level)
    {
        levelNumber = level;
    }

    public void SubtractLevel()
    {
        levelNumber--;
        if (levelNumber < 1)
        {
            levelNumber = 1;
        }
        SaveData();
    }

    public void ResetLevel()
    {
        levelNumber = 1;
    }

    private void SaveData()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
}
