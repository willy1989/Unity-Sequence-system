using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : ScriptPlayableInSequence
{
    public void WaitForXSeconds(float waitTime_Seconds)
    {
        StartCoroutine(WaitCoroutine(waitTime_Seconds));
    }

    private IEnumerator WaitCoroutine(float waitTime_Seconds)
    {
        yield return new WaitForSeconds(waitTime_Seconds);

        endOfActionEvent?.Invoke();
    }
}
