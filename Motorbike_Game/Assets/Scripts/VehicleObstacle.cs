using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleObstacle : MonoBehaviour
{
    [SerializeField] private float _VehicleSpeed;
    [SerializeField] private Rigidbody _RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _Velocity = _RigidBody.velocity;

        _Velocity = Vector3.forward * _VehicleSpeed * Time.deltaTime;

        _RigidBody.velocity = _Velocity;
    }
}
