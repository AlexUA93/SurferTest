using UnityEngine;

public struct TrackStruct
{
    private GameObject _track;
    private Module _module;

    public GameObject Track
    {
        get { return _track; }
    }

    public Module Module
    {
        get { return _module; }
    }

    public TrackStruct(GameObject track, Module module)
    {
        _track = track;
        _module = module;
    }
}
