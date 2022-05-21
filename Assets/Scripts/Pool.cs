using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private EventManager _eventManager;

    private List<TrackStruct> _tracks = new List<TrackStruct>();
    private List<GameObject> _cubes = new List<GameObject>();
    private int _next;

    private void Awake()
    {
        _eventManager.Restart += Restart;
    }

    public void Add(TrackStruct track)
    {
        _tracks.Add(track);
    }

    public void Add(GameObject cube)
    {
        _cubes.Add(cube);
    }

    public TrackStruct Take()
    {
        var track = _tracks[_next];
        SetNext();
        return track;
    }

    public GameObject TakeCube()
    {
        var cube = _cubes.Count > 0? _cubes[0] : null;
        if (cube != null)
            _cubes.Remove(cube);
        return cube;
    }

    private void SetNext()
    {
        _next = _tracks.Count - 1 > _next ? _next + 1 : 0;
    }

    private void Restart()
    {
        foreach (var cube in _cubes)
        {
            cube.SetActive(false);
        }

        foreach (var track in _tracks)
        {
            track.Track.SetActive(false);
        }
    }
}
