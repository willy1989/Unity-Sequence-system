using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_SequenceTask : SequenceTask
{
    [SerializeField] private CameraManager cameraManager;

    [SerializeField] private string cameraTriggerName;

    protected override IEnumerator DoTask()
    {
        yield return StartCoroutine(cameraManager.SwitchCameraCoroutine(cameraTriggerName));
    }
}
