using UnityEngine;
using UnityEngine.Events;

public class InstantAction : ScriptPlayableInSequence
{
    [SerializeField] private UnityEvent unityEvent;

    public void CallUnityEvent()
    {
        unityEvent?.Invoke();
        endOfActionEvent?.Invoke();
    }
}
