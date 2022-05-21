using UnityEngine;

public class CubeView : MonoBehaviour
{
    private Pool _pool;
    private EventManager _eventManager;

    private void Awake()
    {
        var pool = ObjectManager.FindByTag("Pool");
        _pool = pool.GetComponent<Pool>();
        var eventManager = ObjectManager.FindByTag("EventManager");
        _eventManager = eventManager.GetComponent<EventManager>();

        _eventManager.DestroyObjectOnTrack += Destroy;
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Wall" && tag == "CubeInHolder")
        {
            var colTrans = collision.gameObject.transform;
            Vector3 offset = transform.up * (transform.localScale.y / 2f) * -1f;
            Vector3 pos1 = transform.position + offset;
            offset = colTrans.up * (colTrans.localScale.y / 2f) * -1f;
            Vector3 pos2 = colTrans.position + offset;
            var yDif = pos1.y - pos2.y;
            var xDif = Mathf.Abs(colTrans.position.x - transform.position.x);
            if (yDif <= 0.1f && xDif < 0.95f)
            {
                tag = "Cube";
                transform.parent = null;
                if (_pool != null)
                    _pool.Add(gameObject);
                if (_eventManager.RemoveCube != null)
                    _eventManager.RemoveCube.Invoke(gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && tag == "CubeInHolder")
        {
            if (_eventManager.Move != null)
                _eventManager.Move.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "SpawnNextTrack" && tag == "CubeInHolder")
        {
            other.gameObject.tag = "Non";
            if (_eventManager.SpawnTrack != null)
                _eventManager.SpawnTrack.Invoke();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        if (_pool != null)
            _pool.Add(gameObject);
    }
}
