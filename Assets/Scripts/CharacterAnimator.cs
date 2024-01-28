using System.Collections;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Mouth mouth;

    private void Start()
    {
        mouth = GetComponentInChildren<Mouth>();
    }

    public void AnimateLaugh()
    {
        if (mouth == null)
        {
            // TODO
        }
        else
        {
            StartCoroutine(OpenMouth());
        }
    }

    private IEnumerator OpenMouth()
    {
        mouth.SetOpen(true);
        yield return new WaitForSeconds(0.16f);
        mouth.SetOpen(false);
    }
}