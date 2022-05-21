using System.Collections.Generic;
using UnityEngine;

public class TrackView : SimpleTrackView
{
    private const int kCobeInLine = 5;

    [SerializeField]
    private List<GameObject> _cubeInWall;
    [SerializeField]
    private GameObject _spawnNextTrack;
   
    public override void Rebuild(GameObgectType type, List<int> value)
    {
        _spawnNextTrack.tag = "SpawnNextTrack";
        switch (type)
        {
            case GameObgectType.Wall:
                SetWallVisibility(value);
                break;
            case GameObgectType.Non:
                break;
            default:
                Debug.LogWarning($"Incorect type {type}");
                break;
        }
        SpawnCube();
        if (_drawLine != null)
            _drawLine.Rebuild();
    }

    protected void SetWallVisibility(List<int> value)
    {
        int next = 0;
        int counter = 0;
        if (value.Count > 0)
        {
            int count = value[next];
            foreach (var cube in _cubeInWall)
            {
                cube.SetActive(count >= counter);
                counter++;
                if (counter == kCobeInLine)
                {
                    next++;
                    counter = 0;
                    if (value.Count - 1 >= next)
                    {
                        count = value[next];
                    }
                }
            }
        }
    }
}
