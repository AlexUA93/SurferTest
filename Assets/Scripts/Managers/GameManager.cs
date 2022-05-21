using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float speed = 8f;


    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private EventManager _eventManager;
    private PlayerController _playerController;
    private Vector3 _cameraStartPos;
    private bool _gameStart;

    private void Awake()
    {
        _playerController = new PlayerController(_playerView);
        _cameraStartPos = Camera.main.transform.position;
        _eventManager.Hold += GameStart;
        _eventManager.EndGame += GameEnd;
        _eventManager.Restart += GameStart;
    }

    private void FixedUpdate()
    {
        if (_gameStart)
        {
            _playerController.Move(Vector3.forward * speed);
            Camera.main.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    public void PlayerSideMove(Vector3 direction)
    {
        if (_gameStart)
        {
            _playerController.Move(direction * 8f);
        }
    }

    private void GameStart()
    {
        _gameStart = true;
        Camera.main.transform.position = _cameraStartPos;
        if (_eventManager.Hold != null)
            _eventManager.Hold -= GameStart;
    }

    private void GameEnd()
    {
        _gameStart = false;
    }
}
