using UnityEngine;

public class TrackController
{
    private TrackModel _trackModel;
    private TrackView _trackView;

    public TrackController(TrackView trackView)
    {
        _trackView = trackView;
        _trackModel = new TrackModel();
        SpawnWall();
        SpawnCube();
    }

    private void SpawnWall()
    {
        int[] wallsCount = new int[_trackModel.MaxCount];
        for (int i = 0; i < _trackModel.MaxCount; i++)
        {
            wallsCount[i] = Random.Range(_trackModel.MinCount, _trackModel.MaxCount);
        }

        _trackView.SpawnWall(wallsCount);
    }

    public void SpawnCube()
    {
        _trackView.SpawnCube();
    }
}
