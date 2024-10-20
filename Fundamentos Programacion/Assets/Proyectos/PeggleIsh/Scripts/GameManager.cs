using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public bool IsBallInPlay = false;
    [HideInInspector] public List<GameObject> ActivatedPoppers = new List<GameObject>();

    public int BallsLeft = 5;

    public int TotalScore = 0;
    public int TurnScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void StartTurn()
    {
        IsBallInPlay = true;
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
        popper.GetComponent<Popper>().ActivatePopper();
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

}
