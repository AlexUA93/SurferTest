using UnityEngine;
using UnityEngine.EventSystems;

public class TapManager : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private EventManager _eventManager;
    private BaseInput _input;
    private const int _none = 0;
    private const int _tap = 1;

    private Vector2 touchPosition;
    private Vector2 lastPosition;

    private void Update()
    {
        if (null == _input && EventSystem.current.currentInputModule != null)
        {
            _input = EventSystem.current.currentInputModule.input;
        }

        var touch = GetTouch();

        if (touch.fingerId == _tap)
        {
            if (_eventManager.Tap != null)
                _eventManager.Tap.Invoke();
            touchPosition = touch.position;
            MovePlayer();
        }
        else {
            lastPosition = touchPosition = Vector3.zero;
        }
    }

    private Touch GetTouch()
    {
        Touch touch = new Touch();
        if (_input != null)
        {
            if (_input.touchCount > 0)
            {
                touch = _input.GetTouch(0);
                touch.fingerId = _tap;
                return touch;
            }

            if (_input.GetMouseButton(0))
            {
                touch.position = _input.mousePosition;
                touch.fingerId = _tap;
                return touch;
            }
        }

        touch.fingerId = _none;

        return touch;
    }

    private void MovePlayer()
    {
        lastPosition = lastPosition == Vector2.zero ? touchPosition : lastPosition;
        var direction = lastPosition.x < touchPosition.x ? Vector3.right : lastPosition.x > touchPosition.x ? Vector3.left : Vector3.zero;
        if(direction != Vector3.zero && _eventManager.Hold != null)
            _eventManager.Hold.Invoke();
        lastPosition = touchPosition;
        _gameManager.PlayerSideMove(direction);
    }
}
