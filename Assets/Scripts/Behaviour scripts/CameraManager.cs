using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Animator cameraBlendAnimator;

    [SerializeField] private CinemachineStateDrivenCamera stateDrivenCamera;

    [SerializeField] private bool blendingStopped = false;

    public IEnumerator SwitchCameraCoroutine(string triggerName)
    {
        if (stateDrivenCamera.IsBlending == true)
            yield break;

        cameraBlendAnimator.SetTrigger(triggerName);

        yield return null;

        while(stateDrivenCamera.IsBlending == true)
        {
            if(blendingStopped == true)
            {
                blendingStopped = false;
                yield break;
            }

            yield return null;
        }
    }

    public void StopCameraBlending()
    {
        blendingStopped = true;
    }
}
