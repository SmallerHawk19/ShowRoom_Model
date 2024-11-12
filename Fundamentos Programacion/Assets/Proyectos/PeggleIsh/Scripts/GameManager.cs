using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float ExtraBallScore = 1000;
    public int BallsLeft = 5;
    public float TimeLeft = 30;

    [HideInInspector] public bool IsBallInPlay = false;
    [HideInInspector] public List<GameObject> ActivatedPoppers = new List<GameObject>();

    [HideInInspector] public int TotalScore = 0;
    [HideInInspector] public int TurnScore = 0;

    private bool _extraBall = false;

    //public static bool isGameStarted;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        AddBalls();
        ReloadGame();
    }

    public void StartTurn()
    {
        IsBallInPlay = true;
        _extraBall = false;
        BallsLeft--;
        TimeOut();
    }

    public void EndTurn()
    {
        ActivatePoppers();
        TotalScore += TurnScore;
        Debug.Log("Turn Score: " + TurnScore);
        TurnScore = 0;
        IsBallInPlay = false;
        

        Debug.Log("Total Score: " + TotalScore);
    }

    public void AddPopper(GameObject popper)
    {
        TurnScore += popper.GetComponent<Popper>()._scoreValue;
        ActivatedPoppers.Add(popper);
    }

    private void ActivatePoppers()
    {
        foreach (GameObject popper in ActivatedPoppers)
        {
            popper.GetComponent<Popper>().DestroyPopper();
        }
        ActivatedPoppers.Clear();
    }

    private void AddBalls()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BallsLeft++;
        }

        if (TurnScore >= ExtraBallScore && !_extraBall)
        {
            BallsLeft++;
            _extraBall = true;
            Debug.Log("Extra Ball!");
        }
    }

    private void ReloadGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("PeggleIsh");
        }
    }

    public void TimeOut()
    {
        if (TimeLeft <= 0)
        {
            SceneManager.LoadScene("FrenzyMode");
        }
    }
}
