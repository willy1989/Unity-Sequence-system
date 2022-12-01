using System;
using System.Collections;
using UnityEngine;

public abstract class SequenceTask : MonoBehaviour
{
    public abstract IEnumerator DoTask();

    public abstract void AbortTask();
 }