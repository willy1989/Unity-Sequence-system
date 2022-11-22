using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter_SequenceTask : SequenceTask
{
    [Range(0.1f, 60f)]
    [SerializeField] private float waitDuration;

    protected override IEnumerator DoTask()
    {
        yield return new WaitForSeconds(waitDuration);
    }
}
