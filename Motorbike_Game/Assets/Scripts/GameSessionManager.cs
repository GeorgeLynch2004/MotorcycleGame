using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] private float _VehicleSpeed;
    [SerializeField] private float _Score;
    [SerializeField] private float _Fuel;

    private void Start() {
        _Fuel = 1f;
    }
 
    public void SetVehicleSpeed(float speed)
    {
        _VehicleSpeed = speed;
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
