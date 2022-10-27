using System;
using UnityEngine;

public abstract class ScriptPlayableInSequence : MonoBehaviour
{
    protected Action endOfActionEvent;

    public void RegisterToEndOfActionEvent(Sequence sequence, Action action)
    {
        endOfActionEvent = null;
        endOfActionEvent += action;
    }
}
