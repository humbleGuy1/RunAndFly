using UnityEngine;
using Cinemachine;
using System.Collections;

[RequireComponent(typeof(CinemachineVirtualCamera))]

public class DelaySetter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private PlayerGroup _playerGroup;

    private CinemachineVirtualCamera _camera;
    private CinemachineFreeLook _freeLook;

    private Coroutine _coroutine;

    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        _freeLook = _camera.GetComponent<CinemachineFreeLook>();
    }

    private void OnMotionStopped()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(StopMotion());
    }

    private IEnumerator StopMotion()
    {
        Debug.Log("Stoped");
        float timer = 0;

        while (timer <= _delay)
        {
            _freeLook.m_XAxis.m_MaxSpeed = 0.0f;
            _freeLook.m_YAxis.m_MaxSpeed = 0.0f;
            timer += Time.deltaTime;
        }

        yield return null;
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
