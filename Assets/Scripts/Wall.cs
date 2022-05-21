using UnityEngine;

public class Wall : MonoBehaviour
{
    private EventManager _eventManager;

    protected void Awake()
    {
        var pool = ObjectManager.FindByTag("EventManager");
        _eventManager = pool.GetComponent<EventManager>();
    }
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerSkelet" && _eventManager.EndGame != null)
        {
            _eventManager.EndGame.Invoke();
        }
    }
}
