using UnityEngine;

public class Tap : MonoBehaviour
{
    private const float kMin = 40;
    private const float kMax = 50;

    [SerializeField]
    private RectTransform _rectTransform;

    private float step = -1f;

    protected void FixedUpdate()
    {
        _rectTransform.sizeDelta += new Vector2( step, step);
        if (_rectTransform.sizeDelta.x <= kMin || _rectTransform.sizeDelta.x >= kMax)
            step *= -1;
    }
}
