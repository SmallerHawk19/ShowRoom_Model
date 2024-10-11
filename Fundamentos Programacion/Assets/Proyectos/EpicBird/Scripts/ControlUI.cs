using UnityEngine;


public class ControlUi : MonoBehaviour
{
    public TMPro.TextMeshProUGUI GameScore;
    public GameObject spawnPoint;
    public GameObject Obstacle;

    public float interval;
    public float elapsed_time;


    public void Update()
    {
        GameScore.text = FlappyManager.Score.ToString();

        {

            if (ImpulseForce.HP <= 0)
            {
                GameOver();
            }

            if (interval == 0)
            {
                interval = 1;
            }

            if (elapsed_time > interval)
            {
                SpawnObstacle();
            }

            elapsed_time += Time.deltaTime;
        }
    }
    public void StartGame()
    {
        FlappyManager.isGameStarted = true;
    }

    public void Pause()
    {

    }

    public void GameOver()
    {
        FlappyManager.isGameStarted = false;
        Reset();
    }

    public void Reset()
    {
        FlappyManager.Score = 0;
        GameScore.text = "0";
        ImpulseForce.HP = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void SpawnObstacle()

    {
        elapsed_time = 0;
        Instantiate(Obstacle, spawnPoint.transform.position + (Vector3.up * Random.Range(-2, 2)), Quaternion.identity);
    }


}

