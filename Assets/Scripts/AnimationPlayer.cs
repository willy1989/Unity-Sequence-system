using UnityEngine;

public class AnimationPlayer : ScriptPlayableInSequence
{
    [SerializeField] private Animator animator;

    public void PlayAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    private void TriggerEndOfActionEvent()
    {
        endOfActionEvent?.Invoke();
    }
}
