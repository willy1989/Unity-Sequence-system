using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_SequenceTask : SequenceTask
{
    [SerializeField] private VfxPlayer vfxPlayer;

    [SerializeField] private float vfxDuration;

    protected override IEnumerator DoTask()
    {
        yield return StartCoroutine(vfxPlayer.PlayVfxForXSeconds(vfxDuration));
    }
}