using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _StreetLamps;
    [SerializeField] private float _LampOffset;
    [SerializeField] private GameObject _Buildings;
    [SerializeField] private float _BuildingOffset;
    [SerializeField] private float _Timer;
    [SerializeField] private float _SpawnRate;

    // Update is called once per frame
    void Update()
    {
        // Instantiate(_StreetLamps, new Vector3(transform.position.x + _LampOffset, transform.position.y, transform.position.z), new Quaternion(0,90,0,90));
        // Instantiate(_StreetLamps, new Vector3(transform.position.x - _LampOffset, transform.position.y, transform.position.z), new Quaternion(0,90,0,90));
        // Instantiate(_Buildings, new Vector3(transform.position.x + _BuildingOffset, transform.position.y, transform.position.z), new Quaternion(0,-36,0,92));
        // Instantiate(_Buildings, new Vector3(transform.position.x - _BuildingOffset, transform.position.y, transform.position.z), new Quaternion(0,36,0,92));
    }

    public void spawnElement(GameObject objectToSpawn, float offset, Quaternion rotation)
    {
        Instantiate(objectToSpawn, new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), rotation);
    }
}
