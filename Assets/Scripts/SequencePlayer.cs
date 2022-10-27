using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The idea behind the sequence player is to call functions from monobehavior scripts, one after the other.
/// Either by waiting for a certain action to finish, an animation for example, or by setting a set duration for the action.
/// Play this particle effect for 5 seconds for instance.
/// 
/// Sequences are made of sequence actions. 
/// Sequence actions have an endOfActionEvent that informs when an action ends so that the next one can beggin. 
/// </summary>
/// 
public class SequencePlayer : MonoBehaviour
{
    [SerializeField] private Sequence[] sequences;

    private Dictionary<string, Sequence> sequenceNameDictionary = new Dictionary<string, Sequence>();

    private void Awake()
    {
        foreach(Sequence item in sequences)
        {
            if(item.SequenceName == string.Empty)
            {
                throw new ArgumentException("The name of the sequence can't be empty. Please input a valid name.");
            }

            sequenceNameDictionary.Add(item.SequenceName.ToLower().Trim(), item);
        }
    }

    private void Start()
    {
        PlaySequence("start");
    }

    private void PlaySequence(string sequenceName)
    {
        sequenceName = sequenceName.ToLower().Trim();

        if(sequenceNameDictionary.ContainsKey(sequenceName) == true)
            sequenceNameDictionary[sequenceName.ToLower().Trim()].PlayActions();
        else
            throw new ArgumentException("The name you input doesn't match any sequence.");
    }
}
