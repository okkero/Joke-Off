using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancing : MonoBehaviour
{
    [SerializeField] private AnimationCurve xCurve;
    [SerializeField] private AnimationCurve rCurve;
    [SerializeField] private float xMultiplier = 3.0f;
    [SerializeField] private float rMultiplier = 30.0f;

    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        var x = xCurve.Evaluate(Time.timeSinceLevelLoad);
        var r = rCurve.Evaluate(Time.timeSinceLevelLoad);

        Vector3 offset = Vector3.zero;
        offset.x = x * xMultiplier * transform.localScale.x;

        Quaternion rotation = Quaternion.AngleAxis(r * rMultiplier * transform.localScale.x, Vector3.forward);

        transform.rotation = rotation;
        transform.position = startPosition + offset;
    }
}
