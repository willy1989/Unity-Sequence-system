using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImmediateAction_SequenceTask : SequenceTask
{
    [SerializeField] private UnityEvent unityEvent;

    public override void AbortTask()
    {
        //
    }

    public override IEnumerator DoTask()
    {
        unityEvent?.Invoke();

        yield break;
    }
}
