using System.Collections;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private static readonly int Shout = Animator.StringToHash("shout");
    public Mouth mouth;
    private Animator _animator;
    private Laughter _laughter;

    private void Start()
    {
        mouth = GetComponentInChildren<Mouth>();
        _animator = GetComponentInChildren<Animator>();
        _laughter = GetComponentInChildren<Laughter>();
    }

    public void AnimateLaugh(AttackType attackType)
    {
        if (mouth == null)
            _animator.SetTrigger(Shout);
        else
            StartCoroutine(OpenMouth());

        _laughter.Play(attackType);
    }

    public void AnimateHit(AttackType attackType)
    {
        _laughter.Play(attackType);
    }

    public void AnimateBlock(AttackType attackType)
    {
        _laughter.PlayKremt(attackType);
    }

    private IEnumerator OpenMouth()
    {
        mouth.SetOpen(true);
        yield return new WaitForSeconds(0.16f);
        mouth.SetOpen(false);
    }
}