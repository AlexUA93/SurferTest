using System.Collections.Generic;
using UnityEngine;

public class ChildMove : MonoBehaviour
{
    private const float kSpeed = 6f;

    [SerializeField]
    private EventManager _eventManager;
    [SerializeField]
    private List<GameObject> AdditionalObjects;

    private List<GameObject> _children;
    private List<MoveToTarget> _moveToTargets;

    protected void Awake()
    {
        _children = new List<GameObject>();
        _moveToTargets = new List<MoveToTarget>();
        _eventManager.RemoveCube += RemoveChild;
        _eventManager.AddCube += AddChild;
        _eventManager.Move += Move;
    }

    protected void FixedUpdate()
    {
        for (int i = _moveToTargets.Count - 1; i >= 0; i--)
        {
            var move = _moveToTargets[i];
            if (move.IsTargetOnPoint())
                _moveToTargets.Remove(move);
        }
    }

    protected void AddChild(GameObject child)
    {
        _children.Add(child);
    }

    protected void RemoveChild(GameObject child)
    {
        _children.Remove(child);
    }

    protected void Move()
    {
        if (_moveToTargets.Count > 0 || _children.Count == 0)
            return;

        Vector3 endPosition = new Vector3(0, 0.5f, 0);
        var first = _children[0];
        var time = first.transform.position.y / kSpeed;

        for (int i = 0; i <= _children.Count - 1; i++)
        {
            var moveToTarget = new MoveToTarget(_children[i], gameObject.transform.parent.gameObject, endPosition, time);
            _moveToTargets.Add(moveToTarget);
            endPosition += Vector3.up;
        }

        endPosition -= new Vector3(0, 0.5f, 0);

        for (int i = 0; i <= AdditionalObjects.Count - 1; i++)
        {
            var moveToTarget = new MoveToTarget(AdditionalObjects[i], gameObject.transform.parent.gameObject, endPosition, time);
            _moveToTargets.Add(moveToTarget);
            endPosition += Vector3.up;
        }
    }
}
