using UnityEngine;
using Cinemachine;

public class SwitchCameraTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player _))
        {
            _playerCamera.Priority = 0;
            _finishCamera.Priority = 1;
        }
    }
}
