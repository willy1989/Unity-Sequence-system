using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [SerializeField] private string name;
    public string Name => name;

    [SerializeField] private SequenceTask[] sequenceTasks;

    private IEnumerator sequenceCoroutine;

    int currentTaskIndex = 0;

    public void StartSequence()
    {
        if (sequenceTasks.Length > 0)
        {
            sequenceCoroutine = PlaySequences();
            StartCoroutine(sequenceCoroutine);
        }
    }

    private IEnumerator PlaySequences()
    {
        while (currentTaskIndex < sequenceTasks.Length)
        {
            yield return StartCoroutine(sequenceTasks[currentTaskIndex].DoTask());

            currentTaskIndex++;
        }

        currentTaskIndex = 0;
    }

    public void AbortSequence()
    {
        if(sequenceCoroutine != null)
        {
            StopCoroutine(sequenceCoroutine);
            sequenceTasks[currentTaskIndex].AbortTask();
        }
    }

    public void SkipTask()
    {
        if(sequenceCoroutine != null)
            sequenceTasks[currentTaskIndex].AbortTask();
    }
}
