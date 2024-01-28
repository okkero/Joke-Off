using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Laughter : MonoBehaviour
{
    [SerializeField] private AudioClip hiClip;
    [SerializeField] private AudioClip haClip;
    [SerializeField] private AudioClip hoClip;
    [SerializeField] private AudioClip heClip;
    
    [SerializeField] private AudioClip hikClip;
    [SerializeField] private AudioClip hakClip;
    [SerializeField] private AudioClip hokClip;
    [SerializeField] private AudioClip hekClip;
    
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Hi:
                _audioSource.clip = hiClip;
                break;
            case AttackType.Ha:
                _audioSource.clip = haClip;
                break;
            case AttackType.Ho:
                _audioSource.clip = hoClip;
                break;
            case AttackType.He:
                _audioSource.clip = heClip;
                break;
        }

        _audioSource.Play();
    }
    
    public void PlayKremt(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Hi:
                _audioSource.clip = hikClip;
                break;
            case AttackType.Ha:
                _audioSource.clip = hakClip;
                break;
            case AttackType.Ho:
                _audioSource.clip = hokClip;
                break;
            case AttackType.He:
                _audioSource.clip = hekClip;
                break;
        }

        _audioSource.Play();
    }
}
