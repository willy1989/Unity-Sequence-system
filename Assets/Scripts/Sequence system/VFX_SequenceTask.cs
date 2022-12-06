using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_SequenceTask : SequenceTask
{
    [SerializeField] private VfxPlayer vfxPlayer;

    [SerializeField] private float vfxDuration;

    public override void AbortTask()
    {
        vfxPlayer.StopVFX();
    }

    public override IEnumerator DoTask()
    {
        yield return vfxPlayer.PlayVfxForXSeconds(vfxDuration);
    }
}