using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]

public class CameraLockX : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]

    [SerializeField] private float _xPosition;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var position = state.RawPosition;
            position.x = _xPosition;
            state.RawPosition = position;
        }
    }
}