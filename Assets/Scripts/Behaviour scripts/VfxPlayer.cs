using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VfxPlayer : MonoBehaviour
{
    [SerializeField] private VisualEffect visualEffect;

    private bool vfxStopped = false;

    public IEnumerator PlayVfxForXSeconds(float duration)
    {
        visualEffect.Play();

        float elapsedTime = 0f;

        while(elapsedTime <= duration)
        {
            if(vfxStopped == true)
            {
                vfxStopped = false;
                yield break;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        visualEffect.Stop();
    }

    public void StopVFX()
    {
        visualEffect.Stop();
        vfxStopped = true;
    }
}
