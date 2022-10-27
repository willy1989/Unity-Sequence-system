using UnityEngine;

/// <summary>
/// Sequences are made of sequence actions. 
/// Sequence actions have an endOfActionEvent that informs when an action ends so that the next one can beggin. 
/// </summary>

public class Sequence : MonoBehaviour
{
    [SerializeField] private string sequenceName;

    public string SequenceName => sequenceName;

    [SerializeField] private SequenceAction[] sequenceActions;

    [SerializeField] private int currentActionIndex = -1;

    public void PlayActions()
    {
        currentActionIndex++;

        if (currentActionIndex <= sequenceActions.Length - 1)
        {
            sequenceActions[currentActionIndex].PlayableScript.RegisterToEndOfActionEvent(this, () => PlayActions());
            sequenceActions[currentActionIndex].UnityEvent?.Invoke();
        }

        // We reset the current action index when the sequence is over, so that we can play it again if needed.
        else
        {
            currentActionIndex = -1;
        }
    }
}
