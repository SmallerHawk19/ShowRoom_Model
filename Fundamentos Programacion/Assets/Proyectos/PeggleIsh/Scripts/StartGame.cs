using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{


    public void Game()
    {
        //GameManager.isGameStarted = true;
        SceneManager.LoadScene("Peggleish");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Peggle Main Menu");
    }
}
