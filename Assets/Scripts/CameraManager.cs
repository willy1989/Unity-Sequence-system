using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraManager : ScriptPlayableInSequence
{
    [SerializeField] private Animator cameraBlendAnimator;

    [SerializeField] private CinemachineStateDrivenCamera stateDrivenCamera;

    private IEnumerator SwitchCameraCoroutine(string triggerName)
    {
        cameraBlendAnimator.SetTrigger(triggerName);

        yield return null;

        while(stateDrivenCamera.IsBlending == true)
        {
            yield return null;
        }

        endOfActionEvent?.Invoke();
    }

    public void SwitchCamera(string triggerName)
    {
        if (stateDrivenCamera.IsBlending == true)
            return;

        StartCoroutine(SwitchCameraCoroutine(triggerName));
    }
}
