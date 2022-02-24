using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerView _playerView;
    private PlayerModel _playerModel;

    public PlayerController(PlayerView playerView)
    {
        _playerView = playerView;
        _playerModel = new PlayerModel();
    }

    public void Move(Vector3 direction)
    {
        _playerView.Move(direction);
    }
}
