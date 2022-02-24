using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TrackManager _trackManager;
    [SerializeField]
    private PlayerView _playerView;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = new PlayerController(_playerView);
    }

    private void FixedUpdate()
    {
        _playerController.Move(Vector3.forward * 4f);
    }

    public void Spawn()
    {
        _trackManager.Spawn.Invoke();
    }

    public void PlayerSideMove(Vector3 direction)
    {
        _playerController.Move(direction * 8f);
    }
}
