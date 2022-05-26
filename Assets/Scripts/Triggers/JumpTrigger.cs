using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private Transform _endValue;

    public Transform EndValue => _endValue;
}
