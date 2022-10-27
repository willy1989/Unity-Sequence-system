using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VfxPlayer : ScriptPlayableInSequence
{
    [SerializeField] private VisualEffect visualEffect;

    public void PlayVfxForXSeconds(float seconds)
    {
        StartCoroutine(PlayVfxForXSecondsCoroutine(seconds));
    }

    private IEnumerator PlayVfxForXSecondsCoroutine(float seconds)
    {
        visualEffect.Play();

        yield return new WaitForSeconds(seconds);
            
         visualEffect.Stop();
        endOfActionEvent?.Invoke();
    }
}
