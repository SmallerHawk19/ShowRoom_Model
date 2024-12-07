
using UnityEngine;

public class PeggleUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TotalScore;
    public TMPro.TextMeshProUGUI TurnScore;
    public TMPro.TextMeshProUGUI BallsLeft;
    public TMPro.TextMeshProUGUI ExtraBall;
    public TMPro.TextMeshProUGUI TimeLeft;
    public TMPro.TextMeshProUGUI Level;

    public GameObject GameOverPanel;
    public GameObject LevelCompletePanel;


    public void Update()
    {
        if(TotalScore != null) TotalScore.text = GameManager.Instance.TotalScore.ToString();
        if (TurnScore != null) TurnScore.text = GameManager.Instance.TurnScore.ToString();
        if (BallsLeft != null) BallsLeft.text = GameManager.Instance.BallsLeft.ToString();
        if (TimeLeft != null) TimeLeft.text = GameManager.Instance.TimeLeft.ToString("0.0");
        if (Level != null) Level.text = GameManager.Instance._levelData.levelNumber.ToString();
        if (GameOverPanel != null) GameOverPanel.SetActive(GameManager.Instance.LevelFailed);
        if (LevelCompletePanel != null) LevelCompletePanel.SetActive(GameManager.Instance.LevelComplete);

        ExtraBallUI();
    }

    private void ExtraBallUI()
    {
        if(ExtraBall == null) return;
        if (GameManager.Instance.TurnScore >= GameManager.Instance.ExtraBallScore)
        {
            ExtraBall.text = "Extra Ball!";
        }
        else
        {
            ExtraBall.text = GameManager.Instance.TurnScore + "/" + GameManager.Instance.ExtraBallScore;
        }
    }



}
