using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    void Update()
    {
        Game();
    }

    public void Game()
    {
        SceneManager.LoadScene("Peggleish");
    }

}
