using System;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public AttackType attackType;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        switch (attackType)
        {
            case AttackType.Hi:
                _spriteRenderer.color = new Color(0.2f, 0.5f, 1, 0.5f);
                break;
            case AttackType.Ha:
                _spriteRenderer.color = new Color(0, 0.7f, 0, 0.5f);
                break;
            case AttackType.Ho:
                _spriteRenderer.color = new Color(1, 1, 0, 0.5f);
                break;
            case AttackType.He:
                _spriteRenderer.color = new Color(1, 0, 0, 0.5f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Hit()
    {
        GetComponentInParent<Fighter>().Hit(attackType);
    }

    public void SetBlocking(bool blocking)
    {
        var color = _spriteRenderer.color;
        color.a = blocking ? 1.0f : 0.5f;
        _spriteRenderer.color = color;
    }
}