using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Score;
    [SerializeField] private TextMeshProUGUI _Fuel;
    [SerializeField] private TextMeshProUGUI _Speed;
    [SerializeField] private TextMeshProUGUI _Alert;
    private GameSessionManager _GameSessionManager;

    private void Start() {
        _GameSessionManager = GameObject.Find("GameSessionManager").GetComponent<GameSessionManager>();
        _Alert.enabled = false;
    }

    private void Update() {
        _Score.text = "SCORE: " + _GameSessionManager.GetScore();

        if (_GameSessionManager.GetFuel() < .2f)
        {
            DisplayAlertMessage("[ ! Fuel low ! ]");
        }
        else
        {
            _Alert.enabled = false;
        }

        _Fuel.text = "FUEL: " + Math.Round((_GameSessionManager.GetFuel() * 100), 0) + "%";

        float displaySpeed;
        
        if (_GameSessionManager.GetBaseSpeed() == _GameSessionManager.GetVehicleSpeed())
        {
            displaySpeed = _GameSessionManager.GetBaseSpeed();
        }
        else
        {
            displaySpeed = _GameSessionManager.GetVehicleSpeed();
        }

        _Speed.text = "SPEED: " + Math.Round((displaySpeed / 10), 0) + "MPH";

    }

    private void DisplayAlertMessage(string _Text)
    {
        _Alert.text = _Text;
        _Alert.enabled = true;
    }

}
