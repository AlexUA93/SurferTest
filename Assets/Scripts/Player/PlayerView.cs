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
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private EventManager eventManager;
    [SerializeField]
    private List<Rigidbody> _rigidbodies;
    [SerializeField]
    private Pool _pool;

    private Vector3 _position;
    private Vector3 _startPosition;


    protected void Awake()
    {
        eventManager.RemoveCube += RemoveCube;
        eventManager.RebuildAdditional += Restart;
        _position = new Vector3(0, _cubeHolder.transform.position.y, 0) + Vector3.up;
        _startPosition = transform.position;
    }

    public void Restart()
    {
        _position = new Vector3(0, _cubeHolder.transform.position.y, 0);
        transform.position = _startPosition;
        var cube = _pool.TakeCube();
        if (cube != null)
        {
            cube.tag = "CubeInHolder";
            AddCube(cube);
        }    
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
            if (eventManager.AddCube != null)
                eventManager.AddCube.Invoke(other.gameObject);
            AddCube(other.gameObject);
        }
    }

    private void AddCube(GameObject cube)
    {
        var pos = _cubeHolder.transform.position;
        _position = new Vector3(pos.x, _position.y, pos.z);
        cube.transform.position = _position;
        _position += Vector3.up;
        cube.transform.parent = _cubeHolder.transform;
        cube.SetActive(true);
        _player.transform.position = new Vector3(cube.transform.position.x, cube.transform.localPosition.y + 1, cube.transform.position.z);
        _animator.SetTrigger("Jump");
    }

    private void RemoveCube(GameObject value)
    {
        _position -= Vector3.up;
    }
}
