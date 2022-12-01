using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_SequenceTask : SequenceTask
{
    [SerializeField] private AnimationPlayer animationPlayer;

    [SerializeField] private string animationTriggerName;

    private bool animationEnded = false;

    private bool taskAborted = false;

    public override IEnumerator DoTask()
    {
        animationPlayer.RegisterToEndOfAnimationEvent(ToggleAnimationEndedOn);

        animationPlayer.PlayAnimation(animationTriggerName);

        while (animationEnded == false && taskAborted == false)
        {
            yield return null;
        }

        animationPlayer.UnregisterToEndOfAnimationEvent(ToggleAnimationEndedOn);

        animationEnded = false;

        if (taskAborted == true)
            taskAborted = false;
    }

    private void ToggleAnimationEndedOn()
    {
        animationEnded = true;
    }

    public override void AbortTask()
    {
        ToggleAnimationEndedOn();
    }
}