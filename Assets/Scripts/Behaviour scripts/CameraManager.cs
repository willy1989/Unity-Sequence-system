using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Animator cameraBlendAnimator;

    [SerializeField] private CinemachineStateDrivenCamera stateDrivenCamera;

    public IEnumerator SwitchCameraCoroutine(string triggerName)
    {
        if (stateDrivenCamera.IsBlending == true)
            yield break;

        cameraBlendAnimator.SetTrigger(triggerName);

        yield return null;

        while(stateDrivenCamera.IsBlending == true)
        {
            yield return null;
        }
    }
}
