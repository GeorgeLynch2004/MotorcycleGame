using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElements : VehicleObstacle
{
    [SerializeField] private BackgroundSpawner _Spawner;

    private void Start() {
        _Spawner = GameObject.Find("BackgroundSpawner").GetComponent<BackgroundSpawner>();
        _GameSessionManager = GameObject.Find("GameSessionManager").GetComponent<GameSessionManager>();
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Background")
        {
            _Spawner.spawnElement(gameObject, transform.position.x, transform.rotation);
        }    
    }
}
