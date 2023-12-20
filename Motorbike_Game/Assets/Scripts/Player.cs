using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _StrafeSpeed;
    [SerializeField] private Animator _Animator;
    [SerializeField] private GameSessionManager _GameSessionManager;
    [SerializeField] private Transform _Graphics;
    private float _OpponentSpeed;
    private float _IncreasingSpeed;
    private bool _ThrottlePermitted;


    private void Start() {
        _GameSessionManager = GameObject.Find("GameSessionManager").GetComponent<GameSessionManager>();
        _OpponentSpeed = _GameSessionManager.GetVehicleSpeed();
        _ThrottlePermitted = true;
    }

    private void FixedUpdate() 
    {
        Movement();
        FuelSystem();
    }

    private void Movement()
    {
        Vector3 _Position = transform.position;
        Vector3 _Rotation = _Graphics.localEulerAngles;

        if (!_ThrottlePermitted){return;}

        if (Input.GetKey(KeyCode.Space))
        {
            _Animator.SetBool("Wheelie", true);

            _IncreasingSpeed = (_IncreasingSpeed + 50);
            _GameSessionManager.SetVehicleSpeed(_IncreasingSpeed);
            
            _Rotation.z = 0f;
        }
        else
        {
            _Animator.SetBool("Wheelie", false);

            if (_GameSessionManager.GetVehicleSpeed() > _OpponentSpeed)
            {
                _IncreasingSpeed = (_IncreasingSpeed - 50);
                _GameSessionManager.SetVehicleSpeed(_IncreasingSpeed);
            }
            else
            {
                _GameSessionManager.SetVehicleSpeed(_OpponentSpeed);
                _IncreasingSpeed = _OpponentSpeed;
            }


            if (Input.GetKey(KeyCode.A) && RoadRaycast(.2f))
            {
                _Position.x += _StrafeSpeed * Time.deltaTime;
                _Rotation.z = -15f;
            }
            else if (Input.GetKey(KeyCode.D) && RoadRaycast(-.2f))
            {
                _Position.x -= _StrafeSpeed * Time.deltaTime;
                _Rotation.z = 15f;
            }
            else
            {
                _Rotation.z = 0f;
            }
        }

        transform.position = _Position;
        _Graphics.localEulerAngles = _Rotation;
    }

    private void FuelSystem()
    {
        float _CurrentFuel = _GameSessionManager.GetFuel();

        if (_CurrentFuel < .1f)
        {
            // Present warning to player
        }
        if (_CurrentFuel <= 0)
        {
            _ThrottlePermitted = false;
            _GameSessionManager.SetFuel(0f);
        }
        else
        {
            _ThrottlePermitted = true;
        }

        _GameSessionManager.SetFuel(_CurrentFuel -.01f * Time.deltaTime);
    }

    private bool RoadRaycast(float offset)
    {
        RaycastHit _Hit;

        if (Physics.Raycast(new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Vector3.down, out _Hit))
        {
            if (_Hit.collider.CompareTag("Ground"))
            {
                Debug.Log("Ground found");
                Debug.DrawRay(new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Vector3.down, Color.green);
                return true;
            }
        }

        Debug.DrawRay(new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Vector3.down, Color.red);
        return false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Vehicle")
        {
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "Coin")
        {
            _GameSessionManager.IncreaseScore(1f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Fuel")
        {
            _GameSessionManager.SetFuel(1f);
            Destroy(other.gameObject);
        }
    }
}
