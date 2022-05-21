using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    private List<Vector3> _points;

    protected void Awake()
    {
        _points = new List<Vector3>();
    }

    public void AddPoint(Vector3 point)
    {
        if (!_points.Contains(point))
        {
            _points.Add(point);
            Draw();
        }
    }

    public void Rebuild()
    {
        _points.Clear();
        _lineRenderer.positionCount = 0;
    }

    private void Draw()
    {
        _lineRenderer.positionCount = _points.Count;
        for (int i = 0; i <= _points.Count - 1; i++)
        {
            _lineRenderer.SetPosition(i, _points[i]);
        }
    }
}
