
using UnityEngine;

public class PeggleUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TotalScore;
    public TMPro.TextMeshProUGUI TurnScore;
    public TMPro.TextMeshProUGUI BallsLeft;
    public TMPro.TextMeshProUGUI ExtraBall;

    public void Update()
    {
        TotalScore.text = GameManager.Instance.TotalScore.ToString();
        TurnScore.text = GameManager.Instance.TurnScore.ToString();
        BallsLeft.text = GameManager.Instance.BallsLeft.ToString();
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
