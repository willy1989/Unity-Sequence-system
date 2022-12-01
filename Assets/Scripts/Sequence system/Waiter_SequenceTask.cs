using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter_SequenceTask : SequenceTask
{
    [Range(0.1f, 60f)]
    [SerializeField] private float waitDuration;

    private bool taskStopped = false;

    public override void AbortTask()
    {
        taskStopped = true;
    }

    public override IEnumerator DoTask()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= waitDuration)
        {
            if (taskStopped == true)
            {
                taskStopped = false;
                yield break;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
