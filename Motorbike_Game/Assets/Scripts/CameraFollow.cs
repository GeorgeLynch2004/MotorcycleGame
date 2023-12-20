using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _Player;
    [SerializeField] private Vector3 _CameraPositionOffset;
    [SerializeField] private Vector3 _CameraRotationOffset;

    private void Start() {
        _Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update() {
        transform.position = new Vector3(_Player.position.x + _CameraPositionOffset.x, _Player.position.y + _CameraPositionOffset.y, _Player.position.z + _CameraPositionOffset.z);
        transform.localEulerAngles = new Vector3(_Player.localEulerAngles.x + _CameraRotationOffset.x, _Player.localEulerAngles.y + _CameraRotationOffset.y, _Player.localEulerAngles.z + _CameraRotationOffset.z);
    }
}
