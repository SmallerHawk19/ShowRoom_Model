using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int TransSpeedX = 50;

    // Update is called once per frame
    void Update()
    {
        if (FlappyManager.isGameStarted == true)
        {
            Obstaculo();
        }
    }


    public void Obstaculo()
    {
        this.transform.Translate(-Time.deltaTime, 0, 0);
    }
}
