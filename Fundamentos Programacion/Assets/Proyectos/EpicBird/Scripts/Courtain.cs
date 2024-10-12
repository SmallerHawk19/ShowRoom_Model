
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Courtain : MonoBehaviour
{
    public GameObject CourtainSprite;
    public GameObject GameOverSign;

    public Vector3 TargetPosition;  
    public float MoveTime = 2.0f;  

    private Vector3 startPosition;
    private float elapsedTime = 0;

    private bool liftCourtain = false;
    private bool dropCourtain = false;

    void Start()
    {
        startPosition = transform.position;  
    }

    private void Update()
    {
        LiftCourtain();
        DropCourtain();
    }

    public void ShowBegins()
    {
        liftCourtain = true;
        StartCoroutine(LoadGame());
    }

    public void ShowEnds()
    {
        GameOverSign.SetActive(true);
        dropCourtain = true;
        StartCoroutine(LoadMenu());
    }

    private void LiftCourtain()
    {
        if (liftCourtain == true)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, TargetPosition, elapsedTime / MoveTime);
        }
    }

    private void DropCourtain()
    {
        if (dropCourtain == true)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, TargetPosition, elapsedTime / MoveTime);
        }
    }


    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EpicBird");
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
