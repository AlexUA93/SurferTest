using System.Collections.Generic;
using UnityEngine;

public class TrackView : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    [SerializeField]
    private GameObject _wall;
    [SerializeField]
    private List<Transform> _cubeSpawnPoint;
    [SerializeField]
    private List<Transform> _wallSpawnPoint;
    [SerializeField]
    private Pool _pool;
    private float _nextYPosition;

    public void SpawnWall(int[] wallsCount)
    {
        for (int i = 0; i < wallsCount.Length; i++)
        {
            _nextYPosition = 0;
            CreateWall(_wallSpawnPoint[i], wallsCount[i]);
        }
    }

    private void CreateWall(Transform spawnPoint, int count)
    {
        for (int i = 0; i < count; i++)
        {
            spawnPoint.position += Vector3.up * _nextYPosition;
            var wall = Instantiate(_wall, spawnPoint.position, transform.rotation, transform);
            ChangeScale(wall);
            _nextYPosition = 1f;
        }
    }

    public void SpawnCube()
    {
        for (int i = 0; i < _cubeSpawnPoint.Count; i++)
        {
            
            var point = _cubeSpawnPoint[i];
            var position = point.position + Vector3.right * Random.Range(-2f, 2f);
            if (_pool.CheckCount())
            {
                var cube = _pool.Take();
                cube.transform.position = position;
                cube.transform.parent = transform;
            }
            else
                ChangeScale(Instantiate(_cube, position, transform.rotation, transform));
        }
    }

    private void ChangeScale(GameObject cube)
    {
        cube.transform.localScale = new Vector3(cube.transform.localScale.x / 5, cube.transform.localScale.y / 5, cube.transform.localScale.z / 30);
    }
}
