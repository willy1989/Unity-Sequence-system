using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_SequenceTask : SequenceTask
{
    [SerializeField] private AnimationPlayer animationPlayer;

    [SerializeField] private string animationTriggerName;

    private bool animationEnded = false;

    protected override IEnumerator DoTask()
    {
        animationPlayer.RegisterToEndOfAnimationEvent(ToggleAnimationEndedOn);

        animationPlayer.PlayAnimation(animationTriggerName);

        while (animationEnded == false)
        {
            yield return null;
        }

        animationPlayer.UnregisterToEndOfAnimationEvent(ToggleAnimationEndedOn);

        animationEnded = false;
    }

    private void ToggleAnimationEndedOn()
    {
        animationEnded = true;
    }
}