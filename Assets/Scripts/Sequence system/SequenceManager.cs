using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
// The goal of this system is to utilize methods from scripts and organized
// them in a sequence to be played one after the other.

// For instance, an intro sequence could be:

// 1 - Play a vfx for 5 seconds
// 2 - Switch camera
// 3 - Show "Start" message on UI
// 4 - Enable player input

// The sequence system acts as an additional layer and doesn't disrupt not is it tacked on to existing systems.

// The Task class contains a reference from the script we want extract methods from.

// Sequences are made of tasks.
/// </summary>


public class SequenceManager : MonoBehaviour
{
    [SerializeField] private Sequence[] sequences;

    private Dictionary<string, Sequence> sequenceDictionary = new Dictionary<string, Sequence>();

    private void Awake()
    {
        foreach (Sequence item in sequences)
        {
            string name = item.Name.ToLower().Trim();

            if(name == string.Empty)
            {
                throw new ArgumentException("Instances of the Sequence class cannot have an empty 'name' field. " +
                                            "Please make sure this field is not empty.");
            }

            sequenceDictionary.Add(item.Name, item);
        }
    }

    private void Start()
    {
        PlaySequence("start");
    }

    private bool Validate(string sequenceName)
    {
        sequenceName = sequenceName.ToLower().Trim();

        if (sequenceDictionary.ContainsKey(sequenceName) == false)
        {
            throw new ArgumentException("There are no sequences matching the name " + sequenceName + ". " +
                                        "Please input a correct name.");
        }

        return true;
    }

    public void PlaySequence(string sequenceName)
    {
        if(Validate(sequenceName) == true && 
           sequenceDictionary[sequenceName] != null)
        {
            sequenceDictionary[sequenceName].StartSequence();
        }
    }


    public void AbortSequence(string sequenceName)
    {
        if (Validate(sequenceName) == true && 
            sequenceDictionary[sequenceName] != null)
        {
            sequenceDictionary[sequenceName].AbortSequence();
        }
    }

    public void SkipCurrentTask(string sequenceName)
    {
        if (Validate(sequenceName) == true && 
            sequenceDictionary[sequenceName] != null)
        {
            sequenceDictionary[sequenceName].SkipTask();
        }
    }
}
