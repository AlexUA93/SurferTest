using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _trackSpawn;
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private GameObject[] _trackAtStart;
    private List<GameObject> _spawnTrack;
    private Transform _nextSpawnPoint;
    private List<TrackController> _trackControllers;

    public Action Spawn;

    private void Awake()
    {
        _spawnTrack = new List<GameObject>();
        _trackControllers = new List<TrackController>();
        Spawn += SpawnTrack;
        for (int i = 0; i < _trackAtStart.Length; i++)
        {
            var track = _trackAtStart[i];
            if (track.tag == "SpawnTrack")
            {
                AddTrack(track.GetComponent<TrackView>());
            }
        }
        Init();
    }

    private void Init()
    {
        _nextSpawnPoint = _spawnPoint; 
    }

    private void SpawnTrack()
    {
        if (_spawnTrack.Count != 10)
        {
            var track = Instantiate(_trackSpawn, _nextSpawnPoint.position, transform.rotation, transform);
            _spawnTrack.Add(track);
            AddTrack(track.GetComponent<TrackView>());
            SetNextSpawnPos();
        }
        else
        {
            var track = _spawnTrack[0];
            _spawnTrack.Remove(track);
            track.transform.position = _nextSpawnPoint.position;
            SetNextSpawnPos();
            _spawnTrack.Add(track);

            var trackController = _trackControllers[0];
            _trackControllers.Remove(trackController);
            trackController.SpawnCube();
            _trackControllers.Add(trackController);
        }
    }

    private void AddTrack(TrackView trackView)
    {
        TrackController trackController = new TrackController(trackView);
        _trackControllers.Add(trackController);
    }

    private void SetNextSpawnPos()
    {
        _nextSpawnPoint.position += Vector3.forward * 15f; 
    }
}
