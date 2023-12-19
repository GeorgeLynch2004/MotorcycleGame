using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _StrafeSpeed;

    private void Update() 
    {
        movement();
    }

    private void movement()
    {
        Vector3 _Position = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            _Position.x += _StrafeSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _Position.x -= _StrafeSpeed * Time.deltaTime;
        }

        if (_Position.x > 1.25f)
        {
            _Position.x = 1.25f;
        }
        if (_Position.x < -1.25f)
        {
            _Position.x = -1.25f;
        }

        transform.position = _Position;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Vehicle")
        {
            Time.timeScale = 0;
        }
    }
}
