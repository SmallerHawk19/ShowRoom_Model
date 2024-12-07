
using UnityEngine;

public class PeggleUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TotalScore;
    public TMPro.TextMeshProUGUI TurnScore;
    public TMPro.TextMeshProUGUI BallsLeft;
    public TMPro.TextMeshProUGUI ExtraBall;
    public TMPro.TextMeshProUGUI TimeLeft;
    public TMPro.TextMeshProUGUI Level;


    public void Update()
    {
        TotalScore.text = GameManager.Instance.TotalScore.ToString();
        TurnScore.text = GameManager.Instance.TurnScore.ToString();
        BallsLeft.text = GameManager.Instance.BallsLeft.ToString();
        TimeLeft.text = GameManager.Instance.TimeLeft.ToString("0.0");
        Level.text = GameManager.Instance._levelData.levelNumber.ToString();

        ExtraBallUI();
    }

    private void ExtraBallUI()
    {
        if(GameManager.Instance.TurnScore >= GameManager.Instance.ExtraBallScore)
        {
            ExtraBall.text = "Extra Ball!";
        }
        else
        {
            ExtraBall.text = GameManager.Instance.TurnScore + "/" + GameManager.Instance.ExtraBallScore;
        }
    }



}
