using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Mouth mouth;
    private Animator _animator;
    private Laughter _laughter;
    
    private static readonly int Shout = Animator.StringToHash("shout");

    private void Start()
    {
        mouth = GetComponentInChildren<Mouth>();
        _animator = GetComponentInChildren<Animator>();
        _laughter = GetComponentInChildren<Laughter>();
    }

    public void AnimateLaugh(AttackType attackType)
    {
        if (mouth == null)
        {
            _animator.SetTrigger(Shout);
        }
        else
        {
            StartCoroutine(OpenMouth());
        }

        _laughter.Play(attackType);
    }

    private IEnumerator OpenMouth()
    {
        mouth.SetOpen(true);
        yield return new WaitForSeconds(0.16f);
        mouth.SetOpen(false);
    }
}
