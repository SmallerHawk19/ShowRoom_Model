using UnityEngine;
using UnityEngine.UI;

public class FrenzyThermometer : MonoBehaviour
{
    [SerializeField] private Slider _thermometer;
    [SerializeField] private float _maxFrenzyScore = 15000;

    private void Update()
    {
        _thermometer.value = GameManager.Instance.TotalScore / _maxFrenzyScore;
    }
}
