using UnityEngine;
using Cinemachine;
using System.Collections;

[RequireComponent(typeof(CinemachineVirtualCamera))]

public class CameraStopper : MonoBehaviour
{
    [SerializeField] private float _stoppingTimeInSeconds;
    [SerializeField] private PlayerGroup _playerGroup;

    private CinemachineVirtualCamera _camera;

    private Coroutine _coroutine;

    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnMotionStopped(Player player)
    {
        _camera.Follow = player.transform;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(StopMotion(player));
    }

    private IEnumerator StopMotion(Player player)
    {
        var WaitForSeconds = new WaitForSeconds(_stoppingTimeInSeconds);

        _camera.Follow = null;

        yield return WaitForSeconds;

        _camera.Follow = player.transform;
    }

    private void OnEnable()
    {
        _playerGroup.CameraMotionStopped += OnMotionStopped;
    }

    private void OnDisable()
    {
        _playerGroup.CameraMotionStopped -= OnMotionStopped;
    }
}
