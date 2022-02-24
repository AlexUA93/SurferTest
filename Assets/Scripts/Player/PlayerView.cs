using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Bounds _bounds;
    [SerializeField]
    private GameObject _cubeHolder;
    [SerializeField]
    private GameObject _player;
    private Vector3 _position;

    public void Reset()
    {
        _position = Vector3.zero;
    }

    public void Move(Vector3 direction)
    {
        var pos = transform.position + direction * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, _bounds.min.x, _bounds.max.x);
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            other.gameObject.tag = "CubeInHolder";
            AddCube(other.gameObject);
        }
    }

    private void AddCube(GameObject cube)
    {
        cube.transform.position = _cubeHolder.transform.position + _position;
        _position += Vector3.up;
        cube.transform.parent = _cubeHolder.transform;
        _player.transform.position = _cubeHolder.transform.position + _position;

    }

    public void RemoveCube()
    {
        _position -= Vector3.up;
    }
}
