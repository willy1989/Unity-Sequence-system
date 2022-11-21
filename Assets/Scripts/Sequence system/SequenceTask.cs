using System;
using System.Collections;
using UnityEngine;

public abstract class SequenceTask : MonoBehaviour
{
    protected Action TaskCompletedEvent;

    public void RegisterToTaskCompletedEvent(SequenceTask sequenceNode)
    {
        if(TaskCompletedEvent == null)
            TaskCompletedEvent += sequenceNode.StartTask;
    }

    public void StartTask()
    {
        StartCoroutine(StartTaskCoroutine());
    }

    private IEnumerator StartTaskCoroutine()
    {
        yield return StartCoroutine(DoTask());

        TaskCompletedEvent?.Invoke();
    }

    protected abstract IEnumerator DoTask();
}