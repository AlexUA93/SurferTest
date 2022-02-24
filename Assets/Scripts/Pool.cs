using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<GameObject> _cubes;

    private void Awake()
    {
        _cubes = new List<GameObject>();
    }

    public void Add(GameObject cube)
    {
        cube.SetActive(false);
        cube.transform.parent = transform;
        _cubes.Add(cube);
    }

    public GameObject Take()
    {
        GameObject cube = null;
        if (CheckCount())
        {
            cube = _cubes[0];
            _cubes.Remove(cube);
        }

        return cube;
    }

    public bool CheckCount()
    {
        return _cubes.Count > 0;
    }
}
