using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _tapToStart;
    [SerializeField]
    private GameObject _holdToMove;
    [SerializeField]
    private GameObject _restart;
    [SerializeField]
    private EventManager _eventManager;
    [SerializeField]
    private Button _restartButton;

    protected void Awake()
    {
        _tapToStart.SetActive(true);
        _eventManager.Tap += Tap;
        _eventManager.Hold += Hold;
        _eventManager.EndGame += EndGame;
        _restartButton.onClick.AddListener(Restart);
    }

    private void Tap()
    {
        _tapToStart.SetActive(false);
        _holdToMove.SetActive(true);
        _eventManager.Tap -= Tap;
    }

    private void Hold()
    {
        _holdToMove.SetActive(false);
        _eventManager.Hold -= Hold;
    }

    private void EndGame()
    {
        _restart.SetActive(true);
    }

    private void Restart()
    {
        _restart.SetActive(false);
        if (_eventManager.Restart != null)
        {
            _eventManager.Restart.Invoke();
        }
    }
}
