using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    private const int kTrackatStart = 3;
    private const int kMultiplyPosition = 9;
    private const float kTimer = 3f;

    [SerializeField]
    private Pool _pool;
    [SerializeField]
    private EventManager _eventManager;
    [SerializeField]
    private GameObject _spawn;
    private Vector3 _spawnAtStart;
    private List<MoveToTarget> _moveToTargets;


    protected void Awake()
    {
        _moveToTargets = new List<MoveToTarget>();

        ModuleInitializer.Init();
        _spawnAtStart = _spawn.transform.position;
        Prepare();
        _eventManager.Restart += Restart;
       _eventManager.SpawnTrack += NextTrackWhithMove;
    }

    private void Restart()
    {
        if (_eventManager.DestroyObjectOnTrack != null)
            _eventManager.DestroyObjectOnTrack.Invoke();
        if (_eventManager.RebuildAdditional != null)
            _eventManager.RebuildAdditional.Invoke();
        _spawn.transform.position = _spawnAtStart;
        Prepare();
    }

    private void Prepare()
    {
        for (int i = 0; i < kTrackatStart; i++)
        {
            NextTrack(false);
        }
    }

    private void NextTrackWhithMove()
    {
        NextTrack(true);
    }

    private void NextTrack(bool move)
    {
        var track = _pool.Take();
        track.Module.Start();
        if (move)
        {
            Vector3 endPosition = track.Track.transform.position;
            track.Track.transform.position += Vector3.up * kMultiplyPosition;
            var moveToTarget = new MoveToTarget(track.Track, endPosition, kTimer);
            _moveToTargets.Add(moveToTarget);
        }
    }

    protected void FixedUpdate()
    {
        for (int i = _moveToTargets.Count - 1; i >= 0; i--)
        {
            var target = _moveToTargets[i];
            if (target.IsTargetOnPoint())
                _moveToTargets.Remove(target);
        }
    }
}
