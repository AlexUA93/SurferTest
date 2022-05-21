using UnityEngine;

public class Ground : MonoBehaviour
{
    private const float posY = 0.01f;

    [SerializeField]
    private DrawLine _drawLine;

    private EventManager _eventManager;

    protected void Awake()
    {
        var pool = ObjectManager.FindByTag("EventManager");
        _eventManager = pool.GetComponent<EventManager>();
    }

    protected void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CubeInHolder")
        {
            var targetPos = other.gameObject.transform.position;
            var newPos = new Vector3(targetPos.x, posY, targetPos.z);

            _drawLine.AddPoint(newPos);
        }

    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerSkelet" && _eventManager.EndGame != null)
        {
            _eventManager.EndGame.Invoke();
        }
    }
}
