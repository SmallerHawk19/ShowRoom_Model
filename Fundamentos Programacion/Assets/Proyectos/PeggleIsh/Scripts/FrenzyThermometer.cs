using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrenzyThermometer : MonoBehaviour
{
    [SerializeField] private Slider _thermometer;
    public float _maxValue = 100;
    public float _minValue = 0;

    public void Update()
    {
        _thermometer.value = (_minValue / _maxValue);
    }
}
