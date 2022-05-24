//using UnityEngine;
//using Cinemachine;

//[RequireComponent(typeof(CinemachineVirtualCamera))]

//public class TargetSwitcher : MonoBehaviour
//{
//    [SerializeField] private PlayerGroup _playerGroup;

//    private CinemachineVirtualCamera _camera;

//    private void Start()
//    {
//        _camera = GetComponent<CinemachineVirtualCamera>();
//    }

//    private void OnCnangeTarget(Player player)
//    {
//        _camera.Follow = player.transform;
//    }

//    private void OnEnable()
//    {
//        _playerGroup.CameraTargetChanged += OnCnangeTarget;
//    }

//    private void OnDisable()
//    {
//        _playerGroup.CameraTargetChanged -= OnCnangeTarget;
//    }
//}
