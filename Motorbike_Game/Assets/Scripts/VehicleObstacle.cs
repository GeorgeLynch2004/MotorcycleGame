using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleObstacle : MonoBehaviour
{
    [SerializeField] private float _VehicleSpeed;
    [SerializeField] private Rigidbody _RigidBody;
    [SerializeField] public GameSessionManager _GameSessionManager;

    private void Start() 
    {   
        _GameSessionManager = GameObject.Find("GameSessionManager").GetComponent<GameSessionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _VehicleSpeed = _GameSessionManager.GetVehicleSpeed();
        Vector3 _Velocity = _RigidBody.velocity;

        _Velocity = (Vector3.forward * _VehicleSpeed * Time.deltaTime);        

        _RigidBody.velocity = _Velocity;
    }
}
