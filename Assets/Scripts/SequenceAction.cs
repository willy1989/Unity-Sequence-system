using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SequenceAction
{
    [SerializeField] private UnityEvent unityEvent;

    public UnityEvent UnityEvent => unityEvent;

    [SerializeField] private ScriptPlayableInSequence playableScript;

    public ScriptPlayableInSequence PlayableScript => playableScript;
}
