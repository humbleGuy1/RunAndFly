using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private Transform _centralPoint;

    public Transform CentralPoint => _centralPoint;
}
