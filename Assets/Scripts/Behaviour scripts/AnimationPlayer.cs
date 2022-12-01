using System;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private AnimationClip animationClip;

    private Action endOfAnimationEvent;

    public void PlayAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    public void RegisterToEndOfAnimationEvent(Action action)
    {
        endOfAnimationEvent += action;
    }

    public void UnregisterToEndOfAnimationEvent(Action action)
    {
        endOfAnimationEvent -= action;
    }

    private void InvokeEndOfAnimationEvent()
    {
        endOfAnimationEvent?.Invoke();
    }
}
