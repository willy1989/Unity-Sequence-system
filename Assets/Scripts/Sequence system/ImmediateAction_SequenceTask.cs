using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImmediateAction_SequenceTask : SequenceTask
{
    [SerializeField] private UnityEvent unityEvent;

    protected override IEnumerator DoTask()
    {
        unityEvent?.Invoke();

        yield break;
    }
}
