using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent (typeof(ARPlaneManager))]
public class SpawnManager : MonoBehaviour
{
    private ARPlaneManager _planeManager;
    private List<Vector3> _spawnPoints = new List<Vector3>();
    private int _timeToSpawn;
    public int RespawnRateSeconds = 5;
    public UnityEngine.Object Model;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _planeManager = GetComponent<ARPlaneManager>();
        _planeManager.trackablesChanged.AddListener(OnTrackablesChanged);
        _timeToSpawn = RespawnRateSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (--_timeToSpawn == 0)
        {
            _timeToSpawn = RespawnRateSeconds;
            foreach (var spawnPoint in _spawnPoints)
            {
                GameObject.Instantiate(Model, spawnPoint, Quaternion.identity);
            }
        }
    }

    private void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARPlane> trackables)
    {
        foreach (var trackable in trackables.added)
        {
            _spawnPoints.Add(trackable.center);
        }
    }
}
