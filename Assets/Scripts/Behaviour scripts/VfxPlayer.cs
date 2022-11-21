using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VfxPlayer : MonoBehaviour
{
    [SerializeField] private VisualEffect visualEffect;

    public IEnumerator PlayVfxForXSeconds(float duration)
    {
        visualEffect.Play();

        yield return new WaitForSeconds(duration);
            
        visualEffect.Stop();
    }
}
