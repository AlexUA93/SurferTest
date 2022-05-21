using System.Collections.Generic;
using UnityEngine;

public class TrackModuleWhitWall : Module
{
    private const float distance = 30;

    private GameObject _road;
    private GameObject _track;
    private GameObject _spawnPoint;
    private GameObject _trackOnRoad;

    private TrackController _trackController;
    private Pool _pool;

    public override void Init(List<GameObject> gameObjects)
    {
        foreach (var gob in gameObjects)
        {
            if (gob.tag == "SpawnTrackWhithWall")
                _track = gob;

            if (_track != null)
                break;
        }

        if (_track == null)
        {
            Debug.LogWarning("Didn't set track whith wall");
            return;
        }
        SetAdditionalParameter();
        PrepareTrack();
    }

    private void SetAdditionalParameter()
    {
        _spawnPoint = ObjectManager.FindByTag("SpawnPoint");
        _road = ObjectManager.FindByTag("Road");
        var pool = ObjectManager.FindByTag("Pool");
        _pool = pool.GetComponent<Pool>();
    }

    private void PrepareTrack()
    {
        _trackOnRoad = GameObject.Instantiate(_track, _spawnPoint.transform.position, _spawnPoint.transform.rotation) as GameObject;
        _trackOnRoad.transform.parent = _road.transform;
        _trackOnRoad.SetActive(false);
        var view = _trackOnRoad.GetComponent<IEnvironmentView>();
        var model = new TrackModel();
        _trackController = new TrackController(view, model);
        var stract = new TrackStruct(_trackOnRoad, this);
        _pool.Add(stract);

    }

    public override void Start()
    {
        _trackOnRoad.SetActive(true);
        var position = _spawnPoint.transform.position;
        _trackOnRoad.transform.position = position;
        _trackController.Rebuild();

        _spawnPoint.transform.position += Vector3.forward * distance;
    }
}
