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
    private int _popperCount = 0;


    [HideInInspector] public bool IsBallInPlay = false;
    [HideInInspector] public List<GameObject> ActivatedPoppers = new List<GameObject>();

    [HideInInspector] public int TotalScore = 0;
    [HideInInspector] public int TurnScore = 0;

    [SerializeField] public bool IsFrenzyMode = false;
    [SerializeField] private LevelDataSO _levelData;


    private bool _extraBall = false;

    [HideInInspector] public bool isGameStarted = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        AddBalls();
        ReloadGame();
        if(isGameStarted)
        {
            TimeLeft -= Time.deltaTime;
            TimeOut();
        }     
    }

    public void StartTurn()
    {
        IsBallInPlay = true;
        _extraBall = false;
        BallsLeft--;
        isGameStarted = true;
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
            if (IsFrenzyMode)
            {
                SceneManager.LoadScene("FrenzyMode");
            } else
            {
                SceneManager.LoadScene("PeggleIsh");
            }
        }
    }

    private void TimeOut()
    {
        if(!IsFrenzyMode)
        {
            if (TimeLeft >= 0 && _popperCount <= 0)
            {
                SceneManager.LoadScene("FrenzyMode");
            }
            else if (TimeLeft <= 0)
            {
                SceneManager.LoadScene("PeggleIsh");
            }
        }
        else
        {
            if(TimeLeft <= 0)
            {
                BallsLeft = 0;
                _levelData.AddLevel();
                SceneManager.LoadScene("PeggleIsh");
            }
        }
    }

    public void AddPopperCount()
    {
        _popperCount++;
    }
    public void RemovePopperCount()
    {
        _popperCount--;
    }
}
