using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sequence
{
    [SerializeField] private string name;
    public string Name => name;

    [SerializeField] private SequenceTask[] sequenceNodes;

    public void SetUpSequenceNodes()
    {
        for(int i = 0; i < sequenceNodes.Length-1; i++)
        {
            if (sequenceNodes[i] != null)
                sequenceNodes[i].RegisterToTaskCompletedEvent(sequenceNodes[i+1]);
        }
    }

    public void StartSequence()
    {
        if(sequenceNodes[0] != null)
        {
            sequenceNodes[0].StartTask();
        }
    }
}
