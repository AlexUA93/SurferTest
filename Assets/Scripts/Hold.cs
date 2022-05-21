using UnityEngine;

public class Hold : MonoBehaviour
{
    private const float kMin = -80f;
    private const float kMax = 80f;

    [SerializeField]
    private RectTransform _rectTransform;

    private float step = -1f;

    protected void FixedUpdate()
    {
        _rectTransform.localPosition += new Vector3(step, 0, 0);
        if (_rectTransform.localPosition.x <= kMin || _rectTransform.localPosition.x >= kMax)
            step *= -1;
    }
}
