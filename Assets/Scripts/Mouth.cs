using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private float yStart = 0.3f;
    [SerializeField] private float yEnd = -0.3f;

    private float _yVelocity;

    private void Update()
    {
        var open = Input.GetKey(keyCode);

        var t = open ? 1.0f : 0.0f;
        
        var y = Unity.Mathematics.math.remap(0.0f, 1.0f, yStart, yEnd, t);
        Vector3 localPosition = transform.localPosition;
        localPosition.y = Mathf.SmoothDamp(localPosition.y, y, ref _yVelocity, 0.025f);
        
        transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
    }
}
