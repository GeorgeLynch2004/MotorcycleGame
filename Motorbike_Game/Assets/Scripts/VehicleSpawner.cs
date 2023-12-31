using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private float _Lane1X;
    [SerializeField] private float _Lane2X;
    [SerializeField] private float _Lane3X;
    [SerializeField] private float _FuelLaneX;
    [SerializeField] private GameObject _FuelStation;
    [SerializeField] private GameObject[] _Vehicles;
    [SerializeField] private float _SpawnRate;
    [SerializeField] private float _Timer;
    private GameSessionManager _GameSessionManager;
    private bool _FuelStationAvailable;

    // Start is called before the first frame update
    void Start()
    {
        _GameSessionManager = GameObject.Find("GameSessionManager").GetComponent<GameSessionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;

        if (_Timer >= _SpawnRate)
        {
            float[] _Lanes = new float[3]{_Lane1X, _Lane2X, _Lane3X};
            int _RandomVehicleIndex = Random.Range(0, _Vehicles.Length);
            spawnVehicle(_Vehicles[_RandomVehicleIndex], getRandomLane(_Lanes));
            _Timer = 0f;
        }

        if (_GameSessionManager.GetFuel() > .9f)
        {
            _FuelStationAvailable = true;
        }

        if (_GameSessionManager.GetFuel() < .1f && _FuelStationAvailable)
        {
            spawnVehicle(_FuelStation, _FuelLaneX);
            _FuelStationAvailable = false;
        }
    }

    private void spawnVehicle(GameObject _VehicleToSpawn, float _LaneOffsetX)
    {
        Instantiate(_VehicleToSpawn, new Vector3(transform.position.x + _LaneOffsetX, _VehicleToSpawn.transform.position.y, transform.position.z), new Quaternion(0,0,0,0));
    }


    private float getRandomLane(float[] _Lanes)
    {
        int _RandomIndex = Random.Range(0, _Lanes.Length);
        return _Lanes[_RandomIndex];
    }
}
