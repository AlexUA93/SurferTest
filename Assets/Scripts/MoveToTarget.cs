using UnityEngine;

public enum MoveType
{
    ToPoint =0,
    InParen =1
}

public class MoveToTarget
{
    private GameObject _target;
    private GameObject _parent;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _time;
    private float _timeSpend;
    private MoveType _moveType;

    public MoveToTarget(GameObject traget, Vector3 vector, float time)
    {
        _target = traget;
        _startPosition = _target.transform.position;
        _endPosition = vector;
        _time = time;
        _timeSpend = 0;
        _moveType = MoveType.ToPoint;
    }

    public MoveToTarget(GameObject traget, GameObject parent, Vector3 vector, float time)
    {
        _target = traget;
        _parent = parent;
        _startPosition = _target.transform.position;
        _endPosition = vector;
        _time = time;
        _timeSpend = 0;
        _moveType = MoveType.InParen;
    }

    public bool IsTargetOnPoint()
    {
        switch (_moveType)
        {
            case(MoveType.InParen):
                var pos = _parent.transform.position;
                _endPosition = new Vector3(pos.x, _endPosition.y, pos.z);
                break;    
        }
        _timeSpend += Time.deltaTime / _time;
        _target.transform.position = Vector3.Lerp(_startPosition, _endPosition, _timeSpend);
        return _target.transform.position == _endPosition;
    }
}
