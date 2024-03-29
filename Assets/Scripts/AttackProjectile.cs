using System;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    public AttackTarget target;
    public AnimationCurve horizontalFunction;
    public AnimationCurve verticalFunction;

    private float _spawnTime;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    private void Start()
    {
        var transform = this.transform;
        var scale = transform.lossyScale;

        _startPosition = transform.position;
        _spawnTime = Time.time;

        var textTransform = GetComponentInChildren<TextMesh>().transform;
        textTransform.localScale = Vector3.Scale(
            textTransform.localScale,
            new Vector3(Math.Sign(scale.x), Math.Sign(scale.y), Math.Sign(scale.z)));
    }

    // Update is called once per frame
    private void Update()
    {
        var aliveTime = Time.time - _spawnTime;

        if (aliveTime >= 1)
        {
            target.Hit();
            Destroy(gameObject);
            return;
        }

        var targetPosition = target.transform.position;
        var horizontalOffset = _startPosition.x +
                               (targetPosition.x - _startPosition.x) * horizontalFunction.Evaluate(aliveTime);
        var verticalOffset = _startPosition.y + (targetPosition.y - _startPosition.y) * aliveTime +
                             verticalFunction.Evaluate(aliveTime);

        var transform = this.transform;
        var projectilePosition = transform.position;
        projectilePosition.x = horizontalOffset;
        projectilePosition.y = verticalOffset;
        transform.position = projectilePosition;
    }
}