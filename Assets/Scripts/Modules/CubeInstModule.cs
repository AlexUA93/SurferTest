using System.Collections.Generic;
using UnityEngine;

public class CubeInstModule : Module
{
    private const int kCount = 50;
    private GameObject _cube;

    public override void Init(List<GameObject> gameObjects)
    {
        foreach (var gob in gameObjects)
        {
            if (gob.tag == "Cube")
                _cube = gob;

            if (_cube != null)
                break;
        }

        if (_cube == null)
        {
            Debug.LogWarning("Didn't set Cube");
            return;
        }

        Start();
    }

    public override void Start()
    {
        for (int i = 0; i < kCount; i++)
        {
            var cube = GameObject.Instantiate(_cube, Vector3.zero, new Quaternion(0, 0, 0, 0));
            cube.SetActive(false);
            var pool = ObjectManager.FindByTag("Pool");
            var pClass = pool.GetComponent<Pool>();
            pClass.Add(cube);
        }
    }

}
