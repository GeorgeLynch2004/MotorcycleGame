using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] private float _VehicleSpeed;
    [SerializeField] private float _Score;
    [SerializeField] private float _Fuel;
    [SerializeField] public float _BaseSpeed;
    [SerializeField] private float _IncreaseInterval;
    private float _Timer;


    private void Start() {
        _Fuel = 1f;
        _BaseSpeed = _VehicleSpeed;
    }

    private void Update() {

        // Check for player
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            GameOver();
        }

        _Timer += Time.deltaTime;

        if (_Timer >= _IncreaseInterval)
        {
            _BaseSpeed += 50;
            SetVehicleSpeed(_BaseSpeed);
            _Timer = 0;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
    public void SetVehicleSpeed(float speed)
    {
        _VehicleSpeed = speed;
    }

    public float GetBaseSpeed()
    {
        return _BaseSpeed;
    }

    public float GetVehicleSpeed()
    {
        return _VehicleSpeed;
    }

    public void IncreaseScore(float value)
    {
        _Score += value;
    }

    public float GetScore()
    {
        return _Score;
    }

    public void SetFuel(float amount)
    {
        _Fuel = amount;
    }

    public float GetFuel()
    {
        return _Fuel;
    }
}
