using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackView : MonoBehaviour, IEnvironmentView
{
    [SerializeField]
    protected Bounds _bounds;
    [SerializeField]
    protected List<GameObject> _spawnPoint;
    [SerializeField]
    protected DrawLine _drawLine;
    protected Pool _pool;
    private EventManager _eventManager;

    protected void Awake()
    {
        var pool = ObjectManager.FindByTag("Pool");
        _pool = pool.GetComponent<Pool>();

        var ew = ObjectManager.FindByTag("EventManager");
        _eventManager = ew.GetComponent<EventManager>();
    }

    private void Start()
    {
        if (tag == "SimpleTrack")
        {
            Restart();
            _eventManager.RebuildAdditional += Restart;
        }
    }

    private void Restart()
    {
        SpawnCube();
        if (_drawLine != null)
            _drawLine.Rebuild();
    }

    public virtual void Rebuild(GameObgectType type, List<int> value)
    {
       
    }

    protected void SpawnCube()
    {
        foreach (var spawn in _spawnPoint)
        {
            var cube = _pool.TakeCube();
            if (cube != null)
            {
                cube.transform.position = GetSpawnPosition(spawn.transform.position);
                cube.transform.parent = transform;
                cube.SetActive(true);
            }
        }
    }

    private Vector3 GetSpawnPosition(Vector3 pos)
    {
        float posX = Random.Range(_bounds.min.x, _bounds.max.x);
        pos = new Vector3(posX, pos.y, pos.z);
        return pos;
    }
}
